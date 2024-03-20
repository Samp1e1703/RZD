using System;
using System.Windows.Forms;

namespace RZD
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm()); // Замените LoginForm на вашу форму входа
        }
    }
}
