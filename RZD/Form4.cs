using System;
using System.Windows.Forms;

namespace RZD
{
    public partial class DBConnectionForm : System.Windows.Forms.Form
    {
        public string ConnectionString { get; private set; }

        public DBConnectionForm()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string host = txtHost.Text;
            string port = txtPort.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string database = txtDatabase.Text;

            // Проверка наличия введенных данных
            if (string.IsNullOrWhiteSpace(host) || string.IsNullOrWhiteSpace(port) ||
                string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(database))
            {
                MessageBox.Show("Пожалуйста, заполните все поля для подключения.");
                return;
            }

            // Формирование строки подключения
            ConnectionString = $"Host={host};Port={port};Username={username};Password={password};Database={database}";

            // Вызов события для передачи строки подключения
            OnConnectionEstablished(ConnectionString);

            // Закрытие формы
            DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Закрытие формы без установки строки подключения
            DialogResult = DialogResult.Cancel;
        }
        public event EventHandler<ConnectionStringEventArgs> ConnectionEstablished;

        protected virtual void OnConnectionEstablished(string connectionString)
        {
            ConnectionEstablished?.Invoke(this, new ConnectionStringEventArgs(connectionString));
        }
        public class ConnectionStringEventArgs : EventArgs
        {
            public string ConnectionString { get; }

            public ConnectionStringEventArgs(string connectionString)
            {
                ConnectionString = connectionString;
            }
        }
    }
}
