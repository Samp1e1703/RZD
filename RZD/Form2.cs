using Npgsql;
using System;
using System.Windows.Forms;

namespace RZD
{
    public partial class AddTrainForm : System.Windows.Forms.Form
    {
        private NpgsqlConnection conn;

        public AddTrainForm(NpgsqlConnection connection)
        {
            InitializeComponent();
            conn = connection;
        }



        private void button1_Click(object sender, EventArgs e)
        {

            // Закрытие формы без добавления поезда
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            // Получение данных о поезде из полей ввода
            string trainName = textBoxTrainName.Text;
            string trainNumber = txtTrainNumber.Text;
            DateTime departureTime = dateTimePickerDepartureTime.Value;

            // Проверка, что дата отправления не в прошлом
            if (departureTime < DateTime.Today)
            {
                MessageBox.Show("Нельзя добавить маршрут с датой отправления в прошлом.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Дополнительные поля по необходимости
            // Добавление данных о поезде в базу данных
            try
            {
                conn.Open();
                string sql = "INSERT INTO trains (TrainName, TrainNumber, DepartureTime) VALUES (@TrainName, @TrainNumber, @DepartureTime)";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@TrainName", trainName);
                cmd.Parameters.AddWithValue("@TrainNumber", trainNumber);
                cmd.Parameters.AddWithValue("@DepartureTime", departureTime.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.ExecuteNonQuery();
                MessageBox.Show("Поезд успешно добавлен!");
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении поезда: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

    }
}
