using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_10
{
    public class Library : Organization, IInit, ICloneable, IComparable
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
        public Library() => RandomInit();
        public Library BaseOrganization()
        {
            var orgObject = (Library)this.MemberwiseClone();
            return orgObject;
        }
        //переопределение вывода 
        public override string GetString()
        {
            return base.GetString() + $"Кол-во книг: {NumBook}\n";
        }
        public override void Show()
        {
            Console.WriteLine(GetString());
        }
        public new void OrgShow()
        {
            Console.WriteLine($" Название: {Name}\n Адрес: {Address}\n " +
                $"Кол-во сотрудников: {NumEmployess}\n Кол-во книг: {NumBook}\n");
            //var tagsRow = string.Join(", ", Tags);
            //Console.WriteLine("Теги: " + tagsRow);
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

        public override object Clone()
        {
            var newProduct = (Library)this.MemberwiseClone();
            newProduct.Tags = new List<string>(Tags);
            return newProduct;
        }

        public override object ShallowCopy()
        {
            return (Library)MemberwiseClone();
        }
    }
}
