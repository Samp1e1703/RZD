using Npgsql;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace RZD
{
    public partial class TicketListForm : Form
    {
        public TicketListForm()
        {
            InitializeComponent();
            LoadTickets();
        }

        private void LoadTickets()
        {
            using (NpgsqlConnection conn = new NpgsqlConnection("Host=localhost;Port=1703;Username=postgres;Password=GHgh1703;Database=postgres"))
            {
                try
                {
                    conn.Open();
                    string sql = "SELECT * FROM tickets"; // Замените "tickets" на имя вашей таблицы с билетами
                    NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                    NpgsqlDataReader reader = command.ExecuteReader();

                    // Очистка ComboBox перед добавлением новых элементов
                    comboBoxTickets.Items.Clear();

                    // Добавление билетов в ComboBox
                    while (reader.Read())
                    {
                        string ticketInfo = $"id: {reader["id"]}, Пассажир: {reader["passengername"]}, Поезд: {reader["trainname"]}, Номер поезда: {reader["trainnumber"]}, Время отправления: {reader["departuretime"]}, Цена: {reader["price"]}";
                        comboBoxTickets.Items.Add(ticketInfo);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка загрузки списка билетов: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        private void LoadTickets(string passengerName, string trainName, string trainNumber)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection("Host=localhost;Port=1703;Username=postgres;Password=GHgh1703;Database=postgres"))
            {
                try
                {
                    conn.Open();
                    string sql = "SELECT * FROM tickets WHERE passengername LIKE @passengerName AND trainname LIKE @trainName AND trainnumber LIKE @trainNumber";
                    NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                    command.Parameters.AddWithValue("@passengerName", "%" + passengerName + "%");
                    command.Parameters.AddWithValue("@trainName", "%" + trainName + "%");
                    command.Parameters.AddWithValue("@trainNumber", "%" + trainNumber + "%");
                    NpgsqlDataReader reader = command.ExecuteReader();

                    // Очистка ComboBox перед добавлением новых элементов
                    comboBoxTickets.Items.Clear();

                    // Добавление билетов в ComboBox
                    while (reader.Read())
                    {
                        string ticketInfo = $"id: {reader["id"]}, Пассажир: {reader["passengername"]}, Поезд: {reader["trainname"]}, Номер поезда: {reader["trainnumber"]}, Время отправления: {reader["departuretime"]}, Цена: {reader["price"]}";
                        comboBoxTickets.Items.Add(ticketInfo);
                        comboBoxTickets.SelectedIndex = 0;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка загрузки списка билетов: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Закрытие формы без добавления поезда
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void InitializeSearchButton()
        {
            Button searchButton = new Button();
            searchButton.Text = "Поиск";
            searchButton.Location = new Point(150, 100); // Установите нужные координаты кнопки
            searchButton.Click += button2_Click;

            // Добавление кнопки на форму
            Controls.Add(searchButton);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            // Вызов метода LoadTickets() с передачей критериев поиска из текстовых полей
            LoadTickets(txtPassengerName.Text.Trim(), txtTrainName.Text.Trim(), txtTrainNumber.Text.Trim());
        }

        private void ShowTicketCount()
        {
            using (NpgsqlConnection conn = new NpgsqlConnection("Host=localhost;Port=1703;Username=postgres;Password=GHgh1703;Database=postgres"))
            {
                try
                {
                    conn.Open();
                    string countQuery = "SELECT COUNT(*) FROM tickets";
                    NpgsqlCommand countCommand = new NpgsqlCommand(countQuery, conn);
                    int ticketCount = Convert.ToInt32(countCommand.ExecuteScalar());
                    MessageBox.Show($"Всего билетов: {ticketCount}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при выполнении запроса: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void ShowTotalRevenue()
        {
            using (NpgsqlConnection conn = new NpgsqlConnection("Host=localhost;Port=1703;Username=postgres;Password=GHgh1703;Database=postgres"))
            {
                try
                {
                    conn.Open();
                    string sumQuery = "SELECT SUM(price) FROM tickets";
                    NpgsqlCommand sumCommand = new NpgsqlCommand(sumQuery, conn);
                    object result = sumCommand.ExecuteScalar();
                    decimal? totalRevenue = result != DBNull.Value ? Convert.ToDecimal(result) : (decimal?)null;
                    MessageBox.Show(totalRevenue.HasValue ? $"Общая выручка: {totalRevenue:C}" : "Нет данных о выручке");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при выполнении запроса: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void ShowAveragePrice()
        {
            using (NpgsqlConnection conn = new NpgsqlConnection("Host=localhost;Port=1703;Username=postgres;Password=GHgh1703;Database=postgres"))
            {
                try
                {
                    conn.Open();
                    string avgQuery = "SELECT AVG(price) FROM tickets";
                    NpgsqlCommand avgCommand = new NpgsqlCommand(avgQuery, conn);
                    object result = avgCommand.ExecuteScalar();
                    decimal? averagePrice = result != DBNull.Value ? Convert.ToDecimal(result) : (decimal?)null;
                    MessageBox.Show(averagePrice.HasValue ? $"Средняя стоимость билета: {averagePrice:C}" : "Нет данных о средней стоимости");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при выполнении запроса: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ShowTicketCount();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ShowTotalRevenue();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ShowAveragePrice();
        }
        private void ExportDataToFile(string passengerName, string trainName, string trainNumber)
        {
            // Создаем соединение с базой данных
            using (NpgsqlConnection conn = new NpgsqlConnection("Host=localhost;Port=1703;Username=postgres;Password=GHgh1703;Database=postgres"))
            {
                try
                {
                    // Открываем соединение
                    conn.Open();

                    // Формируем SQL запрос с учетом критериев поиска
                    string sql = "SELECT * FROM tickets WHERE passengername LIKE @passengerName AND trainname LIKE @trainName AND trainnumber LIKE @trainNumber";
                    NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                    command.Parameters.AddWithValue("@passengerName", "%" + passengerName + "%");
                    command.Parameters.AddWithValue("@trainName", "%" + trainName + "%");
                    command.Parameters.AddWithValue("@trainNumber", "%" + trainNumber + "%");

                    // Выполняем запрос и получаем данные в виде набора записей (DataTable)
                    NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Проверяем, есть ли данные
                    if (dataTable.Rows.Count > 0)
                    {
                        // Создаем диалог сохранения файла
                        SaveFileDialog saveFileDialog = new SaveFileDialog();
                        saveFileDialog.Filter = "XLS Files|*.xls";
                        saveFileDialog.Title = "Save Data";
                        saveFileDialog.FileName = "Экспорт данных.xls";

                        // Если пользователь выбрал место для сохранения файла и нажал ОК
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            // Получаем путь к файлу
                            string filePath = saveFileDialog.FileName;

                            // Создаем и открываем файл для записи с указанием кодировки UTF-8
                            using (StreamWriter sw = new StreamWriter(filePath, false, Encoding.UTF8))
                            {
                                // Записываем заголовки столбцов
                                for (int i = 0; i < dataTable.Columns.Count; i++)
                                {
                                    sw.Write(dataTable.Columns[i]);
                                    if (i < dataTable.Columns.Count - 1)
                                    {
                                        sw.Write("          ");
                                    }
                                }
                                sw.WriteLine();

                                // Записываем данные
                                foreach (DataRow row in dataTable.Rows)
                                {
                                    for (int i = 0; i < dataTable.Columns.Count; i++)
                                    {
                                        sw.Write(row[i]);
                                        if (i < dataTable.Columns.Count - 1)
                                        {
                                            sw.Write("          ");
                                        }
                                    }
                                    sw.WriteLine("       ");
                                }
                            }

                            MessageBox.Show("Данные успешно экспортированы в файл: " + filePath);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Нет данных для экспорта по указанным критериям.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при экспорте данных: " + ex.Message);
                }
                finally
                {
                    // Закрываем соединение
                    conn.Close();
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Вызов метода ExportDataToFile() с передачей критериев поиска из текстовых полей
            ExportDataToFile(txtPassengerName.Text.Trim(), txtTrainName.Text.Trim(), txtTrainNumber.Text.Trim());
        }

        private void InitializComponent()
        {
            // Остальной код инициализации компонентов формы

            // Создание кнопки
            Button exportButton = new Button();
            exportButton.Text = "Экспорт в файл";
            exportButton.Location = new Point(150, 150); // Установите нужные координаты кнопки
            exportButton.Click += button6_Click;

            // Добавление кнопки на форму
            Controls.Add(exportButton);
        }

    }
}
