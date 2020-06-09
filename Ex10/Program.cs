using System;

namespace Ex10
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите количество вершин графа: ");
            int size = InputNumber(Console.ReadLine());
            int[] arr = new int[size];
            for (int i = 0; i < size; i++)
            {
                Console.Write("Введите информационное значение графа: ");
                arr[i] = InputNumber(Console.ReadLine());
            }

            Console.Write("Введите, вершины с каким информационным полем вы хотите удалить: ");
            int delete = InputNumber(Console.ReadLine());
            Console.WriteLine("Оставшиеся вершины графа:");
            foreach (var high in arr)
            {
                if (high != delete)
                {
                    Console.WriteLine(high);
                }
            }
        }
        private static int InputNumber(string value)
        {
            bool ok;
            do
            {
                int num;
                if (ok = int.TryParse(value, out num) && num > 0)
                {
                    return num;
                }
                Console.WriteLine("Ошибка, введите корректное значение!");
                Console.ReadLine();
            } while (!ok);
            return 0;
        }
    }
}