using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Problem164
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Dictionary<int,Dictionary<int,Dictionary<int,long>>> dicCount = new Dictionary<int, Dictionary<int, Dictionary<int,long>>>();
            for (int i = 0; i < 10; i++)
            {
                dicCount.Add(i,new Dictionary<int, Dictionary<int,long>>());
                for (int j = 0; j < 10; j++)
                {
                    dicCount[i].Add(j,new Dictionary<int, long>());
                    for (int k = 0; k < 10; k++)
                    {
                        dicCount[i][j].Add(k,0);
                    }
                }
            }
            for (int i = 0; i < 1000; i++)
            {
                if (!CheckDigitNum(i, 3))
                    continue;
                int first = i/100;
                int second = (i%100)/10;
                int third = i%10;
                dicCount[first][second][third] ++;
            }
            long totalCount = 0;
            for (int digitNum = 1; digitNum <= 9; digitNum++)
            {
                for (int first = 0; first + digitNum < 10; first++)
                {
                    for (int second = 0; second + first + digitNum < 10; second++)
                    {
                        totalCount += dicCount[first][second].Values.Sum();
                    }
                }
            }
            for (int i = 3; i < 19; i++) { 
                Dictionary<int, Dictionary<int, Dictionary<int, long>>> tempCount = new Dictionary<int, Dictionary<int, Dictionary<int, long>>>();
                for (int digitNum = 0; digitNum <= 9; digitNum++)
                {
                    tempCount.Add(digitNum, new Dictionary<int, Dictionary<int, long>>());
                    Dictionary<int, long> temp = new Dictionary<int, long>();
                    for (int first = 0; first <= 9; first++)
                    {
                        tempCount[digitNum].Add(first, new Dictionary<int, long>());
                        for (int second = 0; second <= 9; second++)
                        {
                            tempCount[digitNum][first].Add(second, 0);
                            if (first + second + digitNum > 9)
                                continue;
                            tempCount[digitNum][first][second] += dicCount[first][second].Values.Sum();
                        }
                    }
                }
                dicCount = tempCount;
            }
            
            totalCount = 0;
            for (int digitNum = 1; digitNum <= 9; digitNum++)
            {
                for (int first = 0; first + digitNum < 10; first++)
                {
                    for (int second = 0; second + first + digitNum < 10; second++)
                    {
                        totalCount += dicCount[first][second].Values.Sum();
                    }
                }
            }

            Console.WriteLine("result is {0}",totalCount);
        }

        static bool CheckDigitNum(long num,int len)
        {
            int max = (int) Math.Pow(10, len);
            long temp = num;
            while (temp > max)
            {
                if (GetDigitsSum(temp%max) > 9)
                    return false;
                temp = temp/10;
            }
            if (GetDigitsSum(temp) > 9)
                return false;
            return true;
        }
        static long GetDigitsSum(long num)
        {
            long result = 0;
            long temp = num;
            while (temp > 0)
            {
                result += temp%10;
                temp = temp/10;
            }
            return result;
        }

    }
}
