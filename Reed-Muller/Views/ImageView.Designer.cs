namespace Reed_Muller
{
    partial class ImageView
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
            this.uploadBtn = new System.Windows.Forms.Button();
            this.uploadedPic = new System.Windows.Forms.PictureBox();
            this.sendImageBtn = new System.Windows.Forms.Button();
            this.encodedPicture = new System.Windows.Forms.PictureBox();
            this.notEncodedPicture = new System.Windows.Forms.PictureBox();
            this.encodedLabel = new System.Windows.Forms.Label();
            this.notEncodedLabel = new System.Windows.Forms.Label();
            this.pInput = new System.Windows.Forms.NumericUpDown();
            this.pLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.uploadedPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.encodedPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.notEncodedPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pInput)).BeginInit();
            this.SuspendLayout();
            // 
            // uploadBtn
            // 
            this.uploadBtn.Location = new System.Drawing.Point(41, 40);
            this.uploadBtn.Name = "uploadBtn";
            this.uploadBtn.Size = new System.Drawing.Size(231, 83);
            this.uploadBtn.TabIndex = 0;
            this.uploadBtn.Text = "Upload image";
            this.uploadBtn.UseVisualStyleBackColor = true;
            this.uploadBtn.Click += new System.EventHandler(this.UploadBtn_Click);
            // 
            // uploadedPic
            // 
            this.uploadedPic.Location = new System.Drawing.Point(41, 163);
            this.uploadedPic.Name = "uploadedPic";
            this.uploadedPic.Size = new System.Drawing.Size(904, 509);
            this.uploadedPic.TabIndex = 1;
            this.uploadedPic.TabStop = false;
            // 
            // sendImageBtn
            // 
            this.sendImageBtn.Location = new System.Drawing.Point(47, 828);
            this.sendImageBtn.Name = "sendImageBtn";
            this.sendImageBtn.Size = new System.Drawing.Size(225, 83);
            this.sendImageBtn.TabIndex = 2;
            this.sendImageBtn.Text = "Send Image";
            this.sendImageBtn.UseVisualStyleBackColor = true;
            this.sendImageBtn.Visible = false;
            this.sendImageBtn.Click += new System.EventHandler(this.SendImageBtn_Click);
            // 
            // encodedPicture
            // 
            this.encodedPicture.Location = new System.Drawing.Point(1528, 163);
            this.encodedPicture.Name = "encodedPicture";
            this.encodedPicture.Size = new System.Drawing.Size(915, 509);
            this.encodedPicture.TabIndex = 3;
            this.encodedPicture.TabStop = false;
            this.encodedPicture.Visible = false;
            // 
            // notEncodedPicture
            // 
            this.notEncodedPicture.Location = new System.Drawing.Point(1528, 927);
            this.notEncodedPicture.Name = "notEncodedPicture";
            this.notEncodedPicture.Size = new System.Drawing.Size(915, 509);
            this.notEncodedPicture.TabIndex = 4;
            this.notEncodedPicture.TabStop = false;
            this.notEncodedPicture.Visible = false;
            // 
            // encodedLabel
            // 
            this.encodedLabel.AutoSize = true;
            this.encodedLabel.Location = new System.Drawing.Point(1899, 101);
            this.encodedLabel.Name = "encodedLabel";
            this.encodedLabel.Size = new System.Drawing.Size(271, 32);
            this.encodedLabel.TabIndex = 5;
            this.encodedLabel.Text = "Image sent encoded";
            this.encodedLabel.Visible = false;
            // 
            // notEncodedLabel
            // 
            this.notEncodedLabel.AutoSize = true;
            this.notEncodedLabel.Location = new System.Drawing.Point(1844, 854);
            this.notEncodedLabel.Name = "notEncodedLabel";
            this.notEncodedLabel.Size = new System.Drawing.Size(376, 32);
            this.notEncodedLabel.TabIndex = 6;
            this.notEncodedLabel.Text = "Image sent without encoding";
            this.notEncodedLabel.Visible = false;
            // 
            // pInput
            // 
            this.pInput.Location = new System.Drawing.Point(47, 760);
            this.pInput.Name = "pInput";
            this.pInput.Size = new System.Drawing.Size(266, 38);
            this.pInput.TabIndex = 13;
            this.pInput.Visible = false;
            // 
            // pLabel
            // 
            this.pLabel.AutoSize = true;
            this.pLabel.Location = new System.Drawing.Point(40, 709);
            this.pLabel.Name = "pLabel";
            this.pLabel.Size = new System.Drawing.Size(272, 32);
            this.pLabel.TabIndex = 12;
            this.pLabel.Text = "Provide p (0<=p<=1)";
            this.pLabel.Visible = false;
            // 
            // ImageView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(240F, 240F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.pInput);
            this.Controls.Add(this.pLabel);
            this.Controls.Add(this.notEncodedLabel);
            this.Controls.Add(this.encodedLabel);
            this.Controls.Add(this.notEncodedPicture);
            this.Controls.Add(this.encodedPicture);
            this.Controls.Add(this.sendImageBtn);
            this.Controls.Add(this.uploadedPic);
            this.Controls.Add(this.uploadBtn);
            this.Name = "ImageView";
            this.Size = new System.Drawing.Size(2577, 1607);
            ((System.ComponentModel.ISupportInitialize)(this.uploadedPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.encodedPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.notEncodedPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button uploadBtn;
        private System.Windows.Forms.PictureBox uploadedPic;
        private System.Windows.Forms.Button sendImageBtn;
        private System.Windows.Forms.PictureBox encodedPicture;
        private System.Windows.Forms.PictureBox notEncodedPicture;
        private System.Windows.Forms.Label encodedLabel;
        private System.Windows.Forms.Label notEncodedLabel;
        private System.Windows.Forms.NumericUpDown pInput;
        private System.Windows.Forms.Label pLabel;
    }
}
