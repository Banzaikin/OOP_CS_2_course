using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lab_10
{
    public interface IInit
    {
        void Init();
        void RandomInit();
    }

    public class SortByNumEmployess : IComparer
    {
        int IComparer.Compare(object? obj1, object? obj2)
        {
            if (obj1 is null || obj2 is null)
                return 1;

            Organization org1 = (Organization)obj1;
            Organization org2 = (Organization)obj2;

            if (org1.NumEmployess > org2.NumEmployess)
                return 1;
            if (org1.NumEmployess < org2.NumEmployess)
                return -1;
            else
                return 0;
        }
    }
}
