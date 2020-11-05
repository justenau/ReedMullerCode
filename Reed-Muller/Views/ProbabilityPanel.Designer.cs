namespace Reed_Muller.Views
{
    partial class ProbabilityPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.sendMessageBtn = new System.Windows.Forms.Button();
            this.pInput = new System.Windows.Forms.NumericUpDown();
            this.label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pInput)).BeginInit();
            this.SuspendLayout();
            // 
            // sendMessageBtn
            // 
            this.sendMessageBtn.Location = new System.Drawing.Point(323, 71);
            this.sendMessageBtn.Name = "sendMessageBtn";
            this.sendMessageBtn.Size = new System.Drawing.Size(184, 67);
            this.sendMessageBtn.TabIndex = 14;
            this.sendMessageBtn.Text = "Send";
            this.sendMessageBtn.UseVisualStyleBackColor = true;
            // 
            // pInput
            // 
            this.pInput.Location = new System.Drawing.Point(0, 87);
            this.pInput.Name = "pInput";
            this.pInput.Size = new System.Drawing.Size(266, 38);
            this.pInput.TabIndex = 13;
            this.pInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PValueInput_KeyPress);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(-6, 18);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(272, 32);
            this.label.TabIndex = 12;
            this.label.Text = "Provide p (0<=p<=1)";
            // 
            // ProbabilityPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(240F, 240F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.sendMessageBtn);
            this.Controls.Add(this.pInput);
            this.Controls.Add(this.label);
            this.Name = "ProbabilityPanel";
            this.Size = new System.Drawing.Size(517, 161);
            ((System.ComponentModel.ISupportInitialize)(this.pInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button sendMessageBtn;
        private System.Windows.Forms.NumericUpDown pInput;
        private System.Windows.Forms.Label label;
    }
}
