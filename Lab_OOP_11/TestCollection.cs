using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Lab_10;

namespace Lab_OOP_11
{
    public class TestCollections
    {
        private int count = 0;
        public Queue<Organization> queueB = new Queue<Organization>();
        public Queue<string> queueS = new Queue<string>();
        public SortedDictionary<Organization, Library> dicGT = new SortedDictionary<Organization, Library>();
        public SortedDictionary<string, Library> dicST = new SortedDictionary<string, Library>();

        public int Count { get { return count; } }

        public void RandomInit(int count)
        {
            for (int i = 0; i < count; ++i)
            {
                var library = new Library();
                library.RandomInit();
                while (queueB.Contains(library.BaseOrganization()))
                {
                    library.RandomInit();
                }
                queueS.Enqueue(library.ToString());
                queueB.Enqueue(library.BaseOrganization());
                dicST.Add(library.ToString(), library);
                dicGT.Add(library.BaseOrganization(), library);
                this.count++;
            }
        }

        public bool Add(Library library)
        {
            if (queueB.Contains(library.BaseOrganization()))
                return false;

            queueS.Enqueue(library.ToString());
            queueB.Enqueue(library.BaseOrganization());
            dicST.Add(library.ToString(), library);
            dicGT.Add(library.BaseOrganization(), library);
            this.count++;
            return true;
        }

        public bool DeleteElem(Library library)
        {
            if (!queueB.Contains(library.BaseOrganization()))
                return false;
            RemoveQueue(queueB, library.BaseOrganization());
            RemoveQueue(queueS, library.ToString());
            dicGT.Remove(library.BaseOrganization());
            dicST.Remove(library.ToString());
            this.count--;
            return true;
        }
        public void RemoveQueue(Queue<Organization> queue, Organization org)
        {
            int queueCount = queue.Count; 
            for (int i = 0; i < queueCount; i++)
            {
                var firstElement = queue.Dequeue(); 
                if (firstElement == org) 
                    continue;
                queue.Enqueue(firstElement); 
            }
        }
        public void RemoveQueue(Queue<string> queue, string org)
        {
            int queueCount = queue.Count;
            for (int i = 0; i < queueCount; i++)
            {
                var firstElement = queue.Dequeue();
                if (firstElement == org)
                    continue;
                queue.Enqueue(firstElement);
            }
        }
    }
}