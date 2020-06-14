using System;
using System.Diagnostics;
using System.Linq;
using static System.ConsoleKey;

namespace Ex12
{
    class Program
    {
        /*
         * Варианты сортировки:
         * Сортировка простым выбором
         * Сортировка подсчётом
         */
        static void Print(int[] mas)
        {
            foreach (int item in mas)
                Console.Write($" {item} ");
            Console.WriteLine();
        }

        static Random random = new Random();

        static void Fill(ref int[] mas)
        {
            for (int i = 0; i < mas.Length; i++)
                mas[i] = random.Next(1000);
        }

        static int[] CountingSort(int[] mas)
        {
            int countEq = 0;
            int countChoises = 0;

            int[] subMas = new int[mas.Max() + 1];
            for (var i = 0; i < mas.Length; ++i)
            {
                subMas[mas[i]]++;
            }
            for (int i = 0, j = 0; i < mas.Length; ++i)
            {
                while (subMas[j] == 0)
                {
                    countEq++;
                    j++;
                }

                countChoises++;
                mas[i] = j;
                subMas[j]--;
            }

            Console.WriteLine();

            Console.WriteLine("Количество сравнений " + countEq);
            Console.WriteLine("Количество перестановок " + countChoises);
            Console.WriteLine();

            return mas;
        }

        static int[] ChooseSort(int[] mas)
        {
            int countEq = 0;
            int countChoises = 0;
            for (int i = 0; i < mas.Length - 1; i++)
            {
                //поиск минимального числа
                int min = i;
                for (int j = i + 1; j < mas.Length; j++)
                {
                    if (mas[j] < mas[min])
                    {
                        min = j;
                        countEq++;
                    }
                }

                //обмен элементов
                int temp = mas[min];
                mas[min] = mas[i];
                mas[i] = temp;
                countChoises++;
            }

            Console.WriteLine();

            Console.WriteLine("Количество сравнений " + countEq);
            Console.WriteLine("Количество перестановок " + countChoises);
            Console.WriteLine();

            return mas;
        }

        static void Main()
        {
            Console.WriteLine("Сортировка массива");
            int[] sortedInc = new int[10];
            int[] sortedDec = new int[10];
            int[] unsorted = new int[10];
            Fill(ref sortedInc);
            Fill(ref sortedDec);
            Fill(ref unsorted);
            Array.Sort(sortedInc);
            Array.Sort(sortedDec);
            Array.Reverse(sortedDec);

            Print(sortedInc);
            Print(sortedDec);
            Print(unsorted);

            Console.WriteLine();
            Console.WriteLine("Сложность сортировки простым выбором => O(n2)");
            Console.WriteLine(
                "Сложность сортировки подсчетом => O(n + r — l), где r - максимальный элемент массива, l - минимальный");
            Console.WriteLine("Сортировка простым выбором массива в котором элементы расположены по возрастанию ==>");
            Print(ChooseSort(sortedInc));
            Console.WriteLine(
                "-----------------------------------------------------------------------------------------");
            Console.WriteLine("Сортировка простым выбором массива в котором элементы расположены по убыванию ==>");
            Print(ChooseSort(sortedDec));
            Console.WriteLine(
                "-----------------------------------------------------------------------------------------");
            Console.WriteLine("Сортировка простым выбором массива в котором элементы беспорядочны ==>");
            Print(ChooseSort(unsorted));
            Console.WriteLine(
                "-----------------------------------------------------------------------------------------");
            Console.WriteLine("Сортировка подсчетом массива в котором элементы расположены по возрастанию ==>");
            Print(CountingSort(sortedInc));
            Console.WriteLine(
                "-----------------------------------------------------------------------------------------");
            Console.WriteLine("Сортировка подсчетом массива в котором элементы расположены по убыванию ==>");
            Print(CountingSort(sortedDec));
            Console.WriteLine(
                "-----------------------------------------------------------------------------------------");
            Console.WriteLine("Сортировка подсчетом массива в котором элементы беспорядочны ==>");
            Print(CountingSort(unsorted));
            Console.WriteLine(
                "-----------------------------------------------------------------------------------------");

            Console.ReadKey();
        }
    }
}