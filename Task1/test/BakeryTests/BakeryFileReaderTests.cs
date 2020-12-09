using Bakery;
using Bakery.Entities;
using Bakery.Services;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace BakeryTests
{
    /// <summary>
    /// Class to test BakeryFileReader class.
    /// </summary>
    public class BakeryFileReaderTests
    {
        /// <summary>
        /// Test of components calorie read method.
        /// </summary>
        [Test]
        public void ReadComponentsCalorieTest()
        {
            // Arrange
            string filePath = @"..\..\..\TestFiles\BakeryInfo.txt";
            Dictionary<string, double> assertComponentsCalorie = new Dictionary<string, double>();
            assertComponentsCalorie.Add("Component 1", 5);
            assertComponentsCalorie.Add("Component 2", 2);
            assertComponentsCalorie.Add("Component 3", 8);
            assertComponentsCalorie.Add("Component 4", 10);
            assertComponentsCalorie.Add("Component 5", 3);
            // Act
            Dictionary<string, double> componentsCalorie = BakeryFileReader.ReadComponentsCalorie(filePath);
            // Assert
            Assert.IsFalse(componentsCalorie.Any(entry => assertComponentsCalorie[entry.Key]!=entry.Value));
        }
        /// <summary>
        /// Test of component prices read method.
        /// </summary>
        [Test]
        public void ReadComponentsPriceTest()
        {
            // Arrange
            string filePath = @"..\..\..\TestFiles\BakeryInfo.txt";
            Dictionary<string, double> assertComponentsPrice = new Dictionary<string, double>();
            assertComponentsPrice.Add("Component 1", 12);
            assertComponentsPrice.Add("Component 2", 20);
            assertComponentsPrice.Add("Component 3", 9);
            assertComponentsPrice.Add("Component 4", 20);
            assertComponentsPrice.Add("Component 5", 100);
            // Act
            Dictionary<string, double> componentsPrice = BakeryFileReader.ReadComponentsPrice(filePath);
            // Assert
            Assert.IsFalse(componentsPrice.Any(entry => assertComponentsPrice[entry.Key] != entry.Value), $"{componentsPrice["Component 5"]} {assertComponentsPrice["Component 5"]}");
        }
        /// <summary>
        /// Test of bake markups read method.
        /// </summary>
        [Test]
        public void ReadMarkupsTest()
        {
            // Arrange
            string filePath = @"..\..\..\TestFiles\BakeryInfo.txt";
            Dictionary<string, double> assertMarkups = new Dictionary<string, double>();
            assertMarkups.Add("Bake 1", 0.12);
            assertMarkups.Add("Bake 2", 0.3);
            assertMarkups.Add("Bake 3", 1.2);
            assertMarkups.Add("Bake 4", 1.4);
            assertMarkups.Add("Bake 5", 0.3);
            // Act
            Dictionary<string, double> markups = BakeryFileReader.ReadMarkups(filePath);
            // Assert
            Assert.IsFalse(markups.Any(entry => assertMarkups[entry.Key] != entry.Value));
        }
        /// <summary>
        /// Test of bakes read method.
        /// </summary>
        [Test]
        public void ReadBakesTest()
        {
            // Arrange
            string filePath = @"..\..\..\TestFiles\ReadBakesTest.txt";
            Dictionary<string, double> componentsCalorie = new Dictionary<string, double>();
            componentsCalorie.Add("Component 1", 5);
            componentsCalorie.Add("Component 2", 2);
            componentsCalorie.Add("Component 3", 8);
            Dictionary<string, double> markups = new Dictionary<string, double>();
            markups.Add("Bake 1", 1);
            markups.Add("Bake 2", 2);
            Dictionary<string, double> componentsPrice = new Dictionary<string, double>();
            componentsPrice.Add("Component 1", 12);
            componentsPrice.Add("Component 2", 20);
            componentsPrice.Add("Component 3", 9);
            Dictionary<string, int>[] compositions = new Dictionary<string, int>[2];
            compositions[0] = new Dictionary<string, int>();
            compositions[0].Add("Component 1", 10);
            compositions[0].Add("Component 2", 3);
            compositions[1] = new Dictionary<string, int>();
            compositions[1].Add("Component 2", 20);
            compositions[1].Add("Component 3", 5);
            Bake[] assertBakes = new Bake[2];
            assertBakes[0] = new Bake("Bake 1", compositions[0], componentsCalorie, componentsPrice, markups);
            assertBakes[1] = new Bake("Bake 2", compositions[1], componentsCalorie, componentsPrice, markups);
            // Act
            Bake[] bakes = BakeryFileReader.ReadBakes(filePath, componentsCalorie, markups, componentsPrice);
            // Assert
            Assert.IsTrue(bakes.SequenceEqual(assertBakes));
        }
    }
}