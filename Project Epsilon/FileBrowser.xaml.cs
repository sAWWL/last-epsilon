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
                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                try
                {
                    openFileDialog1.InitialDirectory = "ftp://" + LoadedRecipe.username + "@" + LoadedRecipe.host + ":" + LoadedRecipe.port;
                    openFileDialog1.Filter = "All files (*.*)|*.*";
                    openFileDialog1.FilterIndex = 2;
                    openFileDialog1.RestoreDirectory = false;
                    var result = openFileDialog1.ShowDialog();

                    //Get Data from file
                    recipedata = File.ReadAllText(openFileDialog1.FileName);
                    LoadedRecipe.file = recipedata;
                    if(recipedata.Split('\n').Count() > 0)
                    {
                        try
                        {
                         
                            reciperows = recipedata.Split('\n');
                            for (int i = 0; i < recipedata.Length; i++)
                            {
                                selectRecipe.Items.Add(Convert.ToString(i + 1) + ": " + reciperows[i].Split(',')[0]);
                            }
                            selectRecipe.IsEnabled = true;
                            LoadFile.IsEnabled = true;
                        }
                        catch
                        {

                        }
                    }else
                    {

                    }
                }
                catch
                {

                } 
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
                string[] tempServerData = reciperows[selectRecipe.SelectedIndex].Split(',');
                LoadedRecipe._product = tempServerData[1];
                LoadedRecipe._lotNumber = Convert.ToInt32(tempServerData[2]);
                LoadedRecipe._recipeNumber = Convert.ToInt32(tempServerData[3]);
                LoadedRecipe._pressureUpperAlarmValue = Convert.ToInt32(tempServerData[4]);
                LoadedRecipe._pressureLowerAlarmValue = Convert.ToInt32(tempServerData[5]);
                LoadedRecipe._pressureSetpointFromOIT = Convert.ToInt32(tempServerData[6]);
                LoadedRecipe._tempHigherAlarmValue = Convert.ToInt32(tempServerData[7]);
                LoadedRecipe._tempLowerAlarmValue = Convert.ToInt32(tempServerData[8]);
                LoadedRecipe._tempSetpoint = Convert.ToInt32(tempServerData[9]);
                LoadedRecipe._sealTime = Convert.ToDouble(tempServerData[10]);
                LoadedRecipe._recipeName = tempServerData[11];
                LoadedRecipe._projectName = tempServerData[12];
                LoadedRecipe._RFIDNumber = Convert.ToInt32(tempServerData[13]);
                LoadedRecipe._UDIRecipe = tempServerData[14];
                LoadedRecipe._avTagRecipeLotSealed = Convert.ToInt32(tempServerData[15]);
                LoadedRecipe._avTagRecipeLotToSeal = Convert.ToInt32(tempServerData[16]);
                LoadedRecipe._recipeName = tempServerData[17];
                LoadedRecipe._recipeGeneratedBy = tempServerData[18];
                LoadedRecipe._recipeGeneratedOn = tempServerData[19];
                LoadedRecipe._recToolRequired = Convert.ToInt32(tempServerData[20]);
                LoadedRecipe._cavMethod2Required = Convert.ToInt32(tempServerData[21]);
                LoadedRecipe._UDIRecipeTool = Convert.ToDouble(tempServerData[22]);
                LoadedRecipe._cavMethodOneSelected = Convert.ToInt32(tempServerData[23]);
                LoadedRecipe._cavMethodTwoSelected = Convert.ToInt32(tempServerData[24]);
                LoadedRecipe._cavMgtUsed = Convert.ToInt32(tempServerData[25]);
                LoadedRecipe._recUDI1 = tempServerData[26];
                LoadedRecipe._recUDI3 = tempServerData[27];
                LoadedRecipe._recUDI4 = tempServerData[28];
                LoadedRecipe._recUDI5 = tempServerData[29];
                LoadedRecipe._recUDI6 = tempServerData[30];
                LoadedRecipe._recUDI7 = tempServerData[31];
                LoadedRecipe._recUDI8 = tempServerData[32];
                LoadedRecipe._recUDI9 = tempServerData[33];
                LoadedRecipe.recipeID = selectRecipe.SelectedIndex;

                this.Close();
        }
    }
}
