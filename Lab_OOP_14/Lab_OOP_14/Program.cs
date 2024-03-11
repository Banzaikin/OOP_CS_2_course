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
        static SortedDictionary<int, Queue> CreateOrganizationRandom(int sizeSortedDictionary, int sizeQueue)
        {
            
            var cities = new SortedDictionary<int, Queue>();
            for (int i = 0; i < sizeSortedDictionary; i++)
            {
                var districts = new Queue();
                for (int j = 0; j < sizeQueue; j++)
                {
                    if (j % 2 == 0)
                        districts.Enqueue(new Organization());
                    else
                        districts.Enqueue(new Library());
                }
                cities.Add(i, districts);
            }
            return cities;
        }
        static void Main(string[] args)
        {
            int sizeSortedDictionary = Menu.InputInt("Введите кол-во городов: ");
            int sizeQueue = Menu.InputInt("Введите кол-во организаций: ");
            var district = new Queue();
            var city = new SortedDictionary<int, Queue>();
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

