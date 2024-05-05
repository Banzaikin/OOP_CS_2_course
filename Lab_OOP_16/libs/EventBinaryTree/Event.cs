using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBinaryTree
{
    public class CollectionHandlerEventArgs : EventArgs
    {
        public string TypeOfChange { get; set; }
        public object? ChaingedObj { get; }

        public CollectionHandlerEventArgs(string TypeOfChange, object? ChaingedObj)
        {
            this.TypeOfChange = TypeOfChange;
            this.ChaingedObj = ChaingedObj;
        }

    }
}
