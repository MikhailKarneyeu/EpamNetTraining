using Goods.Entities;
using NUnit.Framework;
using System;

namespace GoodsTests.Tests
{
    /// <summary>
    /// Class to test good and sellable good classes.
    /// </summary>
    public class GoodTests
    {
        /// <summary>
        /// Test to get good price for one.
        /// </summary>
        [Test]
        public void GoodPriceForOneTest()
        {
            // Arrange
            double priceForOne = 10;
            Good good = new Good("Good name", 10, 10);
            // Act
            double oneGoodPrice = good.PriceForOne();
            // Assert
            Assert.IsTrue(priceForOne == oneGoodPrice);
        }
        /// <summary>
        /// Test to get good full price
        /// </summary>
        [Test]
        public void GoodPrice()
        {
            // Arrange
            double price = 100;
            Good good = new Good("Good name", 10, 10);
            // Act
            double goodPrice = good.Price();
            // Assert
            Assert.IsTrue(price == goodPrice);
        }
        /// <summary>
        /// Converting good to double test.
        /// </summary>
        [Test]
        public void GoodConvertToDouble()
        {
            // Arrange
            double price = 100.5;
            Good good = new Good("Good name", 10.05, 10);
            // Act
            double goodPriceInDouble = good.ToDouble();
            // Assert
            Assert.IsTrue(price == goodPriceInDouble);
        }
        /// <summary>
        /// Converting good to integer test.
        /// </summary>
        [Test]
        public void GoodConvertToInt()
        {
            // Arrange
            double price = 10050;
            Good good = new Good("Good name", 10.05, 10);
            // Act
            double goodPriceInInt = good.ToInt();
            // Assert
            Assert.IsTrue(price == goodPriceInInt);
        }
        /// <summary>
        /// Summ of 2 goods test.
        /// </summary>
        [Test]
        public void GoodsSumTest()
        {
            // Arrange
            Good goodA = new Good("Good name", 10, 1);
            Good goodB = new Good("Good name", 20, 4);
            Good resultGood = new Good("Good name", 18, 5);
            // Act
            Good good = goodA + goodB;
            // Assert
            Assert.IsTrue(good.Equals(resultGood));
        }
        /// <summary>
        /// Good integer subtraction test.
        /// </summary>
        [Test]
        public void GoodIntSubtractionOperationTest()
        {
            // Arrange
            Good good = new Good("Good name", 10, 10);
            int countToSubtract = 5;
            Good resultGood = new Good("Good name", 10, 5);
            // Act
            good = good - countToSubtract;
            // Assert
            Assert.IsTrue(good.Equals(resultGood));
        }
        /// <summary>
        /// Test to get sellable good price for one.
        /// </summary>
        [Test]
        public void SellableGoodPriceForOneTest()
        {
            // Arrange
            double priceForOne = 20;
            SellableGood good = new SellableGood("SellableGood name", 10, 10, 2);
            // Act
            double oneGoodPrice = good.PriceForOne();
            // Assert
            Assert.IsTrue(priceForOne == oneGoodPrice);
        }
        /// <summary>
        /// Test to get full sellable good price.
        /// </summary>
        [Test]
        public void SellableGoodPrice()
        {
            // Arrange
            double price = 200;
            SellableGood good = new SellableGood("SellableGood name", 10, 10, 2);
            // Act
            double goodPrice = good.Price();
            // Assert
            Assert.IsTrue(price == goodPrice);
        }
        /// <summary>
        /// Converting sellable good to double test.
        /// </summary>
        [Test]
        public void SellableGoodConvertToDouble()
        {
            // Arrange
            double price = 301.2;
            SellableGood good = new SellableGood("SellableGood name", 10.04, 10, 3);
            // Act
            double goodPriceInDouble = good.ToDouble();
            // Assert
            Assert.IsTrue(price == goodPriceInDouble);
        }
        /// <summary>
        /// Converting sellable good to integer test.
        /// </summary>
        [Test]
        public void SellableGoodConvertToInt()
        {
            // Arrange
            double price = 20080;
            SellableGood good = new SellableGood("SellableGood name", 10.04, 10, 2);
            // Act
            double goodPriceInInt = good.ToInt();
            // Assert
            Assert.IsTrue(price == goodPriceInInt);
        }
        /// <summary>
        /// Summ of 2 sellable goods test.
        /// </summary>
        [Test]
        public void SellableGoodsSumTest()
        {
            // Arrange
            SellableGood goodA = new SellableGood("SellableGood name", 10, 1, 1);
            SellableGood goodB = new SellableGood("SellableGood name", 20, 4, 2);
            SellableGood resultGood = new SellableGood("SellableGood name", 18, 5, 1.8);
            // Act
            SellableGood good = goodA + goodB;
            // Assert
            Assert.IsTrue(good.Equals(resultGood));
        }
        /// <summary>
        /// Exeprtion generation in goods summ test.
        /// </summary>
        [Test]
        public void GoodsSumFailTest()
        {
            // Arrange
            Good good;
            Good goodA = new Good("Good name", 10, 1);
            Good goodB = new Good("Good name 2", 20, 4);
            InvalidGoodNameExeption ex = null;
            // Act
            try
            {
                good = goodA + goodB;
            }
            catch (InvalidGoodNameExeption e)
            {
                ex = e;
            }
            // Assert
            Assert.That(ex.Message, Is.EqualTo($"Good 1 name:{goodA.Name}. Good 2 name:{goodB.Name}."));
        }
        /// <summary>
        /// Exeprtion generation in sellable goods summ test.
        /// </summary>
        [Test]
        public void SellableGoodsSumFailTest()
        {
            // Arrange
            Good good;
            SellableGood goodA = new SellableGood("SellableGood name", 10, 1, 1);
            SellableGood goodB = new SellableGood("SellableGood name 2", 20, 4, 2);
            InvalidGoodNameExeption ex = null;
            // Act
            try
            {
                good = goodA + goodB;
            }
            catch(InvalidGoodNameExeption e)
            {
                ex = e;
            }
            // Assert
            Assert.That(ex.Message, Is.EqualTo($"Good 1 name:{goodA.Name}. Good 2 name:{goodB.Name}."));
        }
        /// <summary>
        /// Good to sellable good convertion test.
        /// </summary>
        [Test]
        public void GoodConvertToSellableTest()
        {
            // Arrange
            Good good = new Good("Good name", 10, 1);
            SellableGood resultSellableGood = new SellableGood("Good name", 10, 1, 1);
            // Act
            SellableGood sellableGood =SellableGood.ToSellableGood(good);
            // Assert
            Assert.IsTrue(resultSellableGood.Equals(sellableGood));
        }
        /// <summary>
        /// Sellable good to good convertion test.
        /// </summary>
        [Test]
        public void SellableGoodConvertToGoodTest()
        {
            // Arrange
            SellableGood good = new SellableGood("Good name", 10, 1, 1);
            Good resultGood = new Good("Good name", 10, 1);
            // Act
            Good convertedGood = (Good)good;
            // Assert
            Assert.IsTrue(resultGood.Equals(convertedGood));
        }
    }
}