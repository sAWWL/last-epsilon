using System.IO;
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
            System.IO.File.WriteAllText(System.IO.Path.Combine(Directory.GetCurrentDirectory(), CONFIG), output);

        }   
    }
}