using Npgsql;
using System;
using System.Windows.Forms;

namespace RZD
{
    public partial class EditTrainForm : System.Windows.Forms.Form
    {
        private int trainId;
        private string initialTrainName;
        private string initialTrainNumber;
        private string initialDepartureTime;
        private NpgsqlConnection conn;

        public EditTrainForm(int trainId, string trainName, string trainNumber, string departureTime, NpgsqlConnection connection)
        {
            InitializeComponent();
            this.trainId = trainId;
            initialTrainName = trainName;
            initialTrainNumber = trainNumber;
            initialDepartureTime = departureTime;
            txtTrainName.Text = trainName;
            txtTrainNumber.Text = trainNumber;
            dateTimePickerDepartureTime.Text = departureTime;
            conn = connection;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Получите новое значение имени поезда из текстового поля
            string updatedTrainName = txtTrainName.Text;
            string updatedTrainNumber = txtTrainNumber.Text;
            string updatedDepartureTime = dateTimePickerDepartureTime.Text;
            try
            {
                // Откройте соединение с базой данных
                using (NpgsqlConnection conn = new NpgsqlConnection("Host=localhost;Port=1703;Username=postgres;Password=GHgh1703;Database=postgres"))
                {
                    conn.Open();

                    // Выполните SQL-запрос для обновления имени поезда
                    string updateSql = "UPDATE trains SET TrainName = @trainName, TrainNumber = @trainNumber, DepartureTime = @departureTime WHERE TrainId = @trainId";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(updateSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@trainName", updatedTrainName);
                        cmd.Parameters.AddWithValue("@trainNumber", updatedTrainNumber);
                        cmd.Parameters.AddWithValue("@departureTime", updatedDepartureTime);
                        cmd.Parameters.AddWithValue("@trainId", trainId);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Данные о поезде успешно обновлены.");
                        }
                        else
                        {
                            MessageBox.Show("Не удалось обновить данные о поезде.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при обновлении данных о поезде: " + ex.Message);

            }

            // Закройте форму редактирования после сохранения данных
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Закрытие формы без добавления поезда
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
