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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            //Add Machines for Demo Purposes
            Machines.MachineData.Add("ATLASVAC@192.168.1.248:21-HMI");
        }


        private void RecipeEditorBtn_Click(object sender, RoutedEventArgs e)
        {
            RecipeInput RecipeInput = new RecipeInput();
            RecipeInput.Show();
        }      

        private void Exit(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void ConnectionManagerBtn_Click(object sender, RoutedEventArgs e)
        {
            ConnectionManagerWindow connectionmanager = new ConnectionManagerWindow();
            connectionmanager.Show();
        }
    }
}
