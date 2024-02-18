using System;

namespace Lab_OOP_12
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = new string[22];
            arr[0] = "aaa";
            arr[1] = "aab"; arr[2] = "aba";
            arr[3] = "baa"; arr[4] = "abb";
            arr[5] = "bba"; arr[6] = "aac";
            arr[7] = "caa"; arr[8] = "aca";
            arr[9] = "abc"; arr[10] = "bca";
            arr[11] = "acc"; arr[12] = "cca";
            arr[13] = "bcb"; arr[14] = "bbc";
            arr[15] = "ccb"; arr[16] = "bbb";
            arr[17] = "ccc"; arr[18] = "acb";
            arr[19] = "cba"; arr[20] = "ccb";
            arr[21] = "acc";
            HTable ht = new HTable();
            foreach (string s in arr)
                ht.Add(s);
            ht.Print();
            string findStr;
            do
            {
                Console.WriteLine("Введите строку для поиска");
                findStr = Console.ReadLine();
                if (findStr == "end") continue;
                if (ht.FindPoint(findStr)) Console.WriteLine("Строка найдена");
                else Console.WriteLine("Строка не найдена");
            } while (findStr != "end");
        }
    }
}
