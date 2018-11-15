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
    /// Interaction logic for ToolSetupWindow.xaml
    /// </summary>
    public partial class ToolSetupWindow : Window
    {
        public ToolSetupWindow()
        {
            InitializeComponent();
            ToolUDITextbox.Text = LoadedRecipe._UDIRecipe;

        }

        //Back button click event


        private void BackButton(object sender, RoutedEventArgs e)
        {
            this.Close();
            if (ToolConfCheckBox.IsChecked == true)
            {
                LoadedRecipe.numCavUsed = Convert.ToInt32(NumCavsTextbox.Text);
            }
        }

        //Tool Confirmation checkbox event
        private void ToolConfChecked(object sender, EventArgs e)
        {
            if (ToolConfCheckBox.IsChecked == true)
            {
                NumCavsTextbox.Visibility = Visibility.Visible;
                NumCavsLabel.Visibility = Visibility.Visible;
                ToolUDILabel.Visibility = Visibility.Visible;
                ToolUDITextbox.Visibility = Visibility.Visible;
                if (String.IsNullOrWhiteSpace(ToolUDITextbox.Text) == true || String.IsNullOrWhiteSpace(NumCavsTextbox.Text) == true)
                {
                    ErrorMessage.Visibility = Visibility.Visible;
                    BackButton2.IsEnabled = false;
                }
                else
                {
                    ErrorMessage.Visibility = Visibility.Hidden;
                    BackButton2.IsEnabled = true;
                }
            }
            else if (ToolConfCheckBox.IsChecked == false)
            {
                NumCavsTextbox.Visibility = Visibility.Hidden;
                NumCavsLabel.Visibility = Visibility.Hidden;
                ToolUDILabel.Visibility = Visibility.Hidden;
                ToolUDITextbox.Visibility = Visibility.Hidden;
                ErrorMessage.Visibility = Visibility.Hidden;
                BackButton2.IsEnabled = true;
            }

        }

        // Allows only numeric input from user for Number of Cavities in the Tool textbox
        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsValid(((TextBox)sender).Text + e.Text);
        }

        public static bool IsValid(string str)
        {
            int i;
            return int.TryParse(str, out i) && i >= 1 && i <= 8;
        }


        //checks for input in NumCavs Textbox
        private void NumCavsTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (ToolConfCheckBox.IsChecked == true)
            {
                if (String.IsNullOrWhiteSpace(ToolUDITextbox.Text) == true || String.IsNullOrWhiteSpace(NumCavsTextbox.Text) == true)
                {
                    ErrorMessage.Visibility = Visibility.Visible;
                    BackButton2.IsEnabled = false;
                }
                else if (String.IsNullOrWhiteSpace(NumCavsTextbox.Text) == false && String.IsNullOrWhiteSpace(ToolUDITextbox.Text) == false || ToolConfCheckBox.IsChecked == false)
                {
                    ErrorMessage.Visibility = Visibility.Hidden;
                    BackButton2.IsEnabled = true;
                }
            }
            else
            {
                ErrorMessage.Visibility = Visibility.Hidden;
                BackButton2.IsEnabled = true;
            }
        }


        //checks for input in UDI Textbox
        private void ToolUDITextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (ToolConfCheckBox.IsChecked == true)
            {
                if (String.IsNullOrWhiteSpace(ToolUDITextbox.Text) == true || String.IsNullOrWhiteSpace(NumCavsTextbox.Text) == true)
                {
                    ErrorMessage.Visibility = Visibility.Visible;
                    BackButton2.IsEnabled = false;
                }
                else if (String.IsNullOrWhiteSpace(NumCavsTextbox.Text) == false && String.IsNullOrWhiteSpace(ToolUDITextbox.Text) == false || ToolConfCheckBox.IsChecked == false)
                {
                    ErrorMessage.Visibility = Visibility.Hidden;
                    BackButton2.IsEnabled = true;
                }
            }
            else
            {
                ErrorMessage.Visibility = Visibility.Hidden;
                BackButton2.IsEnabled = true;
            }
        }
    }
}
