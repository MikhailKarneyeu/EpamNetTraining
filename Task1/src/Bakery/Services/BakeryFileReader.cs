using Bakery.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Services
{
    /// <summary>
    /// Class to read files with bakes, calorie per component, price for component, markups per bake.
    /// </summary>
    public abstract class BakeryFileReader
    {
        /// <summary>
        /// Method to read file with bakes.
        /// </summary>
        /// <param name="filePath">Path to file.</param>
        /// <param name="componentsCalorie">Calorie per coponent dictionary.</param>
        /// <param name="markups">Bakes markup dictonary.</param>
        /// <param name="componentsPrice">Price for component dictionary.</param>
        /// <returns>Array of Bakes.</returns>
        public static Bake[] ReadBakes(string filePath, Dictionary<string, double> componentsCalorie, Dictionary<string, double> markups, Dictionary<string, double> componentsPrice)
        {
            Bake[] bakes = new Bake[0];

            string fileTest = System.IO.File.ReadAllText(filePath);
            string[] fileParts = fileTest.Split("\n");
            bakes = new Bake[fileParts.Length];
            for (int i = 0; i < fileParts.Length; i++)
            {
                string[] bakeParts = fileParts[i].Split(";");
                Dictionary<string, int> components = new Dictionary<string, int>();
                for (int j = 1; j < bakeParts.Length; j++)
                {
                    string[] componentLineParts = bakeParts[j].Split(":");
                    components.Add(componentLineParts[0], Convert.ToInt32(componentLineParts[1]));
                }
                bakes[i] = new Bake(bakeParts[0], components, componentsCalorie, componentsPrice, markups);
            }
            return bakes;
        }
        /// <summary>
        /// Method to read bakes markups.
        /// </summary>
        /// <param name="filePath">Path to file with markups.</param>
        /// <returns>Dictionary of markups "bake name"-"value".</returns>
        public static Dictionary<string, double> ReadMarkups(string filePath)
        {
            Dictionary<string, double> markups = new Dictionary<string, double>();
            string fileText = System.IO.File.ReadAllText(filePath);
            string[] fileParts = fileText.Split("Components price:");
            string[] markupsLines = fileParts[0].Split("\n");
            for (int i = 1; i < markupsLines.Length-1; i++)
            {
                string[] markup = markupsLines[i].Split(":");
                markups.Add(markup[0], Convert.ToDouble(markup[1]));
            }

            return markups;

        }
        /// <summary>
        /// Method to read component calorie dictionary.
        /// </summary>
        /// <param name="filePath">Path to file.</param>
        /// <returns>Dictionary of calorie "component name"-"value".</returns>
        public static Dictionary<string, double> ReadComponentsCalorie(string filePath)
        {
            Dictionary<string, double> componentsCalorie = new Dictionary<string, double>();
            string fileText = System.IO.File.ReadAllText(filePath);
            string[] fileParts = fileText.Split("Components calorie:");
            string[] componentCalorieLines = fileParts[1].Split("\n");
            for (int i = 1; i < componentCalorieLines.Length; i++)
            {
                string[] componentCalorie = componentCalorieLines[i].Split(":");
                componentsCalorie.Add(componentCalorie[0], Convert.ToDouble(componentCalorie[1]));
            }
            return componentsCalorie;
        }
        /// <summary>
        /// Method to read component prices dictionary.
        /// </summary>
        /// <param name="filePath">Path to file.</param>
        /// <returns>Dictionary of prices "component name"-"value".</returns>
        public static Dictionary<string, double> ReadComponentsPrice(string filePath)
        {
            Dictionary<string, double> componentsPrice = new Dictionary<string, double>();
            string fileText = System.IO.File.ReadAllText(filePath);
            string[] fileParts = fileText.Split("Components calorie:");
            string[] filePartsUp = fileParts[0].Split("Components price:");
            string[] componentPriceLines = filePartsUp[1].Split("\n");
            for (int i = 1; i < componentPriceLines.Length-1; i++)
            {
                string[] componentPrice = componentPriceLines[i].Split(":");
                componentsPrice.Add(componentPrice[0], Convert.ToDouble(componentPrice[1]));
            }
            return componentsPrice;
        }
    }
}
