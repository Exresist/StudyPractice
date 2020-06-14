using System;

namespace Ex6
{
    class Program
    {
        /*
         * Ввести а1, а2, а3, N.
         * Построить последовательность чисел ак = 13* ак–1 – 10* ак-2 + ак–3.
         * Построить N элементов последовательности проверить, образуют ли элементы, стоящие на четных местах,
         * возрастающую подпоследовательность.
         */
        static void Main(string[] args)
        {
            Console.Write("Введите первое число последовательности:");
            int a1 = InputNumber(Console.ReadLine());
            Console.Write("Введите второе число последовательности:");
            int a2 = InputNumber(Console.ReadLine());
            Console.Write("Введите третье число последовательности:");
            
            int a3 = InputNumber(Console.ReadLine());
            Console.Write("Введите количество членов последовательности, включая 3 предыдущих:");
            int N;
            bool ok;
            do
            {
                if (ok = int.TryParse(Console.ReadLine(), out N) && N >= 3) continue;
                Console.WriteLine("Ошибка, введите значение большее двух!");
                Console.ReadLine();
            } while (!ok);
            Console.WriteLine("Построение последовательности элементов:");
            Console.WriteLine(a1 + " 1-й член последовательности");
            Console.WriteLine(a2 + " 2-й член последовательности");
            Console.WriteLine(a3 + " 3-й член последовательности");
            
            int first = a1;
            int second = a2;
            int third = a3;
            
            for (int i = 4; i <= N; i++)
            {
                int fourth = Recursion(first, second, third);
                Console.WriteLine(fourth + $" {i}-й член последовательности");
                first = second;
                second = third;
                third = fourth;
            }
            first = a1;
            second = a2;
            third = a3;
            for (int i = 4; i <= N; i++)
            {
                int fourth = Recursion(first, second, third);
                if (i % 2 == 0 && fourth <= second)
                {
                    ok = false;
                    break;
                }
            }
            Console.WriteLine(ok
                ? "Элементы, стоящие на чётных местах составляют возрастающую подпоследовательность"
                : "Элементы, стоящие на чётных местах не составляют возрастающую подпоследовательность");
            
            
        }
        private static int InputNumber(string value)
        {
            bool ok;
            do
            {
                int num;
                if (ok = int.TryParse(value, out num))
                {
                    return num;
                }
                Console.WriteLine("Ошибка, введите корректное значение!");
                Console.ReadLine();
            } while (!ok);
            return 0;
        }

        private static int Recursion(int a1, int a2, int a3)
        {
            int a4 = 13 * a3 - 10 * a2 + a1;
            return a4;
        }
    }
}