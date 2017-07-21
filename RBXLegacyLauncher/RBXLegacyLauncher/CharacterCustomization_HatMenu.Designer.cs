/*
 * Created by SharpDevelop.
 * User: BITL
 * Date: 5/29/2017
 * Time: 8:58 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace RBXLegacyLauncher
{
	partial class CharacterCustomization_HatMenu
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CharacterCustomization_HatMenu));
			this.label17 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.listBox3 = new System.Windows.Forms.ListBox();
			this.listBox2 = new System.Windows.Forms.ListBox();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.pictureBox3 = new System.Windows.Forms.PictureBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
			this.SuspendLayout();
			// 
			// label17
			// 
			this.label17.Location = new System.Drawing.Point(155, 181);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(35, 14);
			this.label17.TabIndex = 43;
			this.label17.Text = "Hat 3";
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(155, 93);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(35, 13);
			this.label16.TabIndex = 42;
			this.label16.Text = "Hat 2";
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(155, 5);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(35, 13);
			this.label12.TabIndex = 41;
			this.label12.Text = "Hat 1";
			// 
			// listBox3
			// 
			this.listBox3.FormattingEnabled = true;
			this.listBox3.Location = new System.Drawing.Point(12, 198);
			this.listBox3.Name = "listBox3";
			this.listBox3.Size = new System.Drawing.Size(243, 69);
			this.listBox3.TabIndex = 40;
			this.listBox3.SelectedIndexChanged += new System.EventHandler(this.ListBox3SelectedIndexChanged);
			// 
			// listBox2
			// 
			this.listBox2.FormattingEnabled = true;
			this.listBox2.Location = new System.Drawing.Point(12, 109);
			this.listBox2.Name = "listBox2";
			this.listBox2.Size = new System.Drawing.Size(243, 69);
			this.listBox2.TabIndex = 39;
			this.listBox2.SelectedIndexChanged += new System.EventHandler(this.ListBox2SelectedIndexChanged);
			// 
			// listBox1
			// 
			this.listBox1.FormattingEnabled = true;
			this.listBox1.Location = new System.Drawing.Point(12, 21);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(243, 69);
			this.listBox1.TabIndex = 38;
			this.listBox1.SelectedIndexChanged += new System.EventHandler(this.ListBox1SelectedIndexChanged);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(261, 21);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(79, 69);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 44;
			this.pictureBox1.TabStop = false;
			// 
			// pictureBox2
			// 
			this.pictureBox2.Location = new System.Drawing.Point(262, 109);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(79, 69);
			this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox2.TabIndex = 45;
			this.pictureBox2.TabStop = false;
			// 
			// pictureBox3
			// 
			this.pictureBox3.Location = new System.Drawing.Point(261, 198);
			this.pictureBox3.Name = "pictureBox3";
			this.pictureBox3.Size = new System.Drawing.Size(79, 69);
			this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox3.TabIndex = 46;
			this.pictureBox3.TabStop = false;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(12, 273);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(161, 42);
			this.button1.TabIndex = 47;
			this.button1.Text = "Randomize";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(179, 273);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(161, 42);
			this.button2.TabIndex = 48;
			this.button2.Text = "Reset";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.Button2Click);
			// 
			// CharacterCustomization_HatMenu
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.ClientSize = new System.Drawing.Size(353, 327);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.pictureBox3);
			this.Controls.Add(this.pictureBox2);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.label17);
			this.Controls.Add(this.label16);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.listBox3);
			this.Controls.Add(this.listBox2);
			this.Controls.Add(this.listBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "CharacterCustomization_HatMenu";
			this.Text = "Hats";
			this.Load += new System.EventHandler(this.CharacterCustomization_HatMenuLoad);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.PictureBox pictureBox3;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.ListBox listBox2;
		private System.Windows.Forms.ListBox listBox3;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
	}
}
