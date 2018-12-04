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
        bool correctIP;
        List<int> octets = new List<int>();




        public AddMachine()
        {
            InitializeComponent();
            if (Machines.MachineIdx != -1)
            {
                try {
                    string machinedata = Machines.MachineData[Machines.MachineIdx];
                    string machinename = machinedata.Split('-')[1];
                    string machineaddress = machinedata.Split('-')[0].Split('@')[1].Split(':')[0];

                    oct1.Text = machineaddress.Split('.')[0].Split('.')[0];
                    oct2.Text = machineaddress.Split('.')[1].Split('.')[0];
                    oct3.Text = machineaddress.Split('.')[2];
                    oct4.Text = machineaddress.Split('.')[3];
                    machineName.Text = machinename;
                } catch {; }
            machineName.Focus();
            }
        }
        public bool ValidateIP()
        {
            bool valid = true;
            
            try
            {
                octets.Add(Convert.ToInt16(oct1.Text));
                octets.Add(Convert.ToInt16(oct2.Text));
                octets.Add(Convert.ToInt16(oct3.Text));
                octets.Add(Convert.ToInt16(oct4.Text));
                foreach (int octet in octets)
                {
                    if (octet > 255 || octet < 0)
                    {
                        IPAddressError.Visibility = Visibility.Visible;
                        IPAddressError.Text += Convert.ToString(octet);
                        valid = false;
                    }

                }
               if(octets[0] == 192 || octets[0] == 10)
                {
                    
                }else
                {
                    valid = false;
                }


                return valid;

            }
            catch {
                IPAddressError.Visibility = Visibility.Visible;
                IPAddressError.Text = "Not all fields have the correct format";
                return false;
            }
        }
        private void AddMachineBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateIP())
            {
                string ip = "";
                

                foreach (int octet in octets)
                {
                    ip += Convert.ToString(octet) + ".";
                }
                ip.TrimEnd('.');
                if (Machines.MachineIdx == -1)
                {
                    Machines.MachineData.Add("ATLASVAC@" + ip + ":21-" + machineName.Text);
                }
                else
                {
                    Machines.MachineData[Machines.MachineIdx] = "ATLASVAC@" + ip + ":21-" + machineName.Text;
                }
                this.Close();
            }
            else
            {

            }
        }
        private void CancelAddBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
