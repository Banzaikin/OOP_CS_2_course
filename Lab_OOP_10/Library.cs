using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_OOP_10
{
    class Library : Organization
    {
        private int numBook;
        public int NumBook
        {
            set
            {
                while (value < 0)
                    value = Menu.InputInt("Кол-во книг не может быть отрицательным! Введите ещё раз: ");
                numBook = value;
            }
            get { return numBook; }
        }
        //конструктор
        public Library(string name, string address, int numEmployess, int numBook)
            : base(name, address, numEmployess)
        {
            NumBook = numBook;
        }
        //переопределение вывода 
        public override string GetString()
        {
            return base.GetString() + $"Цена страховки: {NumBook}\n";
        }
        public override void Show()
        {
            Console.WriteLine(GetString());
        }
        public new void OrgShow()
        {
            Console.WriteLine($" Название: {Name}\n Адрес: {Address}\n " +
                $"Кол-во сотрудников: {NumEmployess}\n Кол-во книг: {NumBook}\n");
        }
        //переопределение инициализации
        public override void Init()
        {
            base.Init();
            NumBook = Menu.InputInt("Введите кол-во книг: ");
        }
        //переопредление рандомного заполнения объектов
        public override void RandomInit()
        {
            base.RandomInit();
            var rnd = new Random();
            NumEmployess = rnd.Next(100, 10000);
        }
    }
}
