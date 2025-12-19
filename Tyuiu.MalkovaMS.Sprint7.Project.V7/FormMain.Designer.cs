namespace Tyuiu.MalkovaMS.Sprint7.Project.V7
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            tabControlMain_MMS = new TabControl();
            tabPageBase_MMS = new TabPage();
            panelMain_MMS = new Panel();
            dataGridViewTable_MMS = new DataGridView();
            Appartment = new DataGridViewTextBoxColumn();
            Ploshad = new DataGridViewTextBoxColumn();
            Rooms = new DataGridViewTextBoxColumn();
            Familia = new DataGridViewTextBoxColumn();
            Date = new DataGridViewTextBoxColumn();
            People = new DataGridViewTextBoxColumn();
            Kids = new DataGridViewTextBoxColumn();
            Pay = new DataGridViewTextBoxColumn();
            panelTools_MMS = new Panel();
            groupBoxFilter_MMS = new GroupBox();
            buttonFilter_MMS = new Button();
            textBoxFilterKey_MMS = new TextBox();
            labelFilterKey_MMS = new Label();
            textBoxFilterCol_MMS = new TextBox();
            labelFilterCol_MMS = new Label();
            groupBoxFind_MMS = new GroupBox();
            textBoxFindKey_MMS = new TextBox();
            labelFindKey_MMS = new Label();
            groupBoxFile_MMS = new GroupBox();
            buttonAddFile_MMS = new Button();
            buttonSaveFile_MMS = new Button();
            groupBoxChange_MMS = new GroupBox();
            buttonRefresh_MMS = new Button();
            buttonEditRow_MMS = new Button();
            buttonDelRow_MMS = new Button();
            buttonAddRow_MMS = new Button();
            tabPageStat_MMS = new TabPage();
            tabPageChart_MMS = new TabPage();
            tabPagePayInfo_MMS = new TabPage();
            menuStripMain_MMS = new MenuStrip();
            файлToolStripMenuItem_MMS = new ToolStripMenuItem();
            загрузитьДанныеToolStripMenuItem_MMS = new ToolStripMenuItem();
            сохранитьДанныеToolStripMenuItem_MMS = new ToolStripMenuItem();
            выходToolStripMenuItem_MMS = new ToolStripMenuItem();
            справкаToolStripMenuItem_MMS = new ToolStripMenuItem();
            оПрограммеToolStripMenuItem_MMS = new ToolStripMenuItem();
            руководствоПользователяToolStripMenuItem_MMS = new ToolStripMenuItem();
            видToolStripMenuItem_MMS = new ToolStripMenuItem();
            сменитьТемуToolStripMenuItem_MMS = new ToolStripMenuItem();
            toolTipWork_MMS = new ToolTip(components);
            полноэкранныйРежимToolStripMenuItem = new ToolStripMenuItem();
            tabControlMain_MMS.SuspendLayout();
            tabPageBase_MMS.SuspendLayout();
            panelMain_MMS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTable_MMS).BeginInit();
            panelTools_MMS.SuspendLayout();
            groupBoxFilter_MMS.SuspendLayout();
            groupBoxFind_MMS.SuspendLayout();
            groupBoxFile_MMS.SuspendLayout();
            groupBoxChange_MMS.SuspendLayout();
            menuStripMain_MMS.SuspendLayout();
            SuspendLayout();
            // 
            // tabControlMain_MMS
            // 
            tabControlMain_MMS.Controls.Add(tabPageBase_MMS);
            tabControlMain_MMS.Controls.Add(tabPageStat_MMS);
            tabControlMain_MMS.Controls.Add(tabPageChart_MMS);
            tabControlMain_MMS.Controls.Add(tabPagePayInfo_MMS);
            tabControlMain_MMS.Dock = DockStyle.Fill;
            tabControlMain_MMS.Location = new Point(0, 24);
            tabControlMain_MMS.Margin = new Padding(4);
            tabControlMain_MMS.Name = "tabControlMain_MMS";
            tabControlMain_MMS.SelectedIndex = 0;
            tabControlMain_MMS.Size = new Size(1231, 623);
            tabControlMain_MMS.TabIndex = 0;
            // 
            // tabPageBase_MMS
            // 
            tabPageBase_MMS.Controls.Add(panelMain_MMS);
            tabPageBase_MMS.Controls.Add(panelTools_MMS);
            tabPageBase_MMS.Font = new Font("Adobe Fan Heiti Std B", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            tabPageBase_MMS.Location = new Point(4, 29);
            tabPageBase_MMS.Margin = new Padding(4);
            tabPageBase_MMS.Name = "tabPageBase_MMS";
            tabPageBase_MMS.Padding = new Padding(4);
            tabPageBase_MMS.Size = new Size(1223, 590);
            tabPageBase_MMS.TabIndex = 0;
            tabPageBase_MMS.Text = "База данных";
            tabPageBase_MMS.UseVisualStyleBackColor = true;
            // 
            // panelMain_MMS
            // 
            panelMain_MMS.Controls.Add(dataGridViewTable_MMS);
            panelMain_MMS.Dock = DockStyle.Fill;
            panelMain_MMS.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            panelMain_MMS.Location = new Point(4, 110);
            panelMain_MMS.Name = "panelMain_MMS";
            panelMain_MMS.Size = new Size(1215, 476);
            panelMain_MMS.TabIndex = 1;
            // 
            // dataGridViewTable_MMS
            // 
            dataGridViewTable_MMS.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewTable_MMS.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTable_MMS.Columns.AddRange(new DataGridViewColumn[] { Appartment, Ploshad, Rooms, Familia, Date, People, Kids, Pay });
            dataGridViewTable_MMS.Dock = DockStyle.Fill;
            dataGridViewTable_MMS.Location = new Point(0, 0);
            dataGridViewTable_MMS.Name = "dataGridViewTable_MMS";
            dataGridViewTable_MMS.RowHeadersVisible = false;
            dataGridViewTable_MMS.Size = new Size(1215, 476);
            dataGridViewTable_MMS.TabIndex = 0;
            // 
            // Appartment
            // 
            Appartment.FillWeight = 66.0066147F;
            Appartment.HeaderText = "Квартира";
            Appartment.Name = "Appartment";
            // 
            // Ploshad
            // 
            Ploshad.FillWeight = 77.42056F;
            Ploshad.HeaderText = "Общая площадь";
            Ploshad.Name = "Ploshad";
            // 
            // Rooms
            // 
            Rooms.FillWeight = 87.89277F;
            Rooms.HeaderText = "Количество комнат";
            Rooms.Name = "Rooms";
            // 
            // Familia
            // 
            Familia.FillWeight = 97.50092F;
            Familia.HeaderText = "Фамилия";
            Familia.Name = "Familia";
            // 
            // Date
            // 
            Date.FillWeight = 106.316338F;
            Date.HeaderText = "Дата прописки";
            Date.Name = "Date";
            // 
            // People
            // 
            People.FillWeight = 114.40435F;
            People.HeaderText = "Кол-во членов семьи";
            People.Name = "People";
            // 
            // Kids
            // 
            Kids.FillWeight = 121.8251F;
            Kids.HeaderText = "Кол-во детей";
            Kids.Name = "Kids";
            // 
            // Pay
            // 
            Pay.FillWeight = 128.63353F;
            Pay.HeaderText = "Наличие долга";
            Pay.Name = "Pay";
            // 
            // panelTools_MMS
            // 
            panelTools_MMS.Controls.Add(groupBoxFilter_MMS);
            panelTools_MMS.Controls.Add(groupBoxFind_MMS);
            panelTools_MMS.Controls.Add(groupBoxFile_MMS);
            panelTools_MMS.Controls.Add(groupBoxChange_MMS);
            panelTools_MMS.Dock = DockStyle.Top;
            panelTools_MMS.Font = new Font("Adobe Garamond Pro Bold", 11.9999981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            panelTools_MMS.Location = new Point(4, 4);
            panelTools_MMS.Name = "panelTools_MMS";
            panelTools_MMS.Size = new Size(1215, 106);
            panelTools_MMS.TabIndex = 0;
            // 
            // groupBoxFilter_MMS
            // 
            groupBoxFilter_MMS.Controls.Add(buttonFilter_MMS);
            groupBoxFilter_MMS.Controls.Add(textBoxFilterKey_MMS);
            groupBoxFilter_MMS.Controls.Add(labelFilterKey_MMS);
            groupBoxFilter_MMS.Controls.Add(textBoxFilterCol_MMS);
            groupBoxFilter_MMS.Controls.Add(labelFilterCol_MMS);
            groupBoxFilter_MMS.Location = new Point(693, 3);
            groupBoxFilter_MMS.Name = "groupBoxFilter_MMS";
            groupBoxFilter_MMS.Size = new Size(522, 94);
            groupBoxFilter_MMS.TabIndex = 3;
            groupBoxFilter_MMS.TabStop = false;
            groupBoxFilter_MMS.Text = "Фильтрация";
            // 
            // buttonFilter_MMS
            // 
            buttonFilter_MMS.Location = new Point(346, 44);
            buttonFilter_MMS.Name = "buttonFilter_MMS";
            buttonFilter_MMS.Size = new Size(158, 28);
            buttonFilter_MMS.TabIndex = 4;
            buttonFilter_MMS.Text = "Отфильтровать";
            buttonFilter_MMS.UseVisualStyleBackColor = true;
            // 
            // textBoxFilterKey_MMS
            // 
            textBoxFilterKey_MMS.Location = new Point(183, 44);
            textBoxFilterKey_MMS.Name = "textBoxFilterKey_MMS";
            textBoxFilterKey_MMS.Size = new Size(144, 27);
            textBoxFilterKey_MMS.TabIndex = 3;
            // 
            // labelFilterKey_MMS
            // 
            labelFilterKey_MMS.AutoSize = true;
            labelFilterKey_MMS.Font = new Font("Adobe Garamond Pro", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelFilterKey_MMS.Location = new Point(183, 22);
            labelFilterKey_MMS.Name = "labelFilterKey_MMS";
            labelFilterKey_MMS.Size = new Size(146, 20);
            labelFilterKey_MMS.TabIndex = 2;
            labelFilterKey_MMS.Text = "Ключ для фильтра:";
            // 
            // textBoxFilterCol_MMS
            // 
            textBoxFilterCol_MMS.Location = new Point(6, 46);
            textBoxFilterCol_MMS.Name = "textBoxFilterCol_MMS";
            textBoxFilterCol_MMS.Size = new Size(144, 27);
            textBoxFilterCol_MMS.TabIndex = 1;
            // 
            // labelFilterCol_MMS
            // 
            labelFilterCol_MMS.AutoSize = true;
            labelFilterCol_MMS.Font = new Font("Adobe Garamond Pro", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelFilterCol_MMS.Location = new Point(6, 23);
            labelFilterCol_MMS.Name = "labelFilterCol_MMS";
            labelFilterCol_MMS.Size = new Size(144, 20);
            labelFilterCol_MMS.TabIndex = 0;
            labelFilterCol_MMS.Text = "Выберите столбец:";
            // 
            // groupBoxFind_MMS
            // 
            groupBoxFind_MMS.Controls.Add(textBoxFindKey_MMS);
            groupBoxFind_MMS.Controls.Add(labelFindKey_MMS);
            groupBoxFind_MMS.Location = new Point(501, 3);
            groupBoxFind_MMS.Name = "groupBoxFind_MMS";
            groupBoxFind_MMS.Size = new Size(174, 94);
            groupBoxFind_MMS.TabIndex = 2;
            groupBoxFind_MMS.TabStop = false;
            groupBoxFind_MMS.Text = "Поиск";
            // 
            // textBoxFindKey_MMS
            // 
            textBoxFindKey_MMS.Location = new Point(6, 46);
            textBoxFindKey_MMS.Name = "textBoxFindKey_MMS";
            textBoxFindKey_MMS.Size = new Size(158, 27);
            textBoxFindKey_MMS.TabIndex = 1;
            // 
            // labelFindKey_MMS
            // 
            labelFindKey_MMS.AutoSize = true;
            labelFindKey_MMS.Font = new Font("Adobe Garamond Pro", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelFindKey_MMS.Location = new Point(6, 23);
            labelFindKey_MMS.Name = "labelFindKey_MMS";
            labelFindKey_MMS.Size = new Size(134, 20);
            labelFindKey_MMS.TabIndex = 0;
            labelFindKey_MMS.Text = "Ключ для поиска:";
            // 
            // groupBoxFile_MMS
            // 
            groupBoxFile_MMS.Controls.Add(buttonAddFile_MMS);
            groupBoxFile_MMS.Controls.Add(buttonSaveFile_MMS);
            groupBoxFile_MMS.Font = new Font("Adobe Garamond Pro Bold", 11.9999981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBoxFile_MMS.Location = new Point(3, 3);
            groupBoxFile_MMS.Name = "groupBoxFile_MMS";
            groupBoxFile_MMS.Size = new Size(150, 94);
            groupBoxFile_MMS.TabIndex = 1;
            groupBoxFile_MMS.TabStop = false;
            groupBoxFile_MMS.Text = "Файл";
            // 
            // buttonAddFile_MMS
            // 
            buttonAddFile_MMS.BackColor = SystemColors.ButtonFace;
            buttonAddFile_MMS.Image = (Image)resources.GetObject("buttonAddFile_MMS.Image");
            buttonAddFile_MMS.Location = new Point(6, 26);
            buttonAddFile_MMS.Name = "buttonAddFile_MMS";
            buttonAddFile_MMS.Size = new Size(58, 58);
            buttonAddFile_MMS.TabIndex = 1;
            buttonAddFile_MMS.UseVisualStyleBackColor = false;
            // 
            // buttonSaveFile_MMS
            // 
            buttonSaveFile_MMS.Image = (Image)resources.GetObject("buttonSaveFile_MMS.Image");
            buttonSaveFile_MMS.Location = new Point(81, 26);
            buttonSaveFile_MMS.Name = "buttonSaveFile_MMS";
            buttonSaveFile_MMS.Size = new Size(58, 58);
            buttonSaveFile_MMS.TabIndex = 0;
            buttonSaveFile_MMS.UseVisualStyleBackColor = true;
            // 
            // groupBoxChange_MMS
            // 
            groupBoxChange_MMS.Controls.Add(buttonRefresh_MMS);
            groupBoxChange_MMS.Controls.Add(buttonEditRow_MMS);
            groupBoxChange_MMS.Controls.Add(buttonDelRow_MMS);
            groupBoxChange_MMS.Controls.Add(buttonAddRow_MMS);
            groupBoxChange_MMS.Font = new Font("Adobe Garamond Pro Bold", 11.9999981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBoxChange_MMS.Location = new Point(171, 3);
            groupBoxChange_MMS.Name = "groupBoxChange_MMS";
            groupBoxChange_MMS.Size = new Size(312, 94);
            groupBoxChange_MMS.TabIndex = 0;
            groupBoxChange_MMS.TabStop = false;
            groupBoxChange_MMS.Text = "Изменение данных";
            // 
            // buttonRefresh_MMS
            // 
            buttonRefresh_MMS.Image = (Image)resources.GetObject("buttonRefresh_MMS.Image");
            buttonRefresh_MMS.Location = new Point(236, 26);
            buttonRefresh_MMS.Name = "buttonRefresh_MMS";
            buttonRefresh_MMS.Size = new Size(58, 58);
            buttonRefresh_MMS.TabIndex = 1;
            buttonRefresh_MMS.UseVisualStyleBackColor = true;
            // 
            // buttonEditRow_MMS
            // 
            buttonEditRow_MMS.Image = (Image)resources.GetObject("buttonEditRow_MMS.Image");
            buttonEditRow_MMS.Location = new Point(90, 26);
            buttonEditRow_MMS.Name = "buttonEditRow_MMS";
            buttonEditRow_MMS.Size = new Size(58, 58);
            buttonEditRow_MMS.TabIndex = 4;
            buttonEditRow_MMS.UseVisualStyleBackColor = true;
            // 
            // buttonDelRow_MMS
            // 
            buttonDelRow_MMS.Image = Properties.Resources.table_row_delete;
            buttonDelRow_MMS.Location = new Point(163, 26);
            buttonDelRow_MMS.Name = "buttonDelRow_MMS";
            buttonDelRow_MMS.Size = new Size(58, 58);
            buttonDelRow_MMS.TabIndex = 3;
            buttonDelRow_MMS.UseVisualStyleBackColor = true;
            // 
            // buttonAddRow_MMS
            // 
            buttonAddRow_MMS.Image = (Image)resources.GetObject("buttonAddRow_MMS.Image");
            buttonAddRow_MMS.Location = new Point(16, 26);
            buttonAddRow_MMS.Name = "buttonAddRow_MMS";
            buttonAddRow_MMS.Size = new Size(58, 58);
            buttonAddRow_MMS.TabIndex = 2;
            buttonAddRow_MMS.UseVisualStyleBackColor = true;
            // 
            // tabPageStat_MMS
            // 
            tabPageStat_MMS.Location = new Point(4, 24);
            tabPageStat_MMS.Margin = new Padding(4);
            tabPageStat_MMS.Name = "tabPageStat_MMS";
            tabPageStat_MMS.Padding = new Padding(4);
            tabPageStat_MMS.Size = new Size(1223, 595);
            tabPageStat_MMS.TabIndex = 1;
            tabPageStat_MMS.Text = "Статистика";
            tabPageStat_MMS.UseVisualStyleBackColor = true;
            // 
            // tabPageChart_MMS
            // 
            tabPageChart_MMS.Location = new Point(4, 24);
            tabPageChart_MMS.Margin = new Padding(4);
            tabPageChart_MMS.Name = "tabPageChart_MMS";
            tabPageChart_MMS.Padding = new Padding(4);
            tabPageChart_MMS.Size = new Size(1223, 595);
            tabPageChart_MMS.TabIndex = 2;
            tabPageChart_MMS.Text = "Графики";
            tabPageChart_MMS.UseVisualStyleBackColor = true;
            // 
            // tabPagePayInfo_MMS
            // 
            tabPagePayInfo_MMS.Location = new Point(4, 24);
            tabPagePayInfo_MMS.Name = "tabPagePayInfo_MMS";
            tabPagePayInfo_MMS.Size = new Size(1223, 595);
            tabPagePayInfo_MMS.TabIndex = 3;
            tabPagePayInfo_MMS.Text = "Информация о платежах";
            tabPagePayInfo_MMS.UseVisualStyleBackColor = true;
            // 
            // menuStripMain_MMS
            // 
            menuStripMain_MMS.Items.AddRange(new ToolStripItem[] { файлToolStripMenuItem_MMS, справкаToolStripMenuItem_MMS, видToolStripMenuItem_MMS });
            menuStripMain_MMS.Location = new Point(0, 0);
            menuStripMain_MMS.Name = "menuStripMain_MMS";
            menuStripMain_MMS.Size = new Size(1231, 24);
            menuStripMain_MMS.TabIndex = 1;
            // 
            // файлToolStripMenuItem_MMS
            // 
            файлToolStripMenuItem_MMS.DropDownItems.AddRange(new ToolStripItem[] { загрузитьДанныеToolStripMenuItem_MMS, сохранитьДанныеToolStripMenuItem_MMS, выходToolStripMenuItem_MMS });
            файлToolStripMenuItem_MMS.Name = "файлToolStripMenuItem_MMS";
            файлToolStripMenuItem_MMS.Size = new Size(48, 20);
            файлToolStripMenuItem_MMS.Text = "Файл";
            // 
            // загрузитьДанныеToolStripMenuItem_MMS
            // 
            загрузитьДанныеToolStripMenuItem_MMS.Name = "загрузитьДанныеToolStripMenuItem_MMS";
            загрузитьДанныеToolStripMenuItem_MMS.Size = new Size(177, 22);
            загрузитьДанныеToolStripMenuItem_MMS.Text = "Загрузить данные";
            // 
            // сохранитьДанныеToolStripMenuItem_MMS
            // 
            сохранитьДанныеToolStripMenuItem_MMS.Name = "сохранитьДанныеToolStripMenuItem_MMS";
            сохранитьДанныеToolStripMenuItem_MMS.Size = new Size(177, 22);
            сохранитьДанныеToolStripMenuItem_MMS.Text = "Сохранить данные";
            // 
            // выходToolStripMenuItem_MMS
            // 
            выходToolStripMenuItem_MMS.Name = "выходToolStripMenuItem_MMS";
            выходToolStripMenuItem_MMS.Size = new Size(177, 22);
            выходToolStripMenuItem_MMS.Text = "Выход";
            // 
            // справкаToolStripMenuItem_MMS
            // 
            справкаToolStripMenuItem_MMS.DropDownItems.AddRange(new ToolStripItem[] { оПрограммеToolStripMenuItem_MMS, руководствоПользователяToolStripMenuItem_MMS });
            справкаToolStripMenuItem_MMS.Name = "справкаToolStripMenuItem_MMS";
            справкаToolStripMenuItem_MMS.Size = new Size(65, 20);
            справкаToolStripMenuItem_MMS.Text = "Справка";
            // 
            // оПрограммеToolStripMenuItem_MMS
            // 
            оПрограммеToolStripMenuItem_MMS.Name = "оПрограммеToolStripMenuItem_MMS";
            оПрограммеToolStripMenuItem_MMS.Size = new Size(221, 22);
            оПрограммеToolStripMenuItem_MMS.Text = "О программе";
            // 
            // руководствоПользователяToolStripMenuItem_MMS
            // 
            руководствоПользователяToolStripMenuItem_MMS.Name = "руководствоПользователяToolStripMenuItem_MMS";
            руководствоПользователяToolStripMenuItem_MMS.Size = new Size(221, 22);
            руководствоПользователяToolStripMenuItem_MMS.Text = "Руководство пользователя";
            // 
            // видToolStripMenuItem_MMS
            // 
            видToolStripMenuItem_MMS.DropDownItems.AddRange(new ToolStripItem[] { сменитьТемуToolStripMenuItem_MMS, полноэкранныйРежимToolStripMenuItem });
            видToolStripMenuItem_MMS.Name = "видToolStripMenuItem_MMS";
            видToolStripMenuItem_MMS.Size = new Size(39, 20);
            видToolStripMenuItem_MMS.Text = "Вид";
            // 
            // сменитьТемуToolStripMenuItem_MMS
            // 
            сменитьТемуToolStripMenuItem_MMS.Name = "сменитьТемуToolStripMenuItem_MMS";
            сменитьТемуToolStripMenuItem_MMS.Size = new Size(207, 22);
            сменитьТемуToolStripMenuItem_MMS.Text = "Сменить тему";
            // 
            // полноэкранныйРежимToolStripMenuItem
            // 
            полноэкранныйРежимToolStripMenuItem.Name = "полноэкранныйРежимToolStripMenuItem";
            полноэкранныйРежимToolStripMenuItem.Size = new Size(207, 22);
            полноэкранныйРежимToolStripMenuItem.Text = "Полноэкранный режим";
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1231, 647);
            Controls.Add(tabControlMain_MMS);
            Controls.Add(menuStripMain_MMS);
            Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            MainMenuStrip = menuStripMain_MMS;
            MinimumSize = new Size(1247, 686);
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Домоуправление";
            Load += Form1_Load;
            tabControlMain_MMS.ResumeLayout(false);
            tabPageBase_MMS.ResumeLayout(false);
            panelMain_MMS.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewTable_MMS).EndInit();
            panelTools_MMS.ResumeLayout(false);
            groupBoxFilter_MMS.ResumeLayout(false);
            groupBoxFilter_MMS.PerformLayout();
            groupBoxFind_MMS.ResumeLayout(false);
            groupBoxFind_MMS.PerformLayout();
            groupBoxFile_MMS.ResumeLayout(false);
            groupBoxChange_MMS.ResumeLayout(false);
            menuStripMain_MMS.ResumeLayout(false);
            menuStripMain_MMS.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl tabControlMain_MMS;
        private TabPage tabPageBase_MMS;
        private TabPage tabPageStat_MMS;
        private TabPage tabPageChart_MMS;
        private TabPage tabPagePayInfo_MMS;
        private MenuStrip menuStripMain_MMS;
        private ToolStripMenuItem файлToolStripMenuItem_MMS;
        private ToolStripMenuItem загрузитьДанныеToolStripMenuItem_MMS;
        private ToolStripMenuItem сохранитьДанныеToolStripMenuItem_MMS;
        private ToolStripMenuItem выходToolStripMenuItem_MMS;
        private ToolStripMenuItem справкаToolStripMenuItem_MMS;
        private ToolStripMenuItem оПрограммеToolStripMenuItem_MMS;
        private ToolStripMenuItem руководствоПользователяToolStripMenuItem_MMS;
        private ToolStripMenuItem видToolStripMenuItem_MMS;
        private ToolStripMenuItem сменитьТемуToolStripMenuItem_MMS;
        private Panel panelTools_MMS;
        private GroupBox groupBoxChange_MMS;
        private Button buttonRefresh_MMS;
        private Button buttonEditRow_MMS;
        private Button buttonDelRow_MMS;
        private Button buttonAddRow_MMS;
        private Button buttonAddFile_MMS;
        private Button buttonSaveFile_MMS;
        private ToolTip toolTipWork_MMS;
        private GroupBox groupBoxFile_MMS;
        private GroupBox groupBoxFind_MMS;
        private TextBox textBoxFindKey_MMS;
        private Label labelFindKey_MMS;
        private GroupBox groupBoxFilter_MMS;
        private TextBox textBoxFilterKey_MMS;
        private Label labelFilterKey_MMS;
        private TextBox textBoxFilterCol_MMS;
        private Label labelFilterCol_MMS;
        private Button buttonFilter_MMS;
        private Panel panelMain_MMS;
        private DataGridView dataGridViewTable_MMS;
        private DataGridViewTextBoxColumn Appartment;
        private DataGridViewTextBoxColumn Ploshad;
        private DataGridViewTextBoxColumn Rooms;
        private DataGridViewTextBoxColumn Familia;
        private DataGridViewTextBoxColumn Date;
        private DataGridViewTextBoxColumn People;
        private DataGridViewTextBoxColumn Kids;
        private DataGridViewTextBoxColumn Pay;
        private ToolStripMenuItem полноэкранныйРежимToolStripMenuItem;
    }
}
