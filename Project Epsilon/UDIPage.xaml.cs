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
    /// Interaction logic for UDI.xaml
    /// </summary>
    public partial class UDIPage : Window
    {
        public UDIPage()
        {
            InitializeComponent();

            //hide items on page
            lblUDIEntireOrPartial.Visibility = Visibility.Hidden;
            txtUDIEntireOrPartial.Visibility = Visibility.Hidden;
            lblUDIFirstPosition.Visibility = Visibility.Hidden;
            txtUDIFirstPosition.Visibility = Visibility.Hidden;
            lblUDIEndingPosition.Visibility = Visibility.Hidden;
            txtUDIEndingPosition.Visibility = Visibility.Hidden;
            txtUDIPartialCompare.Visibility = Visibility.Hidden;
            lblCavityManagement.Visibility = Visibility.Hidden;
            chkCompareUDI.Visibility = Visibility.Hidden;
            lblCavUDIEntireOrPartial.Visibility = Visibility.Hidden;
            txtCavUDIEntireOrPartial.Visibility = Visibility.Hidden;
            lblCavUDIFirstPosition.Visibility = Visibility.Hidden;
            txtCavUDIFirstPosition.Visibility = Visibility.Hidden;
            lblUDIEndingPosition.Visibility = Visibility.Hidden;
            txtCavUDIFirstPosition.Visibility = Visibility.Hidden;
            lblCavUDIEndingPosition.Visibility = Visibility.Hidden;
            txtCavUDIEndingPosition.Visibility = Visibility.Hidden;
            txtCavUDIPartialCompare.Visibility = Visibility.Hidden;

            //variable
            txtUDIRecipe.Text = LoadedRecipe._UDIRecipe;
            
            //if loaded recipe has a value of 0
            if (LoadedRecipe._recUDI1 == "0")
            {
                //unchecks this checkbox
                chkUseUDI.IsChecked = false;
            }
            //else
            else
            {
                //checks this checkbox
                chkUseUDI.IsChecked = true;
            }
            //displays value of these UDI loaded recipes into textboxes
            txtUDIEntireOrPartial.Text = LoadedRecipe._recUDI3;
            txtUDIFirstPosition.Text = LoadedRecipe._recUDI4;
            txtUDIEndingPosition.Text = LoadedRecipe._recUDI5;

            //if loaded recipe has a value of 1
            if (LoadedRecipe._recUDI6 == "1")
            {
                //checks this checkbox
                chkCompareUDI.IsChecked = true;
            }
            else
            {
                //unchecks this checkbox
                chkCompareUDI.IsChecked = false;
            }
            //displays value of these UDI loaded recipes into textboxes
            txtCavUDIEntireOrPartial.Text = LoadedRecipe._recUDI7;
            txtCavUDIFirstPosition.Text = LoadedRecipe._recUDI8;
            txtCavUDIEndingPosition.Text = LoadedRecipe._recUDI9;

            //if loaded recipe in cavUsed control is true
            if (LoadedRecipe.cavUsed == true)
            {
                //Makes these controls visible
                lblCavityManagement.Visibility = Visibility.Visible;
                chkCompareUDI.Visibility = Visibility.Visible;
                txtUDIPartialCompare.Visibility = Visibility.Visible;
            }
          
        }
        //if udi checkbox is checked then display the next section of the page 
        private void chkUseUDI_Checked(object sender, RoutedEventArgs e)
        { 
            //if checked
            if (chkUseUDI.IsChecked == true)
            {
                //Converts to a string with a certain length
                //Stores into txtUDILength textbox
                txtUDILength.Text = txtUDIRecipe.Text.Length.ToString();

                //Makes these controls visible
                lblUDIEntireOrPartial.Visibility = Visibility.Visible;
                txtUDIEntireOrPartial.Visibility = Visibility.Visible;
            }
            //if unchecked
            else
            {
                //empties the string in this textbox.
                txtUDIRecipe.Text = string.Empty;
                //Make these controls visible
                lblUDIEntireOrPartial.Visibility = Visibility.Hidden;
                txtUDIEntireOrPartial.Visibility = Visibility.Hidden;
                lblUDIFirstPosition.Visibility = Visibility.Hidden;
                txtUDIFirstPosition.Visibility = Visibility.Hidden;
                lblUDIEndingPosition.Visibility = Visibility.Hidden;
                txtUDIEndingPosition.Visibility = Visibility.Hidden;
            }
        }
        //once back button is clicked user is taken to options menu screen 
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            //if checked, populate with a 1
            if (chkUseUDI.IsChecked == true)
            {

                LoadedRecipe._recUDI1 = "1";
            }
            //if unchecked, populate with a 0
            else
            {
                LoadedRecipe._recUDI1 = "0";
            }
            //Store text from text boxes into these variable recipes
            LoadedRecipe._recUDI3 = txtUDIEntireOrPartial.Text;
            LoadedRecipe._recUDI4 = txtUDIFirstPosition.Text;
            LoadedRecipe._recUDI5 = txtUDIEndingPosition.Text;
            
            //if checked, populate with a 1
            if (chkCompareUDI.IsChecked == true)
            {

                LoadedRecipe._recUDI6 = "1";
            }
            //if checked, populate with a 0
            else
            {
                LoadedRecipe._recUDI6 = "0";
            }

            //Store text from text boxes into these variable recipes
            LoadedRecipe._recUDI7 = txtCavUDIEntireOrPartial.Text;
            LoadedRecipe._recUDI8 = txtCavUDIFirstPosition.Text;
            LoadedRecipe._recUDI9 = txtCavUDIEndingPosition.Text;

            //Close window
            this.Close();
        }
        
        private void txtUDIEntireOrPartial_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Variable
            var input = txtUDIEntireOrPartial.Text.ToString();

            //if the variable input = "e"
            if (input == "e")
            {
                //Do entire
                //Make these controls visible
                lblUDIFirstPosition.Visibility = Visibility.Hidden;
                txtUDIFirstPosition.Visibility = Visibility.Hidden;
                lblUDIEndingPosition.Visibility = Visibility.Hidden;
                txtUDIEndingPosition.Visibility = Visibility.Hidden;
                txtUDIPartialCompare.Visibility = Visibility.Hidden;
                txtUDIFirstPosition.IsEnabled = txtUDIEndingPosition.IsEnabled = false;
            }
            //if the variable input = "p"
            else if (input == "p")
            {
                //do partial
                //Make these controls visible
                lblUDIFirstPosition.Visibility = Visibility.Visible;
                txtUDIFirstPosition.Visibility = Visibility.Visible;
                lblUDIEndingPosition.Visibility = Visibility.Visible;
                txtUDIEndingPosition.Visibility = Visibility.Visible;
                txtUDIPartialCompare.Visibility = Visibility.Visible;
                txtUDIFirstPosition.IsEnabled = txtUDIEndingPosition.IsEnabled = true;
            }
            //else
            else
            {
                txtUDIFirstPosition.IsEnabled = txtUDIEndingPosition.IsEnabled = false;
                //invalid input, clear textfield.
            }

        }
       //partial compare for UDI string. 
        private void PartialCompare(string udiFirstP, string udiSecondP ="")
        {
            //Variable used in this method
            string txtUDI = txtUDIRecipe.Text;

            //Try-Catch block to find errors in logic
            try
            {
                int begin = 0;
                int end = txtUDI.Length;

                //if (!string.IsNullOrWhiteSpace(arg1))
                    begin = int.Parse(udiFirstP);

                if (!string.IsNullOrWhiteSpace(udiSecondP))
                    end = int.Parse(udiSecondP);

                txtUDIPartialCompare.Text = txtUDI.Substring(begin, end);
            }
            catch (Exception e)
            {
                txtUDIPartialCompare.Text = txtUDIRecipe.Text;
            }
        }
        

        //validate user input (only integers) for all textboxes concerning position.
        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            //e.Handled = !IsValid(((TextBox)sender).Text + e.Text);
            //var textbox = (TextBox)sender;
            //textbox.Text += e.Text;
            e.Handled = !IsValid((TextBox)sender, e);

        }

        public int FirstPosition { get; set; }
        public int EndPosition { get; set; }

        public bool IsValid(TextBox textbox, TextCompositionEventArgs e)
        {
            if (textbox.Name == "txtUDIFirstPosition" || textbox.Name == "txtCavUDIFirstPosition")
            {
                if (int.TryParse((textbox.Text + e.Text), out int i) && i >= 0 && (i + EndPosition <= 39))
                {
                    FirstPosition = i;
                    return true;
                }
                return false;
            }

            if (textbox.Name == "txtUDIEndingPosition" || textbox.Name == "txtCavUDIEndingPosition")
            {
                if (int.TryParse((textbox.Text + e.Text), out int i) && i >= 0 && (i + FirstPosition) <= 40)
                {
                    EndPosition = i;
                    return true;
                }
                return false;
            }

            //else
            return false;
        }

        //Event for when text changes
        private void txtUDIEndingPosition_TextChanged(object sender, TextChangedEventArgs e)
        {
            PartialCompare(txtUDIFirstPosition.Text, txtUDIEndingPosition.Text);
        }
        
        //Event for when text changes
        private void txtUDIFirstPosition_TextChanged(object sender, TextChangedEventArgs e)
        {
            PartialCompare(txtUDIFirstPosition.Text, txtUDIEndingPosition.Text);
        }

        private void chkCompareUDI_Checked(object sender, RoutedEventArgs e)
        {            
            //if yes to cavity being used on cavity screen 
            if (chkCompareUDI.IsChecked == true)
            { 
                //Makes two controls visible
                lblCavUDIEntireOrPartial.Visibility = Visibility.Visible;
                txtCavUDIEntireOrPartial.Visibility = Visibility.Visible;
            }
            //If no to cavity being used on cavity screen
            else
            {
                //These controls become hidden
                lblCavUDIEntireOrPartial.Visibility = Visibility.Hidden;
                txtCavUDIEntireOrPartial.Visibility = Visibility.Hidden;
                lblCavUDIFirstPosition.Visibility = Visibility.Hidden;
                txtCavUDIFirstPosition.Visibility = Visibility.Hidden;
                lblCavUDIEndingPosition.Visibility = Visibility.Hidden;
                txtCavUDIEndingPosition.Visibility = Visibility.Hidden;
            }

        }

        private void txtCavUDIEntireOrPartial_TextChanged(object sender, TextChangedEventArgs e)
        {
            //variable
            var input = txtCavUDIEntireOrPartial.Text.ToString();

            //if input is assigned "p"
            if (input == "p")
            {
                //Make these controls visible
                lblCavUDIFirstPosition.Visibility = Visibility.Visible;
                txtCavUDIFirstPosition.Visibility = Visibility.Visible;
                lblCavUDIEndingPosition.Visibility = Visibility.Visible;
                txtCavUDIEndingPosition.Visibility = Visibility.Visible;
                txtCavUDIPartialCompare.Visibility = Visibility.Visible;
                //enables first and ending position textboxes
                txtCavUDIFirstPosition.IsEnabled = txtCavUDIEndingPosition.IsEnabled = true;
            }
            //if input is assigned "e"
            else if (input == "e")
            {
                //Make these controls invisible/hidden
                lblCavUDIFirstPosition.Visibility = Visibility.Hidden;
                txtCavUDIFirstPosition.Visibility = Visibility.Hidden;
                lblCavUDIEndingPosition.Visibility = Visibility.Hidden;
                txtCavUDIEndingPosition.Visibility = Visibility.Hidden;
                txtCavUDIPartialCompare.Visibility = Visibility.Hidden;

                //disables first and ending position textboxes
                txtCavUDIFirstPosition.IsEnabled = txtCavUDIEndingPosition.IsEnabled = false;
            }
            //if input is neither "e" or "p"
            else
            {
                //invalid input, clear textfield.
                txtCavUDIFirstPosition.IsEnabled = txtCavUDIEndingPosition.IsEnabled = false;
            }
        }
        //partial compare for CavUDI string. 
        private void CavPartialCompare(string udiCavFirstP, string udiCavSecondP = "")
        {
            //variable
            string CavtxtUDI = txtUDIRecipe.Text;

            //Try-Catch block
            try
            {
                int begin = 0;
                int end = CavtxtUDI.Length;

                //if (!string.IsNullOrWhiteSpace(arg1))
                begin = int.Parse(udiCavFirstP);

                if (!string.IsNullOrWhiteSpace(udiCavSecondP))
                    end = int.Parse(udiCavSecondP);

                txtCavUDIPartialCompare.Text = CavtxtUDI.Substring(begin, end);
            }
            catch (Exception e)
            {
                txtCavUDIPartialCompare.Text = txtUDIRecipe.Text;
            }
        }

        //Event if text changes in textbox
        private void txtCavUDIFirstPosition_TextChanged(object sender, TextChangedEventArgs e)
        {
            CavPartialCompare(txtCavUDIFirstPosition.Text, txtCavUDIEndingPosition.Text);
        }

        //Event if text changes in textbox
        private void txtCavUDIEndingPosition_TextChanged(object sender, TextChangedEventArgs e)
        {
            CavPartialCompare(txtCavUDIFirstPosition.Text, txtCavUDIEndingPosition.Text);
        }
    }
}
