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
                string machineaddress = machinedata.Split('-')[0].Split('@')[1].Split(':')[0];

                machineName.Text = machinename;
                machineAddress.Text = machineaddress;
            }
            
        }
        private void AddMachineBtn_Click(object sender, RoutedEventArgs e)
        {
            if(Machines.MachineIdx == -1)
            {
                Machines.MachineData.Add(machineName.Text + "@" + machineAddress.Text + ":21");
            }else
            {
                Machines.MachineData[Machines.MachineIdx] = machineName.Text + "@" + machineAddress.Text + ":21";
            }
            this.Close();
        }

        private void AddressEntry_LostFocus(object sender, RoutedEventArgs e)
        {
            try // incase there are no periods in string - otherwise would break on .split('.')
            {
                string[] test = machineAddress.Text.Split('.');
                int isInteger;
                if (int.TryParse(test[0], out isInteger)) // If numeric IP address instead of string
                {

                    IPAddressError.Visibility = Visibility.Hidden;
                    int[] octets = new int[4];
                    int counter = 0;
                    bool isCorrectAddress = true;
                    foreach (string octet in machineAddress.Text.Split('.'))
                    {
                        octets[counter] = Convert.ToInt32(octet);
                        if (!Enumerable.Range(0, 256).Contains(Convert.ToInt32(octet)))
                        {
                            isCorrectAddress = false;
                            break;
                        }
                        else
                        {
                            isCorrectAddress = true;
                        }
                        counter += 1;
                    }
                    if (!isCorrectAddress)
                    {
                        IPAddressError.Visibility = Visibility.Visible;
                    }

                    if (octets[0] == 192 || octets[0] == 127)
                    {
                        ;
                    }
                    else
                    {
                        IPAddressError.Visibility = Visibility.Visible;
                        IPAddressError.Text = "Invalid IP Address - Must Be '192.x.x.x' Or '127.0.0.1'";
                    }
                }
            } catch {; }
        }

        private void AddressEntry_OnFocus(object sender, RoutedEventArgs e)
        {
            IPAddressError.Visibility = Visibility.Hidden;
        }

        private void CancelAddBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
