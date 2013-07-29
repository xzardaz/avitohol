using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JoroTheRabbit
{
    class Program
    {
        static void Main(string[] args)
        {
            Rabbit Joro = new Rabbit();
            string inp;
            inp=Console.ReadLine();
            Joro.calculate(inp);
            inp = Console.ReadLine();
        }
    }
    class Rabbit
    {
        private ushort fields;
        private short[] values;
        private int maxJumps;
        public Rabbit()
        {
            maxJumps = 0;
            fields = 5;
        }
        public Rabbit(string input)
        {
            fields = 5;
        }
        private void processInput(string input)
        {
            string[] nums=input.Split(',');
            fields = (ushort)nums.Length;
            values=new short[nums.Length];
            for (int i = 0; i < nums.Length; i++)
                values[i]=short.Parse(nums[i]);
        }
        private bool canJump(int from, int to)
        {
            return values[from] < values[to];
        }
        private ushort calcJumps(int startPos, int steps)
        {
            if (canJump(startPos % fields, (startPos + steps) % fields))
                return (ushort)(1 + calcJumps(startPos + steps, steps));
            return 0;
        }
        public void calculate(string input)
        {
            processInput(input);
            for (ushort steps = 1; steps < fields-1; steps++)
            {
                for (ushort startPos = 0; startPos < fields; startPos++)
                {
                    int a=calcJumps(startPos,steps);
                    if(maxJumps < a+1)
                    {
                        maxJumps = a + 1;
                        //break;
                    }
                    //Console.WriteLine("for strpos " + startPos + " and steps " + steps + " is " + (maxJumps));
                };
            };
            Console.WriteLine(maxJumps);
        }
    }
}
