/*
 * As long as all the money are from .05 to 1000.00,
 * and the smallest gap between money numbers is 0.05, I wont
 * be using floats for storing money, instead I will convert them
 * to a different unit in order to save memory. 1 unit = 20*money units.
 * So the money will be stored in ushort (can be stored in short
 * also, but they are all positive numbers, and I want to be shure there are
 * no mistakes). This will be more CPU intensive, due to the conversions.
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        private static string inp;
        private static float drinkPrice;

        private ushort readShort()
        {
            //this will always be in the ushort range as long as 0 < the input integer < 10^5
            return (ushort)(readInt() / 5);
        }

        //read float from console
        private static uint readInt()
        {
            uint result=0;
            inp = Console.ReadLine();
            try
            {
                result = uint.Parse(inp);
                if (result > 100000)
                {
                    Console.WriteLine("value not in range {0;100000}");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("You did not enter a positive integer.");
            }
            catch (Exception e)
            {
                Console.WriteLine("An exception occurred while parsing your response: {0}", e.ToString());
            }
            return result;
        }

        //read float from console
        private static float readFloat()
        {
            float result=0F;
            inp = Console.ReadLine();
                try
                {
                    result = float.Parse(inp);
                }
                catch (FormatException)
                {
                    Console.WriteLine("You did not enter a valid number.");
                }
                catch (Exception e)
                {
                    Console.WriteLine("An exception occurred while parsing your response: {0}", e.ToString());
                }
            
            float reminder=(float)Math.Round((result%0.05F),2);
            if(Math.Round((result * 100) % 5)!=0)
            {
                Console.WriteLine("You did not enter a valid price. Assuming " + (result-reminder));
                result -= reminder;
            }
            return result;
        }

        //read float from console
        private static void waitForKeystroke()
        {
            Console.ReadLine();
        }

        void Main(string[] args)
        {
            int machineMoney=0;
            float[] trails=new float[5];
            float developerInput, machineOutput;
            ushort currentI;
            for (int i = 0; i < 5; i++)
            {
                currentI = this.readShort();
                //5,10,20 lie on an axponential line and 50 and 100 lie on a streight line;
                machineMoney += (i < 3) ? currentI * (int)Math.Pow(2, i)*5 : currentI * (50 * i - 100);
            };
            developerInput = readFloat();
            drinkPrice = readFloat();
            if (drinkPrice > developerInput)
            {
                Console.WriteLine("More " + Math.Round(drinkPrice - developerInput, 2));
                waitForKeystroke();
            }
            else if (machineMoney < developerInput - drinkPrice)
            {
                Console.WriteLine("No " + Math.Round(developerInput - drinkPrice - machineMoney, 2));
                waitForKeystroke();
            }
            else
            {
                Console.WriteLine("Yes " + Math.Round(machineMoney-developerInput + drinkPrice, 2));
                waitForKeystroke();
            }
        }
    }
}
