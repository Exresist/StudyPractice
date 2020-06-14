using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex9
{
    class CircularList
    {
        public Point Head { get; set; }
        
        public Point Tail { get; set; }
        
        public CircularList()
        {
            Head = null;
            Tail = null;
        }

        // Создание листа с N элементами
        public void CreateCircularList(int N)
        {
            Point head = new Point(N);
            
            Point tail = new Point(1);
            
            head.Next = tail;
            tail.Next = head;

            Add(N - 1, head, tail);

            Head = tail.Next;
            Tail = tail;
        }
        
        public static void Add(int N, Point head, Point tail)
        {
            
            if (N != 1)
            {
                // Временный элемент со значением N
                Point buf = new Point(N);

                // Добавление в промежуток между головой и хвостом
                head.Next = buf;
                buf.Next = tail;

                // Продолжение добавления, происходит перемещение к след. элементу
                Add(N - 1, buf, tail);
            }
        }
        
        public Point Search(int value, Point curr, Point tail)
        {
            // Если найдено или конец листа
            if (curr.Value == value || (curr.Value == tail.Value && curr.Next == tail.Next))
            {
                // Если найдено возвращает элемент, иначе создаётся новый
                if (curr.Value == value)
                    return curr;
                return new Point(0);
            }

            // Проверка следующего элемента
            Point wanted = Search(value, curr.Next, tail);
            return wanted;
        }
        
        public Point Delete(int value, Point prev, Point curr, Point tail)
        {
            
            if (curr.Value == value || (curr.Value == tail.Value && curr.Next == tail.Next))
            {
                // Удаляется, если найдено
                if (curr.Value == value)
                {
                    prev.Next = curr.Next;
                }
                else
                {
                    Console.WriteLine("Элемента с искомым значением найдено не было!");
                }

                return tail;
            }

            // Проверка следующего элементьа
            Point deleted = Delete(value, prev.Next, curr.Next, tail);

            // Возвращение головы
            return deleted.Next;
        }

        // Отображение листа
        public void Show()
        {
            Point current = Head;
            do
            {
                Console.Write(current.Value + " ");
                current = current.Next;
            } while (current != Head);
        }
    }
}