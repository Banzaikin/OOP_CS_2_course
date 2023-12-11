using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_OOP_11
{
    public class TimeWork
    {
        public static string OrganizationOfWorkQueue<T>(Queue<T> queue, T obj)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var flag = queue.Contains(obj);
            stopWatch.Stop();
            return stopWatch.Elapsed.TotalMilliseconds.ToString() + $" Найден: {flag}";
        }
        public static string OrganizationOfWorkSortedDictionary<TKey, TValue>(SortedDictionary<TKey, TValue> SortedDictionary, TKey key) where TKey : notnull
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var flag = SortedDictionary.ContainsKey(key);
            stopWatch.Stop();
            return stopWatch.Elapsed.TotalMilliseconds.ToString() + $" Найден: {flag}";
        }
        public static string OrganizationOfWorkSortedDictionary<TKey, TValue>(SortedDictionary<TKey, TValue> SortedDictionary, TValue value) where TKey : notnull
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var flag = SortedDictionary.ContainsValue(value);
            stopWatch.Stop();
            return stopWatch.Elapsed.TotalMilliseconds.ToString() + $" Найден: {flag}";
        }
    }
}