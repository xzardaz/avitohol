using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace LLuckyNumbers
{
    class Program
    {
        static ulong luckyNumbers = 0;
        static Regex rexpr = new Regex(@"[^35]");
        static ulong A, B;
        static void Main(string[] args)
        {
            ushort digits=0;
            A = 0;
            B = 99999999999999;
            if (A > B)
                return;
            ulong diff = B - A;/*/
            for(ulong i=A;i<B;i+=2)
            {
                if (isLucky(i))
                {
                    digits++;
                }
                i = i + (ulong)(i % 10 == 3 ? 0 : 6);
            }//*/
            Generate(0,0);
            Console.WriteLine("dgtsnmbr" + luckyNumbers);
        }
        private static bool isLucky(ulong n)
        {
            byte digits = (byte)Math.Floor(Math.Log10(n));
            byte halfDigits = (byte)(Math.Floor(digits / 2D));
            for (int i = 0; i <= halfDigits; i++)
            {
                byte currentDigit = (byte)(((n - n % Math.Pow(10, i)) / Math.Pow(10, i)) % 10);
                byte mirrorDigit = (byte)(((n - n % Math.Pow(10, digits - i)) / Math.Pow(10, digits - i)) % 10);
                if (!((currentDigit == 5 || currentDigit == 3) && (mirrorDigit == 5 || mirrorDigit == 3) && (currentDigit == mirrorDigit))) return false;
            }
            return true;
        }
        private static bool isLuckyStr(ulong n)
        {
            string str = n.ToString();
            if (rexpr.IsMatch(str)) return false;
            byte halfDigits = (byte)Math.Floor(str.Length / 2D);
            for (int i = 0; i <= halfDigits; i++)
            {
                if (str.Substring(i,1) != str.Substring(str.Length - i - 1,1)) return true; 
            }
            return false;
        }
        private static bool IsPalindromeNumber(ulong n)
        {
            byte digits = (byte)Math.Floor(Math.Log10(n));
            byte halfDigits = (byte)(Math.Floor(digits / 2D));
            for (int i = 0; i <= halfDigits; i++)
            {
                byte currentDigit = (byte)(((n - n % Math.Pow(10, i)) / Math.Pow(10, i)) % 10);
                byte mirrorDigit = (byte)(((n - n % Math.Pow(10, digits - i)) / Math.Pow(10, digits - i)) % 10);
                if (currentDigit != mirrorDigit) return false;
            }
            return true;
        }
        static void Generate(int start, ulong current)
        {
            if (current < A || current > B) return;
            if (IsPalindromeNumber(current))
                luckyNumbers++;

            if (start == 19)
            {
                return;
            }

            Generate(start + 1, current * 10 + 3);
            Generate(start + 1, current * 10 + 5);
        }
    }
}
