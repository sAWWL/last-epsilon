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
        // List to index each octet of IP address 
        List<int> octets = new List<int>();

        // Method for adding a new machine
        public AddMachine()
        {
            InitializeComponent();
            if (Machines.MachineIdx != -1)
            {
                try
                {
                    string machinedata = Machines.MachineData[Machines.MachineIdx];
                    string machinename = machinedata.Split('-')[1];
                    string machineaddress = machinedata.Split('-')[0].Split('@')[1].Split(':')[0];

                    oct1.Text = machineaddress.Split('.')[0].Split('.')[0];
                    oct2.Text = machineaddress.Split('.')[1].Split('.')[0];
                    oct3.Text = machineaddress.Split('.')[2];
                    oct4.Text = machineaddress.Split('.')[3];
                    machineName.Text = machinename;
                }
                catch {; }
                machineName.Focus();
            }
        }

        // Ensuring the IP entered is a valid local IP
        public bool ValidateIP()
        {
            // Variable to keep track of whether IP is valid or not 
            bool valid = true;

            try
            {
                // Add each of the entered octets in each textbox to octets list
                octets.Add(Convert.ToInt16(oct1.Text));
                octets.Add(Convert.ToInt16(oct2.Text));
                octets.Add(Convert.ToInt16(oct3.Text));
                octets.Add(Convert.ToInt16(oct4.Text));

                // For every octet, check if it is outside the bounds of 0-255. If so, display error message
                foreach (int octet in octets)
                {
                    if (octet > 255 || octet < 0)
                    {
                        IPAddressError.Visibility = Visibility.Visible;
                        IPAddressError.Text += Convert.ToString(octet);
                        valid = false;
                    }

                }

                // Check if first octet is a valid local 192 or 10
                if (octets[0] != 192 || octets[0] != 10)
                {
                    valid = false;
                }
                return valid;

            }
            // If there was some error with the text entry
            catch
            {
                IPAddressError.Visibility = Visibility.Visible;
                IPAddressError.Text = "Not all fields have the correct format";
                return false;
            }
        }

        // Save button was clicked
        private void AddMachineBtn_Click(object sender, RoutedEventArgs e)
        {
            // If the entered IP is valid (ValidateIP method returns false)
            if (ValidateIP())
            {
                // String for concatenating each octet into one IP address string
                string ip = "";

                // Combine each octet into a single IP address string
                foreach (int octet in octets)
                {
                    ip += Convert.ToString(octet) + ".";
                }
                
                // Removes anything left over of string concatenation 
                ip.TrimEnd('.');

                // Apply FTP address to machine
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
        }

        // Cancel button is clicked
        private void CancelAddBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
