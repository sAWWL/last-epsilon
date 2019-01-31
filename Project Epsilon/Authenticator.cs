using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Project_Epsilon
{
    class Authenticator
    {
        public String Encrypt(String rawInput)
        {
            MessageBox.Show(rawInput);
            const int OFFSET = 25;
            byte[] asciiValues = Encoding.ASCII.GetBytes(rawInput);
            for (int i = 0; i < asciiValues.Length; i++)
            {
                asciiValues[i] += (byte)OFFSET;
                while (asciiValues[i] > 122)
                {
                    asciiValues[i] -= 90;
                }
            }
            return Encoding.ASCII.GetString(asciiValues);
        }
    }
}
