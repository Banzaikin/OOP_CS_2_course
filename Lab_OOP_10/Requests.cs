using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Lab_OOP_10
{
    public class Requests
    {
        //Кол-во работников в орагнизации, задаваемой пользователем
        public static int GetTotalNumEmployess(Organization[] orgs, string? orgName)
        {
            return orgs.Where(g => g.Name == orgName).Sum(g => g.NumEmployess);
        }
        //Вывод заводов, где рабочих больше 50
        public static void ShowFactory50Employess(Organization[] orgs)
        {
            foreach (var item in orgs)
            {
                if ((item is Factory) && (item.NumEmployess > 50))
                    Console.WriteLine(item);
            }
        }
        //Кол-во библиотек в городе
        public static int GetTotalNumLibrary(Organization[] orgs)
        {
            int numLib = 0;
            foreach (var item in orgs)
            {
                if (item is Library)
                    numLib++;
            }
            return numLib;
        }

        //бинарный поиск
        public static Organization? BinarySearchByName(List<Organization> organizationsList, string? target)
        {
            if (target is null) return null;
            int min = 0;
            int max = organizationsList.Count - 1;
            while (min <= max)
            {
                int mid = (min + max) / 2;
                int comparison = organizationsList[mid].Name.CompareTo(target);

                if (comparison == 0)
                {
                    return organizationsList[mid];
                }

                if (comparison < 0)
                {
                    min = mid + 1;
                }
                else
                {
                    max = mid - 1;
                }
            }

            return null; 
        }
    }
}
