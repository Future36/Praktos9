using ImapX;
using ImapX.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Email
{
    public partial class Messages : Page
    {
        private UserWindow userWindow;
        MessageCollection messages;
        List<string> messagesList = new List<string>();
        public Messages(UserWindow window)
        {
            InitializeComponent();
            userWindow = window;
        }

        public void Folder(string folder)
        {
            messages = ImapHelper.GetMessagesForFolder(folder);
            if (messages != null)
            {
                MessagesLbx.ItemsSource = null;
                foreach (Message m in messages)
                {
                    messagesList.Add(m.Subject);
                }
                MessagesLbx.ItemsSource = messagesList;
            }
        }

        private void DoubleClickListBox(object sender, MouseButtonEventArgs e)
        {
            if (MessagesLbx.SelectedItem != null)
            {
                OpenningLetter();
            }
        }

        private void MessagesLbx_Click(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = e.OriginalSource as MenuItem;
            if (menuItem?.Name == "Open")
            {
                OpenningLetter();
            }
            else
            {
                SendMail page = new SendMail(this, userWindow);
                page.AddressToWhom = messages[MessagesLbx.SelectedIndex].From.Address;
                userWindow.PageFrame.Content = page;
            }
        }

        private void OpenningLetter()
        {
            var text = messages[MessagesLbx.SelectedIndex].Body.Html;
            string to = "";
            foreach (var i in messages[MessagesLbx.SelectedIndex].To)
            {
                to = i.Address;
                break;
            }
            string from = messages[MessagesLbx.SelectedIndex].From.Address.ToString();
            string subject = messages[MessagesLbx.SelectedIndex].Subject;
            ReadMail readLetterPage = new ReadMail(this, userWindow);
            readLetterPage.GetMessage(to, from, subject, text);
            userWindow.PageFrame.Content = readLetterPage;
        }
    }
}
