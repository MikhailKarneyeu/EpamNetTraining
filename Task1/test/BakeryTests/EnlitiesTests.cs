using NUnit.Framework;
using Bakery;
using System.Collections.Generic;

namespace BakeryTests
{
    class EnlitiesTests
    {
        [Test]
        public void BakePriceTest()
        {
            // Arrange
            string bakeName = "Bake 1";
            double AssertPrice = 400;
            Dictionary<string, double> componentPrices = new Dictionary<string, double>();
            componentPrices.Add("Component 1", 10);
            componentPrices.Add("Component 2", 20);
            Dictionary<string, double> componentCalorie = new Dictionary<string, double>();
            componentCalorie.Add("Component 1", 20);
            componentCalorie.Add("Component 2", 40);
            Dictionary<string, double> markup = new Dictionary<string, double>();
            markup.Add("Bake 1", 2);
            Dictionary<string, int> composition = new Dictionary<string, int>();
            composition.Add("Component 1", 10);
            composition.Add("Component 2", 5);
            // Act
            Bake bakeToTest = new Bake(bakeName, composition, componentCalorie, componentPrices, markup);
            // Assert
            Assert.IsTrue(bakeToTest.Price == AssertPrice, $"{bakeToTest.Price}!={AssertPrice}");
        }

        [Test]
        public void BakeCalorieTest()
        {
            // Arrange
            string bakeName = "Bake 1";
            double AssertCalorie = 450;
            Dictionary<string, double> componentPrices = new Dictionary<string, double>();
            componentPrices.Add("Component 1", 10);
            componentPrices.Add("Component 2", 20);
            Dictionary<string, double> componentCalorie = new Dictionary<string, double>();
            componentCalorie.Add("Component 1", 20);
            componentCalorie.Add("Component 2", 50);
            Dictionary<string, double> markup = new Dictionary<string, double>();
            markup.Add("Bake 1", 2);
            Dictionary<string, int> composition = new Dictionary<string, int>();
            composition.Add("Component 1", 10);
            composition.Add("Component 2", 5);
            // Act
            Bake bakeToTest = new Bake(bakeName, composition, componentCalorie, componentPrices, markup);
            // Assert
            Assert.IsTrue(bakeToTest.Calorie == AssertCalorie, $"{bakeToTest.Price}!={AssertCalorie}");
        }
    }
}
