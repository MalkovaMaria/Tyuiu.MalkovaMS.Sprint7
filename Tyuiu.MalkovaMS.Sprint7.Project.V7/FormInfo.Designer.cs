namespace Tyuiu.MalkovaMS.Sprint7.Project.V7
{
    partial class FormInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInfo));
            labelInformation_MMS = new Label();
            buttonOk_MMS = new Button();
            SuspendLayout();
            // 
            // labelInformation_MMS
            // 
            labelInformation_MMS.AutoSize = true;
            labelInformation_MMS.Font = new Font("Segoe UI Symbol", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelInformation_MMS.Location = new Point(13, 26);
            labelInformation_MMS.Margin = new Padding(4, 0, 4, 0);
            labelInformation_MMS.Name = "labelInformation_MMS";
            labelInformation_MMS.Size = new Size(1102, 390);
            labelInformation_MMS.TabIndex = 0;
            labelInformation_MMS.Text = resources.GetString("labelInformation_MMS.Text");
            // 
            // buttonOk_MMS
            // 
            buttonOk_MMS.BackgroundImageLayout = ImageLayout.Stretch;
            buttonOk_MMS.FlatStyle = FlatStyle.System;
            buttonOk_MMS.Location = new Point(976, 434);
            buttonOk_MMS.Name = "buttonOk_MMS";
            buttonOk_MMS.Size = new Size(139, 37);
            buttonOk_MMS.TabIndex = 3;
            buttonOk_MMS.Text = "OK";
            buttonOk_MMS.UseVisualStyleBackColor = true;
            buttonOk_MMS.Click += buttonOk_MMS_Click;
            // 
            // FormInfo
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1129, 497);
            Controls.Add(buttonOk_MMS);
            Controls.Add(labelInformation_MMS);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormInfo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Руководство пользователя";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelInformation_MMS;
        private Button buttonOk_MMS;
    }
}