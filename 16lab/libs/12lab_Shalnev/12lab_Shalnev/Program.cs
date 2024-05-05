using System;
using System.Collections.Generic;
using BinaryTree;
using lab10lib_Shalnev;

namespace BinaryTree
{
    public class Program
    {
        static BinaryTree<Ship> searchTree = new BinaryTree<Ship>(new Comparer());

        public static void Main()
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Добавить новый корабль");
                Console.WriteLine("2. Удалить корабль");
                Console.WriteLine("3. Вывести дерево кораблей");
                Console.WriteLine("4. Найти корабль");
                Console.WriteLine("5. Удалить дерево из памяти");
                Console.WriteLine("6. Клонировать дерево");
                Console.WriteLine("7. Выход");

                Console.Write("Введите номер действия: ");
                int choice = int.Parse(Console.ReadLine());

                Console.Clear();

                switch (choice)
                {
                    case 1:
                        AddShipInTree();
                        break;
                    case 2:
                        DeleteItemTree();
                        break;
                    case 3:
                        ShowTree();
                        break;
                    case 4:
                        FindItem();
                        break;
                    case 5:
                        searchTree.Clear();
                        Console.WriteLine("Дерево кораблей удалено из памяти.");
                        break;
                    case 6:
                        TaskClone();
                        break;
                    case 7:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Некорректный ввод. Попробуйте снова.");
                        break;
                }

                Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                Console.ReadKey(true);
                Console.Clear();
            }
        }

        public static void AddShipInTree()
        {
            Console.WriteLine("Выберите способ добавления кораблей:");
            Console.WriteLine("1. Ввести количество кораблей вручную");
            Console.WriteLine("2. Сгенерировать случайное количество кораблей");

            Console.Write("Введите выбор (1 или 2): ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddManualShips();
                    break;
                case 2:
                    AddRandomShips();
                    break;
                default:
                    Console.WriteLine("Некорректный ввод. Попробуйте снова.");
                    break;
            }
        }

        public static void AddManualShips()
        {
            Console.Write("Введите количество кораблей: ");
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                Ship product = GetMenuTypeShips(i + 1);
                searchTree.Add(product);
            }

            Console.WriteLine("Корабли успешно добавлены в дерево.");
        }

        public static void AddRandomShips()
        {
            Console.Write("Введите количество кораблей для генерации: ");
            int count = int.Parse(Console.ReadLine());

            Ship[] randomShips = GenerateRandomShipArray(count);

            foreach (Ship ship in randomShips)
            {
                searchTree.Add(ship);
            }

            Console.WriteLine($"Случайные корабли ({count} шт.) успешно добавлены в дерево.");
        }


        public static void DeleteItemTree()
        {
                Ship product = GetMenuTypeShips(1);
                searchTree.Remove(product);
                Console.WriteLine("Корабль успешно удален из дерева.");
        }

        public static void ShowTree()
        {
            if (searchTree.Count == 0)
            {
                Console.WriteLine("Дерево пустое!");
            }
            else
            {
                Console.WriteLine("Количество кораблей в дереве поиска: " + searchTree.Count);
                Console.WriteLine("\nДерево поиска:");
                searchTree.PrintTree();
            }
        }

        public static void FindItem()
        {
            Ship product = GetMenuTypeShips(1);
            Ship foundProduct = searchTree.Find(product);

            if (foundProduct != null)
            {
                Console.WriteLine("Найденный корабль: ");
                Console.WriteLine(foundProduct);
            }
            else
            {
                Console.WriteLine("Корабль не найден.");
            }
        }

        public static void TaskClone()
        {
            if (searchTree.Count == 0)
            {
                Ship[] products = GenerateRandomShipArray(5);
                searchTree = new BinaryTree<Ship>(products, new Comparer());
            }

            Console.WriteLine("Изначальное дерево:");
            ShowTree();

            Console.WriteLine("\nПоверхностное копирование дерева:");
            BinaryTree<Ship> shallowCopy = (BinaryTree<Ship>)searchTree.ShallowCopy();
            ShowTree();

            Console.WriteLine("\nГлубокое копирование дерева:");
            BinaryTree<Ship> deepCopy = (BinaryTree<Ship>)searchTree.Clone();
            ShowTree();
        }

        public static Ship GetMenuTypeShips(int position)
        {
            Ship Ship = null;

            while (true)
            {
                Console.WriteLine($"Выберите тип корабля:");
                Console.WriteLine("1. Базовый класс (Корабль)");
                Console.WriteLine("2. Пароход");
                Console.WriteLine("3. Парусник");
                Console.WriteLine("4. Корвет");
                Console.WriteLine("5. Выход");

                Console.Write("Введите номер выбора: ");
                int choice = int.Parse(Console.ReadLine());

                Console.Clear();

                switch (choice)
                {
                    case 1:
                        Ship = new Ship();
                        Ship.Init();
                        break;
                    case 2:
                        Ship = new Steamship();
                        Ship.Init();
                        break;
                    case 3:
                        Ship = new Sailboat();
                        Ship.Init();
                        break;
                    case 4:
                        Ship = new Corvette();
                        Ship.Init();
                        break;
                    case 5:
                        return null;
                    default:
                        Console.WriteLine("Некорректный ввод. Попробуйте снова.");
                        break;
                }

                if (Ship != null)
                {
                    break;
                }
            }

            return Ship;
        }

        public static Ship[] GenerateRandomShipArray(int size)
        {
            Ship[] products = new Ship[size];
            Random rnd = new Random();

            for (int i = 0; i < size; i++)
            {
                int item = rnd.Next(1, 5);
                products[i] = CreateShip(item);
            }

            return products;
        }

        public static Ship CreateShip(int itemType)
        {
            return itemType switch
            {
                1 => new Ship(),
                2 => new Steamship(),
                3 => new Sailboat(),
                4 => new Corvette(),
                _ => throw new ArgumentException("Неизвестный тип!"),
            };
        }
    }
}
