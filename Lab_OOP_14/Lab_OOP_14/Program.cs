using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using Lab_10;
using System.Linq;
using Lab_OOP_12;

namespace Lab_OOP_14
{
    static class Program
    {
        //создание словаря
        static SortedDictionary<int, Queue<Organization>> CreateOrganizationRandom(int sizeSortedDictionary, int sizeQueue)
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
                        case 5:
                            districts.Enqueue(new Organization());
                            break;
                    }
                }
                cities.Add(i, districts);
            }
            return cities;
        }
        //создание дерева
        static BinarySearchTree<Organization> CreateTreeRandom()
        {
            int size = Menu.InputInt("Введите размер дерева: ");
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
                    case 5:
                        tree.Add(new Organization());
                        break;
                }
            }
            return tree;
        }
        //------------------------------
        //--------- 1 часть ------------
        //------------------------------
        //выборка данных
        static void Queue1(SortedDictionary<int, Queue<Organization>> cities)
        {
            Console.WriteLine("Вывести все организации, в которых сотрудников > 50");
            Console.WriteLine("С помощью LINQ: ");
            var subset = from key in cities.Keys from Organization org in cities[key] where org is Organization value 
                         && (org.NumEmployess > 50) select org;
            foreach (Organization s in subset)
                Console.WriteLine(s);
            Console.WriteLine("С помощью методов расширения: ");
            var subsetMethod = cities.Values.SelectMany(org => org.Where(org => org is Organization value &&
                (org.NumEmployess > 50)).Select(org => org));
            foreach (Organization s in subsetMethod)
                Console.WriteLine(s);
        }
        //Получение счетчика (количества объектов с заданным параметром).
        static void Queue2(SortedDictionary<int, Queue<Organization>> cities)
        {
            Console.WriteLine("Кол-во библиотек в городе");
            Console.WriteLine("С помощью LINQ: ");
            int subset = (from key in cities.Keys
                         from Organization org in cities[key]
                         where org is Library value
                         select org).Count();
            Console.WriteLine("Кол-во библиотек в городе: " + subset);
            Console.WriteLine("С помощью методов расширения: ");
            int subsetMethod = cities.Values.SelectMany(org => org.Where(org => org is Library value)).Count();
            Console.WriteLine("Кол-во библиотек в городе: " + subsetMethod);
        }
        //Использование операций над множествами (пересечение, объединение, разность)
        static void Queue3(SortedDictionary<int, Queue<Organization>> cities)
        {
            Console.WriteLine("Объединение заводы + организации 80+ сотрудников");
            Console.WriteLine("С помощью LINQ: ");
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
            Console.WriteLine("С помощью методов расширения: ");
            var subsetCompany = cities.Values.SelectMany(company => company.Where(company => company is Factory));
            var subsetOrg = cities.Values.SelectMany(org => org.Where(org => org.NumEmployess >= 80));
            var unionSubsets = subsetCompany.Union(subsetOrg);
            foreach (Organization s in unionSubsets)
                Console.WriteLine(s);
        }
        //агрегирование данных
        static void Queue4(SortedDictionary<int, Queue<Organization>> cities)
        {
            Console.WriteLine("Суммарное количество всех сотрудников в городе");
            Console.WriteLine("С помощью LINQ: ");
            int subset = (from key in cities.Keys
                          from Organization org in cities[key]
                          select org.NumEmployess).Sum();
            Console.WriteLine("Кол-во книг: " + subset);
            Console.WriteLine("С помощью методов расширения: ");
            int subsetMethod = cities.Values.SelectMany(org => org.Select(org => org.NumEmployess)).Sum();
            Console.WriteLine("Кол-во книг: " + subsetMethod);
        }
        //Группировка данных
        static void Queue5(SortedDictionary<int, Queue<Organization>> cities)
        {
            Console.WriteLine("Группировка по названию");
            Console.WriteLine("С помощью LINQ: ");
            var subset = (from key in cities.Keys
                          from Organization org in cities[key]
                          group org by org.Name into n
                          select new { Name = n.Key, Count = n.Count() }).ToList();
            foreach (var item in subset)
                Console.WriteLine("С помощью LINQ: " + item.Name + " - " + item.Count);
            Console.WriteLine("С помощью методов расширения: ");
            var subsetMethod = cities.Values.SelectMany(org => org)
                .GroupBy(org => org.Name)
                .Select(n => new { Name = n.Key, Count = n.Count() }).ToList();
            foreach (var item in subsetMethod)
                Console.WriteLine("С помощью LINQ: " + item.Name + " - " + item.Count);
        }
        //------------------------------
        //--------- 2 часть ------------
        //------------------------------
        //На выборку данных по условию.
        static void TreeMethod1(BinarySearchTree<Organization> cities)
        {
            Console.WriteLine("Название всех заводов");
            var subset = cities.SelectOrg(org => org is Factory);
            foreach (Organization s in subset)
                Console.WriteLine(s);
        }
        //Агрегирование данных (среднее, максимум/минимум, сумма и пр.).
        static void TreeMethod2(BinarySearchTree<Organization> cities)
        {
            Console.WriteLine("Кол-во всех сотрудников в библиотеках");
            var subset = cities.CountOrg(org => org is Library value && org.NumEmployess > 0);
            Console.WriteLine(subset);
        }
        //Сортировка коллекции (по убыванию/по возрастанию).
        static void TreeMethod3(BinarySearchTree<Organization> cities)
        {
            Console.WriteLine("Сортировка по кол-ву сотрудников");
            BinarySearchTree<Organization>  newTree = cities.SortOrg(org => org.NumEmployess);
            foreach (Organization s in newTree)
                Console.WriteLine(s);
            newTree.PrintTree();
        }

        static void Main(string[] args)
        {
            int sizeSortedDictionary = Menu.InputInt("Введите кол-во городов: ");
            int sizeQueue = Menu.InputInt("Введите кол-во организаций: ");
            var district = new Queue();
            var cities = new SortedDictionary<int, Queue<Organization>>();
            cities = CreateOrganizationRandom(sizeSortedDictionary, sizeQueue);
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
            Queue1(cities);
            Queue2(cities);
            Queue3(cities);
            Queue4(cities);
            Queue5(cities);

            BinarySearchTree<Organization> tree = new BinarySearchTree<Organization>();
            tree = CreateTreeRandom();
            TreeMethod1(tree);
            TreeMethod2(tree);
            TreeMethod3(tree);
        }
    }
}

