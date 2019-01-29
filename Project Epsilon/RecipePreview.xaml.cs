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
    /// Interaction logic for RecipePreview.xaml
    /// </summary>
    public partial class RecipePreview : Window
    {
        public RecipePreview()
        {
            InitializeComponent();
            preview_recipeName.Focus();
            preview_recipeName.Text = LoadedRecipe._recipeName;
            preview_recipeProduct.Text = LoadedRecipe._product;
            preview_recipeTempHigh.Text = Convert.ToString(LoadedRecipe._tempHigherAlarmValue);
            preview_recipeTempLow.Text = Convert.ToString(LoadedRecipe._tempLowerAlarmValue);
            preview_recipeTempSet.Text = Convert.ToString(LoadedRecipe._tempSetpoint);
            preview_recipePressureHigh.Text = Convert.ToString(LoadedRecipe._pressureUpperAlarmValue);
            preview_recipePressureLow.Text = Convert.ToString(LoadedRecipe._pressureLowerAlarmValue);
            preview_recipePressureSet.Text = Convert.ToString(LoadedRecipe._pressureSetpointFromOIT);
            preview_recipeSealTime.Text = Convert.ToString(LoadedRecipe._sealTime);

        }
        //When an incorrect recipe is clicked, the current load is canceled and page is closed
        private void WrongRecipe_Click(object sender, RoutedEventArgs e)
        {
            LoadedRecipe.confirmload = false;
            this.Close();
        }
        ////When a correct recipe is clicked, the current load is canceled and page is closed
        private void CorrectRecipe_Click(object sender, RoutedEventArgs e)
        {
            LoadedRecipe.confirmload = true;
            this.Close();
        }
    }
}
