namespace DrCost2
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			button2 = new Button();
			label1 = new Label();
			label = new Label();
			SuspendLayout();
			// 
			// button2
			// 
			button2.Location = new Point(1018, 13);
			button2.Margin = new Padding(4);
			button2.Name = "button2";
			button2.Size = new Size(69, 41);
			button2.TabIndex = 1;
			button2.Text = "+";
			button2.UseVisualStyleBackColor = true;
			button2.Click += createProduct_Click;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(12, 13);
			label1.Name = "label1";
			label1.Size = new Size(62, 28);
			label1.TabIndex = 2;
			label1.Text = "всего";
			// 
			// label
			// 
			label.AutoSize = true;
			label.Location = new Point(144, 13);
			label.Name = "label";
			label.Size = new Size(23, 28);
			label.TabIndex = 3;
			label.Text = "0";
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(11F, 28F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1100, 630);
			Controls.Add(label);
			Controls.Add(label1);
			Controls.Add(button2);
			Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			Margin = new Padding(4);
			Name = "Form1";
			Text = "Form1";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion
		private Button button2;
		private Label label1;
		private Label label;
	}
}