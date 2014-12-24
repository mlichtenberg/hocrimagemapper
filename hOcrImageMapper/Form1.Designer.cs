namespace hOcrImageMapper
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtImageFile = new System.Windows.Forms.TextBox();
            this.txtOcrFile = new System.Windows.Forms.TextBox();
            this.btnSelectImageFile = new System.Windows.Forms.Button();
            this.btnSelectOcrFile = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnZoomIn = new System.Windows.Forms.Button();
            this.btnZoomOut = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.ImageLocation = "";
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(454, 599);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // txtImageFile
            // 
            this.txtImageFile.Enabled = false;
            this.txtImageFile.Location = new System.Drawing.Point(577, 13);
            this.txtImageFile.Name = "txtImageFile";
            this.txtImageFile.Size = new System.Drawing.Size(368, 20);
            this.txtImageFile.TabIndex = 5;
            // 
            // txtOcrFile
            // 
            this.txtOcrFile.Enabled = false;
            this.txtOcrFile.Location = new System.Drawing.Point(101, 13);
            this.txtOcrFile.Name = "txtOcrFile";
            this.txtOcrFile.Size = new System.Drawing.Size(368, 20);
            this.txtOcrFile.TabIndex = 6;
            // 
            // btnSelectImageFile
            // 
            this.btnSelectImageFile.Location = new System.Drawing.Point(490, 12);
            this.btnSelectImageFile.Name = "btnSelectImageFile";
            this.btnSelectImageFile.Size = new System.Drawing.Size(81, 21);
            this.btnSelectImageFile.TabIndex = 2;
            this.btnSelectImageFile.Text = "Select Image";
            this.btnSelectImageFile.UseVisualStyleBackColor = true;
            this.btnSelectImageFile.Click += new System.EventHandler(this.btnSelectImageFile_Click);
            // 
            // btnSelectOcrFile
            // 
            this.btnSelectOcrFile.Location = new System.Drawing.Point(12, 12);
            this.btnSelectOcrFile.Name = "btnSelectOcrFile";
            this.btnSelectOcrFile.Size = new System.Drawing.Size(83, 21);
            this.btnSelectOcrFile.TabIndex = 1;
            this.btnSelectOcrFile.Text = "Select hOCR";
            this.btnSelectOcrFile.UseVisualStyleBackColor = true;
            this.btnSelectOcrFile.Click += new System.EventHandler(this.btnSelectOcrFile_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(14, 44);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(455, 620);
            this.panel1.TabIndex = 14;
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(490, 64);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(455, 600);
            this.panel2.TabIndex = 15;
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.btnZoomIn.Location = new System.Drawing.Point(489, 44);
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Size = new System.Drawing.Size(65, 20);
            this.btnZoomIn.TabIndex = 16;
            this.btnZoomIn.Text = "Zoom In";
            this.btnZoomIn.UseVisualStyleBackColor = true;
            this.btnZoomIn.Visible = false;
            this.btnZoomIn.Click += new System.EventHandler(this.btnZoomIn_Click);
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.btnZoomOut.Location = new System.Drawing.Point(553, 44);
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new System.Drawing.Size(65, 20);
            this.btnZoomOut.TabIndex = 17;
            this.btnZoomOut.Text = "Zoom Out";
            this.btnZoomOut.UseVisualStyleBackColor = true;
            this.btnZoomOut.Visible = false;
            this.btnZoomOut.Click += new System.EventHandler(this.btnZoomOut_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 676);
            this.Controls.Add(this.btnZoomOut);
            this.Controls.Add(this.btnZoomIn);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSelectOcrFile);
            this.Controls.Add(this.btnSelectImageFile);
            this.Controls.Add(this.txtOcrFile);
            this.Controls.Add(this.txtImageFile);
            this.Name = "Form1";
            this.Text = "hOcr Image Mapper";
            this.Resize += new System.EventHandler(this.form_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txtImageFile;
        private System.Windows.Forms.TextBox txtOcrFile;
        private System.Windows.Forms.Button btnSelectImageFile;
        private System.Windows.Forms.Button btnSelectOcrFile;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnZoomIn;
        private System.Windows.Forms.Button btnZoomOut;
    }
}

