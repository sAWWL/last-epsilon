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
            txtUDIRecipe.Text = LoadedRecipe._UDIRecipe;
            
            if (LoadedRecipe._recUDI1 == "0")
            {
                chkUseUDI.IsChecked = false;
            }
            else
            {
                chkUseUDI.IsChecked = true;
            }
            txtUDIEntireOrPartial.Text = LoadedRecipe._recUDI3;
            txtUDIFirstPosition.Text = LoadedRecipe._recUDI4;
            txtUDIEndingPosition.Text = LoadedRecipe._recUDI5;
            if (LoadedRecipe._recUDI6 == "1")
            {
                chkCompareUDI.IsChecked = true;
            }
            else
            {
                chkCompareUDI.IsChecked = false;
            }
            txtCavUDIEntireOrPartial.Text = LoadedRecipe._recUDI7;
            txtCavUDIFirstPosition.Text = LoadedRecipe._recUDI8;
            txtCavUDIEndingPosition.Text = LoadedRecipe._recUDI9;

            if (LoadedRecipe.cavUsed == true)
            {
                lblCavityManagement.Visibility = Visibility.Visible;
                chkCompareUDI.Visibility = Visibility.Visible;
                txtUDIPartialCompare.Visibility = Visibility.Visible;
            }
          
        }
        //if udi checkbox is checked then display the next section of the page 
        private void chkUseUDI_Checked(object sender, RoutedEventArgs e)
        {
            if (chkUseUDI.IsChecked == true)
            {
                txtUDILength.Text = txtUDIRecipe.Text.Length.ToString();
                lblUDIEntireOrPartial.Visibility = Visibility.Visible;
                txtUDIEntireOrPartial.Visibility = Visibility.Visible;
            }
            else
            {
                txtUDIRecipe.Text = string.Empty;
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
            if (chkUseUDI.IsChecked == true)
            {

                LoadedRecipe._recUDI1 = "1";
            }
            else
            {
                LoadedRecipe._recUDI1 = "0";
            }
            LoadedRecipe._recUDI3 = txtUDIEntireOrPartial.Text;
            LoadedRecipe._recUDI4 = txtUDIFirstPosition.Text;
            LoadedRecipe._recUDI5 = txtUDIEndingPosition.Text;
            if (chkCompareUDI.IsChecked == true)
            {

                LoadedRecipe._recUDI6 = "1";
            }
            else
            {
                LoadedRecipe._recUDI6 = "0";
            }
            LoadedRecipe._recUDI7 = txtCavUDIEntireOrPartial.Text;
            LoadedRecipe._recUDI8 = txtCavUDIFirstPosition.Text;
            LoadedRecipe._recUDI9 = txtCavUDIEndingPosition.Text;
            this.Close();
        }
        
        private void txtUDIEntireOrPartial_TextChanged(object sender, TextChangedEventArgs e)
        {
            var input = txtUDIEntireOrPartial.Text.ToString();
            if (input == "e")
            {
                //Do entire
                lblUDIFirstPosition.Visibility = Visibility.Hidden;
                txtUDIFirstPosition.Visibility = Visibility.Hidden;
                lblUDIEndingPosition.Visibility = Visibility.Hidden;
                txtUDIEndingPosition.Visibility = Visibility.Hidden;
                txtUDIPartialCompare.Visibility = Visibility.Hidden;
                txtUDIFirstPosition.IsEnabled = txtUDIEndingPosition.IsEnabled = false;
            }
            else if (input == "p")
            {
                lblUDIFirstPosition.Visibility = Visibility.Visible;
                txtUDIFirstPosition.Visibility = Visibility.Visible;
                lblUDIEndingPosition.Visibility = Visibility.Visible;
                txtUDIEndingPosition.Visibility = Visibility.Visible;
                txtUDIPartialCompare.Visibility = Visibility.Visible;
                txtUDIFirstPosition.IsEnabled = txtUDIEndingPosition.IsEnabled = true;
                //do partial
            }
            else
            {
                txtUDIFirstPosition.IsEnabled = txtUDIEndingPosition.IsEnabled = false;
                //invalid input, clear textfield.
            }

        }
       //partial compare for UDI string. 
        private void PartialCompare(string udiFirstP, string udiSecondP ="")
        {
            string txtUDI = txtUDIRecipe.Text;

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
            if (textbox.Name == "txtUDIFirstPosition")
            {
                if (int.TryParse((textbox.Text + e.Text), out int i) && i >= 0 && (i + EndPosition <= 39))
                {
                    FirstPosition = i;
                    return true;
                }
                return false;
            }

            if (textbox.Name == "txtUDIEndingPosition")
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

        private void txtUDIEndingPosition_TextChanged(object sender, TextChangedEventArgs e)
        {
            PartialCompare(txtUDIFirstPosition.Text, txtUDIEndingPosition.Text);
        }

        private void txtUDIFirstPosition_TextChanged(object sender, TextChangedEventArgs e)
        {
            PartialCompare(txtUDIFirstPosition.Text, txtUDIEndingPosition.Text);
        }

        private void chkCompareUDI_Checked(object sender, RoutedEventArgs e)
        {            
            //if yes to cavity being used on cavity screen 
            if (chkCompareUDI.IsChecked == true)
            { 
                lblCavUDIEntireOrPartial.Visibility = Visibility.Visible;
                txtCavUDIEntireOrPartial.Visibility = Visibility.Visible;
            }
            else
            {
                lblCavUDIEntireOrPartial.Visibility = Visibility.Hidden;
                txtCavUDIEntireOrPartial.Visibility = Visibility.Hidden;
            }

        }

        private void txtCavUDIEntireOrPartial_TextChanged(object sender, TextChangedEventArgs e)
        {
            var input = txtCavUDIEntireOrPartial.Text.ToString();
            if (input == "p")
            {

                lblCavUDIFirstPosition.Visibility = Visibility.Visible;
                txtCavUDIFirstPosition.Visibility = Visibility.Visible;
                lblCavUDIEndingPosition.Visibility = Visibility.Visible;
                txtCavUDIEndingPosition.Visibility = Visibility.Visible;
                txtCavUDIPartialCompare.Visibility = Visibility.Visible;
                txtCavUDIFirstPosition.IsEnabled = txtCavUDIEndingPosition.IsEnabled = true;
            }

            else if (input == "e")
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
                txtCavUDIFirstPosition.IsEnabled = txtCavUDIEndingPosition.IsEnabled = false;
                //invalid input, clear textfield.
            }
        }
        //partial compare for CavUDI string. 
        private void CavPartialCompare(string udiCavFirstP, string udiCavSecondP = "")
        {
            string CavtxtUDI = txtUDIRecipe.Text;

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

        private void txtCavUDIFirstPosition_TextChanged(object sender, TextChangedEventArgs e)
        {
            CavPartialCompare(txtCavUDIFirstPosition.Text, txtCavUDIEndingPosition.Text);
        }

        private void txtCavUDIEndingPosition_TextChanged(object sender, TextChangedEventArgs e)
        {
            CavPartialCompare(txtCavUDIFirstPosition.Text, txtCavUDIEndingPosition.Text);
        }
    }
}
