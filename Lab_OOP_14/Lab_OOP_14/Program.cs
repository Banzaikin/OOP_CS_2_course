// See https://aka.ms/new-console-template for more information
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using Lab_10;

namespace Lab_OOP_14
{
    class Program
    {
        //создание словаря
        static SortedDictionary<int, Queue<Organization>> CreateOrganizationRandom(int sizeSortedDictionary, int sizeQueue)
        {
            
            var cities = new SortedDictionary<int, Queue<Organization>>();
            for (int i = 0; i < sizeSortedDictionary; i++)
            {
                var districts = new Queue<Organization>();
                for (int j = 0; j < sizeQueue; j++)
                    districts.Enqueue(new Organization());
                cities.Add(i, districts);
            }
            return cities;
        }
        static void Main(string[] args)
        {
            int sizeSortedDictionary = Menu.InputInt("Введите кол-во организаций: ");
            int sizeQueue = Menu.InputInt("Введите кол-во библиотек: ");
            var district = new Queue<Organization>();
            var city = new SortedDictionary<int, Queue<Organization>>();
            city = CreateOrganizationRandom(sizeSortedDictionary, sizeQueue);
            Console.WriteLine("\tЭлементы словаря: ");
            foreach (var key in city.Keys)
            {
                Console.WriteLine("Элементы очереди");
                for (int i = 0; i < sizeQueue; ++i)
                {
                    Console.WriteLine(city[key].Dequeue());
                }
            }
        }
    }
    //class Organization : IEnumerable
    //{
    //    private Queue<Organization> items = new Queue<Organization>();
    //    public IEnumerator<Organization> GetEnumerator()
    //    {
    //        foreach (Organization item in items)
    //        {
    //            yield return item;
    //        }
    //    }

    //    IEnumerator IEnumerable.GetEnumerator()
    //    {
    //        return GetEnumerator();
    //    }
    //}
}

