namespace DrCost2.viewParticipants
{
	partial class ProductTypeSelectForm
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
			btnSelect = new Button();
			textType = new TextBox();
			SuspendLayout();
			// 
			// btnSelect
			// 
			btnSelect.Location = new Point(570, 13);
			btnSelect.Margin = new Padding(4);
			btnSelect.Name = "btnSelect";
			btnSelect.Size = new Size(173, 69);
			btnSelect.TabIndex = 0;
			btnSelect.Text = "button1";
			btnSelect.UseVisualStyleBackColor = true;
			btnSelect.Click += btnSelect_Click;
			// 
			// textType
			// 
			textType.Location = new Point(12, 12);
			textType.Name = "textType";
			textType.Size = new Size(375, 34);
			textType.TabIndex = 1;
			textType.Text = "Йогурт";
			// 
			// ProductTypeSelectForm
			// 
			AutoScaleDimensions = new SizeF(11F, 28F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(756, 307);
			Controls.Add(textType);
			Controls.Add(btnSelect);
			Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			Margin = new Padding(4);
			Name = "ProductTypeSelectForm";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "ProductTypeSelectForm";
			FormClosing += ProductTypeSelectForm_FormClosing;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button btnSelect;
		private TextBox textType;
	}
}