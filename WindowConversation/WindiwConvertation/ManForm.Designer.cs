
namespace WindiwConvertation
{
	partial class ManForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.button2cancel = new System.Windows.Forms.Button();
			this.button1ok = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// button2cancel
			// 
			this.button2cancel.Location = new System.Drawing.Point(84, 79);
			this.button2cancel.Name = "button2cancel";
			this.button2cancel.Size = new System.Drawing.Size(75, 23);
			this.button2cancel.TabIndex = 3;
			this.button2cancel.Text = "cancel";
			this.button2cancel.UseVisualStyleBackColor = true;
			this.button2cancel.Click += new System.EventHandler(this.button2cancel_Click_1);
			// 
			// button1ok
			// 
			this.button1ok.Location = new System.Drawing.Point(84, 50);
			this.button1ok.Name = "button1ok";
			this.button1ok.Size = new System.Drawing.Size(75, 23);
			this.button1ok.TabIndex = 2;
			this.button1ok.Text = "ok";
			this.button1ok.UseVisualStyleBackColor = true;
			this.button1ok.Click += new System.EventHandler(this.button1ok_Click_1);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(12, 12);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(147, 20);
			this.textBox1.TabIndex = 4;
			this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
			// 
			// ManForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(183, 133);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.button2cancel);
			this.Controls.Add(this.button1ok);
			this.Name = "ManForm";
			this.Text = "ManForm";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button2cancel;
		private System.Windows.Forms.Button button1ok;
		private System.Windows.Forms.TextBox textBox1;
	}
}