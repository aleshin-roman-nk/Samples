namespace FrontEndWinForm
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
			buttonStart = new Button();
			buttonStop = new Button();
			textBoxInputName = new TextBox();
			label1 = new Label();
			labelSenderStatus = new Label();
			textBoxProducts = new TextBox();
			SuspendLayout();
			// 
			// buttonStart
			// 
			buttonStart.Location = new Point(29, 129);
			buttonStart.Name = "buttonStart";
			buttonStart.Size = new Size(112, 34);
			buttonStart.TabIndex = 0;
			buttonStart.Text = "start";
			buttonStart.UseVisualStyleBackColor = true;
			buttonStart.Click += buttonStart_Click;
			// 
			// buttonStop
			// 
			buttonStop.Location = new Point(147, 129);
			buttonStop.Name = "buttonStop";
			buttonStop.Size = new Size(112, 34);
			buttonStop.TabIndex = 1;
			buttonStop.Text = "stop";
			buttonStop.UseVisualStyleBackColor = true;
			buttonStop.Click += buttonStop_Click;
			// 
			// textBoxInputName
			// 
			textBoxInputName.Location = new Point(29, 35);
			textBoxInputName.Name = "textBoxInputName";
			textBoxInputName.Size = new Size(230, 31);
			textBoxInputName.TabIndex = 2;
			textBoxInputName.KeyDown += textBoxInputName_KeyDown;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(469, 9);
			label1.Name = "label1";
			label1.Size = new Size(117, 25);
			label1.TabIndex = 3;
			label1.Text = "sender status";
			// 
			// labelSenderStatus
			// 
			labelSenderStatus.AutoSize = true;
			labelSenderStatus.Location = new Point(607, 9);
			labelSenderStatus.Name = "labelSenderStatus";
			labelSenderStatus.Size = new Size(22, 25);
			labelSenderStatus.TabIndex = 4;
			labelSenderStatus.Text = "0";
			// 
			// textBoxProducts
			// 
			textBoxProducts.Location = new Point(469, 56);
			textBoxProducts.Multiline = true;
			textBoxProducts.Name = "textBoxProducts";
			textBoxProducts.ReadOnly = true;
			textBoxProducts.Size = new Size(550, 273);
			textBoxProducts.TabIndex = 5;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1199, 737);
			Controls.Add(textBoxProducts);
			Controls.Add(labelSenderStatus);
			Controls.Add(label1);
			Controls.Add(textBoxInputName);
			Controls.Add(buttonStop);
			Controls.Add(buttonStart);
			Name = "Form1";
			Text = "Form1";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button buttonStart;
		private Button buttonStop;
		private TextBox textBoxInputName;
		private Label label1;
		private Label labelSenderStatus;
		private TextBox textBoxProducts;
	}
}
