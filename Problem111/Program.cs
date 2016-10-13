using Kang.Algorithm.BaseLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem111
{
    class NumberSigned
    {
        private long _value;
        public long Value
        {
            get { return _value; }
            set {
            _value = value;
            SignNumber();
        } }
        public short[] Sign { get; set; }
        private void SignNumber()
        {
            Sign = new short[10];
            long temp = _value;
            while (temp > 0)
            {
                Sign[temp % 10]++;
                temp = temp / 10;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] str = FileReader.ReadFile("primes_100000000.txt").Split(',');
            int[] primes = new int[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                primes[i] = int.Parse(str[i]);
            }
            List<NumberSigned> signedNumbers = new List<NumberSigned>();
            for (int i = 0; ; i++)
            {
                if (primes[i] > 10000000000)
                    break;
                if (primes[i] < 1000000000)
                    continue;
                signedNumbers.Add(new NumberSigned() { Value = primes[i] });
            }
            for (int i = 0; i < 10; i++)
            {
                int len = M(signedNumbers, i);
                long sum = S(signedNumbers, i, len);
                Console.WriteLine("M(num,{0}) = {1} ; S(num,{0}) = {2}", i,len,sum);

            }
        }
        static int M(List<NumberSigned> signedNumbers, int d)
        {
            if (d < 0 || d > 10)
                throw new ApplicationException("d must between 0 and 10");
            return signedNumbers.Max(x => x.Sign[d]);
        }
        static long S(List<NumberSigned> signedNumbers, int d,int len)
        {
            return signedNumbers.Where(x => x.Sign[d] == len).Sum(x => x.Value);
        }
    }
}
