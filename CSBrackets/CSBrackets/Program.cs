using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSBrackets
{
    class Program
    {
        static void examine(int depth)
        {

        }
        static string multiply(int depth,string ident)
        {
            string id="";
            for (int i = 0; i < depth; i++)
                id += ident;
            return id;
        }
        static string process(string input)
        {
            int indOpen = input.IndexOf('{');
            int indClose = input.LastIndexOf('}');
            //if(input.ElementAt(indOpen)!='\n')
            //    input.Insert(indOpen, "\n");
            //Console.WriteLine(indClose);
            string internala=input.Substring(indOpen,indClose-indOpen).Replace("\n", "tabulation_");
            do
            {
                //input.Substring()
            }
            while (false);
            return internala;
        }
        static void Main(string[] args)
        {
            int depth = 0;
            string[] JoroCodeAr;
            int lines = int.Parse(Console.ReadLine());
            if (lines < 1 || lines >= 1000)
                throw new Exception("not acceptable");
            string indentation = Console.ReadLine();
            if (indentation.Length < 1 || indentation.Length >= 100)
                throw new Exception("not acceptable");
            JoroCodeAr=new string[lines];
            string JoroCode = "";
            for (int i = 0; i < lines; i++)
                JoroCode += Console.ReadLine().Trim();
            Console.WriteLine(process(JoroCode));
            Console.ReadLine();
        }
    }
}
