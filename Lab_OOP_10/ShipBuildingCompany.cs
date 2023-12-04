using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_OOP_10
{
    class ShipBuildingCompany : InsuranceCompany, IInit, ICloneable, IComparable
    {
        private int numShip;
        public int NumShip
        {
            set
            {
                while (value < 0)
                    value = Menu.InputInt("Кол-во кораблей не может быть отрицательным! Введите ещё раз: ");
                numShip = value;
            }
            get { return numShip; }
        }
        //конструктор
        public ShipBuildingCompany(string name, string address, int numEmployess, int price, int numShip)
            : base(name, address, numEmployess, price)
        {
            NumShip = numShip;
        }
        //переопределение вывода 
        public override string GetString()
        {
            return base.GetString() + $"Кол-во кораблей: {NumShip}\n";
        }
        public override void Show()
        {
            Console.WriteLine(GetString());
        }
        public new void OrgShow()
        {
            Console.WriteLine($" Название: {Name}\n Адрес: {Address}\n " +
                $"Кол-во сотрудников: {NumEmployess}\n Цена страховки: {Price}\n" +
                $"Кол-во кораблей: {NumShip}");
            var tagsRow = string.Join(", ", Tags);
            Console.WriteLine("Теги: " + tagsRow);
        }
        public override void Init()
        {
            base.Init();
            NumShip = Menu.InputInt("Введите кол-во кораблей в компании: ");
        }
        public override void RandomInit()
        {
            base.RandomInit();
            var rnd = new Random();
            NumShip = rnd.Next(1, 10);
        }

        public override object Clone()
        {
            var newProduct = (ShipBuildingCompany)this.MemberwiseClone();
            newProduct.Tags = new List<string>(Tags);
            return newProduct;
        }

        public override object ShallowCopy()
        {
            return (ShipBuildingCompany)MemberwiseClone();
        }
    }
}
