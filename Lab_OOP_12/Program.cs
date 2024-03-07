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
            BinarySearchTree<Organization> newTree = new BinarySearchTree<Organization>(new CustomComparer());
            newTree.AddRange(organizations);
            return newTree;
        }
        static BinarySearchTree<Organization> CreateTreeConsole()
        {
            int size = Menu.InputInt("Введите размер массива: ");
            Organization[] organizations = new Organization[size];
            for (int i = 0; i < size; i++)
            {
                organizations[i] = new Organization();
                Console.WriteLine("Введите номер организации: ");
                organizations[i].Name = ("Организация_") + Menu.InputInt("Организация_"); 
                Console.WriteLine("Введите номер дома: ");
                organizations[i].Address = ("ул. Пушкина, д. ") + Menu.InputInt("ул. Пушкина, д. ");
                organizations[i].NumEmployess = Menu.InputInt("Введите кол-во сотрудников " + (i + 1) + " организации: ");
            }
            BinarySearchTree<Organization> newTree = new BinarySearchTree<Organization>(new CustomComparer());
            newTree.AddRange(organizations);
            return newTree;
        }
        static void AddElement(BinarySearchTree<Organization> tree)
        {
            int size = Menu.InputInt("Введите кол-во добавляемых элементов: ");
            Organization[] organizations = new Organization[size];
            for (int i = 0; i < size; i++)
                organizations[i] = new Organization();
            tree.AddRange(organizations);
        }
        static void RemoveElement(BinarySearchTree<Organization> tree)
        {
            foreach (var item in CreateTreeConsole())
                tree.Remove(item);
        }
        static void FindElement(BinarySearchTree<Organization> tree)
        {
            Console.WriteLine("Введите название организации: ");
            string nameOrg = ("Организация_") + Menu.InputInt("Организация_");
            Console.WriteLine("Введите адрес организации: ");
            string adressOrg = ("ул. Пушкина, д. ") + Menu.InputInt("ул. Пушкина, д. ");
            int numEmplOrg = Menu.InputInt("Введите кол-во сотрудников: ");
            Organization org = new Organization(nameOrg, adressOrg, numEmplOrg);
            var findElement = tree.Find(org);
            Console.WriteLine("\tНайденная организация: ");
            if (findElement != null)
                Console.WriteLine(findElement);
            else
                Console.WriteLine("Организация не найдена");
        }
        static void TaskClone(BinarySearchTree<Organization> tree)
        {
            tree.Add(new Organization("1", "1", 1));
            var cloneTree = (BinarySearchTree<Organization>)tree.Clone();
            Console.WriteLine("Изначальное дерево: ");
            tree.PrintTree();
            Console.WriteLine("Клонированное дерево: ");
            cloneTree.PrintTree();
            tree.Remove(new Organization("1", "1", 1));
            Console.WriteLine("Дерево после удаления: ");
            tree.PrintTree();
            Console.WriteLine("Клонированное дерево после удаления: ");
            cloneTree.PrintTree();
        }
        static void TaskShallowCopy(BinarySearchTree<Organization> tree)
        {
            tree.Add(new Organization("1", "1", 1));
            var shallowCopyTree = (BinarySearchTree<Organization>)tree.ShallowCopy();
            Console.WriteLine("Изначальное дерево: ");
            tree.PrintTree();
            Console.WriteLine("Копированное дерево: ");
            shallowCopyTree.PrintTree();
            tree.Remove(new Organization("1", "1", 1));
            Console.WriteLine("Дерево после удаления: ");
            tree.PrintTree();
            Console.WriteLine("Копированное дерево после удаления: ");
            shallowCopyTree.PrintTree();
        }

        public static void Main()
        {
            var tree = new BinarySearchTree<Organization>(new CustomComparer());
            string[] menu = {
                "1. Создание дерева (заполнение рандомными элементами)\n",
                "2. Создание дерева (заполнение вручную)\n\n",
                "3. Добавление элемента (Add)\n",
                "4. Удаление узла (Remove)\n",
                "5. Поиск элемента по значению (FindNode)\n\n",
                "6. Глубокое копирование (Clone)\n",
                "7. Поверхностное копирование (ShallowCopy)\n\n",
                "8. Удаление коллекции из памяти (Clear)\n",
                "9. Вывод дерева (Print)\n",
                "0. Выход из программы\n"
                };
            int command;
            do
            {
                Console.Clear();
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
                    case 3: //Add
                        AddElement(tree);
                        break;
                    case 4: //Remove
                        tree.PrintTree();
                        RemoveElement(tree);
                        break;
                    case 5: //FindNode
                        tree.PrintTree();
                        FindElement(tree);
                        break;
                    case 6: //Clone
                        TaskClone(tree);
                        break;
                    case 7: //ShallowCopy
                        TaskShallowCopy(tree);
                        break;
                    case 8: //Clear
                        tree.Clear();
                        break;
                    case 9: //Print
                        tree.PrintTree();
                        break;
                    case 0:
                        Console.WriteLine("Программа успешно завершила работу");
                        break;
                }
                Console.WriteLine("Нажмите любую клавишу для продолжения...");
                Console.ReadKey();
            } while (command != 0);
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