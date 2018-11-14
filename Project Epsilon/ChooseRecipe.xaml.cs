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
                if (tempServerData[1].Length > 0) { LoadedRecipe._product = tempServerData[1]; }
                if (tempServerData[2].Length > 0) { LoadedRecipe._lotNumber = Convert.ToInt32(tempServerData[2]); }
                if (tempServerData[3].Length > 0) { LoadedRecipe._recipeNumber = Convert.ToInt32(tempServerData[3]); }
                if (tempServerData[4].Length > 0) { LoadedRecipe._pressureUpperAlarmValue = Convert.ToInt32(tempServerData[4]); }
                if (tempServerData[5].Length > 0) { LoadedRecipe._pressureLowerAlarmValue = Convert.ToInt32(tempServerData[5]); }
                if (tempServerData[6].Length > 0) { LoadedRecipe._pressureSetpointFromOIT = Convert.ToInt32(tempServerData[6]); }
                if (tempServerData[7].Length > 0) { LoadedRecipe._tempHigherAlarmValue = Convert.ToInt32(tempServerData[7]); }
                if (tempServerData[8].Length > 0) { LoadedRecipe._tempLowerAlarmValue = Convert.ToInt32(tempServerData[8]); }
                if (tempServerData[9].Length > 0) { LoadedRecipe._tempSetpoint = Convert.ToInt32(tempServerData[9]); }
                if (tempServerData[10].Length > 0) { LoadedRecipe._sealTime = Convert.ToDouble(tempServerData[10]); }
                if (tempServerData[11].Length > 0) { LoadedRecipe._recipeName = tempServerData[11]; }
                if (tempServerData[12].Length > 0) { LoadedRecipe._projectName = tempServerData[12]; }
                if (tempServerData[13].Length > 0) { LoadedRecipe._RFIDNumber = Convert.ToInt32(tempServerData[13]); }
                if (tempServerData[14].Length > 0) { LoadedRecipe._UDIRecipe = tempServerData[14]; }
                if (tempServerData[15].Length > 0) { LoadedRecipe._avTagRecipeLotSealed = Convert.ToInt32(tempServerData[15]); }
                if (tempServerData[16].Length > 0) { LoadedRecipe._avTagRecipeLotToSeal = Convert.ToInt32(tempServerData[16]); }
                if (tempServerData[17].Length > 0) { LoadedRecipe._recipeName = tempServerData[17]; }
                if (tempServerData[18].Length > 0) { LoadedRecipe._recipeGeneratedBy = tempServerData[18]; }
                if (tempServerData[19].Length > 0) { LoadedRecipe._recipeGeneratedOn = tempServerData[19]; }
                if (tempServerData[20].Length > 0) { LoadedRecipe._recToolRequired = Convert.ToInt32(tempServerData[20]); }
                if (tempServerData[21].Length > 0) { LoadedRecipe._cavMethod2Required = Convert.ToInt32(tempServerData[21]); }
                if (tempServerData[22].Length > 0) { LoadedRecipe._UDIRecipeTool = Convert.ToDouble(tempServerData[22]); }
                if (tempServerData[23].Length > 0) { LoadedRecipe._cavMethodOneSelected = Convert.ToInt32(tempServerData[23]); }
                if (tempServerData[24].Length > 0) { LoadedRecipe._cavMethodTwoSelected = Convert.ToInt32(tempServerData[24]); }
                if (tempServerData[25].Length > 0) { LoadedRecipe._cavMgtUsed = Convert.ToInt32(tempServerData[25]); }
                if (tempServerData[26].Length > 0) { LoadedRecipe._recUDI1 = tempServerData[26]; }
                if (tempServerData[27].Length > 0) { LoadedRecipe._recUDI3 = tempServerData[27]; }
                if (tempServerData[28].Length > 0) { LoadedRecipe._recUDI4 = tempServerData[28]; }
                if (tempServerData[29].Length > 0) { LoadedRecipe._recUDI5 = tempServerData[29]; }
                if (tempServerData[30].Length > 0) { LoadedRecipe._recUDI6 = tempServerData[30]; }
                if (tempServerData[31].Length > 0) { LoadedRecipe._recUDI7 = tempServerData[31]; }
                if (tempServerData[32].Length > 0) { LoadedRecipe._recUDI8 = tempServerData[32]; }
                if (tempServerData[33].Length > 0) { LoadedRecipe._recUDI9 = tempServerData[33]; }
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
