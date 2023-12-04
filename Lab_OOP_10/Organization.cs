using System;
using System.Collections.Generic;
using System.Text;


namespace Lab_OOP_10
{
    public class Organization
    {
        private string name; 
        private string address;
        private int numEmployess;
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
        }
        public virtual string GetString()
        {
            var row = $"Название: {Name}\n"
                + $"Адрес: {Address}\n"
                + $"Кол-во сотрудников: {NumEmployess}\n";
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
    }
}
