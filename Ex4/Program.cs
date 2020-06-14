using System;

namespace Ex4
{
    class Program
    {
        /*
         * Вычислить бесконечную сумму с заданной точностью е (е > 0).
         * Считать, что требуемая точность достигнута,
         * если вычислена сумма нескольких первых слагаемых и очередное слагаемое оказалось по модулю меньше,
         * чем е,— это и все последующие слагаемые можно уже не учитывать (см. рис. 4.1).
         */
        static void Main(string[] args)
        {
            Console.Write("Введите точность вычисления суммы ряда:");
            double e = InputNumber(Console.ReadLine()?.Replace('.',','));
            double sum = 0;
            int i = 1;
            do
            {
                sum += 1 / Math.Pow(i, 2);
                i++;
            } while (1 / Math.Pow(i, 2) > e);
            i = 0;
            while (e < 1)
            {
                i++;
                e *= 10;
            }
            Console.WriteLine($"Сумма ряда с заданной точностью равна: {Math.Round(sum, i)}");
        }
        private static double InputNumber(string value)
        {
            bool ok;
            do
            {
                double num;
                if (ok = double.TryParse(value, out num) && num > 0)
                {
                    return num;
                }
                Console.WriteLine("Ошибка, введите корректную точность!");
                Console.ReadLine().Replace('.',',');
            } while (!ok);

            return 0;
        }
    }
}