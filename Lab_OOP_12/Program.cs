using System;
using System.Collections;
using System.Collections.Generic;
using Lab_10;

namespace Lab_OOP_12
{
    class Program
    {
        static BinarySearchTree<Organization> CreateTreeRandom()
        {
            int size = Menu.InputInt("Введите размер массива: ");
            Organization[] organizations = new Organization[size];
            for (int i = 0; i < size; i++)
                organizations[i] = new Organization();
            BinarySearchTree<Organization> newTree = new BinarySearchTree<Organization>(organizations);
            return newTree;
        }
        static BinarySearchTree<Organization> CreateTreeConsole()
        {
            int size = Menu.InputInt("Введите размер массива: ");
            Organization[] organizations = new Organization[size];
            for (int i = 0; i < size; i++)
            {
                organizations[i] = new Organization();
                organizations[i].NumEmployess = Menu.InputInt("Введите кол-во сотрудников " + (i + 1) + " организации: ");
            }
            BinarySearchTree<Organization> newTree = new BinarySearchTree<Organization>(organizations);
            return newTree;
        }

        public static void Main()
        {
            var tree = new BinarySearchTree<Organization>(new CustomComparer());
            string[] menu = {
                "1. Создание дерева (заполнение рандомными элементами)\n",
                "2. Создание дерева (заполнение вручную)\n\n",
                "3. Добавление элемента (Add)\n",
                "4. Удаление узла (Remove)\n",
                "5. Поиск элемента по значению (FindNode)\n",
                "6. Глубокое копирование (Clone)\n",
                "7. Поверхностное копирование (ShallowCopy)\n",
                "8. Удаление коллекции из памяти (Clear)\n",
                "0. Выход из программы\n"
                };
            int command;
            do
            {
                //вывод меню
                for (int i = 0; i < menu.Length; i++)
                {
                    Console.WriteLine(menu[i]);
                }
                command = Menu.InputInt("Введите команду: ");
                switch (command)
                {
                    case 1: //Создание дерева (заполнение рандомными элементами)
                        tree = CreateTreeRandom();
                        break;
                    case 2: //Создание дерева (заполнение вручную)
                        tree = CreateTreeConsole();
                        break;
                }
            } while (command != 0) ;
        }
    }
    public class CustomComparer : IComparer<Organization>
    {
        public int Compare(Organization? organization1, Organization? organization2)
        {
            if (organization1 == null || organization2 == null)
                return 0;

            if (organization1.NumEmployess > organization2.NumEmployess)
                return 1;
            else if (organization1.NumEmployess < organization2.NumEmployess)
                return -1;
            else
                return 0;
        }
    }
}
