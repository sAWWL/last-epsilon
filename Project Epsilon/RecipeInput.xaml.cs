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
        private string _password;


        public RecipeInput()
        {
            InitializeComponent();
            //creates variables
            double highTempAlarm;
            double tempSetPoint;
            double lowTemp;
            double sealTime;
            double highPress;
            double pressSet;
            double lowPressure;

            //displays Yes or No in the read only toolConfirmTxt textbox to show whether or not  tool confirmation has been set to required
            if (LoadedRecipe._recToolRequired == 1)
            {
                toolConfirmTxt.Text = "Yes";
            }
            else if (LoadedRecipe._recToolRequired == 0)
            {
                toolConfirmTxt.Text = "No";
            }
            else
            {
                toolConfirmTxt.Text = "No";
            }

            //displays Yes or No in the read only cavMgtOpt textbox to show whether or not cavity mgt is being used
            if (LoadedRecipe._cavMgtUsed == 1)
            {
                cavMgtOptTxt.Text = "Yes";
            }
            else if (LoadedRecipe._cavMgtUsed == 0)
            {
                cavMgtOptTxt.Text = "No";
            }
            else
            {
                cavMgtOptTxt.Text = "No";
            }

            //displays Yes or No in the read only cavMgtOpt textbox to show whether or not cavity mgt is being used
            if (LoadedRecipe._recUDI1 == "1")
            {
                usingUDITxt.Text = "Yes";
            }
            else if (LoadedRecipe._recUDI1 == "0")
            {
                usingUDITxt.Text = "No";
            }
            else
            {
                usingUDITxt.Text = "No";
            }

            //tests controls is box is null or just empty with white spaces
            if (String.IsNullOrWhiteSpace(recipeTxt.Text) || String.IsNullOrWhiteSpace(productTxt.Text) || String.IsNullOrWhiteSpace(lotTxt.Text) ||
                String.IsNullOrWhiteSpace(recipeUDITxt.Text) || String.IsNullOrWhiteSpace(highTempTxt.Text) || String.IsNullOrWhiteSpace(tempSetTxt.Text) ||
                String.IsNullOrWhiteSpace(lowTempTxt.Text) || String.IsNullOrWhiteSpace(sealTimeTxt.Text) || String.IsNullOrWhiteSpace(highPressTxt.Text) ||
                String.IsNullOrWhiteSpace(pressSetTxt.Text) || String.IsNullOrWhiteSpace(lowPressureTxt.Text) ||
                String.IsNullOrWhiteSpace(cavMgtOptTxt.Text) || String.IsNullOrWhiteSpace(toolConfirmTxt.Text) || String.IsNullOrWhiteSpace(usingUDITxt.Text))
            {
                //error message is visible
                errorTxt.Visibility = Visibility.Visible;

                //disables saveRecipe
                saveRecipe.IsEnabled = false;
                errorTxt.Content = "All Fields (except RFID) are Required";
            }
            else if (!Double.TryParse(highTempTxt.Text, out highTempAlarm) || !Double.TryParse(tempSetTxt.Text, out tempSetPoint) || !Double.TryParse(lowTempTxt.Text, out tempSetPoint)
                || !Double.TryParse(sealTimeTxt.Text, out sealTime) || !Double.TryParse(highPressTxt.Text, out highPress)
                || !Double.TryParse(pressSetTxt.Text, out pressSet) || !Double.TryParse(lowPressureTxt.Text, out lowPressure))
            {
                //pulls public variables, converts, and stores in textboxes
                errorTxt.Visibility = Visibility.Visible;
                saveRecipe.IsEnabled = false;
                errorTxt.Content = "Below fields must be numeric input only";
            }
            else if (recipeUDITxt.Text.Length != 40)
            {
                //pulls public variables, converts, and stores in textboxes
                errorTxt.Visibility = Visibility.Visible;
                saveRecipe.IsEnabled = false;
                errorTxt.Content = "Recipe UDI must be 40 characters";
            }
            else
            {
                //pulls text frrom textboxes, converts to double, and stores in variables
                highTempAlarm = Convert.ToDouble(highTempTxt.Text);
                tempSetPoint = Convert.ToDouble(tempSetTxt.Text);
                lowTemp = Convert.ToDouble(lowTempTxt.Text);
                sealTime = Convert.ToDouble(sealTimeTxt.Text);
                highPress = Convert.ToDouble(highPressTxt.Text);
                pressSet = Convert.ToDouble(pressSetTxt.Text);
                lowPressure = Convert.ToDouble(lowPressureTxt.Text);

                if (highTempAlarm <= tempSetPoint)
                {
                    //error message is visible, save Recipe is disabled, error message is displayed
                    errorTxt.Visibility = Visibility.Visible;
                    saveRecipe.IsEnabled = false;
                    errorTxt.Content = "Fix High Temperature. It is Lower than Temp Setpoint";
                }
                else if (highTempAlarm >= 250)
                {
                    //error message is visible, save Recipe is disabled, error message is displayed
                    errorTxt.Visibility = Visibility.Visible;
                    saveRecipe.IsEnabled = false;
                    errorTxt.Content = "High Temp Alarm must be less than 250 degrees";
                }
                else if (lowTemp >= tempSetPoint)
                {
                    //error message is visible, save Recipe is disabled, error message is displayed
                    errorTxt.Visibility = Visibility.Visible;
                    saveRecipe.IsEnabled = false;
                    errorTxt.Content = "Fix Low Temperature. It is Greater than Temp Setpoint";
                }
                else if (lowTemp <= 50)
                {
                    //error message is visible, save Recipe is disabled, error message is displayed
                    errorTxt.Visibility = Visibility.Visible;
                    saveRecipe.IsEnabled = false;
                    errorTxt.Content = "Low Temp Alarm must be greater than 50 degrees";
                }
                else if (sealTime <= 0)
                {
                    //error message is visible, save Recipe is disabled, error message is displayed
                    errorTxt.Visibility = Visibility.Visible;
                    saveRecipe.IsEnabled = false;
                    errorTxt.Content = "Fix Seal Time. Seal Time must be greater than 0 seconds";
                }
                else if (sealTime >= 10)
                {
                    //error message is visible, save Recipe is disabled, error message is displayed
                    errorTxt.Visibility = Visibility.Visible;
                    saveRecipe.IsEnabled = false;
                    errorTxt.Content = "Fix Seal Time. Seal Time must be less than 10 seconds";
                }
                else if (highPress <= pressSet)
                {
                    //error message is visible, save Recipe is disabled, error message is displayed
                    errorTxt.Visibility = Visibility.Visible;
                    saveRecipe.IsEnabled = false;
                    errorTxt.Content = "Fix High Pressure. It is Lower than Pressure Setpoint";
                }
                else if (highPress >= 125)
                {
                    //error message is visible, save Recipe is disabled, error message is displayed
                    errorTxt.Visibility = Visibility.Visible;
                    saveRecipe.IsEnabled = false;
                    errorTxt.Content = "High Pressure Alarm must be less than 125 PSI";
                }
                else if (lowPressure >= pressSet)
                {
                    //error message is visible, save Recipe is disabled, error message is displayed
                    errorTxt.Visibility = Visibility.Visible;
                    saveRecipe.IsEnabled = false;
                    errorTxt.Content = "Fix Low Pressure. It is Greater than Pressure Setpoint";
                }
                else if (lowPressure <= 0)
                {
                    //error message is visible, save Recipe is disabled, error message is displayed
                    errorTxt.Visibility = Visibility.Visible;
                    saveRecipe.IsEnabled = false;
                    errorTxt.Content = "Low Pressure Alarm must be greater than 0 PSI";
                }
                else
                {

                    //error message is invisible, save Recipe is enabled
                    errorTxt.Visibility = Visibility.Hidden;
                    saveRecipe.IsEnabled = true;
                }
            }
        }

        

        private void optionsBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            //ccreats new instance of OptionsMenu page and displays it as primary window
            OptionsMenu winOptionsMenu = new OptionsMenu();
            winOptionsMenu.Show();

            //stores text in textbox into public variable
            LoadedRecipe._UDIRecipe = recipeUDITxt.Text;
        }
        
        //when home button is clicked
        private void homeBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Close();
        }

        //exit method
        private void Exit()
        {
            System.Windows.Application.Current.Shutdown();
        }

        //load button is clicked
        private void loadBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            //creates new instance of filebrowser
            FileBrowser fileBrowser = new FileBrowser();

            //if filebbroswer shows its dialog to user
            if (fileBrowser.ShowDialog() == true)
            {

            }
            
            //else
            else
            {
                //pulls public variables, converts, and stores in textboxes
                recipeTxt.Text = Convert.ToString(LoadedRecipe._recipeName);
                productTxt.Text = Convert.ToString(LoadedRecipe._product);
                recipeUDITxt.Text = Convert.ToString(LoadedRecipe._UDIRecipe);
                toolConfirmTxt.Text = Convert.ToString(LoadedRecipe._recToolRequired);
                
                //if text has a value of 1
                if (toolConfirmTxt.Text == "1")
                {
                    //display yes
                    toolConfirmTxt.Text = "Yes";
                }
                
                //if text hhas value of 0
                else if (toolConfirmTxt.Text == "0")
                {
                    //display no
                    toolConfirmTxt.Text = "No";
                }
                //convert to string and place in textbox
                cavMgtOptTxt.Text = Convert.ToString(LoadedRecipe._cavMgtUsed);

                //if textbox is given value of 1
                if (cavMgtOptTxt.Text == "1")
                {
                    cavMgtOptTxt.Text = "Yes";
                }

                //if textbox is given value of 0
                else if (cavMgtOptTxt.Text == "0")
                {
                    cavMgtOptTxt.Text = "No";
                }
                //if given any other value
                else
                {
                    toolConfirmTxt.Text = "No";
                }
                //convert to string and place in textbox
                usingUDITxt.Text = Convert.ToString(LoadedRecipe._recUDI1);

                //if textbox is given value of 1
                if (cavMgtOptTxt.Text == "1")
                {
                    cavMgtOptTxt.Text = "Yes";
                }

                //if textbox is given value of 1//if textbox is given value of 0
                else if (cavMgtOptTxt.Text == "0")
                {
                    cavMgtOptTxt.Text = "No";
                }
                //if given any other value
                else
                {
                    toolConfirmTxt.Text = "No";
                }

                //pulls public variables, converts, and stores in textboxes
                lotTxt.Text = Convert.ToString(LoadedRecipe._lotNumber);
                rfidTxt.Text = Convert.ToString(LoadedRecipe._RFIDNumber);
                highTempTxt.Text = Convert.ToString(LoadedRecipe._tempHigherAlarmValue);
                tempSetTxt.Text = Convert.ToString(LoadedRecipe._tempSetpoint);
                lowTempTxt.Text = Convert.ToString(LoadedRecipe._tempLowerAlarmValue);
                sealTimeTxt.Text = Convert.ToString(LoadedRecipe._sealTime);
                pressSetTxt.Text = Convert.ToString(LoadedRecipe._pressureSetpointFromOIT);
                highPressTxt.Text = Convert.ToString(LoadedRecipe._pressureUpperAlarmValue);
                lowPressureTxt.Text = Convert.ToString(LoadedRecipe._pressureLowerAlarmValue);

                //public variables
                double highTempAlarm;
                double tempSetPoint;
                double lowTemp;
                double sealTime;
                double highPress;
                double pressSet;
                double lowPressure;

                //tests controls is box is null or just empty with white spaces
                if (String.IsNullOrWhiteSpace(recipeTxt.Text) || String.IsNullOrWhiteSpace(productTxt.Text) || String.IsNullOrWhiteSpace(lotTxt.Text) ||
                String.IsNullOrWhiteSpace(recipeUDITxt.Text) || String.IsNullOrWhiteSpace(highTempTxt.Text) || String.IsNullOrWhiteSpace(tempSetTxt.Text) ||
                String.IsNullOrWhiteSpace(lowTempTxt.Text) || String.IsNullOrWhiteSpace(sealTimeTxt.Text) || String.IsNullOrWhiteSpace(highPressTxt.Text) ||
                String.IsNullOrWhiteSpace(pressSetTxt.Text) || String.IsNullOrWhiteSpace(lowPressureTxt.Text) ||
                String.IsNullOrWhiteSpace(cavMgtOptTxt.Text) || String.IsNullOrWhiteSpace(toolConfirmTxt.Text) || String.IsNullOrWhiteSpace(usingUDITxt.Text))
                {
                    //error message is visible, saveRecipe is disabled, displays error message
                    errorTxt.Visibility = Visibility.Visible;
                    saveRecipe.IsEnabled = false;
                    errorTxt.Content = "All Fields (except RFID) are Required";
                }
                
                else if (!Double.TryParse(highTempTxt.Text, out highTempAlarm) || !Double.TryParse(tempSetTxt.Text, out tempSetPoint) || !Double.TryParse(lowTempTxt.Text, out tempSetPoint)
                    || !Double.TryParse(sealTimeTxt.Text, out sealTime) || !Double.TryParse(highPressTxt.Text, out highPress)
                    || !Double.TryParse(pressSetTxt.Text, out pressSet) || !Double.TryParse(lowPressureTxt.Text, out lowPressure))
                {
                    //error message is visible, save Recipe is disabled, error message is displayed
                    errorTxt.Visibility = Visibility.Visible;
                    saveRecipe.IsEnabled = false;
                    errorTxt.Content = "Below fields must be numeric input only";
                }
                
                else if (recipeUDITxt.Text.Length != 40)
                {
                    //error message is visible, save Recipe is disabled, error message is displayed
                    errorTxt.Visibility = Visibility.Visible;
                    saveRecipe.IsEnabled = false;
                    errorTxt.Content = "Recipe UDI must be 40 characters";
                }
                else
                {
                    highTempAlarm = Convert.ToDouble(highTempTxt.Text);
                    tempSetPoint = Convert.ToDouble(tempSetTxt.Text);
                    lowTemp = Convert.ToDouble(lowTempTxt.Text);
                    sealTime = Convert.ToDouble(sealTimeTxt.Text);
                    highPress = Convert.ToDouble(highPressTxt.Text);
                    pressSet = Convert.ToDouble(pressSetTxt.Text);
                    lowPressure = Convert.ToDouble(lowPressureTxt.Text);

                    if (highTempAlarm <= tempSetPoint)
                    {
                        //error message is visible, save Recipe is disabled, error message is displayed
                        errorTxt.Visibility = Visibility.Visible;
                        saveRecipe.IsEnabled = false;
                        errorTxt.Content = "Fix High Temperature. It is Lower than Temp Setpoint";
                    }
                    else if (highTempAlarm >= 250)
                    {
                        //error message is visible, save Recipe is disabled, error message is displayed
                        errorTxt.Visibility = Visibility.Visible;
                        saveRecipe.IsEnabled = false;
                        errorTxt.Content = "High Temp Alarm must be less than 250 degrees";
                    }
                    else if (lowTemp >= tempSetPoint)
                    {
                        //error message is visible, save Recipe is disabled, error message is displayed
                        errorTxt.Visibility = Visibility.Visible;
                        saveRecipe.IsEnabled = false;
                        errorTxt.Content = "Fix Low Temperature. It is Greater than Temp Setpoint";
                    }
                    else if (lowTemp <= 50)
                    {
                        //error message is visible, save Recipe is disabled, error message is displayed
                        errorTxt.Visibility = Visibility.Visible;
                        saveRecipe.IsEnabled = false;
                        errorTxt.Content = "Low Temp Alarm must be greater than 50 degrees";
                    }
                    else if (sealTime <= 0)
                    {
                        //error message is visible, save Recipe is disabled, error message is displayed
                        errorTxt.Visibility = Visibility.Visible;
                        saveRecipe.IsEnabled = false;
                        errorTxt.Content = "Fix Seal Time. Seal Time must be greater than 0 seconds";
                    }
                    else if (sealTime >= 10)
                    {
                        //error message is visible, save Recipe is disabled, error message is displayed
                        errorTxt.Visibility = Visibility.Visible;
                        saveRecipe.IsEnabled = false;
                        errorTxt.Content = "Fix Seal Time. Seal Time must be less than 10 seconds";
                    }
                    else if (highPress <= pressSet)
                    {
                        //error message is visible, save Recipe is disabled, error message is displayed
                        errorTxt.Visibility = Visibility.Visible;
                        saveRecipe.IsEnabled = false;
                        errorTxt.Content = "Fix High Pressure. It is Lower than Pressure Setpoint";
                    }
                    else if (highPress >= 125)
                    {
                        //error message is visible, save Recipe is disabled, error message is displayed
                        errorTxt.Visibility = Visibility.Visible;
                        saveRecipe.IsEnabled = false;
                        errorTxt.Content = "High Pressure Alarm must be less than 125 PSI";
                    }
                    else if (lowPressure >= pressSet)
                    {
                        //error message is visible, save Recipe is disabled, error message is displayed
                        errorTxt.Visibility = Visibility.Visible;
                        saveRecipe.IsEnabled = false;
                        errorTxt.Content = "Fix Low Pressure. It is Greater than Pressure Setpoint";
                    }
                    else if (lowPressure <= 0)
                    {
                        //error message is visible, save Recipe is disabled, error message is displayed
                        errorTxt.Visibility = Visibility.Visible;
                        saveRecipe.IsEnabled = false;
                        errorTxt.Content = "Low Pressure Alarm must be greater than 0 PSI";
                    }
                    else
                    {
                        //error is invisible, saveRecipe is enabled
                        errorTxt.Visibility = Visibility.Hidden;
                        saveRecipe.IsEnabled = true;
                    }
                }
            }
        }

        //whhen saveRecipe button is clicked
        private void saveRecipe_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            //Converts toolConfirmTxt textbox string of Yes or No to .csv format  1 or 0
            if (toolConfirmTxt.Text == "Yes")
            {
                LoadedRecipe._recToolRequired = 1;
            }
            else if (toolConfirmTxt.Text == "No")
            {
                LoadedRecipe._recToolRequired = 0;
            }


            //Converts cavMgtOptTxt textbox string of Yes or No to .csv format  1 or 0
            if (cavMgtOptTxt.Text == "Yes")
            {
                LoadedRecipe._cavMgtUsed = 1;
            }
            else if (cavMgtOptTxt.Text == "No")
            {
                LoadedRecipe._cavMgtUsed = 0;
            }


            //Converts usingUDITxt textbox string of Yes or No to .csv format  1 or 0
            if (usingUDITxt.Text == "Yes")
            {
                LoadedRecipe._recUDI1 = "1";
            }
            else if (usingUDITxt.Text == "No")
            {
                LoadedRecipe._recUDI1 = "0";
            }
            //takes input in text boxes, converts if needed, stores in public variable
            LoadedRecipe._recipeName = recipeTxt.Text;
            LoadedRecipe._product = productTxt.Text;
            LoadedRecipe._lotNumber = Convert.ToInt32(lotTxt.Text);
            LoadedRecipe._RFIDNumber = Convert.ToInt32(rfidTxt.Text);
            LoadedRecipe._UDIRecipe = recipeUDITxt.Text;
            LoadedRecipe._tempHigherAlarmValue = Convert.ToInt32(highTempTxt.Text);
            LoadedRecipe._tempSetpoint = Convert.ToInt32(tempSetTxt.Text);
            LoadedRecipe._tempLowerAlarmValue = Convert.ToInt32(lowTempTxt.Text);
            LoadedRecipe._sealTime = Convert.ToDouble(sealTimeTxt.Text);
            LoadedRecipe._pressureUpperAlarmValue = Convert.ToInt32(highPressTxt.Text);
            LoadedRecipe._pressureSetpointFromOIT = Convert.ToInt32(pressSetTxt.Text);
            LoadedRecipe._pressureLowerAlarmValue = Convert.ToInt32(lowPressureTxt.Text);

            //stores text in varriables
            LoadedRecipe._projectName = "Master_HMI_Cavity_Master";
            LoadedRecipe._recipeGeneratedBy = "ADMIN";
            LoadedRecipe._recipeGeneratedOn = "11-11-11:11:11:11";

            //categorizes information from csv file into public variables
            LoadedRecipe.filerows[LoadedRecipe.recipeID] = LoadedRecipe._recipeName + "," + LoadedRecipe._product + "," + LoadedRecipe._lotNumber + "," + LoadedRecipe._recipeNumber + "," + LoadedRecipe._pressureUpperAlarmValue + "," + LoadedRecipe._pressureLowerAlarmValue + "," + LoadedRecipe._pressureSetpointFromOIT + "," + LoadedRecipe._tempHigherAlarmValue + "," + LoadedRecipe._tempLowerAlarmValue + "," + LoadedRecipe._tempSetpoint + "," + LoadedRecipe._sealTime + "," + "0" + "," + LoadedRecipe._projectName + "," + LoadedRecipe._RFIDNumber + "," + LoadedRecipe._UDIRecipe + "," + LoadedRecipe._avTagRecipeLotSealed + "," + LoadedRecipe._avTagRecipeLotToSeal + "," + LoadedRecipe._recipeName + "," + LoadedRecipe._recipeGeneratedBy + "," + LoadedRecipe._recipeGeneratedOn + "," + LoadedRecipe._recToolRequired + "," + LoadedRecipe._cavMethod2Required + "," + LoadedRecipe._UDIRecipeTool + "," + LoadedRecipe._cavMethodOneSelected + "," + LoadedRecipe._cavMethodTwoSelected + "," + LoadedRecipe._cavMgtUsed + "," + LoadedRecipe._recUDI1 + "," + LoadedRecipe._recUDI3 + "," + LoadedRecipe._recUDI4 + "," + LoadedRecipe._recUDI5 + "," + LoadedRecipe._recUDI6 + "," + LoadedRecipe._recUDI7 + "," + LoadedRecipe._recUDI8 + "," + LoadedRecipe._recUDI9;

            //if login is unseccessful
            if (LoadedRecipe.loginSuccess == false)
            {
                //create new instance of password input and prompt for it
                PasswordInput passwordInput = new PasswordInput();
                passwordInput.ShowDialog();
            }

            //creates a try catch block
            try
            {
                FtpWebRequest deletereq = (FtpWebRequest)WebRequest.Create("ftp://" + LoadedRecipe.host + ":" + LoadedRecipe.port + "/Recipe1.csv");
                deletereq.Method = WebRequestMethods.Ftp.DeleteFile;
                deletereq.Credentials = new NetworkCredential(LoadedRecipe.username, LoadedRecipe.password);
                FtpWebResponse response = (FtpWebResponse)deletereq.GetResponse();
            }
            catch
            {

            }
            try
            {
                FtpWebRequest uploadreq = (FtpWebRequest)WebRequest.Create("ftp://" + LoadedRecipe.host + ":" + LoadedRecipe.port + "/Recipe1.csv");
                uploadreq.Credentials = new NetworkCredential(LoadedRecipe.username, LoadedRecipe.password);
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
                MessageBox.Show("Recipe upload was successful.");
            }
            catch
            {
                MessageBox.Show("There was an error while uploading the recipe file. Please check your connection and password.");
            }

        }

        //Validation
        private void UDI_Validation(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            double highTempAlarm;
            double tempSetPoint;
            double lowTemp;
            double sealTime;
            double highPress;
            double pressSet;
            double lowPressure;

            //tests controls is box is null or just empty with white spaces
            if (String.IsNullOrWhiteSpace(recipeTxt.Text) || String.IsNullOrWhiteSpace(productTxt.Text) || String.IsNullOrWhiteSpace(lotTxt.Text) ||
                String.IsNullOrWhiteSpace(recipeUDITxt.Text) || String.IsNullOrWhiteSpace(highTempTxt.Text) || String.IsNullOrWhiteSpace(tempSetTxt.Text) ||
                String.IsNullOrWhiteSpace(lowTempTxt.Text) || String.IsNullOrWhiteSpace(sealTimeTxt.Text) || String.IsNullOrWhiteSpace(highPressTxt.Text) ||
                String.IsNullOrWhiteSpace(pressSetTxt.Text) || String.IsNullOrWhiteSpace(lowPressureTxt.Text) ||
                String.IsNullOrWhiteSpace(cavMgtOptTxt.Text) || String.IsNullOrWhiteSpace(toolConfirmTxt.Text) || String.IsNullOrWhiteSpace(usingUDITxt.Text))
            {
                //error message is visible, save Recipe is disabled, error message is displayed
                errorTxt.Visibility = Visibility.Visible;
                saveRecipe.IsEnabled = false;
                errorTxt.Content = "All Fields (except RFID) are Required";
            }
            else if (!Double.TryParse(highTempTxt.Text, out highTempAlarm) || !Double.TryParse(tempSetTxt.Text, out tempSetPoint) || !Double.TryParse(lowTempTxt.Text, out tempSetPoint)
                || !Double.TryParse(sealTimeTxt.Text, out sealTime) || !Double.TryParse(highPressTxt.Text, out highPress)
                || !Double.TryParse(pressSetTxt.Text, out pressSet) || !Double.TryParse(lowPressureTxt.Text, out lowPressure))
            {
                //error message is visible, save Recipe is disabled, error message is displayed
                errorTxt.Visibility = Visibility.Visible;
                saveRecipe.IsEnabled = false;
                errorTxt.Content = "Below fields must be numeric input only";
            }
            else if (recipeUDITxt.Text.Length != 40)
            {
                //error message is visible, save Recipe is disabled, error message is displayed
                errorTxt.Visibility = Visibility.Visible;
                saveRecipe.IsEnabled = false;
                errorTxt.Content = "Recipe UDI must be 40 characters";
            }
            else
            {
                highTempAlarm = Convert.ToDouble(highTempTxt.Text);
                tempSetPoint = Convert.ToDouble(tempSetTxt.Text);
                lowTemp = Convert.ToDouble(lowTempTxt.Text);
                sealTime = Convert.ToDouble(sealTimeTxt.Text);
                highPress = Convert.ToDouble(highPressTxt.Text);
                pressSet = Convert.ToDouble(pressSetTxt.Text);
                lowPressure = Convert.ToDouble(lowPressureTxt.Text);

                if (highTempAlarm <= tempSetPoint)
                {


                    //error message is visible, save Recipe is disabled, error message is displayed
                    errorTxt.Visibility = Visibility.Visible;
                    saveRecipe.IsEnabled = false;
                    errorTxt.Content = "Fix High Temperature. It is Lower than Temp Setpoint";
                }
                else if (highTempAlarm >= 250)
                {
                    //error message is visible, save Recipe is disabled, error message is displayed
                    errorTxt.Visibility = Visibility.Visible;
                    saveRecipe.IsEnabled = false;
                    errorTxt.Content = "High Temp Alarm must be less than 250 degrees";
                }
                else if (lowTemp >= tempSetPoint)
                {
                    //error message is visible, save Recipe is disabled, error message is displayed
                    errorTxt.Visibility = Visibility.Visible;
                    saveRecipe.IsEnabled = false;
                    errorTxt.Content = "Fix Low Temperature. It is Greater than Temp Setpoint";
                }
                else if (lowTemp <= 50)
                {
                    //error message is visible, save Recipe is disabled, error message is displayed
                    errorTxt.Visibility = Visibility.Visible;
                    saveRecipe.IsEnabled = false;
                    errorTxt.Content = "Low Temp Alarm must be greater than 50 degrees";
                }
                else if (sealTime <= 0)
                {
                    //error message is visible, save Recipe is disabled, error message is displayed
                    errorTxt.Visibility = Visibility.Visible;
                    saveRecipe.IsEnabled = false;
                    errorTxt.Content = "Fix Seal Time. Seal Time must be greater than 0 seconds";
                }
                else if (sealTime >= 10)
                {
                    //error message is visible, save Recipe is disabled, error message is displayed
                    errorTxt.Visibility = Visibility.Visible;
                    saveRecipe.IsEnabled = false;
                    errorTxt.Content = "Fix Seal Time. Seal Time must be less than 10 seconds";
                }
                else if (highPress <= pressSet)
                {
                    //error message is visible, save Recipe is disabled, error message is displayed
                    errorTxt.Visibility = Visibility.Visible;
                    saveRecipe.IsEnabled = false;
                    errorTxt.Content = "Fix High Pressure. It is Lower than Pressure Setpoint";
                }
                else if (highPress >= 125)
                {
                    //error message is visible, save Recipe is disabled, error message is displayed
                    errorTxt.Visibility = Visibility.Visible;
                    saveRecipe.IsEnabled = false;
                    errorTxt.Content = "High Pressure Alarm must be less than 125 PSI";
                }
                else if (lowPressure >= pressSet)
                {
                    //error message is visible, save Recipe is disabled, error message is displayed
                    errorTxt.Visibility = Visibility.Visible;
                    saveRecipe.IsEnabled = false;
                    errorTxt.Content = "Fix Low Pressure. It is Greater than Pressure Setpoint";
                }
                else if (lowPressure <= 0)
                {
                    //error message is visible, save Recipe is disabled, error message is displayed
                    errorTxt.Visibility = Visibility.Visible;
                    saveRecipe.IsEnabled = false;
                    errorTxt.Content = "Low Pressure Alarm must be greater than 0 PSI";
                }
                else
                {
                    //error message is invisible, save Recipe is enabled
                    errorTxt.Visibility = Visibility.Hidden;
                    saveRecipe.IsEnabled = true;
                }
            }
        }

        //clear button is pressed
        private void clearBtn_Click(object sender, RoutedEventArgs e)
        {
            //final message
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure you wish to clear all fields?", "Clear Fields Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                //clears all controls
                highTempTxt.Text = "";
                tempSetTxt.Text = "";
                lowTempTxt.Text = "";
                sealTimeTxt.Text = "";
                highPressTxt.Text = "";
                pressSetTxt.Text = "";
                lowPressureTxt.Text = "";
                recipeTxt.Text = "";
                productTxt.Text = "";
                lotTxt.Text = "";
                recipeUDITxt.Text = "";
                toolConfirmTxt.Text = "";
                cavMgtOptTxt.Text = "";
                usingUDITxt.Text = "";
                rfidTxt.Text = "";
            }
        }
        //when exit is clicked, closes app
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        // when recipe loader in edit tab is clicked
        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            //opens new instance of filebrowser
            FileBrowser fileBrowser = new FileBrowser();
            if (fileBrowser.ShowDialog() == true)
            {

            }
        }
        // Allows only numeric input from user for RFID textbox
        private void TextBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = !IsValid(((System.Windows.Controls.TextBox)sender).Text + e.Text);
        }
        //validationn method
        public static bool IsValid(string str)
        {
            int i;
            return int.TryParse(str, out i);
        }
    }
}