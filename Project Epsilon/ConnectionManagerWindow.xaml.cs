using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.Specialized;
using System.Net.NetworkInformation;
using System.Drawing;
using System.Net.Sockets;

namespace Project_Epsilon
{
    /// <summary>
    /// Interaction logic for ConnectionmanagerWindow.xaml
    /// </summary>
    public partial class ConnectionManagerWindow : Window
    {
        public ConnectionManagerWindow()
        {
            InitializeComponent();
            updateServerList();

        }
        private void deleteServer_Click(object sender, RoutedEventArgs e)
        {
            if (serverList.SelectedIndex != -1)
            {
                string sMessageBoxText = "Do you want to delete the selected Server?";
                string sCaption = "Delete Server?";

                MessageBoxButton btnMessageBox = MessageBoxButton.YesNoCancel;
                MessageBoxImage icnMessageBox = MessageBoxImage.Warning;

                MessageBoxResult rsltMessageBox = MessageBox.Show(sMessageBoxText, sCaption, btnMessageBox, icnMessageBox);

                switch (rsltMessageBox)
                {
                    case MessageBoxResult.Yes:
                        Servers.ServerData.RemoveAt(serverList.SelectedIndex);
                        serverList.Items.RemoveAt(serverList.SelectedIndex);
                        break;
                    case MessageBoxResult.No:
                        break;
                    case MessageBoxResult.Cancel:
                        break;
                }
            }
        }
        private void addServer_Click(object sender, RoutedEventArgs e)
        {
            Servers.ServerIdx = -1;
            AddServer addServer = new AddServer();
            if (addServer.ShowDialog() != true)
            {
                updateServerList();

            }
        }
        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
  
        private void editServer_Click(object sender, RoutedEventArgs e)
        {
            Servers.ServerIdx = serverList.SelectedIndex;
            
            AddServer editServer = new AddServer();
            if (editServer.ShowDialog() != true)
            {
                updateServerList();
            }
        }
        private void updateServerList()
        {
            serverList.Items.Clear();
            foreach (string server in Servers.ServerData)
            {
                serverList.Items.Add(server.Split('-')[1]);
            }
        }
    }

}
