using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            //Add Machines for Demo Purposes
            Machines.MachineData.Add("ATLASVAC@192.168.1.248:21-HMI");
            Machines.MachineData.Add("ATLASVAC@192.168.0.4:21-local");
            Machines.MachineData.Add("ATLASVAC@localhost:21-local2");
        }


        private void RecipeEditorBtn_Click(object sender, RoutedEventArgs e)
        {
            //creates new instance of recipe input page and displays it
            RecipeInput RecipeInput = new RecipeInput();
            RecipeInput.Show();
        }

        private void SettingsBtn_Click(object sender, RoutedEventArgs e)
        {
            ConnectionManagerWindow connectionManagerWindow = new ConnectionManagerWindow();
            connectionManagerWindow.Show();
            this.Hide();
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            //when button pressed, closes the app
            System.Windows.Application.Current.Shutdown();
        }

        private void RecipesBtn_Click(object sender, RoutedEventArgs e)
        {
            //creates new instance of connection manager page and displays it
            if (LoadedRecipe.recipeloaded == false)
            {
                FileBrowser winFileBrowser = new FileBrowser();
                winFileBrowser.Show();
            }
            else
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Resume previous recipe?", "Confirm", System.Windows.MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    RecipeInput winRecipeInput = new RecipeInput();
                    winRecipeInput.Show();
                    this.Close();
                }
                else
                {
                    FileBrowser winFileBrowser = new FileBrowser();
                    winFileBrowser.Show();
                    this.Close();
                }
            }
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }       
    }
}
