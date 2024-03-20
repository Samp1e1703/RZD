using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;
using static RZD.DBConnectionForm;

namespace RZD
{
    public partial class RouteListForm : System.Windows.Forms.Form
    {
        private NpgsqlConnection conn;
        private NpgsqlDataAdapter dataAdapter;
        private DataSet dataSet;
        private string connectionString;

        private void RouteListForm_Load(object sender, EventArgs e)
        {
            LoadData();
            try
            {
                // Открыть подключение к базе данных
                conn.Open();

                // Скрыть столбец с идентификатором
                dataGridViewTrains.Columns["TrainId"].Visible = false;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки данных: " + ex.Message);
            }
        }

        public RouteListForm()
        {
            InitializeComponent();
            var dbConnectionForm = new DBConnectionForm();
            dbConnectionForm.ConnectionEstablished += DbConnectionForm_ConnectionEstablished;
            if (dbConnectionForm.ShowDialog() == DialogResult.OK)
            {
                connectionString = dbConnectionForm.ConnectionString;
                conn = new NpgsqlConnection(connectionString);
                dataAdapter = new NpgsqlDataAdapter();
                dataSet = new DataSet();
            }
            else
            {
                MessageBox.Show("Не удалось установить соединение с базой данных. Приложение будет закрыто.");
                Application.Exit();
            }
        }

        private void DbConnectionForm_ConnectionEstablished(object sender, ConnectionStringEventArgs e)
        {
            connectionString = e.ConnectionString;
        }

        private void LoadData()
        {
            try
            {
                string sql = "SELECT * FROM trains"; // Замените "trains" на имя вашей таблицы с данными о поездах
                dataAdapter.SelectCommand = new NpgsqlCommand(sql, conn);
                dataSet.Reset();
                dataAdapter.Fill(dataSet);
                dataGridViewTrains.DataSource = dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки данных: " + ex.Message);
            }
            finally
            {
                conn.Close(); // Закрыть подключение к базе данных
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            TicketListForm ticketListForm = new TicketListForm();
            ticketListForm.ShowDialog();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (dataGridViewTrains.SelectedRows.Count > 0)
            {
                // Получить информацию о выбранном поезде
                int selectedTrainId = (int)dataGridViewTrains.SelectedRows[0].Cells["TrainId"].Value;
                string trainName = dataGridViewTrains.SelectedRows[0].Cells["TrainName"].Value.ToString();
                string trainNumber = dataGridViewTrains.SelectedRows[0].Cells["trainNumber"].Value.ToString();
                DateTime departureTime = Convert.ToDateTime(dataGridViewTrains.SelectedRows[0].Cells["DepartureTime"].Value);

                // Получите другие данные о поезде, если это необходимо

                // Передать информацию о выбранном поезде на форму покупки билета
                BuyTicketForm buyTicketForm = new BuyTicketForm(selectedTrainId, trainName, trainNumber, departureTime);
                buyTicketForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Выберите поезд для покупки билетов.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Создание новой формы авторизации
            LoginForm loginForm = new LoginForm();

            // Отображение формы авторизации
            loginForm.Show();

            // Закрытие текущей формы
            this.Close();
        }
    }
}
