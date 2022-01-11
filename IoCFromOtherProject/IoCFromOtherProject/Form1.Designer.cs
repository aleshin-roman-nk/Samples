
namespace IoCFromOtherProject
{
	partial class Form1
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
			this.claendarX1 = new IoCFromOtherProject.Ctrls.ClaendarX();
			this.SuspendLayout();
			// 
			// claendarX1
			// 
			this.claendarX1.Cursor = System.Windows.Forms.Cursors.Hand;
			this.claendarX1.Font = new System.Drawing.Font("Roboto Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.claendarX1.Location = new System.Drawing.Point(12, 12);
			this.claendarX1.Name = "claendarX1";
			this.claendarX1.Size = new System.Drawing.Size(300, 400);
			this.claendarX1.TabIndex = 0;
			this.claendarX1.Text = "28";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(859, 546);
			this.Controls.Add(this.claendarX1);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Form1";
			this.ResumeLayout(false);

		}

		#endregion

		private Ctrls.ClaendarX claendarX1;
	}
}

