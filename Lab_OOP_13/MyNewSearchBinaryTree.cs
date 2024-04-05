using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Lab_10;
using Lab_OOP_12;

namespace Lab_OOP_13
{
    delegate void CollectionHandler(object source, CollectionHandlerEventArgs args);
    class MyNewSearchBinaryTree<T> : BinarySearchTree<Organization>
    {
        public string Name { get; } = "SearchTree";
        public MyNewSearchBinaryTree(IComparer<Organization>? comparer = null) : base(comparer) { }
        //происходит при добавлении нового элемента или при удалении элемента
        public event CollectionHandler CollectionCountChanged;
        //объекту коллекции присваивается новое значение
        public event CollectionHandler CollectionReferenceChanged;
        //обработчик события CollectionCountChanged
        public virtual void OnCollectionCountChanged(object source, CollectionHandlerEventArgs args)
        {
            if (CollectionCountChanged != null)
                CollectionCountChanged(source, args);
        }
        //обработчик события OnCollectionReferenceChanged
        public virtual void OnCollectionReferenceChanged(object source, CollectionHandlerEventArgs args)
        {
            if (CollectionReferenceChanged != null)
                CollectionReferenceChanged(source, args);
        }
        private bool CheckIndex(int index)
        {
            if (index > this.Count - 1)
                return false;
            else if (index < 0)
                return false;
            return true;
        }
        public bool Remove(int index)
        {
            if (!CheckIndex(index))
                return false;

            var findElem = this[index];
            Remove(findElem);
            return true;
        }
        public override bool Remove(Organization org)
        {
            OnCollectionCountChanged(this, new CollectionHandlerEventArgs(this.Name, "delete", base.Find(org)));
            return base.Remove(org);
        }
        public override void Add(Organization p)
        {
            OnCollectionCountChanged(this, new CollectionHandlerEventArgs(this.Name, "add", p));
            base.Add(p);
        }
        public override void AddRange(IEnumerable<Organization> collection)
        {
            foreach (var value in collection)
                Add(value);
        }
        public Organization this[int index]
        {
            get
            {
                Organization org = default!;
                int count = 0;
                foreach(Organization item in this)
                {
                    org = item;
                    if (count == index)
                    {
                        break;
                    }
                    count++;
                }
                return org;
            }
            set
            {
                var findItem = this[index];
                OnCollectionReferenceChanged(this, new CollectionHandlerEventArgs(this.Name, "changed", value));
                findItem.Name = value.Name;
            }
        }
    }
    public class CustomComparer : IComparer<Organization>
    {
        public int Compare(Organization? organization1, Organization? organization2)
        {
            if (organization1 == null || organization2 == null)
                return 0;

            if (organization1.NumEmployess > organization2.NumEmployess)
                return 1;
            else if (organization1.NumEmployess < organization2.NumEmployess)
                return -1;
            else
                return 0;
        }
    }
}
