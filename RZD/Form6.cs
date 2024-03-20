using Npgsql;
using System;
using System.Windows.Forms;

namespace RZD
{
    public partial class RegistrationForm : Form
    {
        private const string connectionString = "Host=localhost;Port=1703;Username=postgres;Password=GHgh1703;Database=postgres";

        public RegistrationForm()
        {
            InitializeComponent();

            // Заполняем комбобокс с ролями при загрузке формы
            comboBoxRole.Items.AddRange(new string[] { "Пользователь", "Администратор" });
            comboBoxRole.SelectedIndex = 0; // По умолчанию выбираем "Пользователь"
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string role = comboBoxRole.SelectedItem.ToString(); // Получаем выбранную роль из комбобокса

            // Perform validation if needed

            // Attempt to register the user
            if (RegisterUser(username, password, role))
            {
                MessageBox.Show("Registration successful!");
                this.Close(); // Close the registration form after successful registration
            }
            else
            {
                MessageBox.Show("Registration failed. Please try again.");
            }
        }

        private bool RegisterUser(string username, string password, string role)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Check if the username already exists
                    using (NpgsqlCommand checkUserCommand = new NpgsqlCommand("SELECT COUNT(*) FROM users WHERE username = @username", connection))
                    {
                        checkUserCommand.Parameters.AddWithValue("@username", username);
                        int existingUsersCount = Convert.ToInt32(checkUserCommand.ExecuteScalar());

                        if (existingUsersCount > 0)
                        {
                            MessageBox.Show("Username already exists. Please choose a different username.");
                            return false;
                        }
                    }

                    // If the username is unique, proceed with registration
                    using (NpgsqlCommand registerCommand = new NpgsqlCommand("INSERT INTO users (username, password, role) VALUES (@username, @password, @role)", connection))
                    {
                        registerCommand.Parameters.AddWithValue("@username", username);
                        registerCommand.Parameters.AddWithValue("@password", password);
                        registerCommand.Parameters.AddWithValue("@role", role);

                        int rowsAffected = registerCommand.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while registering the user: " + ex.Message);
                    return false;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close(); // Close the registration form if cancel button is clicked
        }
    }
}
