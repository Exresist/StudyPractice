using System;
using System.Linq;

namespace Ex7
{
    class Program
    {
        /*
         * Найти и исправить ошибку (если она есть) в заданном кодовом слове кода Хэмминга,
         * полученном на выходе канала связи.
         */
        static void Main(string[] args)
        {
            int numOfError = 0; // номер бита с ошибкой
            int index = 0;

            var str = CheckByte("Введите кодовое слово: ");
            int[] mas = new int[str.Length];

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '0') mas[i] = 0;
                if (str[i] == '1') mas[i] = 1;
            }

            var num = Degree(str.Length);

            for (int i = 0; i <= num; i++)
            {
                int sum = 0; // сумма контролируемых битов
                int ratio = 1; 
                double j = Math.Pow(2, i); // 2 в определённой степени

                do
                {
                    for (int k = 0; k < j; k++)
                    {
                        index = k + (int) j * ratio - 1;
                        if (index >= str.Length) break;
                        sum += mas[index];
                    }

                    if (j == 1)
                    {
                        ratio += 2;
                    }
                    else
                    {
                        ratio += (int) j;
                    }

                } while (index < str.Length);

                if (sum % 2 != mas[(int) j - 1])
                {
                    numOfError += (int) j;
                }
            }


            if (numOfError != 0)
            {
                if (numOfError >= mas.Length) numOfError = mas.Length-1;
                if (numOfError == 1) numOfError = 0;
                if (mas[numOfError] == 0) mas[numOfError] = 1; else
                if (mas[numOfError] == 1) mas[numOfError] = 0;
                Console.WriteLine("Ошибка найдена в {0} разряде кодового слова", numOfError+1);
                Console.Write("Исправленное кодовое слово: ");

                for (int i = 0; i < str.Length; i++)
                {
                    Console.Write(mas[i]);
                }

                Console.WriteLine();
            }
            else Console.WriteLine("В кодовом слове не найдена ошибка");
        }

        static string CheckByte(string message)
        {
            bool ok; // Проверка ввода
            string str; // Битовая строка


            do
            {
                Console.Write(message);
                str = Console.ReadLine();

                ok = str.All(t => t == '0' || t == '1');

                if (!ok) Console.WriteLine("Ошибка! Введите битовую строку!");
            } while (!ok);

            return str;
        }

        static int Degree(int str) // Вычисление степени двойки
        {
            int pow = 0;

            while (str > 0)
            {
                str = str / 2;
                pow++;
            }

            pow--;

            return pow;
        }
    }
}