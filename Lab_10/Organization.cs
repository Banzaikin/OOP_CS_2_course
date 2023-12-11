using System;
using System.Collections.Generic;
using System.Text;


namespace Lab_10
{
    public class Organization : IInit, ICloneable, IComparable
    {
        private string name;
        private string address;
        private int numEmployess;
        public List<string> Tags { get; set; } // для показа различия между поверх и полным копированием
        //свойства
        public string Name
        {
            set { name = value; }
            get { return name; }
        }
        public string Address
        {
            set { address = value; }
            get { return address; }
        }
        public int NumEmployess
        {
            set
            {
                while (value < 0)
                    value = Menu.InputInt("Кол-во сотрудников не может быть отрицательным! Введите ещё раз: ");
                numEmployess = value;
            }
            get { return numEmployess; }
        }
        //конструктор
        public Organization(string n, string a, int nE)
        {
            name = n;
            address = a;
            numEmployess = nE;
            Tags = CreateTag();
        }
        public Organization()
        {
            var rnd = new Random();
            Name = "Организация_" + rnd.Next(1, 10);
            Address = "ул. Пушкина, д. " + rnd.Next(1, 100);
            NumEmployess = rnd.Next(1, 100);

            Tags = CreateTag();
        }
        private static List<string> CreateTag()
        {
            var rnd = new Random();
            var tags = new List<string>();

            var size = rnd.Next(1, 3);
            for (int i = 0; i < size; i++)
                tags.Add(Guid.NewGuid().ToString());

            return tags;
        }
        public virtual string GetString()
        {
            var row = $"Название: {Name}\n"
                + $"Адрес: {Address}\n"
                + $"Кол-во сотрудников: {NumEmployess}\n";
            // var tagsRow = string.Join(", ", Tags);
            return row;
        }
        //Вывод объектов класса (виртуальный метод)
        public virtual void Show()
        {
            Console.WriteLine(GetString());
        }
        //Вывод объектов класса (не виртуальный)
        public void OrgShow()
        {
            Console.WriteLine($" Название: {Name}\n Адрес: {Address}\n Кол-во сотрудников: {NumEmployess}\n");
            //var tagsRow = string.Join(", ", Tags);
            //Console.WriteLine("Теги: " + tagsRow);
        }
        //Ввод информации об объектах классов
        public virtual void Init()
        {
            Console.WriteLine("Введите название организации: ");
            Name = Console.ReadLine();
            Console.WriteLine("Введите адрес организации: ");
            Address = Console.ReadLine();
            NumEmployess = Menu.InputInt("Введите кол-во сотрудников: ");
        }
        //рандомное заполнение объектов класса
        public virtual void RandomInit()
        {
            var rnd = new Random();
            Name = "Организация_" + rnd.Next(1, 10);
            Address = "ул. Пушкина, д. " + rnd.Next(1, 100);
            NumEmployess = rnd.Next(1, 100);

            Tags = CreateTag();
        }
        //сравнение объектов
        public override bool Equals(object? obj)
        {
            if (obj is Organization other)
            {
                return Name == other.Name && Address == other.Address && NumEmployess == other.NumEmployess;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Address, NumEmployess);
        }

        //3 часть задания
        public virtual object Clone()
        {
            var newOrganization = (Organization)this.MemberwiseClone();
            newOrganization.Tags = new List<string>(Tags);
            return newOrganization;
        }

        public virtual object ShallowCopy()
        {
            return (Organization)this.MemberwiseClone();
        }

        public int CompareTo(object? obj)
        {
            if (obj is null) return 1;
            else
            {
                var other = (Organization)obj;

                if (String.Compare(Name, other.Name) > 0)
                    return 1;
                else if (String.Compare(Name, other.Name) < 0)
                    return -1;
                if (String.Compare(Address, other.Address) > 0)
                    return 1;
                else if (String.Compare(Address, other.Address) < 0)
                    return -1;
                if (NumEmployess > other.NumEmployess)
                    return 1;
                else if (NumEmployess < other.NumEmployess)
                    return -1;
                return 0;
            }
        }

        public override string ToString()
        {
            return GetString();
        }
    }
}
