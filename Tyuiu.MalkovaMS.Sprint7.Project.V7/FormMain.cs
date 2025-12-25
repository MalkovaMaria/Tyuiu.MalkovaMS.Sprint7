using System.Windows.Forms;
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
                UpdateStatistics();
                UpdateCharts();

                buttonSaveFile_MMS.Enabled = true;
                buttonAddRow_MMS.Enabled = true;
                buttonDelRow_MMS.Enabled = true;
                buttonEditRow_MMS.Enabled = true;
                buttonRefresh_MMS.Enabled = true;
                buttonFilter_MMS.Enabled = true;
                buttonClearFilter_MMS.Enabled = true;
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
                UpdateStatistics();
                UpdateCharts();
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
            UpdateStatistics();
            UpdateCharts();
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

                UpdateStatistics();
                UpdateCharts();
                dataGridViewTable_MMS.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
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
                UpdateStatistics();
                UpdateCharts();
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
                UpdateStatistics();
                UpdateCharts();

                buttonSaveFilePay_MMS.Enabled = true;
                buttonAddRowPay_MMS.Enabled = true;
                buttonDelRowPay_MMS.Enabled = true;
                buttonEditRowPay_MMS.Enabled = true;
                buttonRefreshPay_MMS.Enabled = true;
                buttonFilterPay_MMS.Enabled = true;
                buttonClearFilterPay_MMS.Enabled = true;
                buttonMarkPaid_MMS.Enabled = true;
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
                UpdateStatistics();
                UpdateCharts();
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
            UpdateStatistics();
            UpdateCharts();
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
                UpdateStatistics();
                UpdateCharts();
                dataGridViewPayStat_MMS.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
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
                UpdateStatistics();
                UpdateCharts();
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
            UpdateStatistics();
            UpdateCharts();
        }

        private void UpdateStatistics()
        {
            if (dataGridViewTable_MMS.Rows.Count == 0)
            {
                labelAllKv_MMS.Text = "Всего квартир: 0";
                labelAllPeople_MMS.Text = "Всего жильцов: 0";
                labelSrPloshad_MMS.Text = "Средняя площадь квартиры: 0 м";
                labelMinPloshad_MMS.Text = "Минимальная площадь квартиры: 0 м";
                labelMaksPloshad_MMS.Text = "Максимальная площадь квартиры: 0 м";
                return;
            }

            int totalApartments = dataGridViewTable_MMS.Rows.Count;
            int totalPeople = 0;
            double sumArea = 0;
            double minArea = double.MaxValue;
            double maxArea = double.MinValue;
            int validAreaCount = 0;

            foreach (DataGridViewRow row in dataGridViewTable_MMS.Rows)
            {
                if (row.IsNewRow) continue;
                if (int.TryParse(row.Cells[5].Value?.ToString(), out int people))
                    totalPeople += people;
                string areaStr = row.Cells[1].Value?.ToString();
                if (!string.IsNullOrEmpty(areaStr) &&
                    double.TryParse(areaStr, System.Globalization.NumberStyles.Float,
                                   System.Globalization.CultureInfo.InvariantCulture,
                                   out double area))
                {
                    sumArea += area;
                    if (area < minArea) minArea = area;
                    if (area > maxArea) maxArea = area;
                    validAreaCount++;
                }
            }

            double avgArea = validAreaCount > 0 ? sumArea / validAreaCount : 0;

            labelAllKv_MMS.Text = $"Всего квартир: {totalApartments}";
            labelAllPeople_MMS.Text = $"Всего жильцов: {totalPeople}";
            labelSrPloshad_MMS.Text = $"Средняя площадь квартиры (кв. м.): {avgArea:F1}";
            labelMinPloshad_MMS.Text = $"Минимальная площадь квартиры (кв. м.): {(minArea == double.MaxValue ? 0 : minArea):F1}";
            labelMaksPloshad_MMS.Text = $"Максимальная площадь квартиры (кв. м.): {(maxArea == double.MinValue ? 0 : maxArea):F1}";
        }
        private void UpdateCharts()
        {
            UpdateKidsChart();
            UpdateApartmentTypesChart();
            DrawBarChart();
        }

        private void UpdateKidsChart()
        {
            chartKidsStat_MMS.Series.Clear();
            chartKidsStat_MMS.Titles.Clear();
            var series = new System.Windows.Forms.DataVisualization.Charting.Series
            {
                Name = "Дети",
                ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie
            };
            chartKidsStat_MMS.Series.Add(series);
            var kidsCount = new Dictionary<int, int>();

            foreach (DataGridViewRow row in dataGridViewTable_MMS.Rows)
            {
                if (row.IsNewRow) continue;

                if (int.TryParse(row.Cells[6].Value?.ToString(), out int kids))
                {
                    if (kids < 0) kids = 0;
                    if (!kidsCount.ContainsKey(kids))
                        kidsCount[kids] = 0;
                    kidsCount[kids]++;
                }
            }
            if (kidsCount.TryGetValue(0, out int noKids))
            {
                series.Points.AddXY("Нет детей", noKids);
            }
            var sortedKeys = kidsCount.Keys.Where(k => k > 0).OrderBy(k => k);
            foreach (int count in sortedKeys)
            {
                string label = count switch
                {
                    1 => "1 ребёнок",
                    2 => "2 ребенка",
                    3 => "3 ребенка",
                    4 => "4 ребенка",
                    5 => "5 детей",
                    _ => $"{count} детей"
                };
                series.Points.AddXY(label, kidsCount[count]);
            }
        }

        private void UpdateApartmentTypesChart()
        {
            chartTypesStat_MMS.Series.Clear();
            chartTypesStat_MMS.Titles.Clear();
            var series = new System.Windows.Forms.DataVisualization.Charting.Series
            {
                Name = "Типы квартир",
                ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie
            };
            chartTypesStat_MMS.Series.Add(series);

            var counts = new Dictionary<string, int>
            {
                { "1-комнатные", 0 },
                { "2-комнатные", 0 },
                { "3-комнатные", 0 },
                { "4-комнатные", 0 }
            };

            foreach (DataGridViewRow row in dataGridViewTable_MMS.Rows)
            {
                if (row.IsNewRow) continue;

                if (int.TryParse(row.Cells[2].Value?.ToString(), out int rooms))
                {
                    if (rooms >= 1 && rooms <= 4)
                    {
                        string key = $"{rooms}-комнатные";
                        counts[key]++;
                    }
                }
            }

            foreach (var kvp in counts)
            {
                if (kvp.Value > 0)
                    series.Points.AddXY(kvp.Key, kvp.Value);
            }

            chartTypesStat_MMS.Titles.Clear();
        }

        private void DrawBarChart()
        {
            panelBars_MMS.Invalidate();
        }

        private void panelBars_MMS_Paint(object sender, PaintEventArgs e)
        {
            var panel = panelBars_MMS;
            var graphics = e.Graphics;
            graphics.Clear(Color.White);
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            var payments = new List<(string apt, double amount, string status)>();
            foreach (DataGridViewRow row in dataGridViewPayStat_MMS.Rows)
            {
                if (row.IsNewRow) continue;

                string apt = row.Cells[0].Value?.ToString() ?? "";
                string amt = row.Cells[2].Value?.ToString() ?? "0";
                string status = row.Cells[3].Value?.ToString() ?? "";

                if (double.TryParse(amt,
                    System.Globalization.NumberStyles.Float,
                    System.Globalization.CultureInfo.InvariantCulture,
                    out double amount))
                {
                    if (status == "Долг")
                        amount = 0;

                    payments.Add((apt, amount, status));
                }
            }

            if (payments.Count == 0) return;

            double maxAmount = payments.Where(p => p.status == "Оплачено").Max(p => p.amount);
            if (maxAmount <= 0) maxAmount = 1;

            int margin = 40;
            int width = panel.ClientSize.Width - 2 * margin;
            int height = panel.ClientSize.Height - 2 * margin;

            int barWidth = Math.Max(6, width / payments.Count);
            int barSpacing = Math.Max(1, (width - payments.Count * barWidth) / Math.Max(1, payments.Count));

            for (int i = 0; i < payments.Count; i++)
            {
                double barHeight = (payments[i].amount / maxAmount) * (height - 40);
                int x = margin + i * (barWidth + barSpacing);
                int y = margin + height - (int)barHeight;
                Color barColor = payments[i].status == "Оплачено"
                    ? Color.FromArgb(100, 34, 139, 34)
                    : Color.FromArgb(100, 220, 20, 60);

                using (var brush = new SolidBrush(barColor))
                {
                    graphics.FillRectangle(brush, x, y, barWidth, (int)barHeight);
                }
                using (var font = new Font("Segoe UI", 8))
                using (var brush = new SolidBrush(Color.Black))
                {
                    var textSize = graphics.MeasureString(payments[i].apt, font);
                    graphics.DrawString(payments[i].apt, font, brush,
                        x + (barWidth - textSize.Width) / 2,
                        margin + height + 5);
                }
                if (payments[i].status == "Оплачено")
                {
                    string amountText = payments[i].amount.ToString("F0");
                    using (var amountFont = new Font("Segoe UI", 8, FontStyle.Bold))
                    using (var amountBrush = new SolidBrush(Color.DarkGreen))
                    {
                        var amountSize = graphics.MeasureString(amountText, amountFont);
                        graphics.DrawString(amountText, amountFont, amountBrush,
                            x + (barWidth - amountSize.Width) / 2,
                            y - 20);
                    }
                }
            }
            using (var font = new Font("Segoe UI", 9, FontStyle.Bold))
            using (var brush = new SolidBrush(Color.Black))
            {
                string yLabel = "Сумма оплаты, руб.";
                var ySize = graphics.MeasureString(yLabel, font);
                graphics.TranslateTransform(0, margin + height / 2 + ySize.Width / 2);
                graphics.RotateTransform(-90);
                graphics.DrawString(yLabel, font, brush, 0, 0);
                graphics.ResetTransform();
                string xLabel = "Номер квартиры";
                var xSize = graphics.MeasureString(xLabel, font);
                graphics.DrawString(xLabel, font, brush,
                    panel.ClientSize.Width / 2 - xSize.Width / 2,
                    panel.ClientSize.Height - 20);
            }
        }

        private void оПрограммеToolStripMenuItem_MMS_Click(object sender, EventArgs e)
        {
            FormAbout formAbout = new FormAbout();
            formAbout.ShowDialog();
        }

        private void руководствоПользователяToolStripMenuItem_MMS_Click(object sender, EventArgs e)
        {
            FormInfo formInfo = new FormInfo();
            formInfo.ShowDialog();
        }

        private void выходToolStripMenuItem_MMS_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите закрыть программу?", "Подтвердите выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }
            this.Close();
        }

        private bool isFullScreen = false;
        private void полноэкранныйРежимToolStripMenuItem_MMS_Click(object sender, EventArgs e)
        {
            if (!isFullScreen)
            {
                this.WindowState = FormWindowState.Normal; 
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                this.TopMost = true;

                isFullScreen = true;
                полноэкранныйРежимToolStripMenuItem_MMS.Text = "Выход из полноэкранного режима";
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.WindowState = FormWindowState.Normal;
                this.TopMost = false;


                isFullScreen = false;
                полноэкранныйРежимToolStripMenuItem_MMS.Text = "Полноэкранный режим";
            }
        }
    }
}
