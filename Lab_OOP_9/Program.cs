using Lab_OOP_9;
using System;

namespace Lab_OOP_9
{
    public class Program
    {
        static void Task1()
        {
            Console.WriteLine("Задание 1");

            Triangle triangle = new Triangle();
            triangle.Read();
            triangle.Print();
            Console.WriteLine("Метод класса. Площадь = " + triangle.CalculationS(triangle));
            Console.WriteLine("Статическая функция. Площадь = " + Triangle.CalculationS(triangle.A, triangle.B, triangle.C));
            Console.WriteLine("Кол-во созданных объектов: " + Triangle.Count());
        }
        static void Task2()
        {
            Console.WriteLine("Задание 2");

            Triangle triangle1 = new Triangle();
            triangle1.Read();
            triangle1.Print();
            Triangle triangle2 = new Triangle();
            triangle2.Read();
            triangle2.Print();

            Console.WriteLine("trianle1++: ");
            triangle1++.Print();
            Console.WriteLine("trianle2--: ");
            triangle2--.Print();
            double square = (double)triangle1;
            bool isTriangle = triangle2;
            Console.WriteLine("double(явное) triangle1: " + square);
            Console.WriteLine("bool(неявное) triangle2: " + isTriangle);
            Console.WriteLine("triangle1 <= triangle2: " + (triangle1 <= triangle2));
            Console.WriteLine("triangle1 >= triangle2: " + (triangle1 >= triangle2));
        }
        static void Task3()
        {
            Console.WriteLine("Задание 3");
            Console.WriteLine("Введите Enter...");
            Console.ReadKey();
            var array1 = new TriangleArray();
            Console.WriteLine("1 массив:");
            array1.Display();

            Console.WriteLine();

            var array2 = new TriangleArray(3);
            Console.WriteLine("2 массив:");
            array2.Display();

            Console.WriteLine();

            var array3 = new TriangleArray(
                new Triangle(3, 4, 5),
                new Triangle(12, 13, 5),
                new Triangle(6, 8, 10)
            );
            Console.WriteLine("3 массив:");
            array3.Display();

            Console.WriteLine();

            Console.WriteLine("Элемент под 3 номером: ");
            array3[2].Print();
            Console.WriteLine();
            array3[2] = new Triangle(15, 17, 8);
            Console.WriteLine("Изменение на 15, 17 и 18 под 3 номером:");
            array3.Display();

            Console.WriteLine("Номер треугольника с самой маленькой площадью: " + NumElemMinS(array3));
        }
        public static int NumElemMinS(TriangleArray arr)
        {
            int elemMinS = 0;
            if (arr.Size == 0)
            {
                Console.WriteLine("Пусто!");
                return 0;
            }
            //double MinS = Triangle.CalculationS(arr[0]);
            //elemMinS = 1;
            //for(int i = 1; i < arr.Size; i++)
            //{
            //    if (MinS > Triangle.CalculationS(arr[i]))
            //    {
            //        MinS = Triangle.CalculationS(arr[i]);
            //        elemMinS = i + 1;
            //    }
            //}
            return elemMinS;
        }
        static void Main(string[] args)
        {
            Task1();
            Console.WriteLine();
            Task2();
            Console.WriteLine();
            Task3();
        }
    }
}
