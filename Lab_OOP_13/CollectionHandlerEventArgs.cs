using System;
using System.Collections.Generic;
using System.Text;
using Lab_10;

namespace Lab_OOP_13
{
    public class CollectionHandlerEventArgs : System.EventArgs
    {
        public string NameCollection { get; set; }
        public string TypeChanged {get; set; }
        public Organization LinkObj { get; }
        public CollectionHandlerEventArgs(string NameCollection, string TypeChanged, Organization? LinkObj)
        {
            this.NameCollection = NameCollection;
            this.TypeChanged = TypeChanged;
            this.LinkObj = LinkObj ?? default!;
        }
        public override string ToString()
        {
            return ($"Имя коллекции: {NameCollection}, Тип коллекции: {TypeChanged}\n");
        }
    }
}
