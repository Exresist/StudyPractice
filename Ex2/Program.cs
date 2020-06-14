using System;
using System.IO;
using System.Numerics;

namespace Ex2
{
    class Program
    {
        /*
         * В известном городе Кызылорда, где находятся N центров, живет некий граф - Азамат.
         * Он желает узнать количество различных построек дорог между ними, если известно, что два центра могут быть связаны в одном из двух направлений или не связаны вообще.
         * Например, при N=2 все получается 3 варианта:
         * оба центра не связаны
         * дорога идет из первого во второй центр
         * дорога идет из второго в первый центр
         * Во входном файле INPUT.TXT записано единственное натуральное число - количество центров в городе, 2 ≤ N ≤ 100.
         * В единственную строку выходного файла OUTPUT.TXT нужно вывести число всевозможных построек дорог.
         */
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