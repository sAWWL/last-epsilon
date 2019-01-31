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
            //offsets the cesar-cipher by 25
            MessageBox.Show(rawInput);
            const int OFFSET = 25;
            byte[] asciiValues = Encoding.ASCII.GetBytes(rawInput);
            //creates a counter for the lengh of asciivalues
            for (int i = 0; i < asciiValues.Length; i++)
            {
                asciiValues[i] += (byte)OFFSET;
                //do this when the value reaches a certain point
                while (asciiValues[i] > 122)
                {
                    asciiValues[i] -= 90;
                }
            }
            //converts asciivalues into a string
            //throws it into the encoding return
            return Encoding.ASCII.GetString(asciiValues);
        }
    }
}
