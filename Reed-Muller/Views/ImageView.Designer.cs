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
            this.encodedPicture = new System.Windows.Forms.PictureBox();
            this.notEncodedPicture = new System.Windows.Forms.PictureBox();
            this.encodedLabel = new System.Windows.Forms.Label();
            this.notEncodedLabel = new System.Windows.Forms.Label();
            this.pPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.uploadedPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.encodedPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.notEncodedPicture)).BeginInit();
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
            this.uploadedPic.Size = new System.Drawing.Size(500, 500);
            this.uploadedPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.uploadedPic.TabIndex = 1;
            this.uploadedPic.TabStop = false;
            // 
            // encodedPicture
            // 
            this.encodedPicture.Location = new System.Drawing.Point(1772, 154);
            this.encodedPicture.Name = "encodedPicture";
            this.encodedPicture.Size = new System.Drawing.Size(500, 500);
            this.encodedPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.encodedPicture.TabIndex = 3;
            this.encodedPicture.TabStop = false;
            this.encodedPicture.Visible = false;
            // 
            // notEncodedPicture
            // 
            this.notEncodedPicture.Location = new System.Drawing.Point(1772, 930);
            this.notEncodedPicture.Name = "notEncodedPicture";
            this.notEncodedPicture.Size = new System.Drawing.Size(500, 500);
            this.notEncodedPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
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
            // pPanel
            // 
            this.pPanel.Location = new System.Drawing.Point(41, 710);
            this.pPanel.Name = "pPanel";
            this.pPanel.Size = new System.Drawing.Size(517, 161);
            this.pPanel.TabIndex = 14;
            // 
            // ImageView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(240F, 240F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.pPanel);
            this.Controls.Add(this.notEncodedLabel);
            this.Controls.Add(this.encodedLabel);
            this.Controls.Add(this.notEncodedPicture);
            this.Controls.Add(this.encodedPicture);
            this.Controls.Add(this.uploadedPic);
            this.Controls.Add(this.uploadBtn);
            this.Name = "ImageView";
            this.Size = new System.Drawing.Size(2577, 1607);
            ((System.ComponentModel.ISupportInitialize)(this.uploadedPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.encodedPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.notEncodedPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button uploadBtn;
        private System.Windows.Forms.PictureBox uploadedPic;
        private System.Windows.Forms.PictureBox encodedPicture;
        private System.Windows.Forms.PictureBox notEncodedPicture;
        private System.Windows.Forms.Label encodedLabel;
        private System.Windows.Forms.Label notEncodedLabel;
        private System.Windows.Forms.Panel pPanel;
    }
}
