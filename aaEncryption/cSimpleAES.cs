﻿using System;
using System.Data;
using System.Security.Cryptography;
using System.IO;


namespace aaEncryption
{
	public class cSimpleAES
	{
	    /*
	     * Original source code from:
	     * http://stackoverflow.com/questions/165808/simple-2-way-encryption-for-c
	     */
	
	    // Initialize a vector with multiple integers.
	    private byte[] Vector = {90,141,93,80,204,253,120,106,39,9,22,181,177,255,19,45,57};
	
	    // Get 32 Byte Array.  This translates to 256 bits which is the higest AES security level available	    
	    private byte[] Key;
	
	    private ICryptoTransform EncryptorTransform, DecryptorTransform;
	    private System.Text.UTF8Encoding UTFEncoder;
	    
	    
#region constructors


		/// <summary>
		/// Default Constructor
		/// </summary>	
	    public cSimpleAES()
	    {	    	
	        // Autogenerate the Key and Vector
	    	Key = GenerateEncryptionKey();	        
	       	Vector = GenerateEncryptionVector();	
	        
	        // Call the rest of the functions required to complete the constructor
	        this.CompleteConstructor();
	    }

		/// <summary>
		/// Select Autogeneration of Vector
		/// </summary>
	    public cSimpleAES(bool autoGenerateVector)
	    {	    	
	        // Autogenerate a key because the user did not pass one
	        Key = GenerateEncryptionKey();
	        
	        // If we have the luxury of auto generating a vector then do that instead of using the hardcoded one
	        if(autoGenerateVector)
	        {
	        	Vector = GenerateEncryptionVector();	
	        }	        
	        
	        // Call the rest of the functions required to complete the constructor
	        this.CompleteConstructor();
	    }

	    /// <summary>
		/// Constructor with external seed for key.  Uses default vector
		/// </summary>
		/// <param name="StringSeed">External Seed for Key</param>
	    public cSimpleAES(string StringSeed)
	    {	    	    	
	    	// Create the fingerprint with the additional seed information
	        Key = aaEncryption.cSecurity.FingerPrint.ValueAsByteArray(32,StringSeed);
	        Vector = GenerateEncryptionVector();
	        
	        // Call the rest of the functions required to complete the constructor
	        this.CompleteConstructor();
	    }
	    
	    /// <summary>
		/// Constructor with external seed for key.  Uses automatically generated vector if chosen.
		/// </summary>
		/// <param name="StringSeed">External Seed for Key</param>
	    public cSimpleAES(string StringSeed, bool autoGenerateVector)
	    {	    	

	        // Create the fingerprint with the additional seed information
	        Key = aaEncryption.cSecurity.FingerPrint.ValueAsByteArray(32,StringSeed);
	        
	        if(autoGenerateVector)
	        {
	        	Vector = GenerateEncryptionVector();
	        }
	        
	        // Call the rest of the functions required to complete the constructor
	        this.CompleteConstructor();
	    }

#endregion
    	
#region Utility Methods
	    /// <summary>
	    /// Execute common steps for all constructors
	    /// </summary>
	    private void CompleteConstructor()
	    {
	    	//This is our encryption method
	        RijndaelManaged rm = new RijndaelManaged();
	        
	   		//Create an encryptor and a decryptor using our encryption method, key, and vector.
	        EncryptorTransform = rm.CreateEncryptor(this.Key, this.Vector);
	        DecryptorTransform = rm.CreateDecryptor(this.Key, this.Vector);
	
	        //Used to translate bytes to text and vice versa
	        UTFEncoder = new System.Text.UTF8Encoding();	    	
	    }
	    
	    /// <summary>
	    /// Generate an Encryption key using RijndaelManaged.GenerateKey()
	    /// </summary>
	    /// <returns></returns>
	    static public byte[] GenerateEncryptionKey()
	    {
	        //Generate a Key.
	        RijndaelManaged rm = new RijndaelManaged();
	        rm.GenerateKey();
	        return rm.Key;
	    }
	
