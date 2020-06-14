using System;

namespace Ex8
{
    /*
     * Граф задан матрицей смежности. Найти в нем какой-либо простой цикл из K вершин
     */
    class Program
    {
        static Random rnd = new Random();
        static int ReadNum()
        {
            int inpNum;
            while (true)
            {
                try
                {
                    inpNum = Convert.ToInt32(Console.ReadLine());
                    return inpNum;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Внимание: {e.Message} Попробуйте ещё раз");
                }
            }
        }
        static int ReadNaturalNum()
        {
            int inpNum = 0;
            while (inpNum < 1)
            {
                inpNum = ReadNum();
                if (inpNum < 1)
                {
                    Console.WriteLine("Необходимо ввести натуральное число");
                }
            }
            return inpNum;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите кол-во тестов, которое вы хотите провести:");
            int num = ReadNaturalNum();
            Console.WriteLine($"Кол-во тестов: {num}\nРезультат:");
            Console.WriteLine("+------------------------------+");
            for (int i = 0; i < num; ++i)
            {
                Console.WriteLine($"Тест №{i+1}:\n+------------------------------+");
                Graph curG = new Graph();
                curG.Show();
                int len = rnd.Next(3, curG.NumNodes + 1);
                Console.WriteLine($"Поиск цикла длины {len}:");
                curG.FindCycle(len);
                Console.WriteLine("+------------------------------+");
            }
        }
    }
}