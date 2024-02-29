using System;
using System.Collections.Generic;
using System.Text;
using Lab_10;

namespace Lab_OOP_13
{
    class CollectionHandlerEventArgs : System.EventArgs
    {
        public string NameCollection { get; set; }
        public string TypeChanged {get; set; }
        public Organization LinkObj { get; set; }
        public CollectionHandlerEventArgs(string NameCollection, string TypeChanged, Organization? LinkObj)
        {
            this.NameCollection = NameCollection;
            this.TypeChanged = TypeChanged;
            this.LinkObj = LinkObj;
        }
        public override string ToString()
        {
            return ($"Имя коллекции: {NameCollection}, Тип коллекции: {TypeChanged}\n");
        }
    }
}
