using Bakery;
using BakeryApplication;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryTests
{
    class ProgramTests
    {
        [Test]
        public void CalorieSortTest()
        {
            // Arrange
            Dictionary<string, double> componentsPrice = new Dictionary<string, double>();
            componentsPrice.Add("Component 1", 12);
            componentsPrice.Add("Component 2", 20);
            componentsPrice.Add("Component 3", 9);
            componentsPrice.Add("Component 4", 20);
            componentsPrice.Add("Component 5", 100);
            Dictionary<string, double> componentsCalorie = new Dictionary<string, double>();
            componentsCalorie.Add("Component 1", 5);
            componentsCalorie.Add("Component 2", 2);
            componentsCalorie.Add("Component 3", 8);
            componentsCalorie.Add("Component 4", 10);
            componentsCalorie.Add("Component 5", 3);
            Dictionary<string, double> markups = new Dictionary<string, double>();
            markups.Add("Bake 1", 0.12);
            markups.Add("Bake 2", 0.3);
            markups.Add("Bake 3", 1.2);
            markups.Add("Bake 4", 1.4);
            markups.Add("Bake 5", 0.3);
            Dictionary<string, int>[] compositions = new Dictionary<string, int>[5];
            compositions[0] = new Dictionary<string, int>();
            compositions[0].Add("Component 1", 12);
            compositions[0].Add("Component 3", 300);
            compositions[0].Add("Component 4", 20);
            compositions[1] = new Dictionary<string, int>();
            compositions[1].Add("Component 2", 200);
            compositions[1].Add("Component 3", 20);
            compositions[2] = new Dictionary<string, int>();
            compositions[2].Add("Component 3", 100);
            compositions[2].Add("Component 5", 30);
            compositions[3] = new Dictionary<string, int>();
            compositions[3].Add("Component 3", 400);
            compositions[3].Add("Component 4", 10);
            compositions[3].Add("Component 5", 50);
            compositions[4] = new Dictionary<string, int>();
            compositions[4].Add("Component 2", 200);
            compositions[4].Add("Component 3", 20);
            Bake[] bakes = new Bake[5];
            Bake[] assertBakes = new Bake[5];
            assertBakes[3] = bakes[0] = new Bake("Bake 1",compositions[0], componentsCalorie, componentsPrice, markups);
            assertBakes[0] = bakes[1] = new Bake("Bake 2", compositions[1], componentsCalorie, componentsPrice, markups);
            assertBakes[2] = bakes[2] = new Bake("Bake 3", compositions[2], componentsCalorie, componentsPrice, markups);
            assertBakes[4] = bakes[3] = new Bake("Bake 4", compositions[3], componentsCalorie, componentsPrice, markups);
            assertBakes[1] = bakes[4] = new Bake("Bake 5", compositions[4], componentsCalorie, componentsPrice, markups);
            // Act
            Bake[] testBakes = BakeryConsoleApp.CalorieSort(bakes);
            // Assert
            Assert.IsTrue(testBakes.SequenceEqual(assertBakes));
        }
        [Test]
        public void PriceSortTest()
        {
            // Arrange
            Dictionary<string, double> componentsPrice = new Dictionary<string, double>();
            componentsPrice.Add("Component 1", 12);
            componentsPrice.Add("Component 2", 20);
            componentsPrice.Add("Component 3", 9);
            componentsPrice.Add("Component 4", 20);
            componentsPrice.Add("Component 5", 100);
            Dictionary<string, double> componentsCalorie = new Dictionary<string, double>();
            componentsCalorie.Add("Component 1", 5);
            componentsCalorie.Add("Component 2", 2);
            componentsCalorie.Add("Component 3", 8);
            componentsCalorie.Add("Component 4", 10);
            componentsCalorie.Add("Component 5", 3);
            Dictionary<string, double> markups = new Dictionary<string, double>();
            markups.Add("Bake 1", 0.12);
            markups.Add("Bake 2", 0.3);
            markups.Add("Bake 3", 1.2);
            markups.Add("Bake 4", 1.4);
            markups.Add("Bake 5", 0.3);
            Dictionary<string, int>[] compositions = new Dictionary<string, int>[5];
            compositions[0] = new Dictionary<string, int>();
            compositions[0].Add("Component 1", 12);
            compositions[0].Add("Component 3", 300);
            compositions[0].Add("Component 4", 20);
            compositions[1] = new Dictionary<string, int>();
            compositions[1].Add("Component 2", 200);
            compositions[1].Add("Component 3", 20);
            compositions[2] = new Dictionary<string, int>();
            compositions[2].Add("Component 3", 100);
            compositions[2].Add("Component 5", 30);
            compositions[3] = new Dictionary<string, int>();
            compositions[3].Add("Component 3", 400);
            compositions[3].Add("Component 4", 10);
            compositions[3].Add("Component 5", 50);
            compositions[4] = new Dictionary<string, int>();
            compositions[4].Add("Component 2", 200);
            compositions[4].Add("Component 3", 20);
            Bake[] bakes = new Bake[5];
            Bake[] assertBakes = new Bake[5];
            assertBakes[0] = bakes[0] = new Bake("Bake 1", compositions[0], componentsCalorie, componentsPrice, markups);
            assertBakes[1] = bakes[1] = new Bake("Bake 2", compositions[1], componentsCalorie, componentsPrice, markups);
            assertBakes[3] = bakes[2] = new Bake("Bake 3", compositions[2], componentsCalorie, componentsPrice, markups);
            assertBakes[4] = bakes[3] = new Bake("Bake 4", compositions[3], componentsCalorie, componentsPrice, markups);
            assertBakes[2] = bakes[4] = new Bake("Bake 5", compositions[4], componentsCalorie, componentsPrice, markups);
            // Act
            Bake[] testBakes = BakeryConsoleApp.PriceSort(bakes);
            // Assert
            Assert.IsTrue(testBakes.SequenceEqual(assertBakes));
        }
        [Test]
        public void FindPriceCalorieEqualBakesTest()
        {
            // Arrange
            Dictionary<string, double> componentsPrice = new Dictionary<string, double>();
            componentsPrice.Add("Component 1", 12);
            componentsPrice.Add("Component 2", 20);
            componentsPrice.Add("Component 3", 9);
            componentsPrice.Add("Component 4", 20);
            componentsPrice.Add("Component 5", 100);
            Dictionary<string, double> componentsCalorie = new Dictionary<string, double>();
            componentsCalorie.Add("Component 1", 5);
            componentsCalorie.Add("Component 2", 2);
            componentsCalorie.Add("Component 3", 8);
            componentsCalorie.Add("Component 4", 10);
            componentsCalorie.Add("Component 5", 3);
            Dictionary<string, double> markups = new Dictionary<string, double>();
            markups.Add("Bake 1", 0.12);
            markups.Add("Bake 2", 0.3);
            markups.Add("Bake 3", 1.2);
            markups.Add("Bake 4", 1.4);
            markups.Add("Bake 5", 0.3);
            Dictionary<string, int>[] compositions = new Dictionary<string, int>[5];
            compositions[0] = new Dictionary<string, int>();
            compositions[0].Add("Component 1", 12);
            compositions[0].Add("Component 3", 300);
            compositions[0].Add("Component 4", 20);
            compositions[1] = new Dictionary<string, int>();
            compositions[1].Add("Component 2", 200);
            compositions[1].Add("Component 3", 20);
            compositions[2] = new Dictionary<string, int>();
            compositions[2].Add("Component 3", 100);
            compositions[2].Add("Component 5", 30);
            compositions[3] = new Dictionary<string, int>();
            compositions[3].Add("Component 3", 400);
            compositions[3].Add("Component 4", 10);
            compositions[3].Add("Component 5", 50);
            compositions[4] = new Dictionary<string, int>();
            compositions[4].Add("Component 2", 200);
            compositions[4].Add("Component 3", 20);
            Bake[] bakes = new Bake[5];
            Bake[] assertBakes = new Bake[2];
            bakes[0] = new Bake("Bake 1", compositions[0], componentsCalorie, componentsPrice, markups);
            assertBakes[0] = bakes[1] = new Bake("Bake 2", compositions[1], componentsCalorie, componentsPrice, markups);
            bakes[2] = new Bake("Bake 3", compositions[2], componentsCalorie, componentsPrice, markups);
            bakes[3] = new Bake("Bake 4", compositions[3], componentsCalorie, componentsPrice, markups);
            assertBakes[1] = bakes[4] = new Bake("Bake 5", compositions[4], componentsCalorie, componentsPrice, markups);
            // Act
            Bake[] testBakes = BakeryConsoleApp.FindPriceCalorieEqualBakes(bakes, bakes[1]);
            // Assert
            Assert.IsTrue(testBakes.SequenceEqual(assertBakes));
        }
        [Test]
        public void FindComponentOverrunBakesTest()
        {
            // Arrange
            Dictionary<string, double> componentsPrice = new Dictionary<string, double>();
            componentsPrice.Add("Component 1", 12);
            componentsPrice.Add("Component 2", 20);
            componentsPrice.Add("Component 3", 9);
            componentsPrice.Add("Component 4", 20);
            componentsPrice.Add("Component 5", 100);
            Dictionary<string, double> componentsCalorie = new Dictionary<string, double>();
            componentsCalorie.Add("Component 1", 5);
            componentsCalorie.Add("Component 2", 2);
            componentsCalorie.Add("Component 3", 8);
            componentsCalorie.Add("Component 4", 10);
            componentsCalorie.Add("Component 5", 3);
            Dictionary<string, double> markups = new Dictionary<string, double>();
            markups.Add("Bake 1", 0.12);
            markups.Add("Bake 2", 0.3);
            markups.Add("Bake 3", 1.2);
            markups.Add("Bake 4", 1.4);
            markups.Add("Bake 5", 0.3);
            Dictionary<string, int>[] compositions = new Dictionary<string, int>[5];
            compositions[0] = new Dictionary<string, int>();
            compositions[0].Add("Component 1", 12);
            compositions[0].Add("Component 3", 300);
            compositions[0].Add("Component 4", 20);
            compositions[1] = new Dictionary<string, int>();
            compositions[1].Add("Component 2", 200);
            compositions[1].Add("Component 3", 20);
            compositions[2] = new Dictionary<string, int>();
            compositions[2].Add("Component 3", 100);
            compositions[2].Add("Component 5", 30);
            compositions[3] = new Dictionary<string, int>();
            compositions[3].Add("Component 3", 400);
            compositions[3].Add("Component 4", 10);
            compositions[3].Add("Component 5", 50);
            compositions[4] = new Dictionary<string, int>();
            compositions[4].Add("Component 2", 200);
            compositions[4].Add("Component 3", 20);
            Bake[] bakes = new Bake[5];
            Bake[] assertBakes = new Bake[2];
            string componentToCheck = "Component 3";
            int componentAmount = 250;
            assertBakes[0] = bakes[0] = new Bake("Bake 1", compositions[0], componentsCalorie, componentsPrice, markups);
            bakes[1] = new Bake("Bake 2", compositions[1], componentsCalorie, componentsPrice, markups);
            bakes[2] = new Bake("Bake 3", compositions[2], componentsCalorie, componentsPrice, markups);
            assertBakes[1] = bakes[3] = new Bake("Bake 4", compositions[3], componentsCalorie, componentsPrice, markups);
            bakes[4] = new Bake("Bake 5", compositions[4], componentsCalorie, componentsPrice, markups);
            // Act
            Bake[] testBakes = BakeryConsoleApp.FindComponentOverrunBakes(bakes, componentToCheck, componentAmount);
            // Assert
            Assert.IsTrue(testBakes.SequenceEqual(assertBakes));
        }
        [Test]
        public void FindComponentCountOverrunBakesTest()
        {
            // Arrange
            Dictionary<string, double> componentsPrice = new Dictionary<string, double>();
            componentsPrice.Add("Component 1", 12);
            componentsPrice.Add("Component 2", 20);
            componentsPrice.Add("Component 3", 9);
            componentsPrice.Add("Component 4", 20);
            componentsPrice.Add("Component 5", 100);
            Dictionary<string, double> componentsCalorie = new Dictionary<string, double>();
            componentsCalorie.Add("Component 1", 5);
            componentsCalorie.Add("Component 2", 2);
            componentsCalorie.Add("Component 3", 8);
            componentsCalorie.Add("Component 4", 10);
            componentsCalorie.Add("Component 5", 3);
            Dictionary<string, double> markups = new Dictionary<string, double>();
            markups.Add("Bake 1", 0.12);
            markups.Add("Bake 2", 0.3);
            markups.Add("Bake 3", 1.2);
            markups.Add("Bake 4", 1.4);
            markups.Add("Bake 5", 0.3);
            Dictionary<string, int>[] compositions = new Dictionary<string, int>[5];
            compositions[0] = new Dictionary<string, int>();
            compositions[0].Add("Component 1", 12);
            compositions[0].Add("Component 3", 300);
            compositions[0].Add("Component 4", 20);
            compositions[1] = new Dictionary<string, int>();
            compositions[1].Add("Component 2", 200);
            compositions[1].Add("Component 3", 20);
            compositions[2] = new Dictionary<string, int>();
            compositions[2].Add("Component 3", 100);
            compositions[2].Add("Component 5", 30);
            compositions[3] = new Dictionary<string, int>();
            compositions[3].Add("Component 3", 400);
            compositions[3].Add("Component 4", 10);
            compositions[3].Add("Component 5", 50);
            compositions[4] = new Dictionary<string, int>();
            compositions[4].Add("Component 2", 200);
            compositions[4].Add("Component 3", 20);
            Bake[] bakes = new Bake[5];
            Bake[] assertBakes = new Bake[2];
            int componentCount = 2;
            assertBakes[0] = bakes[0] = new Bake("Bake 1", compositions[0], componentsCalorie, componentsPrice, markups);
            bakes[1] = new Bake("Bake 2", compositions[1], componentsCalorie, componentsPrice, markups);
            bakes[2] = new Bake("Bake 3", compositions[2], componentsCalorie, componentsPrice, markups);
            assertBakes[1] = bakes[3] = new Bake("Bake 4", compositions[3], componentsCalorie, componentsPrice, markups);
            bakes[4] = new Bake("Bake 5", compositions[4], componentsCalorie, componentsPrice, markups);
            // Act
            Bake[] testBakes = BakeryConsoleApp.FindComponentCountOverrunBakes(bakes, componentCount);
            // Assert
            Assert.IsTrue(testBakes.SequenceEqual(assertBakes));
        }
    }
}
