using System;

namespace Ex3
{
    class Program
    {
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