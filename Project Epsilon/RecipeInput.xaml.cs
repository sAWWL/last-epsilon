﻿using System;
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
            double highTempAlarm;
            double tempSetPoint;
            double lowTemp;
            double sealTime;
            double highPress;
            double pressSet;
            double lowPressure;

            if (String.IsNullOrWhiteSpace(recipeTxt.Text) || String.IsNullOrWhiteSpace(productTxt.Text) || String.IsNullOrWhiteSpace(lotTxt.Text) ||
                String.IsNullOrWhiteSpace(recipeUDITxt.Text) || String.IsNullOrWhiteSpace(highTempTxt.Text) || String.IsNullOrWhiteSpace(tempSetTxt.Text) ||
                String.IsNullOrWhiteSpace(lowTempTxt.Text) || String.IsNullOrWhiteSpace(sealTimeTxt.Text) || String.IsNullOrWhiteSpace(highPressTxt.Text) ||
                String.IsNullOrWhiteSpace(pressSetTxt.Text) || String.IsNullOrWhiteSpace(lowPressureTxt.Text) || cavMgtOptTxt.SelectedIndex == -1 ||
                toolConfirmTxt.SelectedIndex == -1 || usingUDITxt.SelectedIndex == -1)
            {
                errorTxt.Visibility = Visibility.Visible;
                saveRecipe.IsEnabled = false;
                errorTxt.Content = "All Fields (except RFID) are Required";
            }
            else if (!Double.TryParse(highTempTxt.Text, out highTempAlarm) || !Double.TryParse(tempSetTxt.Text, out tempSetPoint) || !Double.TryParse(lowTempTxt.Text, out tempSetPoint)
                || !Double.TryParse(sealTimeTxt.Text, out sealTime) || !Double.TryParse(highPressTxt.Text, out highPress)
                || !Double.TryParse(pressSetTxt.Text, out pressSet) || !Double.TryParse(lowPressureTxt.Text, out lowPressure))
            {
                errorTxt.Visibility = Visibility.Visible;
                saveRecipe.IsEnabled = false;
                errorTxt.Content = "Below fields must be numeric input only";
            }
            else if (recipeUDITxt.Text.Length != 40)
            {
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
                    errorTxt.Visibility = Visibility.Visible;
                    saveRecipe.IsEnabled = false;
                    errorTxt.Content = "Fix High Temperature. It is Lower than Temp Setpoint";
                }
                else if (highTempAlarm >= 250)
                {
                    errorTxt.Visibility = Visibility.Visible;
                    saveRecipe.IsEnabled = false;
                    errorTxt.Content = "High Temp Alarm must be less than 250 degrees";
                }
                else if (lowTemp >= tempSetPoint)
                {
                    errorTxt.Visibility = Visibility.Visible;
                    saveRecipe.IsEnabled = false;
                    errorTxt.Content = "Fix Low Temperature. It is Greater than Temp Setpoint";
                }
                else if (lowTemp <= 50)
                {
                    errorTxt.Visibility = Visibility.Visible;
                    saveRecipe.IsEnabled = false;
                    errorTxt.Content = "Low Temp Alarm must be greater than 50 degrees";
                }
                else if (sealTime <= 0)
                {
                    errorTxt.Visibility = Visibility.Visible;
                    saveRecipe.IsEnabled = false;
                    errorTxt.Content = "Fix Seal Time. Seal Time must be greater than 0 seconds";
                }
                else if (sealTime >= 10)
                {
                    errorTxt.Visibility = Visibility.Visible;
                    saveRecipe.IsEnabled = false;
                    errorTxt.Content = "Fix Seal Time. Seal Time must be less than 10 seconds";
                }
                else if (highPress <= pressSet)
                {
                    errorTxt.Visibility = Visibility.Visible;
                    saveRecipe.IsEnabled = false;
                    errorTxt.Content = "Fix High Pressure. It is Lower than Pressure Setpoint";
                }
                else if (highPress >= 125)
                {
                    errorTxt.Visibility = Visibility.Visible;
                    saveRecipe.IsEnabled = false;
                    errorTxt.Content = "High Pressure Alarm must be less than 125 PSI";
                }
                else if (lowPressure >= pressSet)
                {
                    errorTxt.Visibility = Visibility.Visible;
                    saveRecipe.IsEnabled = false;
                    errorTxt.Content = "Fix Low Pressure. It is Greater than Pressure Setpoint";
                }
                else if (lowPressure <= 0)
                {
                    errorTxt.Visibility = Visibility.Visible;
                    saveRecipe.IsEnabled = false;
                    errorTxt.Content = "Low Pressure Alarm must be greater than 0 PSI";
                }
                else
                {
                    errorTxt.Visibility = Visibility.Hidden;
                    saveRecipe.IsEnabled = true;
                }
            }
        }
        private void optionsBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            OptionsMenu winOptionsMenu = new OptionsMenu();
            winOptionsMenu.Show();
            LoadedRecipe._UDIRecipe = recipeUDITxt.Text;
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
            if (fileBrowser.ShowDialog() == true)
            {

            }
            else
            {
                recipeTxt.Text = Convert.ToString(LoadedRecipe._recipeName);
                productTxt.Text = Convert.ToString(LoadedRecipe._product);
                recipeUDITxt.Text = Convert.ToString(LoadedRecipe._UDIRecipe);
                toolConfirmTxt.Text = Convert.ToString(LoadedRecipe._recToolRequired);
                if (toolConfirmTxt.Text == "1")
                {
                    toolConfirmTxt.SelectedIndex = 0;
                }
                else if (toolConfirmTxt.Text == "0")
                {
                    toolConfirmTxt.SelectedIndex = 1;
                }
                else
                {
                    toolConfirmTxt.SelectedItem = null;
                }
                cavMgtOptTxt.Text = Convert.ToString(LoadedRecipe._cavMgtUsed);
                if (cavMgtOptTxt.Text == "1")
                {
                    cavMgtOptTxt.SelectedIndex = 0;
                }
                else if (cavMgtOptTxt.Text == "0")
                {
                    cavMgtOptTxt.SelectedIndex = 1;
                }
                else
                {
                    cavMgtOptTxt.SelectedItem = null;
                }
                usingUDITxt.Text = Convert.ToString(LoadedRecipe._recUDI1);
                if (usingUDITxt.Text == "1")
                {
                    usingUDITxt.SelectedIndex = 0;
                }
                else if (usingUDITxt.Text == "0")
                {
                    usingUDITxt.SelectedIndex = 1;
                }
                else
                {
                    usingUDITxt.SelectedItem = null;
                }
                lotTxt.Text = Convert.ToString(LoadedRecipe._lotNumber);
                rfidTxt.Text = Convert.ToString(LoadedRecipe._RFIDNumber);
                highTempTxt.Text = Convert.ToString(LoadedRecipe._tempHigherAlarmValue);
                tempSetTxt.Text = Convert.ToString(LoadedRecipe._tempSetpoint);
                lowTempTxt.Text = Convert.ToString(LoadedRecipe._tempLowerAlarmValue);
                sealTimeTxt.Text = Convert.ToString(LoadedRecipe._sealTime);
                pressSetTxt.Text = Convert.ToString(LoadedRecipe._pressureSetpointFromOIT);
                highPressTxt.Text = Convert.ToString(LoadedRecipe._pressureUpperAlarmValue);
                lowPressureTxt.Text = Convert.ToString(LoadedRecipe._pressureLowerAlarmValue);
                double highTempAlarm;
                double tempSetPoint;
                double lowTemp;
                double sealTime;
                double highPress;
                double pressSet;
                double lowPressure;

                if (String.IsNullOrWhiteSpace(recipeTxt.Text) || String.IsNullOrWhiteSpace(productTxt.Text) || String.IsNullOrWhiteSpace(lotTxt.Text) ||
                String.IsNullOrWhiteSpace(recipeUDITxt.Text) || String.IsNullOrWhiteSpace(highTempTxt.Text) || String.IsNullOrWhiteSpace(tempSetTxt.Text) ||
                String.IsNullOrWhiteSpace(lowTempTxt.Text) || String.IsNullOrWhiteSpace(sealTimeTxt.Text) || String.IsNullOrWhiteSpace(highPressTxt.Text) ||
                String.IsNullOrWhiteSpace(pressSetTxt.Text) || String.IsNullOrWhiteSpace(lowPressureTxt.Text) || cavMgtOptTxt.SelectedIndex == -1 ||
                toolConfirmTxt.SelectedIndex == -1 || usingUDITxt.SelectedIndex == -1)
                {
                    errorTxt.Visibility = Visibility.Visible;
                    saveRecipe.IsEnabled = false;
                    errorTxt.Content = "All Fields (except RFID) are Required";
                }
                else if (!Double.TryParse(highTempTxt.Text, out highTempAlarm) || !Double.TryParse(tempSetTxt.Text, out tempSetPoint) || !Double.TryParse(lowTempTxt.Text, out tempSetPoint)
                    || !Double.TryParse(sealTimeTxt.Text, out sealTime) || !Double.TryParse(highPressTxt.Text, out highPress)
                    || !Double.TryParse(pressSetTxt.Text, out pressSet) || !Double.TryParse(lowPressureTxt.Text, out lowPressure))
                {
                    errorTxt.Visibility = Visibility.Visible;
                    saveRecipe.IsEnabled = false;
                    errorTxt.Content = "Below fields must be numeric input only";
                }
                else if (recipeUDITxt.Text.Length != 40)
                {
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
                        errorTxt.Visibility = Visibility.Visible;
                        saveRecipe.IsEnabled = false;
                        errorTxt.Content = "Fix High Temperature. It is Lower than Temp Setpoint";
                    }
                    else if (highTempAlarm >= 250)
                    {
                        errorTxt.Visibility = Visibility.Visible;
                        saveRecipe.IsEnabled = false;
                        errorTxt.Content = "High Temp Alarm must be less than 250 degrees";
                    }
                    else if (lowTemp >= tempSetPoint)
                    {
                        errorTxt.Visibility = Visibility.Visible;
                        saveRecipe.IsEnabled = false;
                        errorTxt.Content = "Fix Low Temperature. It is Greater than Temp Setpoint";
                    }
                    else if (lowTemp <= 50)
                    {
                        errorTxt.Visibility = Visibility.Visible;
                        saveRecipe.IsEnabled = false;
                        errorTxt.Content = "Low Temp Alarm must be greater than 50 degrees";
                    }
                    else if (sealTime <= 0)
                    {
                        errorTxt.Visibility = Visibility.Visible;
                        saveRecipe.IsEnabled = false;
                        errorTxt.Content = "Fix Seal Time. Seal Time must be greater than 0 seconds";
                    }
                    else if (sealTime >= 10)
                    {
                        errorTxt.Visibility = Visibility.Visible;
                        saveRecipe.IsEnabled = false;
                        errorTxt.Content = "Fix Seal Time. Seal Time must be less than 10 seconds";
                    }
                    else if (highPress <= pressSet)
                    {
                        errorTxt.Visibility = Visibility.Visible;
                        saveRecipe.IsEnabled = false;
                        errorTxt.Content = "Fix High Pressure. It is Lower than Pressure Setpoint";
                    }
                    else if (highPress >= 125)
                    {
                        errorTxt.Visibility = Visibility.Visible;
                        saveRecipe.IsEnabled = false;
                        errorTxt.Content = "High Pressure Alarm must be less than 125 PSI";
                    }
                    else if (lowPressure >= pressSet)
                    {
                        errorTxt.Visibility = Visibility.Visible;
                        saveRecipe.IsEnabled = false;
                        errorTxt.Content = "Fix Low Pressure. It is Greater than Pressure Setpoint";
                    }
                    else if (lowPressure <= 0)
                    {
                        errorTxt.Visibility = Visibility.Visible;
                        saveRecipe.IsEnabled = false;
                        errorTxt.Content = "Low Pressure Alarm must be greater than 0 PSI";
                    }
                    else
                    {
                        errorTxt.Visibility = Visibility.Hidden;
                        saveRecipe.IsEnabled = true;
                    }
                }
            }
        }
        

        private void saveRecipe_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (toolConfirmTxt.SelectedIndex == 0)
            {
                LoadedRecipe._recToolRequired = 1;
            }
            else if (toolConfirmTxt.SelectedIndex == 1)
            {
                LoadedRecipe._recToolRequired = 0;
            }


            //cavMgtOptTxt combobox to csv
            if (cavMgtOptTxt.SelectedIndex == 0)
            {
                LoadedRecipe._cavMgtUsed = 1;
            }
            else if (cavMgtOptTxt.SelectedIndex == 1)
            {
                LoadedRecipe._cavMgtUsed = 0;
            }


            //usingUDITxt combobox to csv
            if (usingUDITxt.SelectedIndex == 0)
            {
                LoadedRecipe._recUDI1 = "1";
            }
            else if (usingUDITxt.SelectedIndex == 1)
            {
                LoadedRecipe._recUDI1 = "0";
            }
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
            
            LoadedRecipe.filerows[LoadedRecipe.recipeID] = LoadedRecipe._recipeName + "," + LoadedRecipe._product + "," + LoadedRecipe._lotNumber + "," + LoadedRecipe._recipeNumber + "," + LoadedRecipe._pressureUpperAlarmValue + "," + LoadedRecipe._pressureLowerAlarmValue + "," + LoadedRecipe._pressureSetpointFromOIT + "," + LoadedRecipe._tempHigherAlarmValue + "," + LoadedRecipe._tempLowerAlarmValue + "," + LoadedRecipe._tempSetpoint + "," + LoadedRecipe._sealTime + "," + "0" + "," + LoadedRecipe._projectName + "," + LoadedRecipe._RFIDNumber + "," + LoadedRecipe._UDIRecipe + "," + LoadedRecipe._avTagRecipeLotSealed + "," + LoadedRecipe._avTagRecipeLotToSeal + "," + LoadedRecipe._recipeName + "," + LoadedRecipe._recipeGeneratedBy + "," + LoadedRecipe._recipeGeneratedOn + "," + LoadedRecipe._recToolRequired + "," + LoadedRecipe._cavMethod2Required + "," + LoadedRecipe._UDIRecipeTool + "," + LoadedRecipe._cavMethodOneSelected + "," + LoadedRecipe._cavMethodTwoSelected + "," + LoadedRecipe._cavMgtUsed + "," + LoadedRecipe._recUDI1 + "," + LoadedRecipe._recUDI3 + "," + LoadedRecipe._recUDI4 + "," + LoadedRecipe._recUDI5 + "," + LoadedRecipe._recUDI6 + "," + LoadedRecipe._recUDI7 + "," + LoadedRecipe._recUDI8 + "," + LoadedRecipe._recUDI9;

            try
            {
                FtpWebRequest deletereq = (FtpWebRequest)WebRequest.Create("ftp://" + LoadedRecipe.host + ":" + LoadedRecipe.port + "/Recipe1.csv");

                deletereq.Method = WebRequestMethods.Ftp.DeleteFile;

                PasswordInput passwordInput = new PasswordInput();

                if (passwordInput.ShowDialog() == false)
                {
                    deletereq.Credentials = new NetworkCredential(LoadedRecipe.username, LoadedRecipe.password);

                    FtpWebResponse response = (FtpWebResponse)deletereq.GetResponse();

                }
            }
            catch
            {

            }
            FtpWebRequest uploadreq = (FtpWebRequest)WebRequest.Create("ftp://" + LoadedRecipe.host + ":" + LoadedRecipe.port + "/Recipe1.csv");
            uploadreq.Credentials = new NetworkCredential(LoadedRecipe.username, LoadedRecipe.password);       
            uploadreq.Method = WebRequestMethods.Ftp.UploadFile;
            string outputstring = LoadedRecipe.headerrow;
            foreach (string row in LoadedRecipe.filerows)

            {
                outputstring += row + "\n";
            }

            byte[] bytes = Encoding.UTF8.GetBytes(outputstring);

            try
            {
                Stream requestStream = uploadreq.GetRequestStream();
                requestStream.Write(bytes, 0, bytes.Length);
                requestStream.Close();
            }

            catch
            {
                MessageBox.Show("There was an error while uploading Recipe File. Please check your connection and try again!");
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

            if (String.IsNullOrWhiteSpace(recipeTxt.Text) || String.IsNullOrWhiteSpace(productTxt.Text) || String.IsNullOrWhiteSpace(lotTxt.Text) ||
                String.IsNullOrWhiteSpace(recipeUDITxt.Text) || String.IsNullOrWhiteSpace(highTempTxt.Text) || String.IsNullOrWhiteSpace(tempSetTxt.Text) ||
                String.IsNullOrWhiteSpace(lowTempTxt.Text) || String.IsNullOrWhiteSpace(sealTimeTxt.Text) || String.IsNullOrWhiteSpace(highPressTxt.Text) ||
                String.IsNullOrWhiteSpace(pressSetTxt.Text) || String.IsNullOrWhiteSpace(lowPressureTxt.Text) || cavMgtOptTxt.SelectedIndex == -1 ||
                toolConfirmTxt.SelectedIndex == -1 || usingUDITxt.SelectedIndex == -1)
            {
                errorTxt.Visibility = Visibility.Visible;
                saveRecipe.IsEnabled = false;
                errorTxt.Content = "All Fields (except RFID) are Required";
            }
            else if (!Double.TryParse(highTempTxt.Text, out highTempAlarm) || !Double.TryParse(tempSetTxt.Text, out tempSetPoint) || !Double.TryParse(lowTempTxt.Text, out tempSetPoint)
                || !Double.TryParse(sealTimeTxt.Text, out sealTime) || !Double.TryParse(highPressTxt.Text, out highPress)
                || !Double.TryParse(pressSetTxt.Text, out pressSet) || !Double.TryParse(lowPressureTxt.Text, out lowPressure))
            {
                errorTxt.Visibility = Visibility.Visible;
                saveRecipe.IsEnabled = false;
                errorTxt.Content = "Below fields must be numeric input only";
            }
            else if (recipeUDITxt.Text.Length != 40)
            {
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
                    errorTxt.Visibility = Visibility.Visible;
                    saveRecipe.IsEnabled = false;
                    errorTxt.Content = "Fix High Temperature. It is Lower than Temp Setpoint";
                }
                else if (highTempAlarm >= 250)
                {
                    errorTxt.Visibility = Visibility.Visible;
                    saveRecipe.IsEnabled = false;
                    errorTxt.Content = "High Temp Alarm must be less than 250 degrees";
                }
                else if (lowTemp >= tempSetPoint)
                {
                    errorTxt.Visibility = Visibility.Visible;
                    saveRecipe.IsEnabled = false;
                    errorTxt.Content = "Fix Low Temperature. It is Greater than Temp Setpoint";
                }
                else if (lowTemp <= 50)
                {
                    errorTxt.Visibility = Visibility.Visible;
                    saveRecipe.IsEnabled = false;
                    errorTxt.Content = "Low Temp Alarm must be greater than 50 degrees";
                }
                else if (sealTime <= 0)
                {
                    errorTxt.Visibility = Visibility.Visible;
                    saveRecipe.IsEnabled = false;
                    errorTxt.Content = "Fix Seal Time. Seal Time must be greater than 0 seconds";
                }
                else if (sealTime >= 10)
                {
                    errorTxt.Visibility = Visibility.Visible;
                    saveRecipe.IsEnabled = false;
                    errorTxt.Content = "Fix Seal Time. Seal Time must be less than 10 seconds";
                }
                else if (highPress <= pressSet)
                {
                    errorTxt.Visibility = Visibility.Visible;
                    saveRecipe.IsEnabled = false;
                    errorTxt.Content = "Fix High Pressure. It is Lower than Pressure Setpoint";
                }
                else if (highPress >= 125)
                {
                    errorTxt.Visibility = Visibility.Visible;
                    saveRecipe.IsEnabled = false;
                    errorTxt.Content = "High Pressure Alarm must be less than 125 PSI";
                }
                else if (lowPressure >= pressSet)
                {
                    errorTxt.Visibility = Visibility.Visible;
                    saveRecipe.IsEnabled = false;
                    errorTxt.Content = "Fix Low Pressure. It is Greater than Pressure Setpoint";
                }
                else if (lowPressure <= 0)
                {
                    errorTxt.Visibility = Visibility.Visible;
                    saveRecipe.IsEnabled = false;
                    errorTxt.Content = "Low Pressure Alarm must be greater than 0 PSI";
                }
                else
                {
                    errorTxt.Visibility = Visibility.Hidden;
                    saveRecipe.IsEnabled = true;
                }
            }
        }

        private void clearBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure you wish to clear all fields?", "Clear Fields Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
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
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
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

        public static bool IsValid(string str)
        {
            int i;
            return int.TryParse(str, out i);
        }
    }
}
