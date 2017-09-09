/*
 * Created by SharpDevelop.
 * User: Owner
 * Date: 9/5/2017
 * Time: 8:52 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace RBXLegacyLauncher
{
	partial class ClientSettings
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
			this.button1 = new System.Windows.Forms.Button();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.button2 = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.GameOptions = new System.Windows.Forms.Panel();
			this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.checkBox3 = new System.Windows.Forms.CheckBox();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.checkBox4 = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.button3 = new System.Windows.Forms.Button();
			this.checkBox5 = new System.Windows.Forms.CheckBox();
			this.panel1.SuspendLayout();
			this.GameOptions.SuspendLayout();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.button1.Location = new System.Drawing.Point(12, 12);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(203, 25);
			this.button1.TabIndex = 0;
			this.button1.Text = "Name";
			this.button1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.button1.UseVisualStyleBackColor = false;
			// 
			// listBox1
			// 
			this.listBox1.FormattingEnabled = true;
			this.listBox1.Items.AddRange(new object[] {
									"Game Options",
									"Diagnostics",
									"Physics",
									"Authoring",
									"Network",
									"Task Scheduler",
									"Rendering"});
			this.listBox1.Location = new System.Drawing.Point(13, 36);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(201, 199);
			this.listBox1.TabIndex = 1;
			// 
			// button2
			// 
			this.button2.BackColor = System.Drawing.SystemColors.ControlLight;
			this.button2.Location = new System.Drawing.Point(12, 257);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(130, 24);
			this.button2.TabIndex = 2;
			this.button2.Text = "Reset All Settings";
			this.button2.UseVisualStyleBackColor = false;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.panel1.Controls.Add(this.GameOptions);
			this.panel1.Location = new System.Drawing.Point(221, 12);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(278, 223);
			this.panel1.TabIndex = 3;
			// 
			// GameOptions
			// 
			this.GameOptions.Controls.Add(this.checkBox5);
			this.GameOptions.Controls.Add(this.vScrollBar1);
			this.GameOptions.Controls.Add(this.checkBox1);
			this.GameOptions.Controls.Add(this.checkBox3);
			this.GameOptions.Controls.Add(this.checkBox2);
			this.GameOptions.Controls.Add(this.checkBox4);
			this.GameOptions.Controls.Add(this.label1);
			this.GameOptions.Controls.Add(this.textBox2);
			this.GameOptions.Controls.Add(this.textBox1);
			this.GameOptions.Controls.Add(this.label2);
			this.GameOptions.Location = new System.Drawing.Point(1, 1);
			this.GameOptions.Name = "GameOptions";
			this.GameOptions.Size = new System.Drawing.Size(278, 223);
			this.GameOptions.TabIndex = 9;
			// 
			// vScrollBar1
			// 
			this.vScrollBar1.Location = new System.Drawing.Point(258, 2);
			this.vScrollBar1.Name = "vScrollBar1";
			this.vScrollBar1.Size = new System.Drawing.Size(17, 223);
			this.vScrollBar1.TabIndex = 8;
			// 
			// checkBox1
			// 
			this.checkBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBox1.Location = new System.Drawing.Point(6, 4);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(249, 24);
			this.checkBox1.TabIndex = 0;
			this.checkBox1.Text = "Remove Tools / Insert Buttons";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// checkBox3
			// 
			this.checkBox3.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBox3.Checked = true;
			this.checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox3.Location = new System.Drawing.Point(5, 111);
			this.checkBox3.Name = "checkBox3";
			this.checkBox3.Size = new System.Drawing.Size(249, 24);
			this.checkBox3.TabIndex = 7;
			this.checkBox3.Text = "SoundEnabled";
			this.checkBox3.UseVisualStyleBackColor = true;
			// 
			// checkBox2
			// 
			this.checkBox2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBox2.Location = new System.Drawing.Point(6, 23);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(249, 24);
			this.checkBox2.TabIndex = 1;
			this.checkBox2.Text = "Remove Report Abuse Button";
			this.checkBox2.UseVisualStyleBackColor = true;
			this.checkBox2.CheckedChanged += new System.EventHandler(this.CheckBox2CheckedChanged);
			// 
			// checkBox4
			// 
			this.checkBox4.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBox4.Location = new System.Drawing.Point(5, 93);
			this.checkBox4.Name = "checkBox4";
			this.checkBox4.Size = new System.Drawing.Size(249, 24);
			this.checkBox4.TabIndex = 6;
			this.checkBox4.Text = "SoftwareSound";
			this.checkBox4.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(7, 51);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 23);
			this.label1.TabIndex = 2;
			this.label1.Text = "ChatHistory";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(102, 71);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(153, 20);
			this.textBox2.TabIndex = 5;
			this.textBox2.Text = "5";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(102, 48);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(153, 20);
			this.textBox1.TabIndex = 3;
			this.textBox1.Text = "100";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(7, 74);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 4;
			this.label2.Text = "ChatScrollLength";
			// 
			// button3
			// 
			this.button3.BackColor = System.Drawing.SystemColors.ControlLight;
			this.button3.Location = new System.Drawing.Point(435, 256);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(64, 24);
			this.button3.TabIndex = 4;
			this.button3.Text = "Close";
			this.button3.UseVisualStyleBackColor = false;
			// 
			// checkBox5
			// 
			this.checkBox5.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBox5.Location = new System.Drawing.Point(5, 129);
			this.checkBox5.Name = "checkBox5";
			this.checkBox5.Size = new System.Drawing.Size(249, 24);
			this.checkBox5.TabIndex = 9;
			this.checkBox5.Text = "FunnyPhysics";
			this.checkBox5.UseVisualStyleBackColor = true;
			// 
			// ClientSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(511, 292);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.listBox1);
			this.Controls.Add(this.button1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "ClientSettings";
			this.ShowIcon = false;
			this.Text = "Settings";
			this.panel1.ResumeLayout(false);
			this.GameOptions.ResumeLayout(false);
			this.GameOptions.PerformLayout();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.CheckBox checkBox5;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox checkBox4;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.CheckBox checkBox3;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.VScrollBar vScrollBar1;
		private System.Windows.Forms.Panel GameOptions;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Button button1;
	}
}
