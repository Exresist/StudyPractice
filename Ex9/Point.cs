namespace Ex9
{
    // Класс элементов листа
    class Point
    {
        public int Value { get; private set; }

        // Следующий элемент
        public Point Next { get; set; }
        
        public Point(int value)
        {
            Value = value;
            Next = null;
        }
    }
}