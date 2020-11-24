using System;
using System.Collections.Generic;

namespace Bakery
{
    public class Bake
    {
        public string Name { get; }
        public Dictionary<string, int> Composition {get;}
        public double Calorie { get; }
        public double Price { get; }

        public Bake (string name, Dictionary<string, int> composition, Dictionary<string, double> componentsCalorie, Dictionary<string, double> componentsPrice, Dictionary<string, double> markups)
        {
            Name = name;
            Composition = composition;
            Calorie = 0;
            foreach (KeyValuePair<string, int> compositionPair in Composition)
            {
                Calorie = Calorie + componentsCalorie[compositionPair.Key] * compositionPair.Value;
            }
            Price = 0;
            foreach (KeyValuePair<string, int> compositionPair in Composition)
            {
                Price = Price + componentsPrice[compositionPair.Key] * compositionPair.Value;
            }
            Price = Price * markups[Name];
        }

        public override string ToString()
        {
            string result = $"{Name}";
            foreach(KeyValuePair<string,int> compositionPair in Composition)
            {
                result = $"{result};{compositionPair.Key};{compositionPair.Value}";
            }
            result = $"{result};{Calorie};{Price}";
            return result;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            bool result = ToString()==((Bake)obj).ToString();
            return result;
        }
    }
}
