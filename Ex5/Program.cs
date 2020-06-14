using System;

namespace Ex5
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Дана действительная квадратная матрица порядка л.
             * Найти наибольшее из значений элементов, расположенных в заштрихованной части матрицы
             */
            Console.Write("Введите размерность двумерного массива:");
            int row = InputNumber(Console.ReadLine());
            int[,] array = new int[row,row];
            Console.WriteLine("Создать массив:\n1. Случайным образом\n2. Вручную");
            bool okay;
            do
            {


                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        Random rnd = new Random();
                        for (int i = 0; i < row; i++)
                        {
                            for (int j = 0; j < row; j++)
                            {
                                array[i, j] = rnd.Next(-200, 200);
                            }
                        }

                        okay = true;
                        break;
                    case 2:
                        for (int i = 0; i < row; i++)
                        {
                            for (int j = 0; j < row; j++)
                            {
                                Console.Write($"Введите число {i + 1} строки {j + 1} столбца:");
                                bool ok;
                                do
                                {
                                    ok = int.TryParse(Console.ReadLine(), out array[i,j]);
                                    if (ok) continue;
                                    Console.WriteLine("Ошибка, введите целое число!");
                                    Console.ReadLine().Replace('.', ',');
                                } while (!ok);
                            }
                        }
                        okay = true;
                        break;
                    default:
                        Console.WriteLine("Выберите один из представленных вариантов!");
                        okay = false;
                        break;
                }
            } while (!okay);
            Console.WriteLine("Вывод массива:");
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    if (i >= j && i + j >= row - 1)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.Write(array[i,j] + " ");
                    }
                    else
                    {
                        
                        Console.Write(array[i,j] + " ");
                    }
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.WriteLine();
            }
            Console.WriteLine("Зеленым цветом выделена заштрихованная зона.");
            int max = array[row-1, row-1];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    if (i >= j && i + j >= row - 1 && array[i, j] > max)
                    {
                        max = array[i, j];
                    }
                }
            }
            Console.WriteLine($"Максимальное число в заштрихованной зоне равно {max}");
        }
        
        private static int InputNumber(string value)
        {
            bool ok;
            do
            {
                int num;
                if (ok = int.TryParse(value, out num) && num > 2)
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