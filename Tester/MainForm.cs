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
		}
		
		void EncryptClick(object sender, EventArgs e)
		{
			//aaEncryption aae = new aaEncryption.SimpleAES();
		
			System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
			
			sw.Start();
			
			aaEncryption.SimpleAES aae = new aaEncryption.SimpleAES(encrypted.Text);
			
			Debug.Print(sw.ElapsedMilliseconds.ToString());
			sw.Reset();
			
			System.Diagnostics.Debug.Print(aae.EncryptToString(input.Text));
			
			Debug.Print(sw.ElapsedMilliseconds.ToString());
			sw.Restart();
			
			System.Diagnostics.Debug.Print(aae.DecryptString(aae.EncryptToString(input.Text)));
			
			Debug.Print(sw.ElapsedMilliseconds.ToString());
			sw.Restart();
			
			System.Diagnostics.Debug.Print(input.Text);
			Debug.Print(sw.ElapsedMilliseconds.ToString());
			
			sw.Stop();
			
			//encrypted.Text = aae.EncryptToString(input.Text);
			
			//decrypted.Text = aae.DecryptString(encrypted.Text);
		
			
		}
		
	}
}
