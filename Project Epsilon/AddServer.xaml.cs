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

namespace Project_Epsilon
{
    /// <summary>
    /// Interaction logic for AddServer.xaml
    /// </summary>
    public partial class AddServer : Window
    {
        public AddServer()
        {
            InitializeComponent();
            if(Servers.ServerIdx != -1)
            {
                //storing values into variables
                string serverdata = Servers.ServerData[Servers.ServerIdx];
                string servername = serverdata.Split('-')[1];
                string serverusername = serverdata.Split('-')[0].Split('@')[0];
                string serveraddress = serverdata.Split('-')[0].Split('@')[1].Split(':')[0];
                string serverport = serverdata.Split('-')[0].Split('@')[1].Split(':')[1];

                //storing values into variables
                serverName.Text = servername;
                serverAddress.Text = serveraddress;
                serverPort.Text = serverport;
                serverUsername.Text = serverusername;
            }
            
        }


        //event triggered when the add server bbutton is pressed
        private void AddServerBtn_Click(object sender, RoutedEventArgs e)
        {
            if(Servers.ServerIdx == -1)
            {
                Servers.ServerData.Add(serverUsername.Text + "@" + serverAddress.Text + ":" + serverPort.Text + "-" + serverName.Text);
            }else
            {
                Servers.ServerData[Servers.ServerIdx] = serverUsername.Text + "@" + serverAddress.Text + ":" + serverPort.Text + "-" + serverName.Text;
            }
            this.Close();
        }
        //closes the page
        private void CancelAddBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
