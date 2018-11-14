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
    /// Interaction logic for ChooseRecipe.xaml
    /// </summary>
    public partial class ChooseRecipe : Window
    {
        public ChooseRecipe()
        {
            InitializeComponent();
            selectRecipe.Items.Clear();
            foreach(string recipe in LoadedRecipe.filerows)
            {
                selectRecipe.Items.Add(recipe.Split(',')[0]);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(selectRecipe.SelectedIndex != -1)
            {
                string[] tempServerData = LoadedRecipe.filerows[selectRecipe.SelectedIndex].Split(',');
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
            }else
            {
                LoadedRecipe.recipeID = -1;
                this.Close();
            }   
        }
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
            LoadedRecipe._recUDI3 = "";
            LoadedRecipe._recUDI4 = "";
            LoadedRecipe._recUDI5 = "";
            LoadedRecipe._recUDI6 = "";
            LoadedRecipe._recUDI7 = "";
            LoadedRecipe._recUDI8 = "";
            LoadedRecipe._recUDI9 = "";
            this.Close();
        }
    }
}
