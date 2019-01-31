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
        Authenticator auth = new Authenticator();
        //variables
        string recipedata;
        string[] reciperows;
        public string filedata;

        public void addnewmachine(string newmachine)
        {
        }
        public FileBrowser()
        {
            InitializeComponent();

            //Loop through Machines
            foreach(String machine in Machines.MachineData)
            {
                //Add each to the machineselector
                machineSelector.Items.Add(machine.Split('-')[1]);

            }
        }


        private void connectButton_Click(object sender, RoutedEventArgs e)
        {
            //Make sure valid option is selected
            if (machineSelector.SelectedIndex != -1)
            {
                //Acquire Machinedata from global store
                string machinedata = Machines.MachineData[machineSelector.SelectedIndex];
                string machinename = machinedata.Split('/')[1];
                LoadedRecipe.username = machinedata.Split('@')[0];
                LoadedRecipe.host = machinedata.Split('@')[1].Split(':')[0];
                LoadedRecipe.port = machinedata.Split(':')[1].Split('-')[0];


                //creates a try catch block
                try
                {
                    FtpWebRequest downloadreq = (FtpWebRequest)WebRequest.Create("ftp://" + LoadedRecipe.host + ":" + LoadedRecipe.port + "/Recipe1.csv");
                    downloadreq.Method = WebRequestMethods.Ftp.DownloadFile;
                    downloadreq.Credentials = new NetworkCredential(LoadedRecipe.username, auth.Encrypt(LoadedRecipe.password));


                    using (Stream stream = downloadreq.GetResponse().GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                        {
                            filedata = reader.ReadToEnd();
                        }
                    }


                    if (filedata.Contains("\n"))
                    {
                        LoadedRecipe.filerows.Clear();
                        LoadedRecipe.headerrow = filedata.Split('\n')[0];
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
                catch
                {
                    MessageBox.Show("There was an error reading data from the machine.\n Please check your connection details and credentials and try again");
                }
            }
        }

        //closes the page
        private void Button_Click(object sender, RoutedEventArgs e)
        {
                this.Close();
        }

        //closes the page
        private void CancelLoad_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
