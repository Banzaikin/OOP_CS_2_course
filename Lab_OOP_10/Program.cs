using System;
using System.Collections.Generic;

namespace Lab_OOP_10
{
    class Program
    {
        static Organization[] CreateOrganizationRandom()
        {
            int size = Menu.InputInt("Введите размер массива: ");
            Organization[] organizations = new Organization[size];
            for (int i = 0; i < size; i++)
            {
                var rnd = new Random();
                int item = rnd.Next(1, 5);
                switch (item)
                {
                    case 1:
                        organizations[i] = new Organization(); 
                        break;
                    case 2:
                        organizations[i] = new InsuranceCompany(); 
                        break;
                    case 3:
                        organizations[i] = new ShipBuildingCompany(); 
                        break;
                    case 4:
                        organizations[i] = new Factory(); 
                        break;
                    case 5:
                        organizations[i] = new Library();
                        break;
                }
            }
            return organizations;
        }
        static Organization[] CreateOrganizationConsole()
        {
            string[] arrayClass =
            {
                "1. Базовый класс (Организация)\n",
                "2. Страховая компания\n",
                "3. Судостроительная кампания\n",
                "4. Завод\n",
                "5. Библиотека\n",
            };
            int size = Menu.InputInt("Введите размер массива: ");
            Organization[] organizations = new Organization[size];
            for (int i = 0; i < size; i++)
            {
                //вывод классов
                for (int j = 0; j < arrayClass.Length; j++)
                {
                    Console.WriteLine(arrayClass[j]);
                }
                int nameClass = Menu.InputInt($"Введите тип {i + 1} организации: ");
                switch (nameClass)
                {
                    case 1:
                        organizations[i] = new Organization();
                        break;
                    case 2:
                        organizations[i] = new InsuranceCompany();
                        break;
                    case 3:
                        organizations[i] = new ShipBuildingCompany();
                        break;
                    case 4:
                        organizations[i] = new Factory();
                        break;
                    case 5:
                        organizations[i] = new Library();
                        break;
                    default:
                        Console.WriteLine("Неверная команда!");
                        break;
                }
                Console.ReadKey();
            }
            return organizations;
        }
        static void ShowVirtual(Organization[] organizations)
        {
            if (organizations is null || organizations.Length == 0)
            {
                Console.WriteLine("Массив пустой!");
                return;
            }
            foreach(Organization organization in organizations)
            {
                Console.WriteLine(organization.GetType());
                organization.Show();
                Console.WriteLine();
            }
        }
        static void ShowNotVirtual(Organization[] organizations)
        {
            if (organizations is null || organizations.Length == 0)
            {
                Console.WriteLine("Массив пустой!");
                return;
            }
            foreach (Organization organization in organizations)
            {
                Console.WriteLine(organization.GetType());
                organization.OrgShow();
                Console.WriteLine();
            }
        }
        static void CreateRequests(Organization[] org)
        {
            string[] arrayRequests =
            {
                "1. Кол-во работников в организации\n",
                "2. Вывод заводов, в которых рабочих больше 50\n",
                "3. Кол-во библиотек в городе\n",
                "4. Бинарный поиск по названию организации",
            };
            //вывод меню
            for (int i = 0; i < arrayRequests.Length; i++)
            {
                Console.WriteLine(arrayRequests[i]);
            }
            int numRequest = Menu.InputInt("Введите номер запроса: ");
            switch (numRequest)
            {
                case 1:
                    UsingRequest1(org);
                    break;
                case 2:
                    UsingRequest2(org);
                    break;
                case 3:
                    UsingRequest3(org);
                    break;
                case 4:
                    ShowBinarySearch(org);
                    break;
                default:
                    Console.WriteLine("Неправильный запрос!");
                    break;
            }
        }
        static void UsingRequest1(Organization[] org) 
        {
            Console.WriteLine("Введите название организации: ");
            string name = Console.ReadLine();
            Console.WriteLine($"Кол-во работников в {name}:" + Requests.GetTotalNumEmployess(org, name));
        }
        static void UsingRequest2(Organization[] org)
        {
            Console.WriteLine("Введите название организации: ");
            string name = Console.ReadLine();
            Console.WriteLine($"Заводы, в которых рабочих > 50: ");
            Requests.ShowFactory50Employess(org);
        }
        static void UsingRequest3(Organization[] org)
        {
            Console.WriteLine($"Кол-во библиотек в городе: " + Requests.GetTotalNumLibrary(org));
        }
        static void ShowBinarySearch(Organization[] orgs)
        {
            var orgsList = new List<Organization>(orgs);

            orgsList.Sort((x, y) => x.Name.CompareTo(y.Name));

            Console.Write("Введите название организации, которую ищете: ");
            string? name = Console.ReadLine();

            var result = Requests.BinarySearchByName(orgsList, name);

            if (result is null)
                Console.WriteLine("Организация не найдена");
            else
                Console.WriteLine("Найденная организация:\n" + result);
        }

