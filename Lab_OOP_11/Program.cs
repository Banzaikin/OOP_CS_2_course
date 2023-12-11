using Lab_10;
using static Lab_10.Menu;
using System;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;
using System.Linq;

namespace Lab_OOP_11
{
    public class Program
    {
        public static T GetCenterValue<T>(Queue<T> queueG)
        {
            int center = queueG.Count / 2;
            var firstElement = queueG.Dequeue();
            for (int i = 0; i < center; i++)
            {
                firstElement = queueG.Dequeue();
                queueG.Enqueue(firstElement);
            }
            return firstElement;
        }
        public static T GetLastValue<T>(Queue<T> queueG)
        {
            var lastElement = queueG.Dequeue();
            for (int i = 0; i < queueG.Count; i++)
            {
                lastElement = queueG.Dequeue();
                queueG.Enqueue(lastElement);
            }
            return lastElement;
        }

        public static void RandomInitTest(ref TestCollections test)
        {
            test.RandomInit(Menu.InputInt("Введите размер: "));
        }

        public static void DisplayOrganization(TestCollections test)
        {
            if (test.Count == 0)
            {
                Console.WriteLine("Пожалуйста, заполните TestCollections");
                return;
            }

            Console.WriteLine("Поиск первого элемента в коллекции queue<Organization>...");
            Console.WriteLine($"Время = {TimeWork.OrganizationOfWorkQueue(test.queueB, (Organization)test.queueB.Peek())}");
            Console.WriteLine("Поиск центрального элемента в коллекции queue<Organization>...");
            Console.WriteLine($"Время = {TimeWork.OrganizationOfWorkQueue(test.queueB, (Organization)GetCenterValue(test.queueB).Clone())}");
            Console.WriteLine("Поиск последнего элемента в коллекции queue<Organization>...");
            Console.WriteLine($"Время = {TimeWork.OrganizationOfWorkQueue(test.queueB, (Organization)GetLastValue(test.queueB).Clone())}");
            Console.WriteLine("Поиск элемента не входящего в коллекцию queue<Organization>...");
            Console.WriteLine($"Время = {TimeWork.OrganizationOfWorkQueue(test.queueB, new Organization())}");
            Console.WriteLine();

            Console.WriteLine("Поиск первого элемента в коллекции queue<string>...");
            Console.WriteLine($"Время = {TimeWork.OrganizationOfWorkQueue(test.queueS, (string)test.queueS.Peek())}");
            Console.WriteLine("Поиск центрального элемента в коллекции queue<string>...");
            Console.WriteLine($"Время = {TimeWork.OrganizationOfWorkQueue(test.queueS, (string)GetCenterValue(test.queueS).Clone())}");
            Console.WriteLine("Поиск последнего элемента в коллекции queue<string>...");
            Console.WriteLine($"Время = {TimeWork.OrganizationOfWorkQueue(test.queueS, (string)GetLastValue(test.queueS).Clone())}");
            Console.WriteLine("Поиск элемента не входящего в коллекцию queue<string>...");
            Console.WriteLine($"Время = {TimeWork.OrganizationOfWorkQueue(test.queueS, "")}");
            Console.WriteLine();

            Console.WriteLine("Поиск первого ключа в коллекции SortedDictionary<Organization,Library>...");
            Console.WriteLine($"Время = {TimeWork.OrganizationOfWorkSortedDictionary(test.dicGT, (Organization)test.dicGT.Keys.ToArray()[0].Clone())}");
            Console.WriteLine("Поиск центрального ключа в коллекции SortedDictionary<Organization,Library>...");
            Console.WriteLine($"Время = {TimeWork.OrganizationOfWorkSortedDictionary(test.dicGT, (Organization)test.dicGT.Keys.ToArray()[test.dicGT.Keys.Count / 2].Clone())}");
            Console.WriteLine("Поиск последнего ключа в коллекции SortedDictionary<Organization,Library>...");
            Console.WriteLine($"Время = {TimeWork.OrganizationOfWorkSortedDictionary(test.dicGT, (Organization)test.dicGT.Keys.ToArray()[test.dicGT.Keys.Count - 1].Clone())}");
            Console.WriteLine("Поиск ключа не входящего в коллекцию SortedDictionary<Organization,Library>...");
            Console.WriteLine($"Время = {TimeWork.OrganizationOfWorkSortedDictionary(test.dicGT, new Organization())}");
            Console.WriteLine();

            Console.WriteLine("Поиск первого ключа в коллекции SortedDictionary<string,Library>...");
            Console.WriteLine($"Время = {TimeWork.OrganizationOfWorkSortedDictionary(test.dicST, (string)test.dicST.Keys.ToArray()[0].Clone())}");
            Console.WriteLine("Поиск центрального ключа в коллекции SortedDictionary<string,Library>...");
            Console.WriteLine($"Время = {TimeWork.OrganizationOfWorkSortedDictionary(test.dicST, (string)test.dicST.Keys.ToArray()[test.dicST.Keys.Count / 2].Clone())}");
            Console.WriteLine("Поиск последнего ключа в коллекции SortedDictionary<string,Library>...");
            Console.WriteLine($"Время = {TimeWork.OrganizationOfWorkSortedDictionary(test.dicST, (string)test.dicST.Keys.ToArray()[test.dicST.Keys.Count - 1].Clone())}");
            Console.WriteLine("Поиск ключа не входящего в коллекцию SortedDictionary<string,Library>...");
            Console.WriteLine($"Время = {TimeWork.OrganizationOfWorkSortedDictionary(test.dicST, "")}");
            Console.WriteLine();

            Console.WriteLine("Поиск первого элемента в коллекции SortedDictionary<string,Library>...");
            Console.WriteLine($"Время = {TimeWork.OrganizationOfWorkSortedDictionary(test.dicST, (Library)test.dicST.Values.ToArray()[0].Clone())}");
            Console.WriteLine("Поиск центрального элемента в коллекции SortedDictionary<string,Library>...");
            Console.WriteLine($"Время = {TimeWork.OrganizationOfWorkSortedDictionary(test.dicST, (Library)test.dicST.Values.ToArray()[test.queueB.Count / 2].Clone())}");
            Console.WriteLine("Поиск последнего элемента в коллекции SortedDictionary<string,Library>...");
            Console.WriteLine($"Время = {TimeWork.OrganizationOfWorkSortedDictionary(test.dicST, (Library)test.dicST.Values.ToArray()[test.queueB.Count - 1].Clone())}");
            Console.WriteLine("Поиск элемента не входящего в коллекцию SortedDictionary<string,Library>...");
            Console.WriteLine($"Время = {TimeWork.OrganizationOfWorkSortedDictionary(test.dicST, new Library())}");

        }

