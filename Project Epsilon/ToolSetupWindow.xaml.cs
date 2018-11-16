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

            //puts variable from LoadedRecipe into textbox
            ToolUDITextbox.Text = LoadedRecipe._UDIRecipe;
        }

        //Back button click event
        private void BackButton(object sender, RoutedEventArgs e)
        {
            //closes current window
            this.Close();

            //creates new instance of page RecipeInput
            //shows new page as primary page
            RecipeInput RecipeInput = new RecipeInput();
            RecipeInput.Show();

            //if the tool checkbox is checked
            //Convert to integer, load intoo numCavUsed variable
            if (ToolConfCheckBox.IsChecked == true)
            {
                LoadedRecipe.numCavUsed = Convert.ToInt32(NumCavsTextbox.Text);
            }
        }

        //Tool Confirmation checkbox event
        private void ToolConfChecked(object sender, EventArgs e)
        {
            //if tool checkbox is checked
            if (ToolConfCheckBox.IsChecked == true)
            {
                //assigns value "1" to variable
                LoadedRecipe._recToolRequired = 1;
                
                //Makes these controls visible
                NumCavsTextbox.Visibility = Visibility.Visible;
                NumCavsLabel.Visibility = Visibility.Visible;
                ToolUDILabel.Visibility = Visibility.Visible;
                ToolUDITextbox.Visibility = Visibility.Visible;
                
                //tests textboxes is box is null or just empty with white spaces
                if (String.IsNullOrWhiteSpace(ToolUDITextbox.Text) == true || String.IsNullOrWhiteSpace(NumCavsTextbox.Text) == true)
                {
                    //if true, display error message
                    //disables back button
                    ErrorMessage.Visibility = Visibility.Visible;
                    BackButton2.IsEnabled = false;
                }
                //hides error message and enables back button
                else
                {
                    ErrorMessage.Visibility = Visibility.Hidden;
                    BackButton2.IsEnabled = true;
                }
            }
            //if the toool check boxx is unchecked
            else if (ToolConfCheckBox.IsChecked == false)
            {
                //assigns value of "1" to variable
                LoadedRecipe._recToolRequired = 0;

                //Makes these controls invisible
                NumCavsTextbox.Visibility = Visibility.Hidden;
                NumCavsLabel.Visibility = Visibility.Hidden;
                ToolUDILabel.Visibility = Visibility.Hidden;
                ToolUDITextbox.Visibility = Visibility.Hidden;
                ErrorMessage.Visibility = Visibility.Hidden;

                //Enables back button
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
            //only numbers from 1 to 8 are accepted
            int i;
            return int.TryParse(str, out i) && i >= 1 && i <= 8;
        }


        //checks for input in NumCavs Textbox
        private void NumCavsTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //if tool checkbo is checked
            if (ToolConfCheckBox.IsChecked == true)
            {

                //tests textboxes is box is null or just empty with white spaces
                if (String.IsNullOrWhiteSpace(ToolUDITextbox.Text) == true || String.IsNullOrWhiteSpace(NumCavsTextbox.Text) == true)
                {
                    //error message is visible
                    ErrorMessage.Visibility = Visibility.Visible;
                    //disables back button
                    BackButton2.IsEnabled = false;
                }
                //tests textboxes is box is null or just empty with white spaces
                //if tests fails (boxes are filled with items)
                else if (String.IsNullOrWhiteSpace(NumCavsTextbox.Text) == false && String.IsNullOrWhiteSpace(ToolUDITextbox.Text) == false || ToolConfCheckBox.IsChecked == false)
                {
                    //error message in invisible
                    ErrorMessage.Visibility = Visibility.Hidden;
                    //Enables back button
                    BackButton2.IsEnabled = true;
                }
            }
            //else
            else
            {

                //error message is hidden
                ErrorMessage.Visibility = Visibility.Hidden;
                //back button is enabled
                BackButton2.IsEnabled = true;
            }
        }


        //checks for input in UDI Textbox
        private void ToolUDITextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //checks if text changed in this textbox
            if (ToolConfCheckBox.IsChecked == true)
            {
                //tests textboxes is box is null or just empty with white spaces
                if (String.IsNullOrWhiteSpace(ToolUDITextbox.Text) == true || String.IsNullOrWhiteSpace(NumCavsTextbox.Text) == true)
                {
                    //error message is visible
                    ErrorMessage.Visibility = Visibility.Visible;
                    //back button is disabled
                    BackButton2.IsEnabled = false;
                }
                // //tests textboxes is box is null or just empty with white spaces
                else if (String.IsNullOrWhiteSpace(NumCavsTextbox.Text) == false && String.IsNullOrWhiteSpace(ToolUDITextbox.Text) == false || ToolConfCheckBox.IsChecked == false)
                {
                    //error message is hidden
                    ErrorMessage.Visibility = Visibility.Hidden;
                    
                    //back button is enabled
                    BackButton2.IsEnabled = true;
                }
            }
            //else
            else
            {

                //error message is hidden
                ErrorMessage.Visibility = Visibility.Hidden;

                //back button is enabled
                BackButton2.IsEnabled = true;
            }
        }
    }
}
