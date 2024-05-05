using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10lib_Shalnev
{
    [Serializable]
    public class Corvette : Ship, IInit, ICloneable, IComparable
    {
        public int GunsCount { get; set; }
        public string ShipClass { get; set; }

        public Corvette(string name, double length, double tonnage, int gunsCount, string shipClass)
            : base(name, length, tonnage)
        {
            GunsCount = gunsCount;
            ShipClass = shipClass;
        }

        public Corvette() => RandomInit();

        public override string GetString()
        {
            return base.GetString() +
                   $"Количество пушек: {GunsCount} | " +
                   $"Класс корвета: {ShipClass} | ";
        }

        public override void Show()
        {
            Console.WriteLine(GetString());
        }

        public new void SelfShow()
        {
            base.SelfShow();
            Console.WriteLine($"Количество пушек: {GunsCount}\n" +
                              $"Класс корвета: {ShipClass}");
        }

        public override void Init()
        {
            base.Init();


            Console.Write("Введите количество пушек: ");
            GunsCount = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите класс корвета: ");
            ShipClass = Console.ReadLine();
        }

        public override void RandomInit()
        {
            base.RandomInit();

            var random = new Random();

            GunsCount = random.Next(1, 30);
            ShipClass = "Фрегат";
        }

        public override object Clone()
        {
            var newCorvette = (Corvette)this.MemberwiseClone();
            newCorvette.Features = new List<string>(Features);
            return newCorvette;
        }

        public override Corvette ShallowCopy()
        {
            return (Corvette)MemberwiseClone();
        }
    }
}
