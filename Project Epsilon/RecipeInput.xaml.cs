using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows;

namespace Project_Epsilon
{
    public partial class RecipeInput
    {
        public RecipeInput()
        {
            InitializeComponent();
        }
        private void optionsBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            OptionsMenu winOptionsMenu = new OptionsMenu();
            winOptionsMenu.Show();
        }
        private void homeBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Close();
        }
        private void Exit()
        {
            System.Windows.Application.Current.Shutdown();
        }
        private void loadBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            FileBrowser fileBrowser = new FileBrowser();
            if(fileBrowser.ShowDialog() == true)
            {
                
            }
            else
            {
                recipeTxt.Text = Convert.ToString(LoadedRecipe._recipeName);
                productTxt.Text = Convert.ToString(LoadedRecipe._product);
                recipeUDITxt.Text = Convert.ToString(LoadedRecipe._UDIRecipe);
                toolConfirmTxt.Text = Convert.ToString(LoadedRecipe._recToolRequired);
                cavMgtOptTxt.Text = Convert.ToString(LoadedRecipe._cavMgtUsed);
                usingUDITxt.Text = Convert.ToString(LoadedRecipe._recUDI1);
                lotTxt.Text = Convert.ToString(LoadedRecipe._lotNumber);
                rfidTxt.Text = Convert.ToString(LoadedRecipe._RFIDNumber);
                highTempTxt.Text = Convert.ToString(LoadedRecipe._tempHigherAlarmValue);
                tempSetTxt.Text = Convert.ToString(LoadedRecipe._tempSetpoint);
                lowTempTxt.Text = Convert.ToString(LoadedRecipe._tempLowerAlarmValue);
                sealTimeTxt.Text = Convert.ToString(LoadedRecipe._sealTime);
                pressSetTxt.Text = Convert.ToString(LoadedRecipe._pressureSetpointFromOIT);
                highPressTxt.Text = Convert.ToString(LoadedRecipe._pressureUpperAlarmValue);
                lowPressureTxt.Text = Convert.ToString(LoadedRecipe._pressureLowerAlarmValue);
            }
        }
        

        private void saveRecipe_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog saveRecipe = new Microsoft.Win32.SaveFileDialog
            {
                DefaultExt = ".txt",
                Filter = "Comma Seperated Value Files (.csv)|*.csv",
                FileName = LoadedRecipe.fileName,
                InitialDirectory = "ftp://" + LoadedRecipe.username + "@" + LoadedRecipe.host + ":" + LoadedRecipe.port
            };
            string output = "";

            if(LoadedRecipe.recipeID > LoadedRecipe.file.Split('\n').Length - 1)
            {
                
            }else
            {
                for(int i = 0; i < LoadedRecipe.file.Split('\n').Length; i++)
                {
                    if(i == LoadedRecipe.recipeID)
                    {

                    }else
                    {
                        output += LoadedRecipe.file.Split('\n')[i] + "\n";
                    }
                    
                }

                
            }


            byte[] buffer = Encoding.Default.GetBytes("dsadasdasdasd");
            WebRequest request = WebRequest.Create("ftp://" + LoadedRecipe.username + "@" + LoadedRecipe.host + ":" + LoadedRecipe.port + "/" + LoadedRecipe.fileName);
            request.Method = WebRequestMethods.Ftp.UploadFile;
            Stream reqStream = request.GetRequestStream();
            reqStream.Write(buffer, 0, buffer.Length);
            reqStream.Close();

            var result = saveRecipe.ShowDialog();
            MessageBox.Show(saveRecipe.FileName);

            
        }
    }
}
