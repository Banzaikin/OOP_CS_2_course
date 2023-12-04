using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_OOP_10
{
    class Factory : Organization, IInit, ICloneable, IComparable
    {
        private int avarageSalary;
        public int AvarageSalary
        {
            set
            {
                while (value < 0)
                    value = Menu.InputInt("Средняя зарплата не может быть отрицательной! Введите ещё раз: ");
                avarageSalary = value;
            }
            get { return avarageSalary; }
        }
        //конструктор
        public Factory(string name, string address, int numEmployess, int avarageSalary)
            : base(name, address, numEmployess)
        {
            AvarageSalary = avarageSalary;
        }
        //переопределение вывода 
        public override string GetString()
        {
            return base.GetString() + $"Средняя зарплата: {AvarageSalary}\n";
        }
        public override void Show()
        {
            Console.WriteLine(GetString());
        }
        public new void OrgShow()
        {
            Console.WriteLine($" Название: {Name}\n Адрес: {Address}\n " +
                $"Кол-во сотрудников: {NumEmployess}\n Средняя зарплата: {AvarageSalary}\n");
            var tagsRow = string.Join(", ", Tags);
            Console.WriteLine("Теги: " + tagsRow);
        }
        public override void Init()
        {
            base.Init();
            AvarageSalary = Menu.InputInt("Введите среднюю зарплату: ");
        }
        public override void RandomInit()
        {
            base.RandomInit();
            var rnd = new Random();
            AvarageSalary = rnd.Next(15000, 100000);
        }

        public override object Clone()
        {
            var newToy = (Factory)this.MemberwiseClone();
            newToy.Tags = new List<string>(Tags);
            return newToy;
        }
        public override object ShallowCopy()
        {
            return (Factory)MemberwiseClone();
        }
    }
}
