using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_OOP_10
{
    public class Menu
    {
        //Ввод целого числа
        public static int InputInt(string message)
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
    }
}
