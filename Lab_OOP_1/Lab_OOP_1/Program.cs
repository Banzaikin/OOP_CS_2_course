using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_OOP_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isExit = true;
            while(isExit)
            {
                Console.WriteLine("1. 1 Задание");
                Console.WriteLine("2. 2 Задание");
                Console.WriteLine("3. 3 Задание");
                Console.WriteLine("4. Выход из программы");
                int command = InputInt("\nВведите команду: ");
                switch (command)
                {
                    case 1:
                        Console.WriteLine("\n1 Задание\n");
                        int n = InputInt("Введите n: ");
                        int m = InputInt("Введите m: ");
                        double x = InputDouble("Введите x: ");
                        Console.WriteLine();
                        OutputExpressions(n, m, x);
                        break;
                    case 2:
                        Console.WriteLine("\n2 Задание\n");
                        double x1 = InputDouble("Введите координату  по x: ");
                        double y1 = InputDouble("Введите координату по y: ");
                        bool isPointGraph = CheckingPointGraph(x1, y1);
                        Console.WriteLine(isPointGraph);
                        break;
                    case 3:
                        Console.WriteLine("\n3 Задание\n");
                        CalculatingExpressions();
                        break;
                    case 4:
                        isExit = false;
                        break;
                }
                Console.WriteLine("Нажмите любую клавишу для продолжения...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        static int InputInt(string message)
        {
            int number;
            Console.Write(message);
            if (!int.TryParse(Console.ReadLine(), out number))
            {
                do
                {
                    Console.WriteLine("Ошибка!");
                    Console.WriteLine("Введите число типа int");
                    Console.Write(message);
                } while (!int.TryParse(Console.ReadLine(), out number));
            }
            return number;
        }
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
        static bool CheckingPointGraph(double x, double y)
        {
            float value = (float)Math.Pow(x, 2) + (float)Math.Pow(y, 2);
            return (value <= 1.0);
        }
        static void OutputExpressions(int n, int m, double x)
        {
            Console.WriteLine("n = {0}, m = {1}, x = {2}", n, m, x);
            Console.WriteLine("1) n++ x m = " + (n++*m));
            Console.WriteLine("2) n++<m = " + (n++ < m));
            Console.WriteLine("3) --m>n = " + (--m > n));
            double argument = x - Math.Pow(x, 2) + Math.Pow(x, 5);
            if (argument >= 0)
                Console.WriteLine("4) (x - x^2 + x^5)^1/3 = " + Math.Pow(argument, 1.0/3.0));
            else
                Console.WriteLine("4) (x - x^2 + x^5)^1/3 = -" + Math.Pow(-argument, 1.0 / 3.0));
        }
        static void CalculatingExpressions()
        {
            double doubleA = 1000;
            double doubleB = 0.0001;
            float floatA = 1000F;
            float floatB = 0.0001F;

            double differenceABPow3Double = Math.Pow(doubleA - doubleB, 3);
            double differenceAPow3Double = Math.Pow(doubleA, 3);
            double numeratorDouble = differenceABPow3Double - differenceAPow3Double;
            double difference3ABPow2Double = 3 * doubleA * Math.Pow(doubleB, 2);
            double differenceBPow3Double = Math.Pow(doubleB, 3);
            double difference3APow2BDouble = 3 * Math.Pow(doubleA, 2) * doubleB;
            double denominatorDouble = difference3ABPow2Double - differenceBPow3Double - difference3APow2BDouble;
            double resultDouble = numeratorDouble / denominatorDouble;

            float differenceABPow3Float = (float)Math.Pow(floatA - floatB, 3);
            float differeceAPow3Float = (float)Math.Pow(floatA, 3);
            float numeratorFloat = differenceABPow3Float - differeceAPow3Float;
            float difference3ABPow2Float = 3 * floatA * (float)Math.Pow(floatB, 2);
            float differenceBPow3Float = (float)Math.Pow(floatB, 3);
            float difference3APow2BFloat = 3 * (float)Math.Pow(floatA, 2) * floatB;
            float denominatorFloat = difference3ABPow2Float - differenceBPow3Float - difference3APow2BFloat;
            float resultFloat = numeratorFloat / denominatorFloat;

            Console.WriteLine("Вычислить:\n");
            Console.WriteLine("  (a - b)^3 - a^3   ");
            Console.WriteLine("--------------------");
            Console.WriteLine("3ab^2 - b^3 - 3a^2b\n");
            Console.WriteLine("При: a = 1000, b = 0.0001\n");
            Console.WriteLine("Результат вычислений для типа double: " + resultDouble);
            Console.WriteLine("Результат вычислений для типа float: " + resultFloat);
            Console.WriteLine();
        }
    }
}
