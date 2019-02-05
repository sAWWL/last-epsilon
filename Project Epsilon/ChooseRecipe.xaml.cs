using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
    /// Interaction logic for ChooseRecipe.xaml
    /// </summary>
    public partial class ChooseRecipe : Window
    {
        Authenticator auth = new Authenticator();
        public ChooseRecipe()
        {
            InitializeComponent();

            
            
            //focuses the cursor on the selectRecipe control
            selectRecipe.Focus();

            //Clears current selected recipes
            selectRecipe.Items.Clear();

            //adds in recipes for each value, separated by a comma
            foreach (string recipe in LoadedRecipe.filerows)
            {
                selectRecipe.Items.Add(recipe.Split(',')[0]);
            }
            if (selectRecipe.Items.Count == 0)
            {
                NoRecipe.Visibility = Visibility.Visible;
            }
            else
            {
                NoRecipe.Visibility = Visibility.Hidden;
            }
        }

        // Load Recipe button is clicked
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (selectRecipe.SelectedIndex != -1)
            {
                // Sets each property of LoadedRecipe object from the CSV, as long as the field is not blank
                string[] tempMachineData = LoadedRecipe.filerows[selectRecipe.SelectedIndex].Split(',');
                if (tempMachineData[1].Length > 0) { LoadedRecipe._product = tempMachineData[1]; }
                if (tempMachineData[2].Length > 0) { LoadedRecipe._lotNumber = Convert.ToInt32(tempMachineData[2]); }
                if (tempMachineData[3].Length > 0) { LoadedRecipe._recipeNumber = Convert.ToInt32(tempMachineData[3]); }
                if (tempMachineData[4].Length > 0) { LoadedRecipe._pressureUpperAlarmValue = Convert.ToDouble(tempMachineData[4]); }//
                if (tempMachineData[5].Length > 0) { LoadedRecipe._pressureLowerAlarmValue = Convert.ToDouble(tempMachineData[5]); }
                if (tempMachineData[6].Length > 0) { LoadedRecipe._pressureSetpointFromOIT = Convert.ToDouble(tempMachineData[6]); }
                if (tempMachineData[7].Length > 0) { LoadedRecipe._tempHigherAlarmValue = Convert.ToDouble(tempMachineData[7]); }
                if (tempMachineData[8].Length > 0) { LoadedRecipe._tempLowerAlarmValue = Convert.ToDouble(tempMachineData[8]); }
                if (tempMachineData[9].Length > 0) { LoadedRecipe._tempSetpoint = Convert.ToDouble(tempMachineData[9]); }
                if (tempMachineData[10].Length > 0) { LoadedRecipe._sealTime = Convert.ToDouble(tempMachineData[10]); }
                if (tempMachineData[11].Length > 0) { LoadedRecipe._recipeName = tempMachineData[11]; }
                if (tempMachineData[12].Length > 0) { LoadedRecipe._projectName = tempMachineData[12]; }
                if (tempMachineData[13].Length > 0) { LoadedRecipe._RFIDNumber = Convert.ToInt32(tempMachineData[13]); }
                if (tempMachineData[14].Length > 0) { LoadedRecipe._UDIRecipe = tempMachineData[14]; }
                if (tempMachineData[15].Length > 0) { LoadedRecipe._avTagRecipeLotSealed = Convert.ToInt32(tempMachineData[15]); }
                if (tempMachineData[16].Length > 0) { LoadedRecipe._avTagRecipeLotToSeal = Convert.ToInt32(tempMachineData[16]); }
                if (tempMachineData[17].Length > 0) { LoadedRecipe._recipeName = tempMachineData[17]; }
                if (tempMachineData[18].Length > 0) { LoadedRecipe._recipeGeneratedBy = tempMachineData[18]; }
                if (tempMachineData[19].Length > 0) { LoadedRecipe._recipeGeneratedOn = tempMachineData[19]; }
                if (tempMachineData[20].Length > 0) { LoadedRecipe._recToolRequired = Convert.ToInt32(tempMachineData[20]); }
                if (tempMachineData[21].Length > 0) { LoadedRecipe._cavMethod2Required = Convert.ToInt32(tempMachineData[21]); }
                if (tempMachineData[22].Length > 0) { LoadedRecipe._UDIRecipeTool = Convert.ToDouble(tempMachineData[22]); }
                if (tempMachineData[23].Length > 0) { LoadedRecipe._cavMethodOneSelected = Convert.ToInt32(tempMachineData[23]); }
                if (tempMachineData[24].Length > 0) { LoadedRecipe._cavMethodTwoSelected = Convert.ToInt32(tempMachineData[24]); }
                if (tempMachineData[25].Length > 0) { LoadedRecipe._cavMgtUsed = Convert.ToInt32(tempMachineData[25]); }
                if (tempMachineData[26].Length > 0) { LoadedRecipe._recUDI1 = Convert.ToInt32(tempMachineData[26]); }
                if (tempMachineData[27].Length > 0) { LoadedRecipe._recUDI3 = tempMachineData[27]; }
                if (tempMachineData[28].Length > 0) { LoadedRecipe._recUDI4 = tempMachineData[28]; }
                if (tempMachineData[29].Length > 0) { LoadedRecipe._recUDI5 = tempMachineData[29]; }
                if (tempMachineData[30].Length > 0) { LoadedRecipe._recUDI6 = tempMachineData[30]; }
                if (tempMachineData[31].Length > 0) { LoadedRecipe._recUDI7 = tempMachineData[31]; }
                if (tempMachineData[32].Length > 0) { LoadedRecipe._recUDI8 = tempMachineData[32]; }
                if (tempMachineData[33].Length > 0) { LoadedRecipe._recUDI9 = tempMachineData[33]; }
                LoadedRecipe.recipeID = selectRecipe.SelectedIndex;

                // Creates RecipePreview object and sets the properties to be displayed in RecipePreview.xaml
                RecipePreview recipePreview = new RecipePreview();
                recipePreview.ShowDialog();

                // If recipe has been loaded, load the Recipe Input screen and close the Choose Recipe window
                if (LoadedRecipe.confirmload == true)
                {
                    LoadedRecipe.recipeloaded = true;
                    LoadedRecipe.confirmload = false;
                    this.Close();
                    RecipeInput recipeInput = new RecipeInput();
                    recipeInput.ShowDialog();
                    
                }
            }
            //load the variable, close the page
            else
            {
                LoadedRecipe.recipeID = -1;
                RecipePreview recipePreview = new RecipePreview();
                recipePreview.ShowDialog();
                if (LoadedRecipe.confirmload == true)
                {
                    LoadedRecipe.recipeloaded = true;
                    LoadedRecipe.confirmload = false;
                    LoadedRecipe.loginSuccess = true;
                    RecipeInput recipeInput = new RecipeInput();
                    if (recipeInput.ShowDialog() == false)
                    {
                        this.Close();
                    }
                }
            }
        }

        // Add new recipe button is clicked
        private void newRecipeBtn_Click(object sender, RoutedEventArgs e)
        {
            // Clear each of the LoadedRecipe object properties
            LoadedRecipe.recipeID = LoadedRecipe.filerows.Count();
            LoadedRecipe._product = "";
            LoadedRecipe._lotNumber = 0;
            LoadedRecipe._recipeNumber = 0;
            LoadedRecipe._pressureUpperAlarmValue = 0;
            LoadedRecipe._pressureLowerAlarmValue = 0;
            LoadedRecipe._pressureSetpointFromOIT = 0;
            LoadedRecipe._tempHigherAlarmValue = 0;
            LoadedRecipe._tempLowerAlarmValue = 0;
            LoadedRecipe._tempSetpoint = 0;
            LoadedRecipe._sealTime = 0;
            LoadedRecipe._recipeName = "";
            LoadedRecipe._projectName = "";
            LoadedRecipe._RFIDNumber = 0;
            LoadedRecipe._UDIRecipe = "";
            LoadedRecipe._avTagRecipeLotSealed = 0;
            LoadedRecipe._avTagRecipeLotToSeal = 0;
            LoadedRecipe._recipeName = "";
            LoadedRecipe._recipeGeneratedBy = "";
            LoadedRecipe._recipeGeneratedOn = "";
            LoadedRecipe._recToolRequired = 0;
            LoadedRecipe._cavMethod2Required = 0;
            LoadedRecipe._UDIRecipeTool = 0;
            LoadedRecipe._cavMethodOneSelected = 0;
            LoadedRecipe._cavMethodTwoSelected = 0;
            LoadedRecipe._cavMgtUsed = 0;
            LoadedRecipe._recUDI1 = 0;
            LoadedRecipe._recUDI3 = "";
            LoadedRecipe._recUDI4 = "";
            LoadedRecipe._recUDI5 = "";
            LoadedRecipe._recUDI6 = "";
            LoadedRecipe._recUDI7 = "";
            LoadedRecipe._recUDI8 = "";
            LoadedRecipe._recUDI9 = "";
            LoadedRecipe.filerows.Add("");
            LoadedRecipe.recipeloaded = true;
            RecipeInput recipeInput = new RecipeInput();
            recipeInput.Show();
            this.Close();
        }

        // Delete recipe button is clicked
        private void deleteRecipeBtn_Click(object sender, RoutedEventArgs e)
        {

            //deletes any selected recipe(s)
            if (selectRecipe.SelectedIndex != -1)
            {
                // Have user confirm that they wish to delete a recipe (Messagebox confirmation)
                string sMessageBoxText = "Do you want to delete the selected Recipe?";
                string sCaption = "Delete Recipe?";
                MessageBoxButton btnMessageBox = MessageBoxButton.YesNoCancel;
                MessageBoxImage icnMessageBox = MessageBoxImage.Warning;
                MessageBoxResult rsltMessageBox = MessageBox.Show(sMessageBoxText, sCaption, btnMessageBox, icnMessageBox);

                // If user confirms to delete recipe, clear the recipe items
                switch (rsltMessageBox)
                {
                    case MessageBoxResult.Yes:

                        LoadedRecipe.filerows.RemoveAt(selectRecipe.SelectedIndex);
                        selectRecipe.Items.Clear();
                        foreach (string recipe in LoadedRecipe.filerows)
                        {
                            selectRecipe.Items.Add(recipe.Split(',')[0]);
                        }

                        try
                        {
                            FtpWebRequest deletereq = (FtpWebRequest)WebRequest.Create("ftp://" + LoadedRecipe.host + ":" + LoadedRecipe.port + "/Recipe1.csv");
                            deletereq.Method = WebRequestMethods.Ftp.DeleteFile;
                            deletereq.Credentials = new NetworkCredential(LoadedRecipe.username, auth.Encrypt(LoadedRecipe.password));
                            FtpWebResponse response = (FtpWebResponse)deletereq.GetResponse();
                        }
                        catch
                        {
                            MessageBox.Show("There was an error while deleting the recipe file. Please check your connection and password.");
                        }
                        try
                        {
                            FtpWebRequest uploadreq = (FtpWebRequest)WebRequest.Create("ftp://" + LoadedRecipe.host + ":" + LoadedRecipe.port + "/Recipe1.csv");
                            uploadreq.Credentials = new NetworkCredential(LoadedRecipe.username, auth.Encrypt(LoadedRecipe.password));
                            uploadreq.Method = WebRequestMethods.Ftp.UploadFile;
                            string outputstring = LoadedRecipe.headerrow + "\n";
                            foreach (string row in LoadedRecipe.filerows)

                            {
                                outputstring += row + "\n";
                            }

                            byte[] bytes = Encoding.UTF8.GetBytes(outputstring);
                            Stream requestStream = uploadreq.GetRequestStream();
                            requestStream.Write(bytes, 0, bytes.Length);
                            requestStream.Close();
                            LoadedRecipe.loginSuccess = true;
                            LoadedRecipe.recipeloaded = false;
                        }
                        catch
                        {
                            MessageBox.Show("There was an error while uploading the recipe file. Please check your connection and password.");
                        }

                        break;
                    case MessageBoxResult.No:
                        break;
                    case MessageBoxResult.Cancel:
                        break;
                }

            }
        }
    }
}
