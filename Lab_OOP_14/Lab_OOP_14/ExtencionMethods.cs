using Lab_10;
using Lab_OOP_12;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_OOP_14
{
    public static class ExtencionMethods
    {
        //На выборку данных по условию
        public static IEnumerable<Organization> SelectOrg(this BinarySearchTree<Organization> collection, Func<Organization, bool> predicate)
        {
            var subset = collection.Where(predicate);
            return subset;
        }
        //Агрегирование данных (среднее, максимум/минимум, сумма и пр.)
        public static int CountOrg(this BinarySearchTree<Organization> collection, Func<Organization, bool> predicate)
        {
            int count = collection.Where(predicate).Count();
            return count;
        }
        //Сортировка коллекции (по убыванию/по возрастанию)
        public static BinarySearchTree<Organization> SortOrg(this BinarySearchTree<Organization> tree, Func<Organization, int> sortByFunc)
        {
            var comparer = Comparer<Organization>.Create((org1, org2) => sortByFunc(org1).CompareTo(sortByFunc(org2)));
            var newTree = new BinarySearchTree<Organization>(comparer);
            foreach (var org in tree)
            {
                try { newTree.Add(org); }
                catch (Exception e) { Console.WriteLine("Не удалось добавить элемент, т.к. он уже есть: " + org); }
            }
            return newTree;
        }
        //Группировка данных 
        public static IEnumerable<IGrouping<string, Organization>> GroupOrg(this BinarySearchTree<Organization> collection, Func<Organization, string> predicate)
        {
            var subset = collection.GroupBy(predicate);
            return subset;
        }
    }
}
