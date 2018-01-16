namespace RBXLegacyLauncher
{
	partial class DocForm
	{
		private System.ComponentModel.IContainer components = null;
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
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DocForm));
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.SuspendLayout();
			// 
			// richTextBox1
			// 
			this.richTextBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.richTextBox1.Location = new System.Drawing.Point(1, 2);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.ReadOnly = true;
			this.richTextBox1.Size = new System.Drawing.Size(426, 359);
			this.richTextBox1.TabIndex = 0;
			this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
			// 
			// DocForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.ClientSize = new System.Drawing.Size(429, 361);
			this.Controls.Add(this.richTextBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "DocForm";
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.RichTextBox richTextBox1;
	}
}
