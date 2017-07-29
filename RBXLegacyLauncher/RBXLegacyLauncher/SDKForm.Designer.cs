/*
 * Created by SharpDevelop.
 * User: BITL
 * Date: 6/23/2017
 * Time: 2:33 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace RBXLegacyLauncher
{
	partial class SDKForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SDKForm));
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.checkBox4 = new System.Windows.Forms.CheckBox();
			this.button4 = new System.Windows.Forms.Button();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.checkBox3 = new System.Windows.Forms.CheckBox();
			this.button3 = new System.Windows.Forms.Button();
			this.checkBox5 = new System.Windows.Forms.CheckBox();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.button7 = new System.Windows.Forms.Button();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.textBox7 = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.button5 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Location = new System.Drawing.Point(12, 12);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(336, 357);
			this.tabControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.checkBox4);
			this.tabPage1.Controls.Add(this.button4);
			this.tabPage1.Controls.Add(this.textBox3);
			this.tabPage1.Controls.Add(this.label4);
			this.tabPage1.Controls.Add(this.textBox2);
			this.tabPage1.Controls.Add(this.label3);
			this.tabPage1.Controls.Add(this.checkBox3);
			this.tabPage1.Controls.Add(this.button3);
			this.tabPage1.Controls.Add(this.checkBox5);
			this.tabPage1.Controls.Add(this.button2);
			this.tabPage1.Controls.Add(this.button1);
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Controls.Add(this.textBox1);
			this.tabPage1.Controls.Add(this.checkBox2);
			this.tabPage1.Controls.Add(this.checkBox1);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(328, 331);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "CLIENTINFO EDITOR";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// checkBox4
			// 
			this.checkBox4.Location = new System.Drawing.Point(5, 106);
			this.checkBox4.Name = "checkBox4";
			this.checkBox4.Size = new System.Drawing.Size(182, 20);
			this.checkBox4.TabIndex = 34;
			this.checkBox4.Text = "Client has \"rocky\" packet errors";
			this.checkBox4.UseVisualStyleBackColor = true;
			this.checkBox4.CheckedChanged += new System.EventHandler(this.CheckBox4CheckedChanged);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(246, 183);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(75, 23);
			this.button4.TabIndex = 33;
			this.button4.Text = "Help";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.Button4Click);
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(8, 185);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(232, 20);
			this.textBox3.TabIndex = 32;
			this.textBox3.TextChanged += new System.EventHandler(this.TextBox3TextChanged);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(6, 166);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(71, 16);
			this.label4.TabIndex = 31;
			this.label4.Text = "Client Version";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(8, 143);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(311, 20);
			this.textBox2.TabIndex = 30;
			this.textBox2.TextChanged += new System.EventHandler(this.TextBox2TextChanged);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(7, 127);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(65, 13);
			this.label3.TabIndex = 29;
			this.label3.Text = "Client MD5";
			// 
			// checkBox3
			// 
			this.checkBox3.Location = new System.Drawing.Point(5, 89);
			this.checkBox3.Name = "checkBox3";
			this.checkBox3.Size = new System.Drawing.Size(175, 20);
			this.checkBox3.TabIndex = 28;
			this.checkBox3.Text = "Client uses a single EXE to run";
			this.checkBox3.UseVisualStyleBackColor = true;
			this.checkBox3.CheckedChanged += new System.EventHandler(this.CheckBox3CheckedChanged);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(9, 264);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(312, 23);
			this.button3.TabIndex = 27;
			this.button3.Text = "New clientinfo.txt";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.Button3Click);
			// 
			// checkBox5
			// 
			this.checkBox5.Location = new System.Drawing.Point(5, 71);
			this.checkBox5.Name = "checkBox5";
			this.checkBox5.Size = new System.Drawing.Size(310, 20);
			this.checkBox5.TabIndex = 26;
			this.checkBox5.Text = "Loads assets from servers online";
			this.checkBox5.UseVisualStyleBackColor = true;
			this.checkBox5.CheckedChanged += new System.EventHandler(this.CheckBox5CheckedChanged);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(9, 293);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(150, 30);
			this.button2.TabIndex = 25;
			this.button2.Text = "Load";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.Button2Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(168, 293);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(154, 30);
			this.button1.TabIndex = 24;
			this.button1.Text = "Save";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(4, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(307, 30);
			this.label2.TabIndex = 23;
			this.label2.Text = "Check the check boxes corresponding to what your client supports.";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(6, 208);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(92, 16);
			this.label1.TabIndex = 22;
			this.label1.Text = "Client Description";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(9, 226);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(310, 34);
			this.textBox1.TabIndex = 21;
			this.textBox1.TextChanged += new System.EventHandler(this.TextBox1TextChanged);
			// 
			// checkBox2
			// 
			this.checkBox2.Location = new System.Drawing.Point(5, 53);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(307, 20);
			this.checkBox2.TabIndex = 20;
			this.checkBox2.Text = "Allows the launcher to set custom IDs";
			this.checkBox2.UseVisualStyleBackColor = true;
			this.checkBox2.CheckedChanged += new System.EventHandler(this.CheckBox2CheckedChanged);
			// 
			// checkBox1
			// 
			this.checkBox1.Location = new System.Drawing.Point(5, 34);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(307, 24);
			this.checkBox1.TabIndex = 19;
			this.checkBox1.Text = "Allows players to set custom names";
			this.checkBox1.UseVisualStyleBackColor = true;
			this.checkBox1.CheckedChanged += new System.EventHandler(this.CheckBox1CheckedChanged);
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.button7);
			this.tabPage2.Controls.Add(this.textBox4);
			this.tabPage2.Controls.Add(this.textBox5);
			this.tabPage2.Controls.Add(this.textBox6);
			this.tabPage2.Controls.Add(this.textBox7);
			this.tabPage2.Controls.Add(this.label5);
			this.tabPage2.Controls.Add(this.label6);
			this.tabPage2.Controls.Add(this.label7);
			this.tabPage2.Controls.Add(this.label8);
			this.tabPage2.Controls.Add(this.button5);
			this.tabPage2.Controls.Add(this.button6);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(328, 331);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "INFO EDITOR";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// button7
			// 
			this.button7.Location = new System.Drawing.Point(167, 269);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(150, 57);
			this.button7.TabIndex = 32;
			this.button7.Text = "Save";
			this.button7.UseVisualStyleBackColor = true;
			this.button7.Click += new System.EventHandler(this.Button7Click);
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(6, 154);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(311, 20);
			this.textBox4.TabIndex = 31;
			this.textBox4.TextChanged += new System.EventHandler(this.TextBox4TextChanged);
			// 
			// textBox5
			// 
			this.textBox5.Location = new System.Drawing.Point(6, 112);
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new System.Drawing.Size(312, 20);
			this.textBox5.TabIndex = 30;
			this.textBox5.TextChanged += new System.EventHandler(this.TextBox5TextChanged);
			// 
			// textBox6
			// 
			this.textBox6.Location = new System.Drawing.Point(5, 68);
			this.textBox6.Name = "textBox6";
			this.textBox6.Size = new System.Drawing.Size(313, 20);
			this.textBox6.TabIndex = 29;
			this.textBox6.TextChanged += new System.EventHandler(this.TextBox6TextChanged);
			// 
			// textBox7
			// 
			this.textBox7.Location = new System.Drawing.Point(6, 25);
			this.textBox7.Name = "textBox7";
			this.textBox7.Size = new System.Drawing.Size(311, 20);
			this.textBox7.TabIndex = 28;
			this.textBox7.TextChanged += new System.EventHandler(this.TextBox7TextChanged);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(5, 135);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(71, 16);
			this.label5.TabIndex = 27;
			this.label5.Text = "Script MD5";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(5, 91);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(76, 18);
			this.label6.TabIndex = 26;
			this.label6.Text = "Script Path";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(5, 48);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(76, 17);
			this.label7.TabIndex = 25;
			this.label7.Text = "Default Client";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(5, 7);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(44, 15);
			this.label8.TabIndex = 24;
			this.label8.Text = "Version";
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(5, 180);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(312, 83);
			this.button5.TabIndex = 23;
			this.button5.Text = "New info.txt";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.Button5Click);
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(6, 269);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(150, 57);
			this.button6.TabIndex = 22;
			this.button6.Text = "Load";
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new System.EventHandler(this.Button6Click);
			// 
			// SDKForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.ClientSize = new System.Drawing.Size(354, 376);
			this.Controls.Add(this.tabControl1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "SDKForm";
			this.Text = "RBXLegacy SDK";
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.CheckBox checkBox4;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBox7;
		private System.Windows.Forms.TextBox textBox6;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.CheckBox checkBox5;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.CheckBox checkBox3;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabControl tabControl1;
	}
}