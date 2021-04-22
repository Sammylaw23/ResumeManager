namespace ResumeEmailer
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
            this.sendResume = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // sendResume
            // 
            this.sendResume.Location = new System.Drawing.Point(245, 47);
            this.sendResume.Name = "sendResume";
            this.sendResume.Size = new System.Drawing.Size(234, 69);
            this.sendResume.TabIndex = 0;
            this.sendResume.Text = "SEND RESUME";
            this.sendResume.UseVisualStyleBackColor = true;
            this.sendResume.Click += new System.EventHandler(this.sendResume_ClickAsync);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.sendResume);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button sendResume;
    }
}

