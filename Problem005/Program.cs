using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem005
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] divNum = { 3, 4, 6, 7, 8, 9, 11, 12, 13, 14, 15, 16, 17, 18, 19 };
            int i = 20;
            bool found = true;
            while (true)
            {
                found = true;
                foreach (int div in divNum)
                {
                    if (i % div != 0)
                    {
                        found = false;
                        break;
                    }
                }
                if (found)
                    break;
                i += 20;
            }
            Console.WriteLine(i);
            Console.ReadLine();
        }
    }
}
