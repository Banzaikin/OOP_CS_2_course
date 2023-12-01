using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_OOP_9
{
    class Triangle
    {
        private double a;
        private double b;
        private double c;
        private static int count = 0;
        //конструктор
        public Triangle(double a = 3, double b = 4, double c = 5)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            count++;
        }
        // число созданных объектов
        public static int Count() => count;
        public static void CounterErrase() => count = 0;
        public void Print()
        {
            Console.WriteLine($"a: {a}\n  b: {b}\n  c: {c}");
            Console.WriteLine($"Кол-во созданных в программе объектов: {count}");
        }
        //возвращает полупериметр
        private static double CalculationP(Triangle side)
        {
            return (side.a + side.b + side.c) / 2;
        }
        //вычисляет площадь
        public double CalculationS()
        {
            return Math.Sqrt(CalculationP(this) * (CalculationP(this) - a) * (CalculationP(this) - b) * (CalculationP(this) - c));
        }
        public static double CalculationS(Triangle side)
        {
            return Math.Sqrt(CalculationP(side) * (CalculationP(side) - side.a) * (CalculationP(side) - side.b) * (CalculationP(side) - side.c));
        }
    }
}
