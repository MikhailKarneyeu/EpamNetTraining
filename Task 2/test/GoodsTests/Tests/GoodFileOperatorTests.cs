using Goods;
using Goods.Entities;
using Goods.Services;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace GoodsTests.Tests
{
    class GoodFileOperatorTests
    {
        [Test]
        public void ReadAllTest()
        {
            // Arrange
            string filePath = @"..\..\..\TestFiles\TestGoods.txt";
            List<Good> resultGoods = new List<Good>();
            resultGoods.Add(new SellableGood("Good name 1", 10, 5, 2));
            resultGoods.Add(new SellableGood("Good name 2", 12, 6, 1.2));
            resultGoods.Add(new Good("Good name 3", 15, 2));
            resultGoods.Add(new SellableGood("Good name 4", 5, 5, 1));
            // Act
            List<Good> goods = GoodFileOperator.ReadAll(filePath);
            // Assert
            Assert.IsTrue(goods.SequenceEqual(resultGoods));
        }
        [Test]
        public void WriteAllTest()
        {
            // Arrange
            string filePath = @"..\..\..\TestFiles\TestGoods.txt";
            List<Good> goods = new List<Good>();
            goods.Add(new SellableGood("Good name 1", 10, 5, 2));
            goods.Add(new SellableGood("Good name 2", 12, 6, 1.2));
            goods.Add(new Good("Good name 3", 15, 2));
            goods.Add(new SellableGood("Good name 4", 5, 5, 1));
            // Act
            GoodFileOperator.WriteAll(filePath, goods);
            // Assert
            List<Good> resultGoods = GoodFileOperator.ReadAll(filePath);
            Assert.IsTrue(goods.SequenceEqual(resultGoods));
        }
    }
}
