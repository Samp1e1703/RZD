using Npgsql; // Добавляем пространство имен Npgsql для работы с PostgreSQL
using System;
using System.Windows.Forms;

namespace RZD
{
    public partial class LoginForm : Form
    {
        private const string connectionString = "Host=localhost;Port=1703;Username=postgres;Password=GHgh1703;Database=postgres";

        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Validate username and password
            if (IsValidUser(username, password))
            {
                // Determine user role
                string role = GetUserRole(username);

                // Open corresponding form based on user role
                if (role == "Администратор")
                {
                    Form1 Form1 = new Form1();
                    Form1.Show();
                }
                else
                {
                    RouteListForm RouteListForm = new RouteListForm();
                    RouteListForm.Show();
                }

                // Close the login form
                this.Hide(); // Hide the login form instead of closing it
            }
            else
            {
                // Authentication failed
                MessageBox.Show("Invalid username or password. Please try again.");
                txtUsername.Clear();
                txtPassword.Clear();
                txtUsername.Focus();
            }
        }

        private string GetUserRole(string username)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Create a command to retrieve user role
                    using (NpgsqlCommand command = new NpgsqlCommand("SELECT role FROM users WHERE username = @username", connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        string role = command.ExecuteScalar() as string;

                        return role;
                    }
                }
                catch (Exception ex)
                {
                    // Handle exception (e.g., logging, displaying an error message)
                    MessageBox.Show("An error occurred while connecting to the database: " + ex.Message);
                    return null;
                }
            }
        }

        private bool IsValidUser(string username, string password)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Create a command to check for user existence
                    using (NpgsqlCommand command = new NpgsqlCommand("SELECT COUNT(*) FROM users WHERE username = @username AND password = @password", connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", password);

                        int count = Convert.ToInt32(command.ExecuteScalar());

                        return count > 0;
                    }
                }
                catch (Exception ex)
                {
                    // Handle exception (e.g., logging, displaying an error message)
                    MessageBox.Show("An error occurred while connecting to the database: " + ex.Message);
                    return false;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Закрытие формы без добавления поезда
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RegistrationForm registrationForm = new RegistrationForm();
            registrationForm.ShowDialog();
        }
    }
}
