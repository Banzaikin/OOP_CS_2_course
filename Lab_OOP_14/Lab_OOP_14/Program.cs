using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using Lab_10;
using System.Linq;
using Lab_OOP_12;

namespace Lab_OOP_14
{
    public static class Program
    {
        //создание словаря
        public static SortedDictionary<int, Queue<Organization>> CreateOrganizationRandom(int sizeSortedDictionary, int sizeQueue)
        {
            
            var cities = new SortedDictionary<int, Queue<Organization>>();
            for (int i = 1; i <= sizeSortedDictionary; i++)
            {
                var districts = new Queue<Organization>();
                for (int j = 0; j < sizeQueue; j++)
                {
                    var rnd = new Random();
                    int item = rnd.Next(1, 5);
                    switch (item)
                    {
                        case 1:
                            districts.Enqueue(new Library());
                            break;
                        case 2:
                            districts.Enqueue(new InsuranceCompany());
                            break;
                        case 3:
                            districts.Enqueue(new ShipBuildingCompany());
                            break;
                        case 4:
                            districts.Enqueue(new Factory());
                            break;
                    }
                }
                cities.Add(i, districts);
            }
            return cities;
        }
        //создание дерева
        public static BinarySearchTree<Organization> CreateTreeRandom(int size)
        {
            var tree = new BinarySearchTree<Organization>();
            for (int i = 1; i <= size; i++)
            {
                var rnd = new Random();
                int item = rnd.Next(1, 5);
                switch (item)
                {
                    case 1:
                        tree.Add(new Library());
                        break;
                    case 2:
                        tree.Add(new InsuranceCompany());
                        break;
                    case 3:
                        tree.Add(new ShipBuildingCompany());
                        break;
                    case 4:
                        tree.Add(new Factory());
                        break;
                }
            }
            return tree;
        }
        //------------------------------
        //--------- 1 часть ------------
        //------------------------------
        //выборка данных
        public static void LinqQueue1(SortedDictionary<int, Queue<Organization>> cities)
        {
            Console.WriteLine("\n------------Вывод организаций, в которых сотрудников > 50 (С помощью LINQ): \n");
            var subset = from key in cities.Keys
                         from Organization org in cities[key]
                         where org is Organization value
                         && (org.NumEmployess > 50)
                         select org;
            foreach (Organization s in subset)
                Console.WriteLine(s);
        }
        public static void ExtensionQueue1(SortedDictionary<int, Queue<Organization>> cities)
        {
            Console.WriteLine("\n-----------Вывод организаций, в которых сотрудников > 50 (С помощью методов расширения): \n");
            var subsetMethod = cities.Values.SelectMany(org => org.Where(org => org is Organization value &&
                (org.NumEmployess > 50)).Select(org => org));
            foreach (Organization s in subsetMethod)
                Console.WriteLine(s);
        }
        //Получение счетчика (количества объектов с заданным параметром).
        static void LinqQueue2(SortedDictionary<int, Queue<Organization>> cities)
        {
            int subset = (from key in cities.Keys
                         from Organization org in cities[key]
                         where org is Library value
                         select org).Count();
            Console.Write("\n-----------Кол-во библиотек в городе (С помощью LINQ): " + subset);
        }
        static void ExtensionQueue2(SortedDictionary<int, Queue<Organization>> cities)
        {
            int subsetMethod = cities.Values.SelectMany(org => org.Where(org => org is Library value)).Count();
            Console.Write("\n-----------Кол-во библиотек в городе (С помощью методов расширения): " + subsetMethod);
        }
        //Использование операций над множествами (пересечение, объединение, разность)
        static void LinqQueue3(SortedDictionary<int, Queue<Organization>> cities)
        {
            Console.WriteLine("\n-----------Объединение заводы + организации 80+ сотрудников (С помощью Linq): \n");
            var subset = (from key in cities.Keys
                         from Organization org in cities[key]
                         where org.NumEmployess >= 80
                         select org).Union
                         (from key in cities.Keys
                          from Organization company in cities[key]
                          where company is Factory value
                          select company);
            foreach (Organization s in subset)
                Console.WriteLine(s);
        }
        static void ExtensionQueue3(SortedDictionary<int, Queue<Organization>> cities)
        {
            Console.WriteLine("\n---------Объединение заводы + организации 80+ сотрудников (С помощью методов расширения): \n");
            var subsetCompany = cities.Values.SelectMany(company => company.Where(company => company is Factory));
            var subsetOrg = cities.Values.SelectMany(org => org.Where(org => org.NumEmployess >= 80));
            var unionSubsets = subsetCompany.Union(subsetOrg);
            foreach (Organization s in unionSubsets)
                Console.WriteLine(s);
        }
        //агрегирование данных
        static void LinqQueue4(SortedDictionary<int, Queue<Organization>> cities)
        {
            int subset = (from key in cities.Keys
                          from Organization org in cities[key]
                          select org.NumEmployess).Sum();
            Console.Write("\n---------Суммарное количество всех сотрудников в городе (С помощью Linq): " + subset);
        }
        static void ExtensionQueue4(SortedDictionary<int, Queue<Organization>> cities)
        {
            int subsetMethod = cities.Values.SelectMany(org => org.Select(org => org.NumEmployess)).Sum();
            Console.Write("\n---------Суммарное количество всех сотрудников в городе (С помощью методов расширения): " + subsetMethod);
        }
        //Группировка данных
        static void LinqQueue5(SortedDictionary<int, Queue<Organization>> cities)
        {
            Console.WriteLine("\n---------Группировка по названию (С помощью Linq): \n");
            var subset = (from key in cities.Keys
                          from Organization org in cities[key]
                          group org by org.Name into n
                          select new { Name = n.Key, Count = n.Count() }).ToList();
            foreach (var item in subset)
                Console.WriteLine(item.Name + " - " + item.Count);
        }
        static void ExtensionQueue5(SortedDictionary<int, Queue<Organization>> cities)
        {
            Console.WriteLine("\n---------Группировка по названию (С помощью методов расширения): \n");
            var subsetMethod = cities.Values.SelectMany(org => org)
                .GroupBy(org => org.Name)
                .Select(n => new { Name = n.Key, Count = n.Count() }).ToList();
            foreach (var item in subsetMethod)
                Console.WriteLine(item.Name + " - " + item.Count);
        }
        //------------------------------
        //--------- 2 часть ------------
        //------------------------------
        //На выборку данных по условию.
        static void TreeMethod1(BinarySearchTree<Organization> tree)
        {
            Console.WriteLine("\n--------Название всех заводов\n");
            var subset = tree.SelectOrg(org => org is Factory);
            foreach (Organization s in subset)
                Console.WriteLine(s);
        }
        //Агрегирование данных (среднее, максимум/минимум, сумма и пр.).
        static void TreeMethod2(BinarySearchTree<Organization> tree)
        {
            Console.Write("----------Кол-во всех сотрудников в библиотеках: ");
            var subset = tree.CountOrg(org => org is Library value && org.NumEmployess > 0);
            Console.WriteLine(subset);
        }
        //Сортировка коллекции (по убыванию/по возрастанию).
        static void TreeMethod3(BinarySearchTree<Organization> tree)
        {
            Console.WriteLine("\n------------Сортировка по кол-ву сотрудников\n");
            BinarySearchTree<Organization>  newTree = tree.SortOrg(org => org.NumEmployess);
            foreach (Organization s in newTree)
                Console.WriteLine(s);
        }
        //Группировка данных
        static void TreeMethod4(BinarySearchTree<Organization> tree)
        {
            Console.WriteLine("\n----------Группировка по названию\n");
            var subset = tree.GroupOrg(org => org.Name).Select(n => new { Name = n.Key, Count = n.Count() }).ToList();

            foreach (var item in subset)
                Console.WriteLine("С помощью методов расширения: " + item.Name + " - " + item.Count);
        }

