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

            if (LoadedRecipe._cavMethodOneSelected == 1)
            {
                methodOneCheckbox.IsChecked = true;
            }

            if (LoadedRecipe._cavMethodTwoSelected == 1)
            {
                methodTwoCheckbox.IsChecked = true;
            }
            numCavitiesTxtBox.Text = Convert.ToString(LoadedRecipe._cavMgtUsed);
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            if (methodOneCheckbox.IsChecked == true)
            {
                LoadedRecipe._cavMethodOneSelected = 1;
            }
            else
            {
                LoadedRecipe._cavMethodOneSelected = 0;
            }

            if (methodTwoCheckbox.IsChecked == true)
            {
                LoadedRecipe._cavMethodTwoSelected = 1;
            }
            else
            {
                LoadedRecipe._cavMethodTwoSelected = 0;
            }
            LoadedRecipe._cavMgtUsed = Convert.ToInt32(numCavitiesTxtBox.Text);

            if( methodOneCheckbox.IsChecked == true || methodTwoCheckbox.IsChecked == true)
            {
                LoadedRecipe.cavUsed = true;
            }
            this.Close();          
        }
        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsValid(((TextBox)sender).Text + e.Text);
        }

        public static bool IsValid(string str)
        {
            int i;
            return int.TryParse(str, out i) && i >= 1 && i <= 8;
        }

    }
}
