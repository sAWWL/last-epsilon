using System;
using System.IO;
using System.Windows;

namespace Project_Epsilon
{
    public static class SaveConfig
    {
        public static void Save()
        {
            string output = "";
            string CONFIG = "config.ini";
            foreach (string server in Machines.MachineData)
            {
                output += server.Split('@')[1].Split(':')[0] + "-";
                output += server.Split('-')[1].Split('/')[0] + "-";
                output += server.Split('/')[1] + "|";
            }

            output = output.TrimEnd('|');
            File.WriteAllText(Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents", CONFIG), output);
        }   
    }
}