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
    /// Interaction logic for AddMachine.xaml
    /// </summary>
    public partial class AddMachine : Window
    {
        public AddMachine()
        {
            InitializeComponent();
            if(Machines.MachineIdx != -1)
            {
                string machinedata = Machines.MachineData[Machines.MachineIdx];
                string machinename = machinedata.Split('-')[1];
                string machineusername = machinedata.Split('-')[0].Split('@')[0];
                string machineaddress = machinedata.Split('-')[0].Split('@')[1].Split(':')[0];
                string machineport = machinedata.Split('-')[0].Split('@')[1].Split(':')[1];

                machineName.Text = machinename;
                machineAddress.Text = machineaddress;
                machinePort.Text = machineport;
                machineUsername.Text = machineusername;
            }
            
        }
        private void AddMachineBtn_Click(object sender, RoutedEventArgs e)
        {
            if(Machines.MachineIdx == -1)
            {
                Machines.MachineData.Add(machineUsername.Text + "@" + machineAddress.Text + ":" + machinePort.Text + "-" + machineName.Text);
            }else
            {
                Machines.MachineData[Machines.MachineIdx] = machineUsername.Text + "@" + machineAddress.Text + ":" + machinePort.Text + "-" + machineName.Text;
            }
            this.Close();
        }

        private void CancelAddBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
