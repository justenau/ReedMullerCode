namespace Reed_Muller
{
    partial class TextView
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
            this.messageBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.sendMessageBtn = new System.Windows.Forms.Button();
            this.pInput = new System.Windows.Forms.NumericUpDown();
            this.label = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.messageTextBox = new System.Windows.Forms.TextBox();
            this.encodedTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pInput)).BeginInit();
            this.SuspendLayout();
            // 
            // messageBox
            // 
            this.messageBox.Location = new System.Drawing.Point(23, 80);
            this.messageBox.Multiline = true;
            this.messageBox.Name = "messageBox";
            this.messageBox.Size = new System.Drawing.Size(2454, 311);
            this.messageBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(273, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Provide text to send:";
            // 
            // sendMessageBtn
            // 
            this.sendMessageBtn.Location = new System.Drawing.Point(335, 487);
            this.sendMessageBtn.Name = "sendMessageBtn";
            this.sendMessageBtn.Size = new System.Drawing.Size(184, 67);
            this.sendMessageBtn.TabIndex = 11;
            this.sendMessageBtn.Text = "Send";
            this.sendMessageBtn.UseVisualStyleBackColor = true;
            this.sendMessageBtn.Click += new System.EventHandler(this.SendBtn_Click);
            // 
            // pInput
            // 
            this.pInput.Location = new System.Drawing.Point(29, 503);
            this.pInput.Name = "pInput";
            this.pInput.Size = new System.Drawing.Size(266, 38);
            this.pInput.TabIndex = 10;
            this.pInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PValueInput_KeyPress);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(22, 438);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(272, 32);
            this.label.TabIndex = 9;
            this.label.Text = "Provide p (0<=p<=1)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 654);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(191, 32);
            this.label2.TabIndex = 12;
            this.label2.Text = "Sent encoded";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 1054);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(238, 32);
            this.label3.TabIndex = 13;
            this.label3.Text = "Sent not encoded";
            // 
            // messageTextBox
            // 
            this.messageTextBox.Location = new System.Drawing.Point(23, 1099);
            this.messageTextBox.Multiline = true;
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.Size = new System.Drawing.Size(2454, 314);
            this.messageTextBox.TabIndex = 0;
            // 
            // encodedTextBox
            // 
            this.encodedTextBox.Location = new System.Drawing.Point(23, 709);
            this.encodedTextBox.Multiline = true;
            this.encodedTextBox.Name = "encodedTextBox";
            this.encodedTextBox.Size = new System.Drawing.Size(2454, 314);
            this.encodedTextBox.TabIndex = 0;
            // 
            // TextView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(240F, 240F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.messageTextBox);
            this.Controls.Add(this.encodedTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.sendMessageBtn);
            this.Controls.Add(this.pInput);
            this.Controls.Add(this.label);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.messageBox);
            this.Name = "TextView";
            this.Size = new System.Drawing.Size(2577, 1607);
            ((System.ComponentModel.ISupportInitialize)(this.pInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox messageBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button sendMessageBtn;
        private System.Windows.Forms.NumericUpDown pInput;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox messageTextBox;
        private System.Windows.Forms.TextBox encodedTextBox;
    }
}
