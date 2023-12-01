using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_OOP_9
{
    public class Triangle
    {
        private double a;
        private double b;
        private double c;
        private static int count = 0;
        //свойства
        public double SideA
        {
            set { a = value; }
            get { return a; }
        }
        public double SideB
        {
            set { b = value; }
            get { return b; }
        }
        public double SideC
        {
            set { c = value; }
            get { return c; }
        }
        //конструктор
        public Triangle(double a = 0, double b = 0, double c = 0)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            count++;
        }
        // число созданных объектов
        public static int Count() => count;
        public static void CounterErrase() => count = 0;
        //ввод double значений
        static double InputDouble(string message)
        {
            double number;
            Console.Write(message);
            if (!double.TryParse(Console.ReadLine(), out number))
            {
                do
                {
                    Console.WriteLine("Ошибка!");
                    Console.WriteLine("Введите число типа double");
                    Console.Write(message);
                } while (!double.TryParse(Console.ReadLine(), out number));
            }
            return number;
        }
        //существует треугольник или нет
        private static bool IsTriangle(Triangle trian)
        {
            if ((trian.a >= trian.b + trian.c) || (trian.b >= trian.a + trian.c) || (trian.c >= trian.a + trian.b))
                return false;
            else
                return true;
        }
        public void Read()
        {
            a = InputDouble("Введите 1 сторону: ");
            b = InputDouble("Введите 2 сторону: ");
            c = InputDouble("Введите 3 сторону: ");
        }
        public void Print()
        {
            Console.WriteLine($"a: {a}\nb: {b}\nc: {c}");
        }
        //возвращает полупериметр
        private static double CalculationP(Triangle side)
        {
            return (side.a + side.b + side.c) / 2;
        }
        //вычисляет площадь
        public double CalculationS()
        {
            if (IsTriangle(this))
                return Math.Sqrt(CalculationP(this) * (CalculationP(this) - a) * (CalculationP(this) - b) * (CalculationP(this) - c));
            else
                return -1;
        }
        public static double CalculationS(Triangle side)
        {
            if (IsTriangle(side))
                return Math.Sqrt(CalculationP(side) * (CalculationP(side) - side.a) * (CalculationP(side) - side.b) * (CalculationP(side) - side.c));
            else
                return -1;
        }
        //перегрузка операций
        public static Triangle operator ++(Triangle trian)
        {
            return new Triangle(++trian.a, ++trian.b, ++trian.c);
        }
        public static Triangle operator --(Triangle trian)
        {
            return new Triangle(--trian.a, --trian.b, --trian.c);
        }
        //приведение к double (явная)
        public static explicit operator double(Triangle trian)
        {
            if (IsTriangle(trian))
                return CalculationS(trian);
            else
                return (-1.0);
        }
        //приведение к bool (неявное)
        public static implicit operator bool(Triangle trian)
        {
            return IsTriangle(trian);
        }
        //бинарные операции
        public static bool operator <=(Triangle t1, Triangle t2)
        {
            return CalculationS(t1) <= CalculationS(t2);
        }
        public static bool operator >=(Triangle t1, Triangle t2)
        {
            return CalculationS(t1) >= CalculationS(t2);
        }
    }
}
