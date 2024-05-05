using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_10
{
    public class Menu
    {
        //Ввод целого числа
        public static int InputInt(string message)
        {
            int number;
            Console.Write(message);
            if (!int.TryParse(Console.ReadLine(), out number) || (number < 0))
            {
                do
                {
                    Console.Write("Ошибка! ");
                    if (number < 0)
                        Console.WriteLine("Введите положительное число ");
                    else
                        Console.WriteLine("Введите число типа int");
                    Console.Write(message);
                } while (!int.TryParse(Console.ReadLine(), out number) || (number < 0));
            }
            return number;
        }
    }
}
