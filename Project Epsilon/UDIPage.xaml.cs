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
using System.Text.RegularExpressions;

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

            //udi from loaded recipe is put into the udi textbox of udipage
            txtUDIRecipe.Text = LoadedRecipe._UDIRecipe;
            txtUDILength.Text = txtUDIRecipe.Text.Length.ToString();
            txtCavUDIEntireOrPartial.Text = LoadedRecipe._recUDI7;
            txtCavUDIFirstPosition.Text = LoadedRecipe._recUDI8;
            txtCavUDIEndingPosition.Text = LoadedRecipe._recUDI9;
            txtUDIEntireOrPartial.Text = LoadedRecipe._recUDI3;
            txtUDIFirstPosition.Text = LoadedRecipe._recUDI4;
            txtUDIEndingPosition.Text = LoadedRecipe._recUDI5;
            txtUDIPartialCompare.Visibility = Visibility.Hidden;


            //if there is a value from the recipe load it in 
            if (!string.IsNullOrWhiteSpace(LoadedRecipe._recUDI3))
            {
                lblUDIEntireOrPartial.Visibility = Visibility.Visible;
                txtUDIEntireOrPartial.Visibility = Visibility.Visible;
            }

            //if there is a first position value from the recipe and p was the value of _recUDI3 then load it in 
            if (!string.IsNullOrWhiteSpace(LoadedRecipe._recUDI4) && txtUDIEntireOrPartial.Text == "p")
            {
                lblUDIFirstPosition.Visibility = Visibility.Visible;
                txtUDIFirstPosition.Visibility = Visibility.Visible;
                txtUDIFirstPosition.IsEnabled = txtUDIEndingPosition.IsEnabled = true;
                txtUDIPartialCompare.Visibility = Visibility.Visible;
            }

            //if there is an end position value from the recipe load it in p was the value of _recUDI3 then load it in 
            if (!string.IsNullOrWhiteSpace(LoadedRecipe._recUDI5) && txtUDIEntireOrPartial.Text == "p")
            {
                lblUDIEndingPosition.Visibility = Visibility.Visible;
                txtUDIEndingPosition.Visibility = Visibility.Visible;
            }

            //if there is true or false value from the recipe load it in 
            if (!string.IsNullOrWhiteSpace(LoadedRecipe._recUDI6) || (LoadedRecipe._cavMgtUsed == 1))
            {
                lblCavityManagement.Visibility = Visibility.Visible;
                chkCompareUDI.Visibility = Visibility.Visible;
            }

            //if there is a value from the recipe load it in
            if (!string.IsNullOrWhiteSpace(LoadedRecipe._recUDI7))
            {
                lblCavUDIEntireOrPartial.Visibility = Visibility.Visible;
                txtCavUDIEntireOrPartial.Visibility = Visibility.Visible;
            }

            //if there is a value for the postion and p was the value of _recUDI8 then load it in 
            if (!string.IsNullOrWhiteSpace(LoadedRecipe._recUDI8) && txtCavUDIEntireOrPartial.Text == "p")
            {
                lblCavUDIFirstPosition.Visibility = Visibility.Visible;
                txtCavUDIFirstPosition.Visibility = Visibility.Visible;
                txtCavUDIPartialCompare.Visibility = Visibility.Visible;
                txtUDIFirstPosition.IsEnabled = txtUDIEndingPosition.IsEnabled = true;
            }

            //if there  is a value for the end position and p was the value of recUDI3 then load it in
            if (!string.IsNullOrWhiteSpace(LoadedRecipe._recUDI9) && txtCavUDIEntireOrPartial.Text == "p")
            {
                lblCavUDIEndingPosition.Visibility = Visibility.Visible;
                txtCavUDIEndingPosition.Visibility = Visibility.Visible;
            }

        }
        //if udi checkbox is checked then display the next section of the page 
        private void chkUseUDI_Checked(object sender, RoutedEventArgs e)
        {
            lblUDIEntireOrPartial.Visibility = Visibility.Visible;
            txtUDIEntireOrPartial.Visibility = Visibility.Visible;
            //if checked
            if (chkUseUDI.IsChecked.Value)

            {
                ////Converts to a string with a certain length
                //if (!string.IsNullOrWhiteSpace(txtUDIEntireOrPartial.Text))
                //{

                //}

                if (!string.IsNullOrWhiteSpace(txtUDIFirstPosition.Text) && txtUDIEntireOrPartial.Text == "p")
                {
                    lblUDIFirstPosition.Visibility = Visibility.Visible;
                    txtUDIFirstPosition.Visibility = Visibility.Visible;
                    txtUDIFirstPosition.IsEnabled = txtUDIEndingPosition.IsEnabled = true;
                    txtUDIPartialCompare.Visibility = Visibility.Visible;
                }

                if (!string.IsNullOrWhiteSpace(txtUDIEndingPosition.Text) && txtUDIEntireOrPartial.Text == "p")
                {
                    lblUDIEndingPosition.Visibility = Visibility.Visible;
                    txtUDIEndingPosition.Visibility = Visibility.Visible;
                }
            }
            //if unchecked
            else
            {
                //hidden from screen
                lblUDIEntireOrPartial.Visibility = Visibility.Hidden;
                txtUDIEntireOrPartial.Visibility = Visibility.Hidden;
                lblUDIFirstPosition.Visibility = Visibility.Hidden;
                txtUDIFirstPosition.Visibility = Visibility.Hidden;
                lblUDIEndingPosition.Visibility = Visibility.Hidden;
                txtUDIEndingPosition.Visibility = Visibility.Hidden;
                txtUDIPartialCompare.Visibility = Visibility.Hidden;
                chkCompareUDI.IsChecked = false;
            }
        }
        //once back button is clicked user is taken to options menu screen 
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            //if checked, populate with a 1
            if (chkUseUDI.IsChecked == true)
            {

                LoadedRecipe._recUDI1 = 1;
            }
            //if unchecked, populate with a 0
            else
            {
                LoadedRecipe._recUDI1 = 0;
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
            Regex regex = new Regex(@"[ep]");
            MatchCollection matches = regex.Matches(txtUDIEntireOrPartial.Text);

            var input = txtUDIEntireOrPartial.Text.ToString();
            if (input == "p")
            {
                lblUDIFirstPosition.Visibility = Visibility.Visible;
                txtUDIFirstPosition.Visibility = Visibility.Visible;
                lblUDIEndingPosition.Visibility = Visibility.Visible;
                txtUDIEndingPosition.Visibility = Visibility.Visible;
                txtUDIFirstPosition.IsEnabled = txtUDIEndingPosition.IsEnabled = true;
                txtUDIPartialCompare.Visibility = Visibility.Visible;
            }
            else if (input == "e")
            {
                lblUDIFirstPosition.Visibility = Visibility.Hidden;
                txtUDIFirstPosition.Visibility = Visibility.Hidden;
                lblUDIEndingPosition.Visibility = Visibility.Hidden;
                txtUDIEndingPosition.Visibility = Visibility.Hidden;
                txtUDIFirstPosition.IsEnabled = txtUDIEndingPosition.IsEnabled = false;
                txtUDIPartialCompare.Visibility = Visibility.Hidden;
            }
        }
        //partial compare for UDI string. 
        private void PartialCompare(string udiFirstP, string udiSecondP = "")
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
            if (chkCompareUDI.IsChecked.Value)
            {
                lblCavUDIEntireOrPartial.Visibility = Visibility.Visible;
                txtCavUDIEntireOrPartial.Visibility = Visibility.Visible;

                if (!string.IsNullOrWhiteSpace(txtCavUDIFirstPosition.Text) && txtCavUDIEntireOrPartial.Text == "p")
                {
                    lblCavUDIFirstPosition.Visibility = Visibility.Visible;
                    txtCavUDIFirstPosition.Visibility = Visibility.Visible;
                    txtCavUDIFirstPosition.IsEnabled = txtCavUDIEndingPosition.IsEnabled = true;
                    txtCavUDIPartialCompare.Visibility = Visibility.Visible;
                }

                if (!string.IsNullOrWhiteSpace(txtCavUDIEndingPosition.Text) && txtCavUDIEntireOrPartial.Text == "p")
                {
                    lblCavUDIEndingPosition.Visibility = Visibility.Visible;
                    txtCavUDIEndingPosition.Visibility = Visibility.Visible;
                }
            }

            else
            {
                lblCavUDIFirstPosition.Visibility = Visibility.Hidden;
                txtCavUDIFirstPosition.Visibility = Visibility.Hidden;
                txtCavUDIFirstPosition.IsEnabled = txtCavUDIEndingPosition.IsEnabled = false;
                txtCavUDIPartialCompare.Visibility = Visibility.Hidden;
                lblCavUDIEndingPosition.Visibility = Visibility.Hidden;
                txtCavUDIEndingPosition.Visibility = Visibility.Hidden;
            }

        }

        private void txtCavUDIEntireOrPartial_TextChanged(object sender, TextChangedEventArgs e)
        {


            var cavInput = txtCavUDIEntireOrPartial.Text.ToString();
            if (cavInput == "p")
            {
                lblCavUDIFirstPosition.Visibility = Visibility.Visible;
                txtCavUDIFirstPosition.Visibility = Visibility.Visible;
                lblCavUDIEndingPosition.Visibility = Visibility.Visible;
                txtCavUDIEndingPosition.Visibility = Visibility.Visible;
                txtCavUDIFirstPosition.IsEnabled = txtCavUDIEndingPosition.IsEnabled = true;
                txtCavUDIPartialCompare.Visibility = Visibility.Visible;
            }
            else if (cavInput == "e")
            {
                lblCavUDIFirstPosition.Visibility = Visibility.Hidden;
                txtCavUDIFirstPosition.Visibility = Visibility.Hidden;
                lblCavUDIEndingPosition.Visibility = Visibility.Hidden;
                txtCavUDIEndingPosition.Visibility = Visibility.Hidden;
                txtCavUDIPartialCompare.Visibility = Visibility.Hidden;
                txtCavUDIFirstPosition.IsEnabled = txtCavUDIEndingPosition.IsEnabled = false;

            }
            else
            {

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