using System;
using System.Collections.Generic;
using System.Text;
using Lab_10;

namespace Lab_OOP_13
{
    class Journal
    {
        public List<JournalEntry> journal;
        public class JournalEntry
        {
            public string NameCollection { get; set; }
            public string TypeChanged { get; set; }
            public string LinkObj { get; set; }
            public JournalEntry(string NameCollection, string TypeChanged, string LinkObj)
            {
                this.NameCollection = NameCollection;
                this.TypeChanged = TypeChanged;
                this.LinkObj = LinkObj;
            }
            public override string ToString()
            {
                return ($"Имя коллекции: {NameCollection}, Тип коллекции: {TypeChanged}, Изменения в коллекции: {LinkObj}\n");
            }
        }
        public Journal()
        {
            journal = new List<JournalEntry>();
        }
        public override string ToString()
        {
            string outStr = "";
            foreach (JournalEntry je in journal)
                outStr += je.ToString();
            return outStr;
        }
        public void CollectionCountChanged(object sourse, CollectionHandlerEventArgs e)
        {
            JournalEntry je = new JournalEntry(e.NameCollection, e.TypeChanged, e.LinkObj.ToString());
            journal.Add(je);
        }
        public void CollectionReferenceChanged(object sourse, CollectionHandlerEventArgs e)
        {
            JournalEntry je = new JournalEntry(e.NameCollection, e.TypeChanged, e.LinkObj.ToString());
            journal.Add(je);
        }
    }
}
