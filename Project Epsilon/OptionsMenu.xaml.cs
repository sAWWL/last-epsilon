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

        //creates new instance of tool setup window and displays it
        private void ToolSetup_Click(object sender , RoutedEventArgs e)
        {
            ToolSetupWindow winToolSetup = new ToolSetupWindow();
            winToolSetup.Show();
        }
        //creates new instance of cavity management window and displays it
        private void CavMgmtBtn_Click(object sender, RoutedEventArgs e)
        {
            CavityToolWindow objCavMgmtWindow = new CavityToolWindow();
            objCavMgmtWindow.Show();
        }
        //closes the page
        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        //creates new instance of UDIPage and displays it
        private void UDISetupBtn_Click(object sender, RoutedEventArgs e)
        {
            UDIPage winUDIPage = new UDIPage();
            winUDIPage.Show();
        }
    }
}
