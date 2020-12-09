using System;
using System.Collections.Generic;

namespace Bakery.Entities
{
    /// <summary>
    /// Class to make bakes.
    /// </summary>
    public class Bake
    {
        /// <summary>
        /// Bake name.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Bake composition in dictionary "component name" - "count".
        /// </summary>
        public Dictionary<string, int> Composition {get;}
        /// <summary>
        /// Calorie of bake.
        /// </summary>
        public double Calorie { get; }
        /// <summary>
        /// Price of bake.
        /// </summary>
        public double Price { get; }
        /// <summary>
        /// Main bake onstructor.
        /// Calorie and price calculate here.
        /// </summary>
        /// <param name="name">Bake name.</param>
        /// <param name="composition">Bake composition dictionary.</param>
        /// <param name="componentsCalorie">Component calorie dictionary. </param>
        /// <param name="componentsPrice">Component price dictionary.</param>
        /// <param name="markups">Bake markups dictionary.</param>
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
        /// <summary>
        /// Method ovveride to get string form.
        /// </summary>
        /// <returns>String "name;composition;calorie;price"</returns>
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
        /// <summary>
        /// Method ovveride to get hash code of a bake.
        /// </summary>
        /// <returns>Integer hash code.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        /// <summary>
        /// Method ovveride to compare equality of two bakes.
        /// </summary>
        /// <param name="obj">Bake to compare.</param>
        /// <returns>Boolean result of comparison.</returns>
        public override bool Equals(object obj)
        {
            bool result = ToString()==((Bake)obj).ToString();
            return result;
        }
    }
}
