using System;

namespace Ex3
{
    class Program
    {
        /*
         * Пусть D — заштрихованная часть плоскости (рис.3, а — 3, ё) и пусть и определяется по х и у следующим
         * образом:
         * u =  x^2 -1, если (x,y) принадлежит D
         * u = sqrt(abs(x-1)) в противном случае.
         * Даны действительные числа x,y. Определить u.
         */
        static void Main(string[] args)
        {
            Console.Write("Введите координату x:");
            double x = InputCoordinate(Console.ReadLine().Replace('.',','));
            Console.Write("Введите координату y:");
            double y = InputCoordinate(Console.ReadLine().Replace('.',','));
            if (InCircle(x, y))
            {
                Console.WriteLine("Точка находится внутри круга.");
                double u = Math.Pow(x, 2) - 1;
                Console.WriteLine($"Значение u при введённых значениях: {u}");
            }
            else
            {
                Console.WriteLine("Точка не находится внутри заштрихованной области.");
                double u = Math.Sqrt(Math.Abs(x - 1));
                Console.WriteLine($"Значение u при введённых значениях: {u}");
            }
        }

        private static double InputCoordinate(string value)
        {
            bool ok;
            double num;
            do
            {
                if (ok = double.TryParse(value, out num))
                {
                    return num;
                }

                Console.WriteLine("Ошибка, введите корректную координату!");
                Console.ReadLine().Replace('.',',');
            } while (!ok);

            return 0;
        }

        private static bool InCircle(double x, double y)
        {
            if (!(y > 0)) return false;
            if (y >= 0 && y < 0.3 && x > 0 && x < 0.3) return false;
            return y >= 0 && (x >= 0.3 && x <= 1 || x <= 0 && x >= -1);
        }
    }
}