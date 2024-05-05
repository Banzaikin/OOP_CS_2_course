using lab10lib_Shalnev;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Serialization;

namespace lab10lib_Shalnev
{
    [Serializable]
    [XmlInclude(typeof(Steamship))]
    [XmlInclude(typeof(Sailboat))]
    [XmlInclude(typeof(Corvette))]
    public class Ship : IInit, ICloneable, IComparable
    {
        double length;
        double tonnage;

        public List<string> Features { get; set; }
        public string Name { get; set; }
        public double Length
        {
            get => length;
            set
            {
                if (value < 0)
                    Console.WriteLine("Длина не может быть меньше 0!");
                else
                    length = value;
            }
        }

        public double Tonnage
        {
            get => tonnage;
            set
            {
                if (value < 0)
                    Console.WriteLine("Водоизмещение не может быть меньше 0!");
                else
                    tonnage = value;
            }
        }

        public Ship(string name, double length, double tonnage)
        {
            Name = name;
            Length = length;
            Tonnage = tonnage;
            Features = CreateFeatures();
        }

        public Ship()
        {
            var rnd = new Random();
            Name = rnd.Next(1, 1000) + " Корабль_" + rnd.Next(1, 1000);
            Length = Math.Round(rnd.NextDouble() * 300, 2);
            Tonnage = Math.Round(rnd.NextDouble() * 50000, 2);

            Features = CreateFeatures();
        }

        private static List<string> CreateFeatures()
        {
            var rnd = new Random();
            var features = new List<string>();

            var size = rnd.Next(1, 3);
            for (int i = 0; i < size; i++)
                features.Add(Guid.NewGuid().ToString());

            return features;
        }

        public virtual string GetString()
        {
            var row = $"Название корабля: {Name} | " +
                      $"Длина: {Length} | " +
                      $"Водоизмещение: {Tonnage} | ";

            return row;
        }

        public virtual void Show()
        {
            Console.WriteLine(GetString());
        }

        public void SelfShow()
        {
            Console.WriteLine($"Название корабля: {Name}\n" +
                              $"Длина: {Length}\n" +
                              $"Водоизмещение: {Tonnage}");
        }

        public virtual void Init()
        {
            Console.Write("Введите название корабля: ");
            Name = Console.ReadLine();

            Console.Write("Введите длину корабля: ");
            length = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введите водоизмещение корабля: ");
            tonnage = Convert.ToDouble(Console.ReadLine());
        }

        public virtual void RandomInit()
        {
            var rnd = new Random();
            Name = "Корабль_" + rnd.Next(1, 10);
            Length = Math.Round(rnd.NextDouble() * 300, 2);
            Tonnage = Math.Round(rnd.NextDouble() * 50000, 2);

            Features = CreateFeatures();
        }

        public override bool Equals(object? obj)
        {
            if (obj is Ship other)
            {
                return Name == other.Name && Length == other.Length && Tonnage == other.Tonnage;
            }
            return false;
        }

        public virtual object Clone()
        {
            var newShip = (Ship)this.MemberwiseClone();
            newShip.Features = new List<string>(Features);
            return newShip;
        }

        public virtual Ship ShallowCopy()
        {
            return (Ship)this.MemberwiseClone();
        }

        public int CompareTo(object? obj)
        {
            if (obj == null) return 1;

            Ship other = obj as Ship;
            if (other != null)
            {
                int nameComparison = string.Compare(Name, other.Name);
                if (nameComparison != 0)
                    return nameComparison;

                if (Length > other.Length)
                    return 1;
                else if (Length < other.Length)
                    return -1;

                if (Tonnage > other.Tonnage)
                    return 1;
                else if (Tonnage < other.Tonnage)
                    return -1;

                return 0;
            }
            else
            {
                throw new ArgumentException("Object is not a Ship");
            }
        }


        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Length, Tonnage);
        }

        public override string ToString()
        {
            return GetString();
        }
    }
}
