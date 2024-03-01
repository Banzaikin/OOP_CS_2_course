﻿using System;
using System.Collections.Generic;
using System.Text;
using Lab_10;
using Lab_OOP_12;

namespace Lab_OOP_13
{
    delegate void CollectionHandler(object source, CollectionHandlerEventArgs args);
    class MyNewSearchBinaryTree<T> : BinarySearchTree<Organization>
    {
        public string Name { get; } = "SearchTree";
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
        public bool Remove(int j)
        {
            if ((j > 0) && (j < this.Count - 1))
            {
                var findItem = this[j];
                Remove(findItem);
                return true;
            }
            return false;
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
        public Organization this[int index]
        {
            get
            {
                Organization org = default;
                int count = 0;
                foreach(Organization item in this)
                {
                    if (count == index)
                    {
                        org = item;
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
                var inElem = this.FindNode(findItem, this.RootNode);
                inElem.Data.Name = value.Name;
            }
        }

    }
}