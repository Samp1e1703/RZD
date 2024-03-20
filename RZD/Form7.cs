using Npgsql;
using System;
using System.Drawing;
using System.Windows.Forms;
namespace RZD
{
    public partial class BuyTicketForm : Form
    {
        private int selectedTrainId;
        private string trainName;
        private string trainNumber;
        private DateTime departureTime;
        private string userName;

        public BuyTicketForm(int selectedTrainId
            , string trainName, string trainNumber, DateTime departureTime)
        {
            InitializeComponent();
            this.selectedTrainId = selectedTrainId;
            this.trainName = trainName;
            this.trainNumber = trainNumber;
            this.departureTime = departureTime;

            // Отобразим информацию о поезде на форме покупки билета
            lblTrainName.Text = $"Поезд: {trainName}";
            lblTrainNumber.Text = $"Номер: {trainNumber}";
            lblTravelDate.Text = $"Дата поездки: {departureTime.ToShortDateString()}"; // Отображение даты поездки

            // Добавим в комбо-бокс варианты количества билетов
            for (int i = 1; i <= 10; i++)
            {
                cmbTicketQuantity.Items.Add(i);
            }
            cmbTicketQuantity.SelectedIndex = 0; // Установим начальное значение

            // Добавим несколько CheckBox для дополнительных услуг
            AddServiceCheckbox("Wi-Fi", 200);
            AddServiceCheckbox("Питание", 500);
            // Добавьте другие услуги по вашему усмотрению

            // Добавим текстовое поле для ввода имени пользователя
            TextBox txtUserName = new TextBox();
            txtUserName.Location = new Point(10, 200); // Установите расположение текстового поля на форме
            txtUserName.Size = new Size(150, 20); // Установите размер текстового поля
        }

        private void AddServiceCheckbox(string serviceName, double serviceCost)
        {
            CheckBox checkBox = new CheckBox();
            checkBox.Text = $"{serviceName} ({serviceCost} рублей)";
            checkBox.AutoSize = true;
            checkBox.Tag = serviceCost; // Сохраняем стоимость услуги в свойстве Tag чекбокса
            checkBox.CheckedChanged += UpdateTotalCost;
            flowLayoutPanel1.Controls.Add(checkBox);
        }

        private void UpdateTotalCost(object sender, EventArgs e)
        {
            double totalCost = 0;

            // Сначала добавляем стоимость билетов
            int ticketQuantity = Convert.ToInt32(cmbTicketQuantity.SelectedItem);
            double ticketCost = ticketQuantity * 1000.0;
            totalCost += ticketCost;

            // Далее добавляем стоимость выбранных дополнительных услуг, умножая их на количество билетов
            foreach (CheckBox checkBox in flowLayoutPanel1.Controls)
            {
                if (checkBox.Checked)
                {
                    double serviceCost = (double)checkBox.Tag;
                    // Умножаем стоимость услуги на количество билетов
                    totalCost += serviceCost * ticketQuantity;
                }
            }

            // Обновляем отображение общей стоимости
            lblTotalCost.Text = $"Итого: {totalCost} рублей";
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            UpdateTotalCost(sender, e);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {  // Закрытие формы без добавления поезда
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Проверка, что дата отправления не в прошлом
            if (departureTime < DateTime.Today)
            {
                MessageBox.Show("Нельзя купить билет на поезд в прошлом.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Получение данных о пассажире из текстового поля
            string passengerName = txtUserName.Text.Trim();
            if (string.IsNullOrWhiteSpace(passengerName))
            {
                MessageBox.Show("Пожалуйста, введите имя пассажира.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Проверка, что введено только текстовое значение
            foreach (char c in passengerName)
            {
                if (!char.IsLetter(c))
                {
                    MessageBox.Show("Имя пассажира должно содержать только буквы.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // Подключение к базе данных
            using (NpgsqlConnection conn = new NpgsqlConnection("Host=localhost;Port=1703;Username=postgres;Password=GHgh1703;Database=postgres"))
            {
                conn.Open();

                // Создание SQL-запроса для вставки новой записи
                string sql = "INSERT INTO tickets (passengername, trainname, trainnumber, departuretime, price) VALUES (@passengerName, @trainName, @trainNumber, @departureTime, @price)";

                // Подготовка команды
                using (NpgsqlCommand command = new NpgsqlCommand(sql, conn))
                {
                    command.Parameters.AddWithValue("@passengerName", passengerName);
                    command.Parameters.AddWithValue("@trainName", trainName);
                    command.Parameters.AddWithValue("@trainNumber", trainNumber);
                    command.Parameters.AddWithValue("@departureTime", departureTime);
                    command.Parameters.AddWithValue("@price", CalculateTotalCost());

                    // Выполнение команды
                    command.ExecuteNonQuery();
                }
            }
            // После успешного добавления билета можно закрыть форму или выполнить другие действия
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        // Метод для расчета общей стоимости билета
        private double CalculateTotalCost()
        {
            double totalCost = 0;

            // Сначала добавляем стоимость билетов
            int ticketQuantity = Convert.ToInt32(cmbTicketQuantity.SelectedItem);
            double ticketCost = ticketQuantity * 1000.0; // предполагается, что стоимость билета - 1000 рублей
            totalCost += ticketCost;

            // Далее добавляем стоимость выбранных дополнительных услуг
            foreach (CheckBox checkBox in flowLayoutPanel1.Controls)
            {
                if (checkBox.Checked)
                {
                    double serviceCost = (double)checkBox.Tag;
                    totalCost += serviceCost;
                }
            }

            return totalCost;
        }

    }
}
