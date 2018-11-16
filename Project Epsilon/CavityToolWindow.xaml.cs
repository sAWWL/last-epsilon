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
    /// Interaction logic for CavityToolWindow.xaml
    /// </summary>
    public partial class CavityToolWindow : Window
    {
        public CavityToolWindow()
        {
            InitializeComponent();

            //if LoadedRecipe._cavMethodOneSelected has a value of 1
            if (LoadedRecipe._cavMethodOneSelected == 1)
            {
                //unchecks method two checkbox
                methodTwoCheckbox.IsChecked = false;
            }
            //if LoadedRecipe._cavMethodTwoSelected has a value of 1
            if (LoadedRecipe._cavMethodTwoSelected == 1)
            {
                //Checks method two checkbox
                methodTwoCheckbox.IsChecked = true;
            }
            //Converts numCavUsed to a string
            //Displays it as text in textbox
            numCavitiesTxtBox.Text = Convert.ToString(LoadedRecipe.numCavUsed);
            if (LoadedRecipe._recToolRequired == 1)
            {
                numCavitiesTxtBox.IsReadOnly = true;
            }
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            LoadedRecipe.numCavUsed = Convert.ToInt32(numCavitiesTxtBox.Text);

            //Assigns method one checkbox a number when button is pressed.
            //If method one checkbox is checked, then value assigned is 1
            if (methodOneCheckbox.IsChecked == true)
            {
                LoadedRecipe._cavMethodOneSelected = 1;
            }
            //else value assigned is 0
            else
            {
                LoadedRecipe._cavMethodOneSelected = 0;
            }
            //Assigns method two checkbox a number when button is pressed.
            //If method two checkbox is checked, then value assigned is 1, otherwise it is 0.
            if (methodTwoCheckbox.IsChecked == true)
            {
                LoadedRecipe._cavMethodTwoSelected = 1;
            }
            else
            {
                LoadedRecipe._cavMethodTwoSelected = 0;
            }
            //Converts the input in textbox to a number.
            //Stores it in variable numCavUsed to be used in the LoadedRecipes page
            LoadedRecipe.numCavUsed = Convert.ToInt32(numCavitiesTxtBox.Text);

            //if either checkboox is checked, then assigns "true" to loaded recipe cavUsed
            if( methodOneCheckbox.IsChecked == true || methodTwoCheckbox.IsChecked == true)
            {
                LoadedRecipe.cavUsed = true;
            }
            //Closes the current window
            this.Close();          
        }

        //runs the IsValid method for limiting input from user
        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsValid(((TextBox)sender).Text + e.Text);
        }

        //Method to limit the input from user
        public static bool IsValid(string str)
        {

            //variable/counter
            int i;

            //only input between integers 1 and 8 are accepted
            return int.TryParse(str, out i) && i >= 1 && i <= 8;
        }

        //Event for when one checkbox, it unchecks the other checkbox.
        private void MethodOneCheckbox_Checked(object sender, RoutedEventArgs e)
        {

            //If Method one checkbox is checked, method two checkbox is unchecked.
            if (methodOneCheckbox.IsChecked == true)
            {
                methodTwoCheckbox.IsChecked = false;
            }
        }

        //Event for when one checkbox, it unchecks the other checkbox.
        private void MethodTwoCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            //If method two checkbox is checked, method one checkbox is unchecked.
            if (methodTwoCheckbox.IsChecked == true)
            {
                methodOneCheckbox.IsChecked = false;
            }
        }
    }
}
