using System.Windows;

namespace Project_Epsilon
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class OptionsMenu : Window
    {
        public OptionsMenu()
        {
            InitializeComponent();
        }


        private void ToolSetup_Click(object sender , RoutedEventArgs e)
        {
            ToolSetupWindow winToolSetup = new ToolSetupWindow();
            winToolSetup.Show();
        }

        private void CavMgmtBtn_Click(object sender, RoutedEventArgs e)
        {
            CavityToolWindow objCavMgmtWindow = new CavityToolWindow();
            objCavMgmtWindow.Show();
        }
        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void UDISetupBtn_Click(object sender, RoutedEventArgs e)
        {
            UDIPage winUDIPage = new UDIPage();
            winUDIPage.Show();
        }
    }
}
