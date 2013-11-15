/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 11/2/2013
 * Time: 9:15 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Tester
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.input = new System.Windows.Forms.TextBox();
			this.encrypt = new System.Windows.Forms.Button();
			this.decrypt = new System.Windows.Forms.Button();
			this.encrypted = new System.Windows.Forms.TextBox();
			this.decrypted = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// input
			// 
			this.input.Location = new System.Drawing.Point(25, 20);
			this.input.Name = "input";
			this.input.Size = new System.Drawing.Size(421, 20);
			this.input.TabIndex = 0;
			// 
			// encrypt
			// 
			this.encrypt.Location = new System.Drawing.Point(28, 67);
			this.encrypt.Name = "encrypt";
			this.encrypt.Size = new System.Drawing.Size(75, 23);
			this.encrypt.TabIndex = 1;
			this.encrypt.Text = "button1";
			this.encrypt.UseVisualStyleBackColor = true;
			this.encrypt.Click += new System.EventHandler(this.EncryptClick);
			// 
			// decrypt
			// 
			this.decrypt.Location = new System.Drawing.Point(28, 165);
			this.decrypt.Name = "decrypt";
			this.decrypt.Size = new System.Drawing.Size(75, 23);
			this.decrypt.TabIndex = 3;
			this.decrypt.Text = "button2";
			this.decrypt.UseVisualStyleBackColor = true;
			// 
			// encrypted
			// 
			this.encrypted.Location = new System.Drawing.Point(25, 118);
			this.encrypted.Name = "encrypted";
			this.encrypted.Size = new System.Drawing.Size(421, 20);
			this.encrypted.TabIndex = 2;
			// 
			// decrypted
			// 
			this.decrypted.Location = new System.Drawing.Point(28, 222);
			this.decrypted.Name = "decrypted";
			this.decrypted.Size = new System.Drawing.Size(421, 20);
			this.decrypted.TabIndex = 4;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(167, 50);
			this.Controls.Add(this.decrypted);
			this.Controls.Add(this.decrypt);
			this.Controls.Add(this.encrypted);
			this.Controls.Add(this.encrypt);
			this.Controls.Add(this.input);
			this.Name = "MainForm";
			this.Text = "Tester";
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.TextBox decrypted;
		private System.Windows.Forms.TextBox encrypted;
		private System.Windows.Forms.Button decrypt;
		private System.Windows.Forms.Button encrypt;
		private System.Windows.Forms.TextBox input;
	}
}
