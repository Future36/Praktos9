using System;
using System.Windows;
using System.Windows.Controls;

namespace Email
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            string email = emailTextBox.Text;
            string password = passwordBox.Password;
            ComboBoxItem selectedComboBoxItem = comboBox.SelectedItem as ComboBoxItem;

            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password) && selectedComboBoxItem != null)
            {
                if (IsEmailValid(email))
                {
                    string selectedComboBoxItemTag = selectedComboBoxItem.Tag.ToString();

                    ImapHelper.Initialize(selectedComboBoxItemTag);

                    if (ImapHelper.Login(email, password))
                    {
                        UserWindow userWindowInstance = new UserWindow();
                        userWindowInstance.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Неверный логин или пароль");
                    }
                }
                else
                {
                    MessageBox.Show("Неверный формат почты");
                }
            }
            else
            {
                MessageBox.Show("Поля и список не должны быть пустыми");
            }
        }

        private bool IsEmailValid(string email)
        {
            try
            {
                var mailAddress = new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

    }
}
