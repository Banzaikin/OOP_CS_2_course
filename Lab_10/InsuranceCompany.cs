using System;
using System.Collections.Generic;
using System.Text;


namespace Lab_10
{
    public class InsuranceCompany : Organization, IInit, ICloneable, IComparable
    {
        private int price;
        public int Price
        {
            set
            {
                while (value < 0)
                    value = Menu.InputInt("Цена страховки не может быть отрицательной! Введите ещё раз: ");
                price = value;
            }
            get { return price; }
        }
        //конструктор
        public InsuranceCompany(string name, string address, int numEmployess, int price)
            : base(name, address, numEmployess)
        {
            Price = price;
        }
        public InsuranceCompany() => RandomInit();
        //переопределение вывода 
        public override string GetString()
        {
            return base.GetString() + $"Цена страховки: {Price}\n";
        }
        public override void Show()
        {
            Console.WriteLine(GetString());
        }
        public new void OrgShow()
        {
            Console.WriteLine($" Название: {Name}\n Адрес: {Address}\n " +
                $"Кол-во сотрудников: {NumEmployess}\n Цена страховки: {Price}\n");
        }
        public override void Init()
        {
            base.Init();
            Price = Menu.InputInt("Введите цену страховки: ");
        }
        public override void RandomInit()
        {
            base.RandomInit();
            var rnd = new Random();
            NumEmployess = rnd.Next(1000, 100000);
        }

        public override object Clone()
        {
            var newProduct = (InsuranceCompany)this.MemberwiseClone();
            newProduct.Tags = new List<string>(Tags);
            return newProduct;
        }

        public override object ShallowCopy()
        {
            return (InsuranceCompany)MemberwiseClone();
        }
    }
}
