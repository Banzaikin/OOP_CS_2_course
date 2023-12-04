using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_OOP_10
{
    class ClassNotHierarchy : IInit
    {
        public string? Id { get; private set; }

        public void Init()
        {
            Id = Guid.NewGuid().ToString();
        }

        public void RandomInit()
        {
            Id = $"Random_{new Random().Next(1, 100)}";
        }
    }
}
