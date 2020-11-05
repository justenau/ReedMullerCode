namespace Reed_Muller
{
    partial class MainView
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
            this.vectorBtn = new System.Windows.Forms.Button();
            this.textBtn = new System.Windows.Forms.Button();
            this.imageBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // vectorBtn
            // 
            this.vectorBtn.Location = new System.Drawing.Point(89, 53);
            this.vectorBtn.Name = "vectorBtn";
            this.vectorBtn.Size = new System.Drawing.Size(769, 65);
            this.vectorBtn.TabIndex = 0;
            this.vectorBtn.Text = "Vector";
            this.vectorBtn.UseVisualStyleBackColor = true;
            this.vectorBtn.Click += new System.EventHandler(this.vectorBtn_Click);
            // 
            // textBtn
            // 
            this.textBtn.Location = new System.Drawing.Point(1001, 53);
            this.textBtn.Name = "textBtn";
            this.textBtn.Size = new System.Drawing.Size(769, 65);
            this.textBtn.TabIndex = 1;
            this.textBtn.Text = "Text";
            this.textBtn.UseVisualStyleBackColor = true;
            this.textBtn.Click += new System.EventHandler(this.textBtn_Click);
            // 
            // imageBtn
            // 
            this.imageBtn.Location = new System.Drawing.Point(1897, 55);
            this.imageBtn.Name = "imageBtn";
            this.imageBtn.Size = new System.Drawing.Size(769, 63);
            this.imageBtn.TabIndex = 2;
            this.imageBtn.Text = "Image";
            this.imageBtn.UseVisualStyleBackColor = true;
            this.imageBtn.Click += new System.EventHandler(this.imageBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1235, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(269, 32);
            this.label1.TabIndex = 3;
            this.label1.Text = "Choose input option";
            // 
            // panel
            // 
            this.panel.AutoSize = true;
            this.panel.Location = new System.Drawing.Point(89, 139);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(2577, 1607);
            this.panel.TabIndex = 4;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(240F, 240F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(2719, 1792);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.imageBtn);
            this.Controls.Add(this.textBtn);
            this.Controls.Add(this.vectorBtn);
            this.Name = "MainView";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "TabbedWindow";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainView_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button vectorBtn;
        private System.Windows.Forms.Button textBtn;
        private System.Windows.Forms.Button imageBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel;
    }
}