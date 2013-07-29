using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KaspichanNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            //init.
            ulong number = ulong.Parse(Console.ReadLine());
            StringBuilder KaspichanNotation = new StringBuilder();

            //The (rounded up) logarithm of integer gives the digits of the integer at base of the log
            //log_base256(x)=log_somebase(x)/log_somebase(256)
            byte digits = (byte)Math.Ceiling(Math.Log(number+1) / Math.Log(256));

            //Convert each digit to Kaspichan notation
            for (int i = digits-1; i >= 0; i--)
            {
                //extract the i'th digit from the number
                ulong r=(ulong)Math.Pow(256, i);
                ulong digit = (((number - number % r) / r) % 256);

                //convert to Kaspichan notation
                //(with prefix if >25)
                if (digit > 25)
                    KaspichanNotation.Append(Convert.ToChar(96 + (byte)(Math.Floor(digit / 26D))));
                KaspichanNotation.Append(Convert.ToChar(65 + digit % 26));
            }
            //ready :)
            Console.WriteLine(b);
        }
    }
}
