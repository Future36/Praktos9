using ImapX.Collections;
using System.Windows;
using System.Windows.Controls;
using System;
namespace Email
{
    public partial class UserWindow : Window
    {
        private CommonFolderCollection folders;

        public UserWindow()
        {
            InitializeComponent();
            InitializeFolders();
        }

        private void InitializeFolders()
        {
            folders = ImapHelper.GetFolders();
            foreach (var folder in folders)
            {
                FoldersLbx.Items.Add(folder.Name);
            }
        }

        private void FoldersLbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FoldersLbx.SelectedItem != null)
            {
                Messages list = new Messages(this);
                string folder = FoldersLbx.SelectedItem.ToString();
                list.Folder(folder);
                PageFrame.Content = list;
            }
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            SendMail sendLetter = new SendMail(null, null);
            PageFrame.Content = sendLetter;
        }
    }
}