	    /// <summary>
	    /// Generates a Vector using 
	    /// </summary>
	    /// <returns></returns>
	    static public byte[] GenerateEncryptionVector()
	    {
	        //Generate a Vector RijndaelManaged.GenerateIV()
	        RijndaelManaged rm = new RijndaelManaged();
	        rm.GenerateIV();
	        return rm.IV;
	    }
#endregion

	    
#region Common Methods

	    /// ----------- The commonly used methods ------------------------------    
	    /// Encrypt some text and return a string suitable for passing in a URL.
	    public string EncryptToString(string TextValue)
	    {
	        return ByteArrToString(Encrypt(TextValue));
	    }
	
	    /// Encrypt some text and return an encrypted byte array.
	    public byte[] Encrypt(string TextValue)
	    {
	        //Translates our text value into a byte array.
	        Byte[] bytes = UTFEncoder.GetBytes(TextValue);
	
	        //Used to stream the data in and out of the CryptoStream.
	        MemoryStream memoryStream = new MemoryStream();
	
	        /*
	         * We will have to write the unencrypted bytes to the stream,
	         * then read the encrypted result back from the stream.
	         */
	        #region Write the decrypted value to the encryption stream
	        CryptoStream cs = new CryptoStream(memoryStream, EncryptorTransform, CryptoStreamMode.Write);
	        cs.Write(bytes, 0, bytes.Length);
	        cs.FlushFinalBlock();
	        #endregion
	
	        #region Read encrypted value back out of the stream
	        memoryStream.Position = 0;
	        byte[] encrypted = new byte[memoryStream.Length];
	        memoryStream.Read(encrypted, 0, encrypted.Length);
	        #endregion
	
	        //Clean up.
	        cs.Close();
	        memoryStream.Close();
	
	        return encrypted;
	    }
	
	    /// The other side: Decryption methods
	    public string DecryptString(string EncryptedString)
	    {
	        return Decrypt(StrToByteArray(EncryptedString));
	    }
	
	    /// Decryption when working with byte arrays.    
	    public string Decrypt(byte[] EncryptedValue)
	    {
	        #region Write the encrypted value to the decryption stream
	        MemoryStream encryptedStream = new MemoryStream();
	        CryptoStream decryptStream = new CryptoStream(encryptedStream, DecryptorTransform, CryptoStreamMode.Write);
	        decryptStream.Write(EncryptedValue, 0, EncryptedValue.Length);
	        decryptStream.FlushFinalBlock();
	        #endregion
	
	        #region Read the decrypted value from the stream.
	        encryptedStream.Position = 0;
	        Byte[] decryptedBytes = new Byte[encryptedStream.Length];
	        encryptedStream.Read(decryptedBytes, 0, decryptedBytes.Length);
	        encryptedStream.Close();
	        #endregion
	        return UTFEncoder.GetString(decryptedBytes);
	    }
	
	    /// Convert a string to a byte array.  NOTE: Normally we'd create a Byte Array from a string using an ASCII encoding (like so).
	    //      System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
	    //      return encoding.GetBytes(str);
	    // However, this results in character values that cannot be passed in a URL.  So, instead, I just
	    // lay out all of the byte values in a long string of numbers (three per - must pad numbers less than 100).
	    public byte[] StrToByteArray(string str)
	    {
	        if (str.Length == 0)
	            throw new Exception("Invalid string value in StrToByteArray");
	
	        byte val;
	        byte[] byteArr = new byte[str.Length / 3];
	        int i = 0;
	        int j = 0;
	        do
	        {
	            val = byte.Parse(str.Substring(i, 3));
	            byteArr[j++] = val;
	            i += 3;
	        }
	        while (i < str.Length);
	        return byteArr;
	    }
	
	    // Same comment as above.  Normally the conversion would use an ASCII encoding in the other direction:
	    //      System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
	    //      return enc.GetString(byteArr);    
	    public string ByteArrToString(byte[] byteArr)
	    {
	        byte val;
	        string tempStr = "";
	        for (int i = 0; i <= byteArr.GetUpperBound(0); i++)
	        {
	            val = byteArr[i];
	            if (val < (byte)10)
	                tempStr += "00" + val.ToString();
	            else if (val < (byte)100)
	                tempStr += "0" + val.ToString();
	            else
	                tempStr += val.ToString();
	        }
	        return tempStr;
	    }
#endregion

	}
}