using System;
using System.Collections.Generic;
using Bakery.Entities;
using Bakery.Services;

namespace BakeryApplication
{
    /// <summary>
    /// Console application operating bakes according taks.
    /// </summary>
    public class BakeryConsoleApp
    {
        static void Main(string[] args)
        {
            Dictionary<string, double> markups = BakeryFileReader.ReadMarkups(@"..\..\..\TestFiles\BakeryInfo.txt");
            Dictionary<string, double> componentsCalorie = BakeryFileReader.ReadComponentsCalorie(@"..\..\..\TestFiles\BakeryInfo.txt");
            Dictionary<string, double> componentsPrice = BakeryFileReader.ReadComponentsPrice(@"..\..\..\TestFiles\BakeryInfo.txt");
            Bake[] bakes = BakeryFileReader.ReadBakes(@"..\..\..\TestFiles\Bakes.txt", componentsCalorie, markups, componentsPrice);
            Console.WriteLine("Original array:");
            ShowBakes(bakes);
            Bake[] clonedBakes = (Bake[])bakes.Clone();
            clonedBakes = CalorieSort(clonedBakes);
            Console.WriteLine("Cloned sorted by calorie array:");
            ShowBakes(clonedBakes);
            Bake[] copiedBakes = new Bake[bakes.Length];
            bakes.CopyTo(copiedBakes, 0);
            copiedBakes = PriceSort(copiedBakes);
            Console.WriteLine("Copied sorted by price array:");
            ShowBakes(copiedBakes);
            Bake bakeToCompare = bakes[1];
            Bake[] searchResult = FindPriceCalorieEqualBakes(bakes, bakeToCompare);
            Console.WriteLine("Bake to compare:");
            Console.WriteLine(bakeToCompare);
            Console.WriteLine("Result:");
            ShowBakes(searchResult);
            string component = "Component 3";
            int componentAmount = 250;
            Bake[] componentOverrunBakes = FindComponentOverrunBakes(bakes, component, componentAmount);
            Console.WriteLine("Component and amount to check:");
            Console.WriteLine($"{component} {componentAmount}");
            Console.WriteLine("Component overrun bakes:");
            ShowBakes(componentOverrunBakes);
            int componentCount = 2;
            Bake[] componentCountOverrunBakes = FindComponentCountOverrunBakes(bakes, componentCount);
            Console.WriteLine($"Component count to check: {componentCount}");
            ShowBakes(componentCountOverrunBakes);
            Console.ReadKey();
        }
        /// <summary>
        /// Method sorting bakes by calorie.
        /// </summary>
        /// <param name="bakeToSort">Bakes array to sort.</param>
        /// <returns>Sorted array of bakes.</returns>
        public static Bake[] CalorieSort(Bake[] bakeToSort)
        {
            Array.Sort(bakeToSort, new CalorieSorter());
            return bakeToSort;
        }
        /// <summary>
        /// Method sorting bakes by price.
        /// </summary>
        /// <param name="bakeToSort">Bakes array to sort.</param>
        /// <returns>Sorted array of bakes.</returns>
        public static Bake[] PriceSort(Bake[] bakeToSort)
        {
            Array.Sort(bakeToSort, new PriceSorter());
            return bakeToSort;
        }
        /// <summary>
        /// Method searching bakes equal by calorie and price to given bake.
        /// </summary>
        /// <param name="bakes">Array of bakes to search in.</param>
        /// <param name="bakeToCompare">Given bake to compare.</param>
        /// <returns>Array of bakes equal to given bake.</returns>
        public static Bake[] FindPriceCalorieEqualBakes(Bake[] bakes, Bake bakeToCompare)
        {
            Bake[] equalBakes = Array.FindAll<Bake>(bakes, x => x.Price == bakeToCompare.Price && x.Calorie == bakeToCompare.Calorie);
            return equalBakes;
        }
        /// <summary>
        /// Method to bakes with given component overrun.
        /// </summary>
        /// <param name="bakes">Array of bakes to search in.</param>
        /// <param name="component">Name of component.</param>
        /// <param name="componentCount">Count of component to compare.</param>
        /// <returns>Array of bakes with component overrun.</returns>
        public static Bake[] FindComponentOverrunBakes(Bake[] bakes, string component, int componentCount)
        {
            Bake[] overrunBakes = Array.FindAll<Bake>(bakes, x=>x.Composition.ContainsKey(component)&&x.Composition[component]>componentCount);
            return overrunBakes;
        }
        /// <summary>
        /// Method of search bakes with component count overrun.
        /// </summary>
        /// <param name="bakes">Array of bakes to search in.</param>
        /// <param name="componentsCount">Count of components to compare.</param>
        /// <returns>Array of bakes with component count overrun.</returns>
        public static Bake[] FindComponentCountOverrunBakes(Bake[] bakes, int componentsCount)
        {
            Bake[] overrunBakes = Array.FindAll<Bake>(bakes, x=>x.Composition.Count>componentsCount);
            return overrunBakes;
        }
        /// <summary>
        /// Method to show bake array.
        /// </summary>
        /// <param name="bakes">Bake array to show.</param>
        public static void ShowBakes(Bake[] bakes)
        {
            foreach(Bake bake in bakes)
            {
                Console.WriteLine(bake);
            }
        }
    }
}
