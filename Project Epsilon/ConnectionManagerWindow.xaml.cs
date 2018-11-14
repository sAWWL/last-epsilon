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
            

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (serverName.Text == "" || serverAddress.Text == "" || serverPort.Text == "" || serverUsername.Text == "")
            {
                MessageBox.Show("Please ensure all fields are filled out!");
            }
            else
            {
                //serverConnectLog.Text = "Attempting to connect to " + serverAddress.Text + " on port " + serverPort.Text + "\n";
                //var ping = new Ping();
                var tcpClient = new TcpClient();
                //try
                //{
                //    var reply = ping.Send(serverAddress.Text, 6 * 100);
                //    serverConnectLog.Text += " Success! Server is responding to ping!" + "\n";
               // }
                //catch
               // {
                 //   serverConnectLog.Text += " Error! Server NOT is responding to ping!" + "\n";
               // }

                IAsyncResult ar = tcpClient.BeginConnect(serverAddress.Text, Convert.ToInt16(serverPort.Text), null, null);
                System.Threading.WaitHandle wh = ar.AsyncWaitHandle;
                try
                {
                    if (!ar.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(2), false))
                    {
                        tcpClient.Close();
                        serverConnectLog.Text += " Error! Server is NOT responding on port " + serverPort.Text + "\n";
                        throw new TimeoutException();
                    }
                    else
                    {
                        serverConnectLog.Text += " Success! Server is responding on port " + serverPort.Text + "\n";
                    }

                    tcpClient.EndConnect(ar);
                }
                finally
                {
                    wh.Close();
                }
            }
        }

        private void deleteServer_Click(object sender, RoutedEventArgs e)
        {
            if (serverList.SelectedIndex != -1)
            {
                string sMessageBoxText = "Do you want to delete the selected Server?";
                string sCaption = "My Test Application";

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
            if (serverName.Text == "" || serverAddress.Text == "" || serverPort.Text == "" || serverUsername.Text == "")
            {
                MessageBox.Show("Please ensure all fields are filled out!");
            }
            else
            {
                Servers.ServerData.Add(serverUsername.Text + "@" + serverAddress.Text + ":" + serverPort.Text + "-" + serverName.Text);
                serverList.Items.Add(serverName.Text);
            }
        }
        private void serverList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (serverList.SelectedIndex != -1)
            {
                string serverdata = Servers.ServerData[serverList.SelectedIndex];
                string servername = serverdata.Split('-')[1];
                string serverusername = serverdata.Split('-')[0].Split('@')[0];
                string serveraddress = serverdata.Split('-')[0].Split('@')[1].Split(':')[0];
                string serverport = serverdata.Split('-')[0].Split('@')[1].Split(':')[1];

                serverName.Text = servername;
                serverAddress.Text = serveraddress;
                serverPort.Text = serverport;
                serverUsername.Text = serverusername;
            }
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

}
