using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_OOP_9
{
    class TriangleArray
    {
        Triangle[] arr;
        static private int count = 0;
        public int Size => arr.Length;
        public static int Count() => count;
        public static void CounterErrase() => count = 0;

        //конструктор без параметров
        public TriangleArray() : this(0) { }
        //Конструктор с параметрами с рандомным заполнением
        public TriangleArray(int size)
        {
            if (size < 0)
            {
                Console.WriteLine("Размер не может быть меньше 0");
                size = 0;
            }
            arr = new Triangle[size];
            var random = new Random();

            for (int i = 0; i < size; i++)
            {
                double a = random.Next(0, 100);
                double b = random.Next(0, 100);
                double c = random.Next(0, 100);

                arr[i] = new Triangle(a, b, c);
            }
            count++;
        }
        //конструктор с параметрами с вводом с клавиатуры
        public TriangleArray(bool console)
        {
            Console.WriteLine("Введите новый размер массива: ");
            int newSize = Convert.ToInt32(Console.ReadLine());
            arr = new Triangle[newSize];
            for (int i = 0; i < Size; i++)
            {
                arr[i] = new Triangle();
                arr[i].Read();
            }
            count++;
        }

        //заранее известные элементы массива
        public TriangleArray(params Triangle[] Triangles)
        {
            arr = new Triangle[Triangles.Length];

            for (int i = 0; i < Triangles.Length; i++)
            {
                arr[i] = Triangles[i];
            }
        }

        //вывод элементов массива
        public void Display()
        {
            if (arr.Length == 0)
            {
                Console.WriteLine("Массив пуст.");
            }
            foreach (Triangle Triangle in arr)
            {
                Triangle.Print();
            }
        }
        //индексатор
        public Triangle this[int index]
        {
            get
            {
                if (index >= 0 && index < arr.Length)
                {
                    return arr[index];
                }
                else
                {
                    throw new IndexOutOfRangeException("Выход за границы.");
                }
            }
            set
            {
                if (index >= 0 && index < arr.Length)
                {
                    arr[index] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("Выход за границы.");
                }
            }
        }
    }
}
