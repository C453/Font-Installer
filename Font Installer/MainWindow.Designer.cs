﻿namespace Font_Installer
{
    partial class MainWindow
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
            this.ChooseFolderBtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ChooseFolderBtn
            // 
            this.ChooseFolderBtn.Location = new System.Drawing.Point(21, 150);
            this.ChooseFolderBtn.Name = "ChooseFolderBtn";
            this.ChooseFolderBtn.Size = new System.Drawing.Size(128, 23);
            this.ChooseFolderBtn.TabIndex = 0;
            this.ChooseFolderBtn.Text = "Select Font Directory";
            this.ChooseFolderBtn.UseVisualStyleBackColor = true;
            this.ChooseFolderBtn.Click += new System.EventHandler(this.ChooseFolderBtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Font_Installer.Properties.Resources.Linux_penguin_computing;
            this.pictureBox1.Location = new System.Drawing.Point(-2, -8);
            this.pictureBox1.MaximumSize = new System.Drawing.Size(329, 261);
            this.pictureBox1.MinimumSize = new System.Drawing.Size(329, 261);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(329, 261);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 243);
            this.Controls.Add(this.ChooseFolderBtn);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 500);
            this.MinimumSize = new System.Drawing.Size(291, 161);
            this.Name = "MainWindow";
            this.Text = "C453 Font Installer";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ChooseFolderBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

