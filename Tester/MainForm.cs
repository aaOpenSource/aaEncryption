/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 11/2/2013
 * Time: 9:15 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using aaEncryption;
using System.Diagnostics;

namespace Tester
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			this.test();
		}
		
		void test()
		{
			string seedString = "asdfadgce234098d23d13hqcejklhch390123n1";			
			
			Debug.Print("1");
			this.RunTest(new aaEncryption.cSimpleAES(seedString));			
						
			Debug.Print("2");
			this.RunTest(new aaEncryption.cSimpleAES(true));
			
			Debug.Print("3");
			this.RunTest(new aaEncryption.cSimpleAES(false));			

			Debug.Print("4");
			this.RunTest(new aaEncryption.cSimpleAES(seedString, true));
			
			Debug.Print("5");
			this.RunTest(new aaEncryption.cSimpleAES(seedString, false));

			Debug.Print("6");
			this.RunTest(new aaEncryption.cSimpleAES(seedString.PadRight(1024,'a')));

			Debug.Print("7");
			this.RunTest(new aaEncryption.cSimpleAES(seedString.PadRight(10240,'a')));

			Debug.Print("8");
			this.RunTest(new aaEncryption.cSimpleAES());
			
		}
		
		void EncryptClick(object sender, EventArgs e)
		{
			this.test();
			
			//aaEncryption aae = new aaEncryption.SimpleAES();
		
			//System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
			
			//sw.Start();
		
			
			//Debug.Print(sw.ElapsedMilliseconds.ToString());
			//sw.Reset();
			
			//System.Diagnostics.Debug.Print(aae.EncryptToString(input.Text));
			
			//Debug.Print(sw.ElapsedMilliseconds.ToString());
			//sw.Restart();
		

			

			//System.Diagnostics.Debug.Print(input.Text.CompareTo(aae.DecryptString(aae.EncryptToString(input.Text))).ToString());
			
/*			
			Debug.Print(sw.ElapsedMilliseconds.ToString());
			sw.Restart();
			
			Debug.Print(sw.ElapsedMilliseconds.ToString());
			
			sw.Stop();
*/			
			//encrypted.Text = aae.EncryptToString(input.Text);
			
			//decrypted.Text = aae.DecryptString(encrypted.Text);
		
			
		}
		
		private void RunTest(aaEncryption.cSimpleAES csa)
		{
			this.RunTest(csa,0);
		}
		
		private void RunTest(aaEncryption.cSimpleAES csa,int PadLength)
		{			
			string TestString = "Quick brown fox and lazy dog!";
						
			//Debug.Print(aae5.DecryptString(aae5.EncryptToString(TestString)));
			//Debug.Print(TestString);
			if((csa.DecryptString(csa.EncryptToString(TestString.PadRight(PadLength,'q'))) == TestString.PadRight(PadLength,'q')))
			{
				Debug.Print("Passed");
			}
			else
			{
				Debug.Print("Failed");
			}
				
		}
		
	}
}
