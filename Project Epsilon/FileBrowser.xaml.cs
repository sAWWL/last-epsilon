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
using System.IO;
using System.Net;
using Microsoft.Win32;
using System.Windows.Controls.Primitives;

namespace Project_Epsilon
{
    /// <summary>
    /// Interaction logic for FileBrowser.xaml
    /// </summary>
    public partial class FileBrowser : Window
    {
        string recipedata;
        string[] reciperows;
        public string filedata;

        public void addnewserver(string newserver)
        {
        }
        public FileBrowser()
        {
            InitializeComponent();

            //Loop through Servers
            foreach(String server in Servers.ServerData)
            {
                //Add each to the serverselector
                serverSelector.Items.Add(server.Split('-')[1]);
                
            }
        }


        private void connectButton_Click(object sender, RoutedEventArgs e)
        {
            //Make sure valid option is selected
            if (serverSelector.SelectedIndex != -1)
            {

                //Acquire Serverdata from global store
                string serverdata = Servers.ServerData[serverSelector.SelectedIndex];
                string servername = serverdata.Split('-')[1];
                LoadedRecipe.username = serverdata.Split('-')[0].Split('@')[0];
                LoadedRecipe.host = serverdata.Split('-')[0].Split('@')[1].Split(':')[0];
                LoadedRecipe.port = serverdata.Split('-')[0].Split('@')[1].Split(':')[1];



                    //Connect to Server selected
                    OpenFileDialog openFileDialog1 = new OpenFileDialog
                    {
                        InitialDirectory = "ftp://" + LoadedRecipe.username + "@" + LoadedRecipe.host + ":" + LoadedRecipe.port,
                        Filter = "All files (*.*)|*.*",
                        FilterIndex = 2,
                        RestoreDirectory = false
                    };


                if (openFileDialog1.ShowDialog() == true)
                {
                    filedata = File.ReadAllText(openFileDialog1.FileName);
                    if (filedata.Contains("\n"))
                    {
                        for (int x = 1; x < filedata.Split('\n').Count(); x++)
                        {
                            if (filedata.Split('\n')[x].Split(',').Count() == 34)
                            {
                                LoadedRecipe.filerows.Add(filedata.Split('\n')[x]);
                            }
                        }
                        ChooseRecipe chooseRecipe = new ChooseRecipe();
                        if (chooseRecipe.ShowDialog() != true)
                        {
                            this.Close();
                        }



                    }
                }

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
                

                this.Close();
        }

        private void CancelLoad_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
