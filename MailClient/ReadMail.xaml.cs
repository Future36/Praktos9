using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Email
{
    public partial class ReadMail : Page
    {
        private Messages listPage;
        private UserWindow userWindow;

        private string recipient;
        private string sender;
        private string messageSubject;
        private string messageContent;

        public ReadMail(Messages list, UserWindow user)
        {
            InitializeComponent();
            listPage = list;
            userWindow = user;
        }

        public void GetMessage(string To, string From, string Sub, string Message)
        {
            recipient = To;
            sender = From;
            messageSubject = Sub;
            messageContent = Message;

            UpdateUI();
        }

        private void UpdateUI()
        {
            ToWhom.Text = recipient;
            FromWhom.Text = sender;
            SubjectTbx.Text = messageSubject;

            LoadMessageContent();
        }

        private void LoadMessageContent()
        {
            string rtfFilePath = "msg.rtf";

            ConverterRTF.ConvertToRtf(messageContent);

            if (File.Exists(rtfFilePath))
            {
                var textRange = new TextRange(MessageRtb.Document.ContentStart, MessageRtb.Document.ContentEnd);

                using (FileStream fileStream = new FileStream(rtfFilePath, FileMode.Open))
                {
                    textRange.Load(fileStream, DataFormats.Rtf);
                }

                File.Delete(rtfFilePath);
            }
        }

        private void AnswerBT_Click(object sender, RoutedEventArgs e)
        {
            SendMail send = new SendMail(listPage, userWindow);
            send.ToTbx.Text = this.sender;
            userWindow.PageFrame.Content = send;
        }

        private void ReturnBT_Click(object sender, RoutedEventArgs e)
        {
            userWindow.PageFrame.Content = listPage;
        }
    }
}
