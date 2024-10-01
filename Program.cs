using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayDemo
{
    class Program
    {
        static int Main(string[] args)
        {
            int[] array = { 20, 20, 10, 40 };
            int MaxNum = int.MinValue;
            int SecondMaxNum = int.MinValue;

            foreach (int num in array)
            {
                if (num > MaxNum)
                {
                    SecondMaxNum = MaxNum;
                    MaxNum = num;

                }
                else if (num > SecondMaxNum && num < MaxNum)
                {
                    SecondMaxNum = num;
                }

            }
            return SecondMaxNum;
            Console.WriteLine("The Second Maximum Number is : {SecondMaxNum}");
            Console.ReadLine();
        }
    }
}
