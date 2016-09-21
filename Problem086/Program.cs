using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem086
{
    class Program
    {
        static void Main(string[] args)
        {   
            int c = 1;  
            int count = 0;  
            while (count < 1000000)  {  
                c++;  
                for (int ab = 2; ab <= 2 * c; ab++)  
                {  
                    int path=ab*ab + c*c;  
                    int tmp = (int)Math.Sqrt(path);  
                    if (tmp*tmp == path)
                    {  
                        count += (ab >= c) ? 1+(c-(ab+1)/2) : ab / 2;  
                    }  
                }  
            }
            Console.WriteLine("Result is {0}", c);
        }
    }
}
