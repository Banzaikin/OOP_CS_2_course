using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_OOP_9
{
    public class Menu
    {
        //ввод double значений
        public static double InputDouble(string message)
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

    }
}
