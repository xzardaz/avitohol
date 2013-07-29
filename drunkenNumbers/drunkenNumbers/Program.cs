using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace drunkenNumbers
{
    class Program
    {
        private static long MitkoSum = 0;
        private static long VladkoSum = 0;

        private static byte MitkoInd = 0;
        private static byte VladkoInd = 1;
        private static long[] SumsArray;

        private static int number;
        private static ThreadStart starter;
        private static void nthDigitPopulate(long number, byte n, byte person)
        {
            SumsArray[person] += ((int)((number - (int)(number % Math.Pow(10, n))) / Math.Pow(10, n))) % 10;
        }
        private static void toDigitsThr(string snumber)
        {
            number = Int32.Parse(snumber);
            byte digits = (byte)Math.Floor(Math.Log10(number) + 1);
            for (byte i = 0; i < digits; i++)
            {
                if (i < Math.Ceiling(digits / 2.0))
                {
                    starter = delegate { nthDigitPopulate(number, i, 1); };
                    new Thread(starter).Start();
                }
                if (i >= Math.Floor(digits / 2.0))
                {
                    starter = delegate { nthDigitPopulate(number, i, 0); };
                    new Thread(starter).Start();
                }
            }
        }
        private static void toDigits(string snumber)
        {
            number = Int32.Parse(snumber);
            byte digits = (byte)Math.Floor(Math.Log10(number)+1);
            //digits = (byte)Math.Ceiling(digits/2.0);
            //Console.WriteLine(digits);
            for (byte i = 0; i < digits; i++)
            {
                if (i < Math.Ceiling(digits / 2.0))
                    SumsArray[VladkoInd] += ((int)((number - (int)(number % Math.Pow(10, i))) / Math.Pow(10, i))) % 10;
                if (i >= Math.Floor(digits / 2.0))
                    SumsArray[MitkoInd] += ((int)((number - (int)(number % Math.Pow(10, i))) / Math.Pow(10, i))) % 10;
            }
        }
        private static void toDigitsStr(string number)
        {
            VladkoSum = 0;
            MitkoSum = 0;
            //byte digits = (byte)Math.Floor(Math.Log10(number) + 1);
            byte digits = (byte)number.Length;
            //Console.WriteLine(number.ElementAt(2).ToString());
            for (byte i = 0; i < digits; i++)
            {
                if (i < Math.Ceiling(digits / 2.0))
                    SumsArray[VladkoInd] += long.Parse(number.ElementAt(digits - i - 1).ToString());
                if (i >= Math.Floor(digits / 2.0))
                    SumsArray[MitkoInd] += long.Parse(number.ElementAt(i).ToString());
            }
        }
        private static void toDigitsASCII(string number)
        {
            VladkoSum = 0;
            MitkoSum = 0;
            //byte digits = (byte)Math.Floor(Math.Log10(number) + 1);
            byte digits = (byte)number.Length;
            //Console.WriteLine(number.ElementAt(2).ToString());
            for (byte i = 0; i < digits; i++)
            {
                if (i < Math.Ceiling(digits / 2.0))
                {
                    if (48 > number.ElementAt(digits - i - 1) || 57 < number.ElementAt(digits-i-1)) { return; };
                    SumsArray[VladkoInd] += 48 + number.ElementAt(digits - i - 1);
                };
                if (i >= Math.Floor(digits / 2.0))
                {
                    if (48 > number.ElementAt(i) || 57 < number.ElementAt(i)) { return; };
                    SumsArray[MitkoInd] += 48 + number.ElementAt(i);
                }
            }
        }
        static void Main(string[] args)
        {
            SumsArray = new long[2];
            Random rand = new Random();
            byte rounds;
            int dNumber;
            MitkoSum=0;
            VladkoSum = 0;
            string snum = "" + 12345678;
            //int inum = 12345678;
            for (int i = 0; i < 1;i++ )
            {
                //int num = rand.Next(10000, 99999999);
                char ch='0';
                int a = 0 + ch;
                //Console.WriteLine("ASCII" + a);
                toDigits(snum);
                Console.WriteLine("VL" + SumsArray[VladkoInd]);
                Console.WriteLine("MT" + SumsArray[MitkoInd]);
                toDigitsStr(snum);
                Console.WriteLine("VL" + SumsArray[VladkoInd]);
                Console.WriteLine("MT" + SumsArray[MitkoInd]);
                toDigitsASCII(snum);
                Console.WriteLine("VL" + SumsArray[VladkoInd]);
                Console.WriteLine("MT" + SumsArray[MitkoInd]);
                toDigitsThr(snum);
                Console.WriteLine("VL" + SumsArray[VladkoInd]);
                Console.WriteLine("MT" + SumsArray[MitkoInd]);
            }
            //Console.WriteLine("VL"+VladkoSum);
            //Console.WriteLine("MT"+MitkoSum);

            ThreadStart job = new ThreadStart(ThreadJob);
            Thread thread = new Thread(job);
            thread.Start();

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Main thread: {0}", i);
                Thread.Sleep(1000);
            }

            Console.ReadLine();
        }

        static void ThreadJob()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Other thread: {0}", i);
                Thread.Sleep(500);
            }
        }
    }
}
