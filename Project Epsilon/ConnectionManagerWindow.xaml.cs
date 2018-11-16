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
using System.Collections.Specialized;
using System.Net.NetworkInformation;
using System.Drawing;
using System.Net.Sockets;

namespace Project_Epsilon
{
    /// <summary>
    /// Interaction logic for ConnectionmanagerWindow.xaml
    /// </summary>
    public partial class ConnectionManagerWindow : Window
    {
        public ConnectionManagerWindow()
        {
            InitializeComponent();
            updateMachineList();

        }
        private void deleteMachine_Click(object sender, RoutedEventArgs e)
        {
            if (machineList.SelectedIndex != -1)
            {
                string sMessageBoxText = "Do you want to delete the selected Machine?";
                string sCaption = "Delete Machine?";

                MessageBoxButton btnMessageBox = MessageBoxButton.YesNoCancel;
                MessageBoxImage icnMessageBox = MessageBoxImage.Warning;

                MessageBoxResult rsltMessageBox = MessageBox.Show(sMessageBoxText, sCaption, btnMessageBox, icnMessageBox);

                switch (rsltMessageBox)
                {
                    case MessageBoxResult.Yes:
                        Machines.MachineData.RemoveAt(machineList.SelectedIndex);
                        machineList.Items.RemoveAt(machineList.SelectedIndex);
                        break;
                    case MessageBoxResult.No:
                        break;
                    case MessageBoxResult.Cancel:
                        break;
                }
            }
        }
        private void addMachine_Click(object sender, RoutedEventArgs e)
        {
            Machines.MachineIdx = -1;
            AddMachine addMachine = new AddMachine();
            if (addMachine.ShowDialog() != true)
            {
                updateMachineList();

            }
        }
        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
  
        private void editMachine_Click(object sender, RoutedEventArgs e)
        {
            Machines.MachineIdx = machineList.SelectedIndex;
            
            AddMachine editMachine = new AddMachine();
            if (editMachine.ShowDialog() != true)
            {
                updateMachineList();
            }
        }
        private void updateMachineList()
        {
            machineList.Items.Clear();
            foreach (string machine in Machines.MachineData)
            {
                machineList.Items.Add(machine.Split('-')[1]);
            }
        }
    }

}
