using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem024
{
    class Program
    {
        static void Main(string[] args)
        {
            Permutation(new List<int>(), new List<int>() { 0, 1, 2 ,3,4,5,6,7,8,9});
            Console.ReadLine();
        }
        static int index = 0;
        static void Permutation(List<int> preList, List<int> keys)
        {
            if (keys.Count == 1)
            {
                //foreach (int item in preList)
                //{
                //    Console.Write(item);
                //}
                //Console.WriteLine(keys[0]);
                index++;
                if (index == 1000000)
                {
                    foreach (int item in preList)
                    {
                        Console.Write(item);
                    }
                    Console.WriteLine(keys[0]);
                }
                return;
            }
            for (int i = 0; i < keys.Count; i++)
            {
                int key = keys[i];
                List<int> otherKeys = new List<int>();
                otherKeys.AddRange(keys);
                otherKeys.RemoveAt(i);
                List<int> curPreList = new List<int>();
                curPreList.AddRange(preList);
                curPreList.Add(key);
                Permutation(curPreList, otherKeys);
            }
        }
    }
}
