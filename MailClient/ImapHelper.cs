using ImapX.Collections;
using ImapX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Email
{
    internal class ImapHelper
    {
        private static ImapClient client;

        public static LoggedUser LoggedUser { get; } = new LoggedUser();
        public static CommonFolderCollection Folders { get; private set; }

        public static void Initialize(string host)
        {
            client = new ImapClient(host, true);
            if (!client.Connect())
            {
                throw new Exception("Error connecting to the client.");
            }
            else
            {
                LoggedUser.SmtpHost = host.Replace("imap", "smtp");
            }
        }

        public static bool Login(string email, string password)
        {
            LoggedUser.Email = email;
            LoggedUser.Pass = password;
            return client.Login(email, password);
        }

        public static void Logout()
        {
            if (client.IsAuthenticated)
            {
                client.Logout();
                client.Dispose();
            }
        }

        public static CommonFolderCollection GetFolders()
        {
            client.Folders.Inbox.StartIdling();
            client.Folders.Inbox.OnNewMessagesArrived += Inbox_OnNewMessagesArrived;
            Folders = client.Folders;
            return Folders;
        }

        private static void Inbox_OnNewMessagesArrived(object sender, IdleEventArgs e)
        {
            MessageBox.Show($"Пришло новое сообщение в папку {e.Folder.Name}.");
        }

        public static MessageCollection GetMessagesForFolder(string folderName)
        {
            client.Folders[folderName].Messages.Download();
            return client.Folders[folderName].Messages;
        }
    }

    internal class LoggedUser
    {
        public string Email { get; set; }
        public string Pass { get; set; }
        public string SmtpHost { get; set; }
    }
}