        static void DisplayTestCollection(TestCollections test)
        {
            if (test.queueS.Count == 0)
                Console.WriteLine("TestCollections пуст.");
            foreach (var item in test.queueS)
                Console.WriteLine(item + "\n");

        }

        static void DisplayDelItem(TestCollections test)
        {
            var library = new Library();
            library.Init();
            if (test.DeleteElem(library))
                Console.WriteLine("Библиотка успешно удалена.");
            else
                Console.WriteLine("Такой библиотеки нет.");
        }

        static void DisplayAddItem(TestCollections test)
        {
            var Library = new Library();
            Library.Init();
            if (test.Add(Library))
                Console.WriteLine("Библиотка успешно добавлена.");
            else
                Console.WriteLine("Не удалось добавить библиотеку.");
        }

        static void Main()
        {

            var test = new TestCollections();
            string[] menu =
            {
                "1. Создать TestCollections",
                "2. Время поиска в различных коллекциях",
                "3. Добавление элемента",
                "4. Удаление элемента",
                "5. Вывод элементов коллекций",
                "0. Выход из программы"
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
                    case 1:
                        RandomInitTest(ref test);
                        break;
                    case 2:
                        DisplayOrganization(test);
                        break;
                    case 3:
                        DisplayAddItem(test);
                        break;
                    case 4:
                        DisplayDelItem(test);
                        break;
                    case 5:
                        DisplayTestCollection(test);
                        break;
                    case 0:
                        Console.WriteLine("\nПрограмма успешно завершила работу");
                        break;
                    default:
                        Console.WriteLine("Неправильная команда!");
                        break;
                }
                Console.WriteLine("Введите любую клавишу для продолжения...");
                Console.ReadKey();
                Console.Clear();
                
            } while (command != 0);
        }
    }
}
