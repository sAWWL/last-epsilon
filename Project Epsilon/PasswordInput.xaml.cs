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
    /// Interaction logic for PasswordInput.xaml
    /// </summary>
    public partial class PasswordInput : Window
    {
        public PasswordInput()
        {
            InitializeComponent();
        }

        private void applyPasswordBtn_Click(object sender, RoutedEventArgs e)
        {

            //if variable is blank do this
            if(passwordInputTxt.Password != "")
            {
                //creates new instance of password loaded recipe and stores it
                //closes the page
                LoadedRecipe.password = passwordInputTxt.Password;
                this.Close();
            }
        }
        //closes the page
        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
