using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10lib_Shalnev
{
    [Serializable]
    public class Sailboat : Ship, IInit, ICloneable, IComparable
    {
        public double MastHeight { get; set; }
        public string SailMaterial { get; set; }

        public Sailboat(string name, double length, double tonnage, double mastHeight, string sailMaterial)
            : base(name, length, tonnage)
        {
            MastHeight = mastHeight;
            SailMaterial = sailMaterial;
        }

        public Sailboat() => RandomInit();

        public override string GetString()
        {
            return base.GetString() +
                   $"Высота мачты: {MastHeight} | " +
                   $"Материал паруса: {SailMaterial} |";
        }

        public override void Show()
        {
            Console.WriteLine(GetString());
        }

        public new void SelfShow()
        {
            base.SelfShow();
            Console.WriteLine($"Высота мачты: {MastHeight}\n" +
                              $"Материал паруса: {SailMaterial}");
        }

        public override void Init()
        {
            base.Init();

            Console.Write("Введите высоту мачты: ");
            MastHeight = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите материал паруса: ");
            SailMaterial = Console.ReadLine();
        }

        public override void RandomInit()
        {
            base.RandomInit();

            var random = new Random();

            MastHeight = Math.Round(random.NextDouble() * 20, 2);
            SailMaterial = "Нейлон";
        }

        public override object Clone()
        {
            var newSailboat = (Sailboat)this.MemberwiseClone();
            newSailboat.Features = new List<string>(Features);
            return newSailboat;
        }

        public override Sailboat ShallowCopy()
        {
            return (Sailboat)MemberwiseClone();
        }
    }

}
