using System;
using System.Collections.Generic;
using Bakery;

namespace BakeryApplication
{
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
        public static Bake[] CalorieSort(Bake[] bakeToSort)
        {
            Array.Sort(bakeToSort, new CalorieSorter());
            return bakeToSort;
        }
        public static Bake[] PriceSort(Bake[] bakeToSort)
        {
            Array.Sort(bakeToSort, new PriceSorter());
            return bakeToSort;
        }
        public static Bake[] FindPriceCalorieEqualBakes(Bake[] bakes, Bake bakeToCompare)
        {
            Bake[] equalBakes = Array.FindAll<Bake>(bakes, x => x.Price == bakeToCompare.Price && x.Calorie == bakeToCompare.Calorie);
            return equalBakes;
        }
        public static Bake[] FindComponentOverrunBakes(Bake[] bakes, string component, int componentCount)
        {
            Bake[] overrunBakes = Array.FindAll<Bake>(bakes, x=>x.Composition.ContainsKey(component)&&x.Composition[component]>componentCount);
            return overrunBakes;
        }
        public static Bake[] FindComponentCountOverrunBakes(Bake[] bakes, int componentsCount)
        {
            Bake[] overrunBakes = Array.FindAll<Bake>(bakes, x=>x.Composition.Count>componentsCount);
            return overrunBakes;
        }
        public static void ShowBakes(Bake[] bakes)
        {
            foreach(Bake bake in bakes)
            {
                Console.WriteLine(bake);
            }
        }
    }
}
