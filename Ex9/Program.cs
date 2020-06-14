using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex9;

namespace PracticeTask9
{
    class Program
    {
        /*
         * Напишите метод создания циклического списка,
         * в информационные поля элементов которого последовательно заносятся номера с 1 до N (N водится с клавиатуры).
         * Первый включенный в список элемент, имеющий номер 1, оказывается в хвосте списка (последним).
         * Разработайте методы поиска и удаления элементов списка.
         */
        static void Main(string[] args)
        {
            int N = GetN();

            // Создание
            Console.Write("Созданный лист: ");
            CircularList circularList = new CircularList();
            circularList.CreateCircularList(N);
            circularList.Show();
            Console.WriteLine();
            // Поиск
            int value = GetWantedValue();
            Point wanted = circularList.Search(value, circularList.Head, circularList.Tail);
            if (wanted.Next == null)
            {
                Console.WriteLine("Элементов с искомым значений найдено не было!");
            }
            else
            {
                Console.WriteLine($"Элемент с искомым значением: {wanted.Value}\nСледующий элемент: {wanted.Next.Value}");
            }
            // Удаление
            value = GetWantedValue();
            circularList.Head = circularList.Delete(value, circularList.Tail, circularList.Head, circularList.Tail);
            circularList.Show();

            Console.ReadLine();
        }

        // Получение N
        public static int GetN()
        {
            int N;
            bool ok;
            do
            {
                Console.Write("Введите количество элементов: ");
                ok = Int32.TryParse(Console.ReadLine(), out N);
                if (!ok || N < 2)
                    Console.WriteLine("Ошибка! Число элементов должно быть больше 1!");
            } while (!ok || N < 2);

            return N;
        }

        // Получение искомого значения
        public static int GetWantedValue()
        {
            int value;
            bool ok;
            do
            {
                Console.Write("Введите искомое значение: ");
                ok = Int32.TryParse(Console.ReadLine(), out value);
                if (!ok)
                    Console.WriteLine("Ошибка! Введите целое число!");
            } while (!ok);

            return value;
        }
    }
}