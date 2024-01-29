namespace DrCost2.viewParticipants
{
	partial class ProductForm
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
			btnCreate = new Button();
			label1 = new Label();
			label2 = new Label();
			button1 = new Button();
			label3 = new Label();
			textProductName = new TextBox();
			btnClose = new Button();
			numberPrice = new NumericUpDown();
			numberCount = new NumericUpDown();
			((System.ComponentModel.ISupportInitialize)numberPrice).BeginInit();
			((System.ComponentModel.ISupportInitialize)numberCount).BeginInit();
			SuspendLayout();
			// 
			// btnCreate
			// 
			btnCreate.Location = new Point(674, 169);
			btnCreate.Margin = new Padding(4);
			btnCreate.Name = "btnCreate";
			btnCreate.Size = new Size(117, 64);
			btnCreate.TabIndex = 3;
			btnCreate.Text = "создать";
			btnCreate.UseVisualStyleBackColor = true;
			btnCreate.Click += btnCreate_Click;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(13, 61);
			label1.Name = "label1";
			label1.Size = new Size(109, 28);
			label1.TabIndex = 2;
			label1.Text = "Стоимость";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(12, 115);
			label2.Name = "label2";
			label2.Size = new Size(120, 28);
			label2.TabIndex = 4;
			label2.Text = "Количество";
			// 
			// button1
			// 
			button1.Location = new Point(747, 13);
			button1.Margin = new Padding(4);
			button1.Name = "button1";
			button1.Size = new Size(44, 36);
			button1.TabIndex = 5;
			button1.Text = "...";
			button1.UseVisualStyleBackColor = true;
			button1.Click += button1_Click;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(13, 13);
			label3.Name = "label3";
			label3.Size = new Size(89, 28);
			label3.TabIndex = 6;
			label3.Text = "Продукт";
			// 
			// textProductName
			// 
			textProductName.Enabled = false;
			textProductName.Location = new Point(139, 13);
			textProductName.Margin = new Padding(4);
			textProductName.Name = "textProductName";
			textProductName.Size = new Size(600, 34);
			textProductName.TabIndex = 7;
			// 
			// btnClose
			// 
			btnClose.Location = new Point(549, 169);
			btnClose.Margin = new Padding(4);
			btnClose.Name = "btnClose";
			btnClose.Size = new Size(117, 64);
			btnClose.TabIndex = 8;
			btnClose.Text = "закрыть";
			btnClose.UseVisualStyleBackColor = true;
			btnClose.Click += btnClose_Click;
			// 
			// numberPrice
			// 
			numberPrice.DecimalPlaces = 2;
			numberPrice.Location = new Point(139, 61);
			numberPrice.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
			numberPrice.Minimum = new decimal(new int[] { 1000000000, 0, 0, int.MinValue });
			numberPrice.Name = "numberPrice";
			numberPrice.Size = new Size(652, 34);
			numberPrice.TabIndex = 1;
			numberPrice.Tag = "";
			// 
			// numberCount
			// 
			numberCount.DecimalPlaces = 2;
			numberCount.Location = new Point(139, 113);
			numberCount.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
			numberCount.Minimum = new decimal(new int[] { 1000000000, 0, 0, int.MinValue });
			numberCount.Name = "numberCount";
			numberCount.Size = new Size(652, 34);
			numberCount.TabIndex = 2;
			numberCount.Tag = "";
			numberCount.Value = new decimal(new int[] { 1, 0, 0, 0 });
			// 
			// ProductView
			// 
			AutoScaleDimensions = new SizeF(11F, 28F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(804, 245);
			Controls.Add(numberCount);
			Controls.Add(numberPrice);
			Controls.Add(btnClose);
			Controls.Add(textProductName);
			Controls.Add(label3);
			Controls.Add(button1);
			Controls.Add(label2);
			Controls.Add(label1);
			Controls.Add(btnCreate);
			Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			FormBorderStyle = FormBorderStyle.FixedDialog;
			Margin = new Padding(4);
			Name = "ProductView";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Покупка";
			FormClosing += ProductView_FormClosing;
			((System.ComponentModel.ISupportInitialize)numberPrice).EndInit();
			((System.ComponentModel.ISupportInitialize)numberCount).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion
		private Button btnCreate;
		private Label label1;
		private Label label2;
		private TextBox textBox2;
		private Button button1;
		private Label label3;
		private TextBox textProductName;
		private Button btnClose;
		private NumericUpDown numberPrice;
		private NumericUpDown numberCount;
	}
}