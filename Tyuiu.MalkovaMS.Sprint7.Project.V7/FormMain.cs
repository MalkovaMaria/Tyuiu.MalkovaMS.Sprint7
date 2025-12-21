using Tyuiu.MalkovaMS.Sprint7.Project.V7.Lib;

namespace Tyuiu.MalkovaMS.Sprint7.Project.V7
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            openFileDialog_MMS.Filter = "Значения, разделённые запятыми(*.csv)|*.csv|Все файлы(*.*)|*.*";
            openFileDialogPay_MMS.Filter = "Значения, разделённые запятыми(*.csv)|*.csv|Все файлы(*.*)|*.*";
        }
        private List<string[]> _originalRows = null;
        private List<string[]> _fullPaymentData = null;

        DataService ds = new DataService();

        static int rows;
        static int columns;
        static string openFilePath;
        static string openFilePathPay;

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

        private void textBoxFindKey_MMS_TextChanged(object sender, EventArgs e)
        {
            string currentText = textBoxFindKey_MMS.Text;
            foreach (DataGridViewRow row in dataGridViewTable_MMS.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null && !string.IsNullOrEmpty(currentText) && cell.Value.ToString().ToUpper().Contains(currentText.ToUpper()))
                    {
                        cell.Style.BackColor = Color.LightGreen;
                    }
                    else
                    {
                        cell.Style.BackColor = Color.White;
                    }
                }
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            comboBoxColumn_MMS.Items.Clear();
            foreach (DataGridViewColumn column in dataGridViewTable_MMS.Columns)
            {
                comboBoxColumn_MMS.Items.Add(column.HeaderText);
            }

            comboBoxColumn_MMS.SelectedIndex = -1;

            comboBoxStatusPay_MMS.Items.Clear();
            comboBoxStatusPay_MMS.Items.Add("Оплачено");
            comboBoxStatusPay_MMS.Items.Add("Долг");
            comboBoxStatusPay_MMS.SelectedIndex = -1;
        }

        private void buttonFilter_MMS_Click(object sender, EventArgs e)
        {
            string search = textBoxFilterKey_MMS.Text.Trim();
            string colName = comboBoxColumn_MMS.SelectedItem.ToString();

            int colIndex = -1;
            for (int i = 0; i < dataGridViewTable_MMS.Columns.Count; i++)
            {
                if (dataGridViewTable_MMS.Columns[i].HeaderText == colName)
                {
                    colIndex = i;
                    break;
                }
            }

            if (colIndex == -1) return;

            _originalRows = new List<string[]>();
            foreach (DataGridViewRow row in dataGridViewTable_MMS.Rows)
            {
                if (row.IsNewRow) continue;
                var r = new string[dataGridViewTable_MMS.ColumnCount];
                for (int j = 0; j < r.Length; j++)
                    r[j] = row.Cells[j].Value?.ToString() ?? "";
                _originalRows.Add(r);
            }

            dataGridViewTable_MMS.Rows.Clear();
            foreach (var row in _originalRows)
            {
                if (row[colIndex].IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0)
                    dataGridViewTable_MMS.Rows.Add(row);
            }
        }
        private void comboBoxColumn_MMS_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void textBoxFilterKey_MMS_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonClearFilter_MMS_Click(object sender, EventArgs e)
        {
            if (_originalRows != null)
            {
                dataGridViewTable_MMS.Rows.Clear();
                foreach (var row in _originalRows)
                    dataGridViewTable_MMS.Rows.Add(row);
            }
            textBoxFilterKey_MMS.Clear();
        }

        private void buttonAddFilePay_MMS_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialogPay_MMS.ShowDialog();
                openFilePathPay = openFileDialogPay_MMS.FileName;

                string[,] rawDataPay = ds.LoadFromFileData(openFilePathPay);
                dataGridViewPayStat_MMS.Rows.Clear();

                int rowCountPay = rawDataPay.GetLength(0);
                int colCountPay = rawDataPay.GetLength(1);

                if (colCountPay != dataGridViewPayStat_MMS.ColumnCount)
                {
                    MessageBox.Show($"Ошибка: файл содержит {colCountPay} колонок, " +
                                    $"а таблица ожидает {dataGridViewPayStat_MMS.ColumnCount}.",
                                    "Несоответствие структуры",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                for (int i = 0; i < rowCountPay; i++)
                {
                    string[] row = new string[colCountPay];
                    for (int j = 0; j < colCountPay; j++)
                    {
                        row[j] = rawDataPay[i, j];
                    }
                    dataGridViewPayStat_MMS.Rows.Add(row);
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

        private void buttonSaveFilePay_MMS_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialogPay_MMS.FileName = "DataPay.csv";
                saveFileDialogPay_MMS.InitialDirectory = @"C:\DataSprint7\";

                if (saveFileDialogPay_MMS.ShowDialog() != DialogResult.OK)
                    return;

                string path = saveFileDialogPay_MMS.FileName;

                File.WriteAllText(path, "");

                int rows = dataGridViewPayStat_MMS.RowCount;
                int columns = dataGridViewPayStat_MMS.ColumnCount;

                for (int i = 0; i < rows; i++)
                {
                    if (dataGridViewPayStat_MMS.Rows[i].IsNewRow)
                        continue;

                    string str = "";
                    for (int j = 0; j < columns; j++)
                    {
                        var cellValue = dataGridViewPayStat_MMS.Rows[i].Cells[j].Value;
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

        private void buttonAddRowPay_MMS_Click(object sender, EventArgs e)
        {
            try
            {
                int newRowIndex = dataGridViewPayStat_MMS.Rows.Add();

                if (newRowIndex >= 0)
                {
                    dataGridViewPayStat_MMS.FirstDisplayedScrollingRowIndex = newRowIndex;
                    dataGridViewPayStat_MMS.ClearSelection();
                    dataGridViewPayStat_MMS.Rows[newRowIndex].Selected = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении новой строки:\n{ex.Message}",
                                "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonEditRowPay_MMS_Click(object sender, EventArgs e)
        {
            if (dataGridViewPayStat_MMS.ReadOnly)
            {
                dataGridViewPayStat_MMS.ReadOnly = false;
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
                dataGridViewPayStat_MMS.ReadOnly = true;
                MessageBox.Show(
                    "Режим редактирования выключен.\n" +
                    "Изменения можно сохранить с помощью кнопки «Сохранить файл».",
                    "Редактирование",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        private void buttonDelRowPay_MMS_Click(object sender, EventArgs e)
        {
            dataGridViewPayStat_MMS.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            if (dataGridViewPayStat_MMS.SelectedRows.Count == 0)
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
                foreach (DataGridViewRow selectedRow in dataGridViewPayStat_MMS.SelectedRows)
                    rowsToDelete.Add(selectedRow.Index);

                for (int i = rowsToDelete.Count - 1; i >= 0; i--)
                {
                    dataGridViewPayStat_MMS.Rows.RemoveAt(rowsToDelete[i]);
                }

                dataGridViewPayStat_MMS.ClearSelection();
                MessageBox.Show("Строка успешно удалена!", "Успех",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка удаления строки: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonRefreshPay_MMS_Click(object sender, EventArgs e)
        {
            try
            {
                string[,] rawDataPay = ds.LoadFromFileData(openFilePathPay);

                dataGridViewPayStat_MMS.Rows.Clear();

                for (int i = 0; i < rawDataPay.GetLength(0); i++)
                {
                    string[] row = new string[rawDataPay.GetLength(1)];
                    for (int j = 0; j < row.Length; j++)
                    {
                        row[j] = rawDataPay[i, j];
                    }
                    dataGridViewPayStat_MMS.Rows.Add(row);
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

        private void buttonFilterPay_MMS_Click(object sender, EventArgs e)
        {
            if (comboBoxStatusPay_MMS.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите статус для фильтрации.", "Информация",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string statusToFilter = comboBoxStatusPay_MMS.SelectedItem.ToString();
            int statusColumnIndex = -1;

            for (int i = 0; i < dataGridViewPayStat_MMS.Columns.Count; i++)
            {
                if (dataGridViewPayStat_MMS.Columns[i].HeaderText == "Статус оплаты")
                {
                    statusColumnIndex = i;
                    break;
                }
            }

            if (statusColumnIndex == -1)
            {
                MessageBox.Show("Колонка 'Статус оплаты' не найдена.", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_fullPaymentData == null)
            {
                _fullPaymentData = new List<string[]>();
                foreach (DataGridViewRow row in dataGridViewPayStat_MMS.Rows)
                {
                    if (row.IsNewRow) continue;
                    var r = new string[dataGridViewPayStat_MMS.ColumnCount];
                    for (int j = 0; j < r.Length; j++)
                    {
                        r[j] = row.Cells[j].Value?.ToString() ?? "";
                    }
                    _fullPaymentData.Add(r);
                }
            }
            var filtered = _fullPaymentData
                .Where(row => row[statusColumnIndex] == statusToFilter)
                .ToList();
            dataGridViewPayStat_MMS.Rows.Clear();
            foreach (var row in filtered)
            {
                dataGridViewPayStat_MMS.Rows.Add(row);
            }
        }

        private void buttonClearFilterPay_MMS_Click(object sender, EventArgs e)
        {
            if (_fullPaymentData != null)
            {
                dataGridViewPayStat_MMS.Rows.Clear();
                foreach (var row in _fullPaymentData)
                {
                    dataGridViewPayStat_MMS.Rows.Add(row);
                }
                _fullPaymentData = null;
            }
            comboBoxStatusPay_MMS.SelectedIndex = -1;
        }

        private void buttonMarkPaid_MMS_Click(object sender, EventArgs e)
        {
            if (dataGridViewPayStat_MMS.CurrentRow == null)
            {
                MessageBox.Show("Выберите платёж для отметки.");
                return;
            }

            var row = dataGridViewPayStat_MMS.CurrentRow;
            if (row.Cells[3].Value?.ToString() == "Долг")
            {
                row.Cells[3].Value = "Оплачено";
                MessageBox.Show("Платёж отмечен как оплаченный.");
            }
            else
            {
                MessageBox.Show("Только долг можно отметить как оплаченный.");
            }
        }
    }
}