        static void Main(string[] args)
        {
            int sizeSortedDictionary = Menu.InputInt("Введите кол-во городов: ");
            int sizeQueue = Menu.InputInt("Введите кол-во организаций: ");
            SortedDictionary<int, Queue<Organization>> cities = CreateOrganizationRandom(sizeSortedDictionary, sizeQueue);
            Console.WriteLine("\tЭлементы словаря: ");
            foreach (var key in cities.Keys)
            {
                Console.WriteLine($"ключ: {key}");
                Console.WriteLine("Элементы очереди");
                for (int i = 0; i < sizeQueue; ++i)
                {
                    var element = cities[key].Dequeue();
                    Console.WriteLine(element);
                    cities[key].Enqueue(element);   
                }
            }
            Console.WriteLine("\n\n-------- 1 часть -------\n\n");

            LinqQueue1(cities);
            ExtensionQueue1(cities);

            LinqQueue2(cities);
            ExtensionQueue2(cities);
            
            LinqQueue3(cities);
            ExtensionQueue3(cities);
            
            LinqQueue4(cities);
            ExtensionQueue4(cities);
            
            LinqQueue5(cities);
            ExtensionQueue5(cities);

            Console.WriteLine("\n\n-------- 2 часть -------\n\n");
            int size = Menu.InputInt("Введите размер дерева: ");
            BinarySearchTree<Organization> tree = CreateTreeRandom(size);
            Console.WriteLine("Созданное дерево:\n");
            tree.PrintTree();
            TreeMethod1(tree);
            TreeMethod2(tree);
            TreeMethod3(tree);
            TreeMethod4(tree);
        }
    }
}

