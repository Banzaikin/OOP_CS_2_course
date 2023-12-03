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
        public double A
        {
            set 
            {
                while (value < 0)
                    value = Menu.InputDouble("Сторона не может быть отрицательной, введите ещё раз: ");
                a = value; 
            }
            get { return a; }
        }
        public double B
        {
            set
            {
                while (value < 0)
                    value = Menu.InputDouble("Сторона не может быть отрицательной, введите ещё раз: ");
                b = value;
            }
            get { return b; }
        }
        public double C
        {
            set
            {
                while (value < 0)
                    value = Menu.InputDouble("Сторона не может быть отрицательной, введите ещё раз: ");
                c = value;
            }
            get { return c; }
        }
        //конструктор
        public Triangle(double a = 0, double b = 0, double c = 0)
        {
            A = a;
            B = b;
            C = c;
            count++;
        }
        // число созданных объектов
        public static int Count() => count;
        public static void CounterErrase() => count = 0;
        
        //существует треугольник или нет
        private static bool IsTriangle(double A, double B, double C)
        {
            if ((A >= B + C) || (B >= A + C) || (C >= A + B))
                return false;
            else
                return true;
        }
        public void Read()
        {
            A = Menu.InputDouble("Введите 1 сторону: ");
            B = Menu.InputDouble("Введите 2 сторону: ");
            C = Menu.InputDouble("Введите 3 сторону: ");
        }
        public void Print()
        {
            Console.WriteLine($"a: {a}\nb: {b}\nc: {c}\n");
        }
        //возвращает полупериметр
        private static double CalculationP(double A, double B, double C)
        {
            return (A + B + C) / 2;
        }
        //вычисляет площадь
        public double CalculationS(Triangle trian)
        {
            if (IsTriangle(trian.A, trian.B, trian.C))
            {
                double p = CalculationP(trian.A, trian.B, trian.C);
                return Math.Sqrt(p * (p - trian.A) * (p - trian.B) * (p - trian.C));
            }
            else
                return -1;
        }
        public static double CalculationS(double A, double B, double C)
        {
            if (IsTriangle(A, B, C))
            {
                double p = CalculationP(A, B, C);
                return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
            }
            else
                return -1;
        }
        //перегрузка операций
        public static Triangle operator ++(Triangle trian)
        {
            return new Triangle(++trian.A, ++trian.B, ++trian.C);
        }
        public static Triangle operator --(Triangle trian)
        {
            return new Triangle(--trian.A, --trian.B, --trian.C);
        }
        //приведение к double (явная)
        public static explicit operator double(Triangle trian)
        {
            if (IsTriangle(trian.A, trian.B, trian.C))
                return CalculationS(trian.A, trian.B, trian.C);
            else
                return (-1.0);
        }
        //приведение к bool (неявное)
        public static implicit operator bool(Triangle trian)
        {
            return IsTriangle(trian.A, trian.B, trian.C);
        }
        //бинарные операции
        public static bool operator <=(Triangle t1, Triangle t2)
        {
            return CalculationS(t1.A, t1.B, t1.C) <= CalculationS(t2.A, t2.B, t2.C);
        }
        public static bool operator >=(Triangle t1, Triangle t2)
        {
            return CalculationS(t1.A, t1.B, t1.C) >= CalculationS(t2.A, t2.B, t2.C);
        }
    }
}
