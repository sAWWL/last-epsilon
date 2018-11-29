﻿using System;
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
    /// Interaction logic for ChooseRecipe.xaml
    /// </summary>
    public partial class ChooseRecipe : Window
    {
        public ChooseRecipe()
        {
            InitializeComponent();
            selectRecipe.Focus();

            //Clears current selected recipes
            selectRecipe.Items.Clear();
            
            //adds in recipes for each value, separated by a comma
            foreach(string recipe in LoadedRecipe.filerows)
            {
                selectRecipe.Items.Add(recipe.Split(',')[0]);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            if(selectRecipe.SelectedIndex != -1)
            {
                string[] tempMachineData = LoadedRecipe.filerows[selectRecipe.SelectedIndex].Split(',');
                if (tempMachineData[1].Length > 0) { LoadedRecipe._product = tempMachineData[1]; }
                if (tempMachineData[2].Length > 0) { LoadedRecipe._lotNumber = Convert.ToInt32(tempMachineData[2]); }
                if (tempMachineData[3].Length > 0) { LoadedRecipe._recipeNumber = Convert.ToInt32(tempMachineData[3]); }
                if (tempMachineData[4].Length > 0) { LoadedRecipe._pressureUpperAlarmValue = Convert.ToInt32(tempMachineData[4]); }
                if (tempMachineData[5].Length > 0) { LoadedRecipe._pressureLowerAlarmValue = Convert.ToInt32(tempMachineData[5]); }
                if (tempMachineData[6].Length > 0) { LoadedRecipe._pressureSetpointFromOIT = Convert.ToInt32(tempMachineData[6]); }
                if (tempMachineData[7].Length > 0) { LoadedRecipe._tempHigherAlarmValue = Convert.ToInt32(tempMachineData[7]); }
                if (tempMachineData[8].Length > 0) { LoadedRecipe._tempLowerAlarmValue = Convert.ToInt32(tempMachineData[8]); }
                if (tempMachineData[9].Length > 0) { LoadedRecipe._tempSetpoint = Convert.ToInt32(tempMachineData[9]); }
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
                if (tempMachineData[26].Length > 0) { LoadedRecipe._recUDI1 = tempMachineData[26]; }
                if (tempMachineData[27].Length > 0) { LoadedRecipe._recUDI3 = tempMachineData[27]; }
                if (tempMachineData[28].Length > 0) { LoadedRecipe._recUDI4 = tempMachineData[28]; }
                if (tempMachineData[29].Length > 0) { LoadedRecipe._recUDI5 = tempMachineData[29]; }
                if (tempMachineData[30].Length > 0) { LoadedRecipe._recUDI6 = tempMachineData[30]; }
                if (tempMachineData[31].Length > 0) { LoadedRecipe._recUDI7 = tempMachineData[31]; }
                if (tempMachineData[32].Length > 0) { LoadedRecipe._recUDI8 = tempMachineData[32]; }
                if (tempMachineData[33].Length > 0) { LoadedRecipe._recUDI9 = tempMachineData[33]; }
                LoadedRecipe.recipeID = selectRecipe.SelectedIndex;
                LoadedRecipe.recipeloaded = true;
                this.Close();
            }

            //load the variable, close the page
            else
            {
                LoadedRecipe.recipeID = -1;
                LoadedRecipe.recipeloaded = true;
                this.Close();
            }   
        }
        //enters values into variables
        private void newRecipeBtn_Click(object sender, RoutedEventArgs e)
        {
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
            LoadedRecipe._recUDI1 = "";
            LoadedRecipe._recUDI3 = "e";
            LoadedRecipe._recUDI4 = "0";
            LoadedRecipe._recUDI5 = "0";
            LoadedRecipe._recUDI6 = "";
            LoadedRecipe._recUDI7 = "e";
            LoadedRecipe._recUDI8 = "0";
            LoadedRecipe._recUDI9 = "0";
            LoadedRecipe.filerows.Add("");
            LoadedRecipe.recipeloaded = true;
            LoadedRecipe.recipeloaded = true;
            this.Close();
        }

        private void deleteRecipeBtn_Click(object sender, RoutedEventArgs e)
        {

            //deletes any selected recipe(s)
            if(selectRecipe.SelectedIndex != -1)
            {
                string sMessageBoxText = "Do you want to delete the selected Recipe?";
                string sCaption = "Delete Recipe?";

                //displays message boxes and controls
                MessageBoxButton btnMessageBox = MessageBoxButton.YesNoCancel;
                MessageBoxImage icnMessageBox = MessageBoxImage.Warning;

                MessageBoxResult rsltMessageBox = MessageBox.Show(sMessageBoxText, sCaption, btnMessageBox, icnMessageBox);

                switch (rsltMessageBox)
                {
                    case MessageBoxResult.Yes:
                        LoadedRecipe.filerows.RemoveAt(selectRecipe.SelectedIndex);
                        selectRecipe.Items.Clear();
                        foreach (string recipe in LoadedRecipe.filerows)
                        {
                            selectRecipe.Items.Add(recipe.Split(',')[0]);
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
