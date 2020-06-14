using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Ex1
{
    class Program
    {
        /*
         * Первая строка входного файла содержит два числа: xn и yn — координаты города N.
         * Вторая строка входного файла содержит количество k треугольных стран (1 ≤ k ≤ 1000).
         * Последующие k строк каждая описывают одну треугольную страну. Описание треугольной страны состоит из шести целых чисел x1,y1,x2,y2,x3,y3,
         * где (x1,y1), (x2,y2), (x3,y3) — координаты вершин этой страны.
         * Гарантируется, что все страны имеют ненулевую площадь. Все координаты не превосходят 10000 по абсолютной величине.
         * В первой строке выходного файла выведите количество стран, в которые мог входить город N.
         * Во второй строке выведите через пробел номера этих стран в возрастающем порядке.
         * Страны нумеруются с единицы в том порядке, в каком они заданы во входном файле.
         */
        static void Main()
        {
            StreamReader streamReader = new StreamReader("input.txt", Encoding.UTF8);
            StreamWriter streamWriter = new StreamWriter("output.txt");
            string[] coordinate = streamReader.ReadLine().Split(' ');
            int x = int.Parse(coordinate[0]);
            int y = int.Parse(coordinate[1]);

            string tempVar = streamReader.ReadLine();
            int n = int.Parse(tempVar);

            List<int> ak = new List<int>();


            for (int j = 0; j < n; j++)
            {
                int[] a = new int[6];
                tempVar = streamReader.ReadLine();
                string[] temp = tempVar.Split(' ');
                for (int i = 0; i < 6; i++)
                {
                    a[i] = int.Parse(temp[i]);
                }
                int first = (a[0] - x) * (a[3] - a[1]) - (a[2] - a[0]) * (a[1] - y);
                int second = (a[2] - x) * (a[5] - a[3]) - (a[4] - a[2]) * (a[3] - y);
                int third = (a[4] - x) * (a[1] - a[5]) - (a[0] - a[4]) * (a[5] - y);
                if (first > 0 && second > 0 && third > 0 || (first < 0 && second < 0 && third < 0))
                {
                    ak.Add(j+1);
                }
            }
            streamWriter.WriteLine(ak.Count);

            foreach (var t in ak)
            {
                streamWriter.Write(t + " ");
            }

            streamWriter.Close();
        }
    }
}