using lab10lib_Shalnev;
using System;

namespace lab10lib_Shalnev
{
    [Serializable]
    public class Steamship : Ship, IInit, ICloneable, IComparable
    {
        public double EnginePower { get; set; }
        public int PassengerCapacity { get; set; }

        public Steamship(string name, double length, double tonnage, double enginePower, int passengerCapacity)
            : base(name, length, tonnage)
        {
            EnginePower = enginePower;
            PassengerCapacity = passengerCapacity;
        }

        public Steamship() => RandomInit();

        public override string GetString()
        {
            return base.GetString() +
                   $"Мощность двигателя: {EnginePower} | " +
                   $"Пассажирская вместимость: {PassengerCapacity} | ";
        }

        public override void Show()
        {
            Console.WriteLine(GetString());
        }

        public new void SelfShow()
        {
            base.SelfShow();
            Console.WriteLine($"Мощность двигателя: {EnginePower}\n" +
                              $"Пассажирская вместимость: {PassengerCapacity}");
        }

        public override void Init()
        {
            base.Init();

            Console.Write("Введите мощность двигателя: ");
            EnginePower = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите пассажирскую вместимость: ");
            PassengerCapacity = Convert.ToInt32(Console.ReadLine());
        }

        public override void RandomInit()
        {
            base.RandomInit();

            var random = new Random();

            EnginePower = Math.Round(random.NextDouble() * 10000, 2);
            PassengerCapacity = random.Next(1, 1000);
        }

        public override object Clone()
        {
            var newSteamship = (Steamship)this.MemberwiseClone();
            newSteamship.Features = new List<string>(Features);
            return newSteamship;
        }

        public override Steamship ShallowCopy()
        {
            return (Steamship)MemberwiseClone();
        }

        [Newtonsoft.Json.JsonIgnore]
        public Ship BaseShip
        {
            get
            {
                return new Ship(Name, Length, Tonnage);
            }
        }
    }
}
