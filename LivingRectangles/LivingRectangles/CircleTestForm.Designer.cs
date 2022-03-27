namespace LivingRectangles
{
    partial class CircleTestForm
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
            this.circlePlan1 = new LivingRectangles.CirclePlan();
            this.SuspendLayout();
            // 
            // circlePlan1
            // 
            this.circlePlan1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.circlePlan1.Location = new System.Drawing.Point(0, 0);
            this.circlePlan1.Name = "circlePlan1";
            this.circlePlan1.Size = new System.Drawing.Size(800, 450);
            this.circlePlan1.TabIndex = 0;
            this.circlePlan1.Text = "circlePlan1";
            // 
            // CircleTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.circlePlan1);
            this.Name = "CircleTestForm";
            this.Text = "CircleTestForm";
            this.ResumeLayout(false);

        }

        #endregion

        private CirclePlan circlePlan1;
    }
}