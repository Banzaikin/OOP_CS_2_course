﻿using System;
using System.Collections.Generic;
using Lab_10;

namespace Lab_OOP_13
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree1 = new MyNewSearchBinaryTree<Organization>();
            var tree2 = new MyNewSearchBinaryTree<Organization>();

            var journal1 = new Journal();
            var journal2 = new Journal();

            tree1.CollectionCountChanged += new CollectionHandler(journal1.CollectionCountChanged);
            tree1.CollectionReferenceChanged += new CollectionHandler(journal1.CollectionReferenceChanged);

            tree1.CollectionReferenceChanged += new CollectionHandler(journal2.CollectionReferenceChanged);
            tree2.CollectionReferenceChanged += new CollectionHandler(journal2.CollectionReferenceChanged);

            var organizations = new Organization[3];
            for (int i = 0; i < 3; i++)
                organizations[i] = new Organization();
            tree1.AddRange(organizations);
            tree2.AddRange(organizations);

            tree1.Remove(2);
            tree1.Remove(0);
            tree2.Remove(2);
            tree2.Remove(0);

            var organization = new Organization("1", "1", 1);
            tree1[0] = organization;
            tree2[0] = organization;

            Console.WriteLine(journal1 + "\n\n" + journal2);
            Console.WriteLine("\tПервое дерево: ");
            tree1.PrintTree();
            Console.WriteLine();
            Console.WriteLine("\tВторое дерево: ");
            tree2.PrintTree();

            Console.ReadKey(true);
        }
    }
}
