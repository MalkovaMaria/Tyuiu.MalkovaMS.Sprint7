using Tyuiu.MalkovaMS.Sprint7.Project.V7.Lib;

namespace Tyuiu.MalkovaMS.Sprint7.Project.V7
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            openFileDialog_MMS.Filter = "Значения, разделённые запятыми(*.csv)|*.csv|Все файлы(*.*)|*.*";
        }

        DataService ds = new DataService();
        static int rows;
        static int columns;
        static string openFilePath;

        private void buttonAddFile_MMS_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog_MMS.ShowDialog();
                openFilePath = openFileDialog_MMS.FileName;

                string[,] rawData = ds.LoadFromFileData(openFilePath);
                dataGridViewTable_MMS.Rows.Clear();

                int rowCount = rawData.GetLength(0);
                int colCount = rawData.GetLength(1);

                if (colCount != dataGridViewTable_MMS.ColumnCount)
                {
                    MessageBox.Show($"Ошибка: файл содержит {colCount} колонок, " +
                                    $"а таблица ожидает {dataGridViewTable_MMS.ColumnCount}.",
                                    "Несоответствие структуры",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                for (int i = 1; i < rowCount; i++)
                {
                    string[] row = new string[colCount];
                    for (int j = 0; j < colCount; j++)
                    {
                        row[j] = rawData[i, j];
                    }
                    dataGridViewTable_MMS.Rows.Add(row);
                }
                MessageBox.Show("Данные успешно загружены!", "Успех",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке файла:\n{ex.Message}",
                                "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSaveFile_MMS_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog_MMS.FileName = "DataBase.csv";
                saveFileDialog_MMS.InitialDirectory = @"C:\DataSprint7\";
                saveFileDialog_MMS.ShowDialog();


                string path = saveFileDialog_MMS.FileName;

                FileInfo fileInfo = new FileInfo(path);
                bool fileExists = fileInfo.Exists;
                if (fileExists)
                {
                    File.Delete(path);
                }
                int rows = dataGridViewTable_MMS.RowCount;
                int columns = dataGridViewTable_MMS.ColumnCount;
                string str = "";

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        if (j != columns - 1)
                        {
                            str = str + dataGridViewTable_MMS.Rows[i].Cells[j].Value + ";";
                        }
                        else
                        {
                            str = str + dataGridViewTable_MMS.Rows[i].Cells[j].Value;
                        }
                    }
                    File.AppendAllText(path, str + Environment.NewLine);
                    str = "";
                    MessageBox.Show("Данные успешно сохранены!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении файла:\n{ex.Message}",
                        "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
