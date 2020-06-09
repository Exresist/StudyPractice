using System;
using System.IO;
using System.Numerics;

namespace Ex2
{
    class Program
    {
        static void Main()
        {
            BigInteger result;
            using (StreamReader streamReader = new StreamReader("input.txt"))
            {
                int c = int.Parse(streamReader.ReadLine());
                int y = Convert.ToInt32(c * (c - 1) / 2);
                result = BigInteger.Pow(3, y);

            }



            using (StreamWriter stream = new StreamWriter("output.txt"))
            {
                stream.Write(Convert.ToString(result));
            }
        }
    }
}