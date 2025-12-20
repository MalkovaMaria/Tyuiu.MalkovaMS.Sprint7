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

                for (int i = 0; i < rowCount; i++)
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

                if (saveFileDialog_MMS.ShowDialog() != DialogResult.OK)
                    return;

                string path = saveFileDialog_MMS.FileName;

                File.WriteAllText(path, "");

                int rows = dataGridViewTable_MMS.RowCount;
                int columns = dataGridViewTable_MMS.ColumnCount;

                for (int i = 0; i < rows; i++)
                {
                    if (dataGridViewTable_MMS.Rows[i].IsNewRow)
                        continue;

                    string str = "";
                    for (int j = 0; j < columns; j++)
                    {
                        var cellValue = dataGridViewTable_MMS.Rows[i].Cells[j].Value;
                        string cellStr = cellValue?.ToString() ?? "";

                        if (j == columns - 1)
                            str += cellStr;
                        else
                            str += cellStr + ";";
                    }
                    File.AppendAllText(path, str + "\r\n", System.Text.Encoding.UTF8);
                }

                MessageBox.Show("Данные успешно сохранены!", "Успех",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении файла:\n{ex.Message}",
                                "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAddRow_MMS_Click(object sender, EventArgs e)
        {
            try
            {
                int maxApartment = 0;
                foreach (DataGridViewRow row in dataGridViewTable_MMS.Rows)
                {
                    if (row.IsNewRow) continue;

                    if (int.TryParse(row.Cells[0].Value?.ToString(), out int aptNum))
                    {
                        if (aptNum > maxApartment) maxApartment = aptNum;
                    }
                }
                int newApartmentNumber = maxApartment + 1;

                int newRowIndex = dataGridViewTable_MMS.Rows.Add();

                if (dataGridViewTable_MMS.ColumnCount > 0)
                {
                    dataGridViewTable_MMS.Rows[newRowIndex].Cells[0].Value = newApartmentNumber;
                }
                if (newRowIndex >= 0)
                {
                    dataGridViewTable_MMS.FirstDisplayedScrollingRowIndex = newRowIndex;
                    dataGridViewTable_MMS.ClearSelection();
                    dataGridViewTable_MMS.Rows[newRowIndex].Selected = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении новой строки:\n{ex.Message}",
                                "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonEditRow_MMS_Click(object sender, EventArgs e)
        {
            if (dataGridViewTable_MMS.ReadOnly)
            {
                dataGridViewTable_MMS.ReadOnly = false;
                MessageBox.Show(
                    "Режим редактирования включён.\n" +
                    "Кликните по ячейке для изменения данных.",
                    "Редактирование",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            else
            {
                dataGridViewTable_MMS.ReadOnly = true;
                MessageBox.Show(
                    "Режим редактирования выключен.\n" +
                    "Изменения можно сохранить с помощью кнопки «Сохранить файл».",
                    "Редактирование",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        private void buttonDelRow_MMS_Click(object sender, EventArgs e)
        {
            dataGridViewTable_MMS.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            if (dataGridViewTable_MMS.SelectedRows.Count == 0)
            {
                MessageBox.Show("Пожалуйста, выберите строку для удаления.", "Строка не выбрана", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Вы уверены, что хотите удалить выбранные строки?", "Подтвердить удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            try
            {

                List<int> rowsToDelete = new List<int>();
                foreach (DataGridViewRow selectedRow in dataGridViewTable_MMS.SelectedRows)
                    rowsToDelete.Add(selectedRow.Index);

                for (int i = rowsToDelete.Count - 1; i >= 0; i--)
                {
                    dataGridViewTable_MMS.Rows.RemoveAt(rowsToDelete[i]);
                }

                dataGridViewTable_MMS.ClearSelection();
                MessageBox.Show("Строка успешно удалена!", "Успех",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка удаления строки: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonRefresh_MMS_Click(object sender, EventArgs e)
        {
            try
            {
                string[,] rawData = ds.LoadFromFileData(openFilePath);

                dataGridViewTable_MMS.Rows.Clear();

                for (int i = 0; i < rawData.GetLength(0); i++)
                {
                    string[] row = new string[rawData.GetLength(1)];
                    for (int j = 0; j < row.Length; j++)
                    {
                        row[j] = rawData[i, j];
                    }
                    dataGridViewTable_MMS.Rows.Add(row);
                }
                MessageBox.Show("Данные успешно обновлены!", "Успех",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка обновления данных: {ex.Message}", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
