namespace LivingRectangles
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
            this.button1 = new System.Windows.Forms.Button();
            this.customScrollBar1 = new LivingRectangles.CustomScrollBar();
            this.cellsOfPlan1 = new LivingRectangles.CellsOfPlan();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(12, 576);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 44);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // customScrollBar1
            // 
            this.customScrollBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customScrollBar1.Location = new System.Drawing.Point(12, 519);
            this.customScrollBar1.Name = "customScrollBar1";
            this.customScrollBar1.Size = new System.Drawing.Size(869, 25);
            this.customScrollBar1.TabIndex = 2;
            this.customScrollBar1.Text = "customScrollBar1";
            // 
            // cellsOfPlan1
            // 
            this.cellsOfPlan1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cellsOfPlan1.Location = new System.Drawing.Point(12, 37);
            this.cellsOfPlan1.Name = "cellsOfPlan1";
            this.cellsOfPlan1.Size = new System.Drawing.Size(869, 476);
            this.cellsOfPlan1.TabIndex = 0;
            this.cellsOfPlan1.Text = "cellsOfPlan1";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox1.Location = new System.Drawing.Point(12, 550);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 624);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.customScrollBar1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cellsOfPlan1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CustomScrollBar Enabled";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CellsOfPlan cellsOfPlan1;
        private System.Windows.Forms.Button button1;
        private CustomScrollBar customScrollBar1;
        private System.Windows.Forms.TextBox textBox1;
    }
}

