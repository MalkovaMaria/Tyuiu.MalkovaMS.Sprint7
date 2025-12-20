namespace Tyuiu.MalkovaMS.Sprint7.Project.V7
{
    partial class FormAbout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAbout));
            labelAbout_MMS = new Label();
            pictureBoxPhoto_MMS = new PictureBox();
            buttonOk_MMS = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPhoto_MMS).BeginInit();
            SuspendLayout();
            // 
            // labelAbout_MMS
            // 
            labelAbout_MMS.AutoSize = true;
            labelAbout_MMS.Location = new Point(161, 7);
            labelAbout_MMS.Margin = new Padding(2, 0, 2, 0);
            labelAbout_MMS.Name = "labelAbout_MMS";
            labelAbout_MMS.Size = new Size(303, 150);
            labelAbout_MMS.TabIndex = 0;
            labelAbout_MMS.Text = resources.GetString("labelAbout_MMS.Text");
            // 
            // pictureBoxPhoto_MMS
            // 
            pictureBoxPhoto_MMS.Image = (Image)resources.GetObject("pictureBoxPhoto_MMS.Image");
            pictureBoxPhoto_MMS.Location = new Point(8, 7);
            pictureBoxPhoto_MMS.Margin = new Padding(2, 2, 2, 2);
            pictureBoxPhoto_MMS.Name = "pictureBoxPhoto_MMS";
            pictureBoxPhoto_MMS.Size = new Size(142, 182);
            pictureBoxPhoto_MMS.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxPhoto_MMS.TabIndex = 1;
            pictureBoxPhoto_MMS.TabStop = false;
            // 
            // buttonOk_MMS
            // 
            buttonOk_MMS.BackgroundImageLayout = ImageLayout.Stretch;
            buttonOk_MMS.FlatStyle = FlatStyle.System;
            buttonOk_MMS.Location = new Point(384, 167);
            buttonOk_MMS.Margin = new Padding(2, 2, 2, 2);
            buttonOk_MMS.Name = "buttonOk_MMS";
            buttonOk_MMS.Size = new Size(97, 22);
            buttonOk_MMS.TabIndex = 2;
            buttonOk_MMS.Text = "OK";
            buttonOk_MMS.UseVisualStyleBackColor = true;
            buttonOk_MMS.Click += buttonOk_MMS_Click;
            // 
            // FormAbout
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(505, 196);
            Controls.Add(buttonOk_MMS);
            Controls.Add(pictureBoxPhoto_MMS);
            Controls.Add(labelAbout_MMS);
            Margin = new Padding(2, 2, 2, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormAbout";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormAbout";
            ((System.ComponentModel.ISupportInitialize)pictureBoxPhoto_MMS).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelAbout_MMS;
        private PictureBox pictureBoxPhoto_MMS;
        private Button buttonOk_MMS;
    }
}