        static void ShowIInit()
        {
            Console.WriteLine("\tИнтерфейс IInit: ");
            IInit[] objects = new IInit[]
            {
                new Organization(),
                new InsuranceCompany(),
                new ShipBuildingCompany(),
                new Factory(),
                new ShipBuildingCompany(),
                new ClassNotHierarchy()
            };

            Console.WriteLine("IInit[5] objects = new IInit[5] - состоит из объектов Organization, " +
                "InsuranceCompany, ShipBuildingCompany, Factory, ClassNotHierarchy");
            int count = 1;
            foreach (var item in objects)
            {
                Console.WriteLine($"Создается объект под номером {count++}: {item.GetType()}");
                item.RandomInit();
                Console.WriteLine(item + "\n");
            }
        }

        static void ShowSortIComparable()
        {
            Organization[] organizations = CreateOrganizationRandom();

            Array.Sort(organizations);
            Console.WriteLine("Отсортированный массив: ");
            ShowVirtual(organizations);
        }

        static void ShowSortICompare()
        {
            Organization[] organizations = CreateOrganizationRandom();
            Array.Sort(organizations, new SortByNumEmployess());
            Console.WriteLine("Отсортированный массив по кол-ву сотрудников: ");
            ShowVirtual(organizations);
        }

        static void ShowClone()
        {
            var originalOrganization = new Organization
            {
                Tags = new List<string> { "1", "2", "3" }
            };
            var clonedOrganization = (Organization)originalOrganization.Clone();

            Console.WriteLine("До изменения полное копирование:");
            foreach (var item in originalOrganization.Tags)
                Console.Write(item + " ");
            Console.WriteLine();

            originalOrganization.Tags.Clear();

            Console.WriteLine("После изменеия полное копирование:");
            foreach (var item in clonedOrganization.Tags)
                Console.Write(item + " ");
            Console.WriteLine();


            originalOrganization = new Organization
            {
                Tags = new List<string> { "1", "2", "3" }
            };
            var shallowCopyOrganization = (Organization)originalOrganization.ShallowCopy();

            Console.WriteLine("До изменения неполное копирование:");
            foreach (var item in originalOrganization.Tags)
                Console.Write(item + " ");
            Console.WriteLine();

            originalOrganization.Tags.Clear();

            Console.WriteLine("После изменения неполное копирование:");
            foreach (var item in shallowCopyOrganization.Tags)
                Console.Write(item + " ");
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            var organizations = Array.Empty<Organization>();
            string[] menu =
            {
                "   1 часть\n",
                "1. Создание массива организаций (вручную)\n",
                "2. Создание массива организаций (рандомно)\n",
                "3. Вывод организаций (с виртуальным методом)\n",
                "4. Вывод организаций (без виртуального метода)\n",
                "   2 часть\n",
                "5. Выполнить запросы\n",
                "   3 часть\n",
                "6. Демонстрация интерфейса IInit\n",
                "7. Демонстрация сортировки, используя стандартный интерфейс IComparable\n",
                "8. Демонстация сортировки, используя ICompare\n",
                "9. Создание клонов, их демонстрация\n",
                "0. Выход\n",
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
                        organizations = CreateOrganizationConsole();
                        break;
                    case 2:
                        organizations = CreateOrganizationRandom();
                        break;
                    case 3:
                        ShowVirtual(organizations);
                        break;
                    case 4:
                        ShowNotVirtual(organizations);
                        break;
                    case 5:
                        CreateRequests(organizations);
                        break;
                    case 6:
                        ShowIInit();
                        break;
                    case 7:
                        ShowSortIComparable();
                        break;
                    case 8:
                        ShowSortICompare();
                        break;
                    case 9:
                        ShowClone();
                        break;
                    case 0:
                        Console.WriteLine("\nПрограмма успешно завершила работу");
                        break;
                    default:
                        Console.WriteLine("Неправильная команда!");
                        break;
                }
            } while (command != 0);
        }
    }
}
