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
            Permutation(new List<int>(), new List<int>() { 0, 1, 2 });
            Console.ReadLine();
        }
        static void Permutation(List<int> preList, List<int> keys)
        {
            List<int> curPreList = new List<int>();
            curPreList.AddRange(preList);
            if (keys.Count == 1)
            {
                foreach (int item in preList)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine(keys[0]);
                return;
            }
            for (int i = 0; i < keys.Count; i++)
            {
                int key = keys[i];
                List<int> otherKeys = new List<int>();
                otherKeys.AddRange(keys);
                otherKeys.RemoveAt(i);
                curPreList.Add(key);
                Permutation(curPreList, otherKeys);
            }
        }
    }
}
