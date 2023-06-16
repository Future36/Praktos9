using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Windows;
using System.Windows.Controls;

namespace Email
{

    public partial class SendMail : Page
    {
        public string AddressToWhom;
        private Messages listPage;
        private UserWindow userWindow;

        public SendMail(Messages list, UserWindow user)
        {
            InitializeComponent();
            listPage = list;
            userWindow = user;
        }

        private void ReturnBT_Click(object sender, RoutedEventArgs e)
        {
            if (userWindow != null || listPage != null)
            {
                userWindow.PageFrame.Content = listPage;
            }
            else
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void SendBT_Click(object sender, RoutedEventArgs e)
        {
            if (MessageRtb != null && ToTbx != null && !string.IsNullOrEmpty(SubjectTbx.Text) && ComboBx.SelectedItem != null)
            {
                try
                {
                    var credentials = ImapHelper.LoggedUser;
                    // Проверка наличия файла "send.html" и его автоматическое создание, если отсутствует
                    string sendHtmlFilePath = "send.html";
                    if (!File.Exists(sendHtmlFilePath))
                    {
                        File.WriteAllText(sendHtmlFilePath, string.Empty);
                    }

                    string txt = File.ReadAllText(sendHtmlFilePath);
                    MailMessage m = new MailMessage(credentials.Email, ToTbx.Text, SubjectTbx.Text, txt);
                    m.IsBodyHtml = true;
                    credentials.SmtpHost = (ComboBx.SelectedItem as ComboBoxItem).Tag.ToString();
                    SmtpClient smtp = new SmtpClient(credentials.SmtpHost, 465);
                    smtp.Credentials = new NetworkCredential(credentials.Email, credentials.Pass);
                    smtp.EnableSsl = true;
                    smtp.Send(m);

                    MessageBox.Show("Сообщение успешно отправлено!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при отправке сообщения: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Поля и список не должны быть пустыми");
            }
        }
    }
}
