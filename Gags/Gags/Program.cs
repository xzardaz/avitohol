using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gags
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = "adsfads";
            byte digitsCount=0;
            byte[] digits=new byte[20];
            for (int i = 0; i < a.Length; i++)
            {
                switch (a[i])
                {
                    case '-':
                        digits[digitsCount] = 0;
                        digitsCount++;
                        break;
                    case '*':
                        if (a[i + 1] == '*')
                        {
                            digits[digitsCount] = 1;
                            digitsCount++;
                        }
                        else//!
                        {
                            digits[digitsCount] = 6;
                            digitsCount++;
                            i += 2;
                        }
                        break;
                    case '&':
                        if (a[i + 1] == '&')
                        {
                            digits[digitsCount] = 3;
                            digitsCount++;
                        }
                        else if (a[i + 1] == '-')
                        {
                            digits[digitsCount] = 4;
                            digitsCount++;
                        }
                        else
                        {
                            digits[digitsCount] = 7;
                            digitsCount++;
                            i ++;
                        }
                        break;
                    case '!':
                        if (a[i + 1] == '-')
                        {
                            digits[digitsCount] = 5;
                            digitsCount++;
                        }
                        else//!
                        {
                            if (a[i + 2] == '!')
                            {
                                digits[digitsCount] = 2;
                                digitsCount++;
                            }
                            else//!
                            {
                                digits[digitsCount] = 8;
                                digitsCount++;
                                i++;
                            }
                        }
                        break;
                }
                i++;
            }
        }
    }
}
