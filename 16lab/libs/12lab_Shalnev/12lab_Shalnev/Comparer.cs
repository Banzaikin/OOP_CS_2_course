using lab10lib_Shalnev;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public class Comparer : IComparer<Ship>
    {
        public int Compare(Ship? ship1, Ship? ship2)
        {
            if (ship1 == null || ship2 == null)
                return 0;

            if (ship1.Length > ship2.Length)
            {
                return 1;
            }
            else if (ship1.Length < ship2.Length)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
