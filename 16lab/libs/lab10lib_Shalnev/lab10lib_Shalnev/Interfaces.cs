using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10lib_Shalnev
{
    public interface IInit
    {
        void Init();
        void RandomInit();
    }

    public class SortByLength : IComparer
    {
        int IComparer.Compare(object? obj1, object? obj2)
        {
            if (obj1 is null || obj2 is null)
                return 1;

            Ship ship1 = (Ship)obj1;
            Ship ship2 = (Ship)obj2;

            if (ship1.Length > ship2.Length)
                return 1;
            if (ship1.Length < ship2.Length)
                return -1;
            else
                return 0;
        }
    }

    public class CompareByName : IComparer
    {
        int IComparer.Compare(object? obj1, object? obj2)
        {
            if (obj1 is null || obj2 is null)
                return 1;

            Ship ship1 = (Ship)obj1;
            Ship ship2 = (Ship)obj2;

            return ship1.Name.CompareTo(ship2.Name);   

        }
    }
}
