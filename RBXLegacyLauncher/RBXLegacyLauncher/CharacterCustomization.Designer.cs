/*
 * Created by SharpDevelop.
 * User: BITL
 * Date: 2/5/2017
 * Time: 1:53 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace RBXLegacyLauncher
{
	partial class CharacterCustomization
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CharacterCustomization));
			this.label1 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.textBox7 = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.textBox8 = new System.Windows.Forms.TextBox();
			this.textBox9 = new System.Windows.Forms.TextBox();
			this.textBox10 = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.label7 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.label18 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.listBox3 = new System.Windows.Forms.ListBox();
			this.listBox2 = new System.Windows.Forms.ListBox();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.button1 = new System.Windows.Forms.Button();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(28, 2);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(217, 14);
			this.label1.TabIndex = 0;
			this.label1.Text = "Character Color Hash (used for body colors)";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(9, 19);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(240, 20);
			this.textBox1.TabIndex = 1;
			this.textBox1.Text = "0";
			this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.textBox1.TextChanged += new System.EventHandler(this.TextBox1TextChanged);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(109, 74);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(33, 16);
			this.label3.TabIndex = 3;
			this.label3.Text = "Outfit";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(46, 96);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(49, 14);
			this.label4.TabIndex = 4;
			this.label4.Text = "Shirt ID";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(47, 122);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(49, 14);
			this.label5.TabIndex = 5;
			this.label5.Text = "Pants ID";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(46, 148);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(57, 14);
			this.label6.TabIndex = 6;
			this.label6.Text = "T-Shirt ID";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(109, 93);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(100, 20);
			this.textBox2.TabIndex = 7;
			this.textBox2.Text = "0";
			this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.textBox2.TextChanged += new System.EventHandler(this.TextBox2TextChanged);
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(109, 119);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(100, 20);
			this.textBox3.TabIndex = 8;
			this.textBox3.Text = "0";
			this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.textBox3.TextChanged += new System.EventHandler(this.TextBox3TextChanged);
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(109, 145);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(100, 20);
			this.textBox4.TabIndex = 9;
			this.textBox4.Text = "0";
			this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.textBox4.TextChanged += new System.EventHandler(this.TextBox4TextChanged);
			// 
			// textBox5
			// 
			this.textBox5.Location = new System.Drawing.Point(83, 195);
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new System.Drawing.Size(100, 20);
			this.textBox5.TabIndex = 17;
			this.textBox5.Text = "0";
			this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.textBox5.TextChanged += new System.EventHandler(this.TextBox5TextChanged);
			// 
			// textBox6
			// 
			this.textBox6.Location = new System.Drawing.Point(83, 224);
			this.textBox6.Name = "textBox6";
			this.textBox6.Size = new System.Drawing.Size(100, 20);
			this.textBox6.TabIndex = 16;
			this.textBox6.Text = "0";
			this.textBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.textBox6.TextChanged += new System.EventHandler(this.TextBox6TextChanged);
			// 
			// textBox7
			// 
			this.textBox7.Location = new System.Drawing.Point(83, 252);
			this.textBox7.Name = "textBox7";
			this.textBox7.Size = new System.Drawing.Size(100, 20);
			this.textBox7.TabIndex = 15;
			this.textBox7.Text = "0";
			this.textBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.textBox7.TextChanged += new System.EventHandler(this.TextBox7TextChanged);
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(28, 255);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(49, 14);
			this.label8.TabIndex = 14;
			this.label8.Text = "Hat 3 ID";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(28, 227);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(49, 14);
			this.label9.TabIndex = 13;
			this.label9.Text = "Hat 2 ID";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(28, 198);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(49, 14);
			this.label10.TabIndex = 12;
			this.label10.Text = "Hat 1 ID";
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(120, 176);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(33, 16);
			this.label11.TabIndex = 11;
			this.label11.Text = "Hats";
			// 
			// label13
			// 
			this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label13.ForeColor = System.Drawing.Color.Red;
			this.label13.Location = new System.Drawing.Point(3, 275);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(249, 69);
			this.label13.TabIndex = 19;
			this.label13.Text = resources.GetString("label13.Text");
			this.label13.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(189, 176);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(42, 16);
			this.label14.TabIndex = 23;
			this.label14.Text = "Version";
			// 
			// textBox8
			// 
			this.textBox8.Location = new System.Drawing.Point(189, 195);
			this.textBox8.Name = "textBox8";
			this.textBox8.Size = new System.Drawing.Size(40, 20);
			this.textBox8.TabIndex = 24;
			this.textBox8.Text = "1";
			this.textBox8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.textBox8.TextChanged += new System.EventHandler(this.TextBox8TextChanged);
			// 
			// textBox9
			// 
			this.textBox9.Location = new System.Drawing.Point(189, 224);
			this.textBox9.Name = "textBox9";
			this.textBox9.Size = new System.Drawing.Size(40, 20);
			this.textBox9.TabIndex = 25;
			this.textBox9.Text = "1";
			this.textBox9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.textBox9.TextChanged += new System.EventHandler(this.TextBox9TextChanged);
			// 
			// textBox10
			// 
			this.textBox10.Location = new System.Drawing.Point(189, 252);
			this.textBox10.Name = "textBox10";
			this.textBox10.Size = new System.Drawing.Size(40, 20);
			this.textBox10.TabIndex = 26;
			this.textBox10.Text = "1";
			this.textBox10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.textBox10.TextChanged += new System.EventHandler(this.TextBox10TextChanged);
			// 
			// label15
			// 
			this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label15.ForeColor = System.Drawing.Color.Red;
			this.label15.Location = new System.Drawing.Point(12, 42);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(233, 27);
			this.label15.TabIndex = 27;
			this.label15.Text = "Note: THIS IS REQUIRED IN ORDER FOR THE OUTFIT TO WORK.";
			this.label15.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Location = new System.Drawing.Point(9, 12);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.ShowToolTips = true;
			this.tabControl1.Size = new System.Drawing.Size(263, 367);
			this.tabControl1.TabIndex = 28;
			this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.label7);
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Controls.Add(this.textBox10);
			this.tabPage1.Controls.Add(this.label15);
			this.tabPage1.Controls.Add(this.textBox9);
			this.tabPage1.Controls.Add(this.textBox1);
			this.tabPage1.Controls.Add(this.textBox8);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Controls.Add(this.textBox5);
			this.tabPage1.Controls.Add(this.label14);
			this.tabPage1.Controls.Add(this.textBox6);
			this.tabPage1.Controls.Add(this.label13);
			this.tabPage1.Controls.Add(this.textBox7);
			this.tabPage1.Controls.Add(this.label11);
			this.tabPage1.Controls.Add(this.label8);
			this.tabPage1.Controls.Add(this.textBox2);
			this.tabPage1.Controls.Add(this.label9);
			this.tabPage1.Controls.Add(this.label3);
			this.tabPage1.Controls.Add(this.label10);
			this.tabPage1.Controls.Add(this.label4);
			this.tabPage1.Controls.Add(this.label5);
			this.tabPage1.Controls.Add(this.label6);
			this.tabPage1.Controls.Add(this.textBox4);
			this.tabPage1.Controls.Add(this.textBox3);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(255, 341);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Custom Outfit (Online)";
			this.tabPage1.ToolTipText = "Requires Internet Connection";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// label7
			// 
			this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label7.Location = new System.Drawing.Point(12, 72);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(228, 2);
			this.label7.TabIndex = 29;
			// 
			// label2
			// 
			this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label2.Location = new System.Drawing.Point(12, 174);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(228, 2);
			this.label2.TabIndex = 28;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.label18);
			this.tabPage2.Controls.Add(this.label17);
			this.tabPage2.Controls.Add(this.label16);
			this.tabPage2.Controls.Add(this.label12);
			this.tabPage2.Controls.Add(this.listBox3);
			this.tabPage2.Controls.Add(this.listBox2);
			this.tabPage2.Controls.Add(this.listBox1);
			this.tabPage2.Controls.Add(this.button1);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(255, 341);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Custom Outfit (Local)";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// label18
			// 
			this.label18.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label18.Location = new System.Drawing.Point(6, 58);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(243, 2);
			this.label18.TabIndex = 7;
			// 
			// label17
			// 
			this.label17.Location = new System.Drawing.Point(108, 245);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(35, 18);
			this.label17.TabIndex = 6;
			this.label17.Text = "Hat 3";
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(108, 157);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(35, 13);
			this.label16.TabIndex = 5;
			this.label16.Text = "Hat 2";
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(108, 69);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(35, 13);
			this.label12.TabIndex = 4;
			this.label12.Text = "Hat 1";
			// 
			// listBox3
			// 
			this.listBox3.FormattingEnabled = true;
			this.listBox3.Location = new System.Drawing.Point(6, 266);
			this.listBox3.Name = "listBox3";
			this.listBox3.Size = new System.Drawing.Size(243, 69);
			this.listBox3.TabIndex = 3;
			this.listBox3.SelectedIndexChanged += new System.EventHandler(this.ListBox3SelectedIndexChanged);
			// 
			// listBox2
			// 
			this.listBox2.FormattingEnabled = true;
			this.listBox2.Location = new System.Drawing.Point(6, 173);
			this.listBox2.Name = "listBox2";
			this.listBox2.Size = new System.Drawing.Size(243, 69);
			this.listBox2.TabIndex = 2;
			this.listBox2.SelectedIndexChanged += new System.EventHandler(this.ListBox2SelectedIndexChanged);
			// 
			// listBox1
			// 
			this.listBox1.FormattingEnabled = true;
			this.listBox1.Location = new System.Drawing.Point(6, 85);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(243, 69);
			this.listBox1.TabIndex = 1;
			this.listBox1.SelectedIndexChanged += new System.EventHandler(this.ListBox1SelectedIndexChanged);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(6, 6);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(243, 40);
			this.button1.TabIndex = 0;
			this.button1.Text = "Edit Character Colors";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// CharacterCustomization
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.ClientSize = new System.Drawing.Size(281, 391);
			this.Controls.Add(this.tabControl1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "CharacterCustomization";
			this.Text = "Character Customization";
			this.Load += new System.EventHandler(this.CharacterCustomizationLoad);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ListBox listBox2;
		private System.Windows.Forms.ListBox listBox3;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.TextBox textBox10;
		private System.Windows.Forms.TextBox textBox9;
		private System.Windows.Forms.TextBox textBox8;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox textBox7;
		private System.Windows.Forms.TextBox textBox6;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label1;
	}
}
