namespace Reed_Muller
{
    partial class VectorView
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
            this.label1 = new System.Windows.Forms.Label();
            this.vectorLengthLabel = new System.Windows.Forms.Label();
            this.inputField = new System.Windows.Forms.TextBox();
            this.encodeBtn = new System.Windows.Forms.Button();
            this.encodedLabel = new System.Windows.Forms.Label();
            this.encodedVectorLabel = new System.Windows.Forms.TextBox();
            this.receivedVectorLabel = new System.Windows.Forms.Label();
            this.receivedVectorField = new System.Windows.Forms.TextBox();
            this.distortionLabel = new System.Windows.Forms.Label();
            this.decodeBtn = new System.Windows.Forms.Button();
            this.decodedField = new System.Windows.Forms.TextBox();
            this.decodedLabel = new System.Windows.Forms.Label();
            this.sendBtn = new System.Windows.Forms.Button();
            this.pValueInput = new System.Windows.Forms.NumericUpDown();
            this.pLabel = new System.Windows.Forms.Label();
            this.distortionPlaceholder = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pValueInput)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(468, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Provide binary input vector of length";
            // 
            // vectorLengthLabel
            // 
            this.vectorLengthLabel.AutoSize = true;
            this.vectorLengthLabel.Location = new System.Drawing.Point(525, 43);
            this.vectorLengthLabel.Name = "vectorLengthLabel";
            this.vectorLengthLabel.Size = new System.Drawing.Size(31, 32);
            this.vectorLengthLabel.TabIndex = 1;
            this.vectorLengthLabel.Text = "#";
            // 
            // inputField
            // 
            this.inputField.Location = new System.Drawing.Point(57, 101);
            this.inputField.Name = "inputField";
            this.inputField.Size = new System.Drawing.Size(2232, 38);
            this.inputField.TabIndex = 2;
            // 
            // encodeBtn
            // 
            this.encodeBtn.Location = new System.Drawing.Point(2334, 89);
            this.encodeBtn.Name = "encodeBtn";
            this.encodeBtn.Size = new System.Drawing.Size(184, 60);
            this.encodeBtn.TabIndex = 3;
            this.encodeBtn.Text = "Encode";
            this.encodeBtn.UseVisualStyleBackColor = true;
            this.encodeBtn.Click += new System.EventHandler(this.EncodeBtn_Click);
            // 
            // encodedLabel
            // 
            this.encodedLabel.AutoSize = true;
            this.encodedLabel.Location = new System.Drawing.Point(51, 164);
            this.encodedLabel.Name = "encodedLabel";
            this.encodedLabel.Size = new System.Drawing.Size(212, 32);
            this.encodedLabel.TabIndex = 4;
            this.encodedLabel.Text = "Encoded value:";
            this.encodedLabel.Visible = false;
            // 
            // encodedVectorLabel
            // 
            this.encodedVectorLabel.Location = new System.Drawing.Point(57, 216);
            this.encodedVectorLabel.Multiline = true;
            this.encodedVectorLabel.Name = "encodedVectorLabel";
            this.encodedVectorLabel.ReadOnly = true;
            this.encodedVectorLabel.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.encodedVectorLabel.Size = new System.Drawing.Size(2461, 426);
            this.encodedVectorLabel.TabIndex = 5;
            this.encodedVectorLabel.Visible = false;
            // 
            // receivedVectorLabel
            // 
            this.receivedVectorLabel.AutoSize = true;
            this.receivedVectorLabel.Location = new System.Drawing.Point(51, 808);
            this.receivedVectorLabel.Name = "receivedVectorLabel";
            this.receivedVectorLabel.Size = new System.Drawing.Size(226, 32);
            this.receivedVectorLabel.TabIndex = 9;
            this.receivedVectorLabel.Text = "Received vector:";
            this.receivedVectorLabel.Visible = false;
            // 
            // receivedVectorField
            // 
            this.receivedVectorField.Location = new System.Drawing.Point(57, 853);
            this.receivedVectorField.Multiline = true;
            this.receivedVectorField.Name = "receivedVectorField";
            this.receivedVectorField.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.receivedVectorField.Size = new System.Drawing.Size(2457, 402);
            this.receivedVectorField.TabIndex = 10;
            this.receivedVectorField.Visible = false;
            // 
            // distortionLabel
            // 
            this.distortionLabel.AutoSize = true;
            this.distortionLabel.Location = new System.Drawing.Point(55, 1267);
            this.distortionLabel.Name = "distortionLabel";
            this.distortionLabel.Size = new System.Drawing.Size(264, 32);
            this.distortionLabel.TabIndex = 11;
            this.distortionLabel.Text = "Distortion in places:";
            this.distortionLabel.Visible = false;
            // 
            // decodeBtn
            // 
            this.decodeBtn.Location = new System.Drawing.Point(57, 1384);
            this.decodeBtn.Name = "decodeBtn";
            this.decodeBtn.Size = new System.Drawing.Size(184, 65);
            this.decodeBtn.TabIndex = 13;
            this.decodeBtn.Text = "Decode";
            this.decodeBtn.UseVisualStyleBackColor = true;
            this.decodeBtn.Visible = false;
            this.decodeBtn.Click += new System.EventHandler(this.DecodeBtn_Click);
            // 
            // decodedField
            // 
            this.decodedField.Location = new System.Drawing.Point(57, 1532);
            this.decodedField.Name = "decodedField";
            this.decodedField.ReadOnly = true;
            this.decodedField.Size = new System.Drawing.Size(2461, 38);
            this.decodedField.TabIndex = 14;
            this.decodedField.Visible = false;
            // 
            // decodedLabel
            // 
            this.decodedLabel.AutoSize = true;
            this.decodedLabel.Location = new System.Drawing.Point(55, 1480);
            this.decodedLabel.Name = "decodedLabel";
            this.decodedLabel.Size = new System.Drawing.Size(213, 32);
            this.decodedLabel.TabIndex = 15;
            this.decodedLabel.Text = "Decoded value:";
            this.decodedLabel.Visible = false;
            // 
            // sendBtn
            // 
            this.sendBtn.Location = new System.Drawing.Point(372, 719);
            this.sendBtn.Name = "sendBtn";
            this.sendBtn.Size = new System.Drawing.Size(184, 67);
            this.sendBtn.TabIndex = 18;
            this.sendBtn.Text = "Send";
            this.sendBtn.UseVisualStyleBackColor = true;
            this.sendBtn.Visible = false;
            this.sendBtn.Click += new System.EventHandler(this.SendBtn_Click);
            // 
            // pValueInput
            // 
            this.pValueInput.Location = new System.Drawing.Point(66, 735);
            this.pValueInput.Name = "pValueInput";
            this.pValueInput.Size = new System.Drawing.Size(266, 38);
            this.pValueInput.TabIndex = 17;
            this.pValueInput.Visible = false;
            // 
            // pLabel
            // 
            this.pLabel.AutoSize = true;
            this.pLabel.Location = new System.Drawing.Point(59, 670);
            this.pLabel.Name = "pLabel";
            this.pLabel.Size = new System.Drawing.Size(272, 32);
            this.pLabel.TabIndex = 16;
            this.pLabel.Text = "Provide p (0<=p<=1)";
            this.pLabel.Visible = false;
            // 
            // distortionPlaceholder
            // 
            this.distortionPlaceholder.Location = new System.Drawing.Point(61, 1302);
            this.distortionPlaceholder.Multiline = true;
            this.distortionPlaceholder.Name = "distortionPlaceholder";
            this.distortionPlaceholder.ReadOnly = true;
            this.distortionPlaceholder.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.distortionPlaceholder.Size = new System.Drawing.Size(2453, 65);
            this.distortionPlaceholder.TabIndex = 19;
            this.distortionPlaceholder.Visible = false;
            // 
            // VectorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(240F, 240F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.distortionPlaceholder);
            this.Controls.Add(this.sendBtn);
            this.Controls.Add(this.pValueInput);
            this.Controls.Add(this.pLabel);
            this.Controls.Add(this.decodedLabel);
            this.Controls.Add(this.decodedField);
            this.Controls.Add(this.decodeBtn);
            this.Controls.Add(this.distortionLabel);
            this.Controls.Add(this.receivedVectorField);
            this.Controls.Add(this.receivedVectorLabel);
            this.Controls.Add(this.encodedVectorLabel);
            this.Controls.Add(this.encodedLabel);
            this.Controls.Add(this.encodeBtn);
            this.Controls.Add(this.inputField);
            this.Controls.Add(this.vectorLengthLabel);
            this.Controls.Add(this.label1);
            this.Name = "VectorView";
            this.Size = new System.Drawing.Size(2577, 1607);
            ((System.ComponentModel.ISupportInitialize)(this.pValueInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label vectorLengthLabel;
        private System.Windows.Forms.TextBox inputField;
        private System.Windows.Forms.Button encodeBtn;
        private System.Windows.Forms.Label encodedLabel;
        private System.Windows.Forms.TextBox encodedVectorLabel;
        private System.Windows.Forms.Label receivedVectorLabel;
        private System.Windows.Forms.TextBox receivedVectorField;
        private System.Windows.Forms.Label distortionLabel;
        private System.Windows.Forms.Button decodeBtn;
        private System.Windows.Forms.TextBox decodedField;
        private System.Windows.Forms.Label decodedLabel;
        private System.Windows.Forms.Button sendBtn;
        private System.Windows.Forms.NumericUpDown pValueInput;
        private System.Windows.Forms.Label pLabel;
        private System.Windows.Forms.TextBox distortionPlaceholder;
    }
}
