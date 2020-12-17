using NUnit.Framework;
using Figures.Entities;
using System;

namespace FiguresTests
{
    class FigureTests
    {
        [Test]
        public void CircleSquareTest()
        {
            // Arrange
            double radius = 1;
            double testSquare = Math.PI * Math.Pow(radius, 2);
            CircleFigure circle = new CircleFigure("Circle", new double[1] { radius });
            // Act
            double square = circle.Square();
            // Assert
            Assert.IsTrue(testSquare == square);
        }

        [Test]
        public void CirclePerimeterTest()
        {
            // Arrange
            double radius = 1;
            double testPerimeter = 2 * Math.PI * radius;
            CircleFigure circle = new CircleFigure("Circle", new double[1] { radius });
            // Act
            double square = circle.Perimeter();
            // Assert
            Assert.IsTrue(testPerimeter == square);
        }

        [Test]
        public void RectangleSquareTest()
        {
            // Arrange
            double[] side = new double[2] { 1, 2 };
            double testSquare = side[0] * side[1];
            RectangleFigure rectangle = new RectangleFigure("Rectangle", side);
            // Act
            double square = rectangle.Square();
            // Assert
            Assert.IsTrue(testSquare == square);
        }

        [Test]
        public void RectanglePerimeterTest()
        {
            // Arrange
            double[] side = new double[2] { 1, 2 };
            double testPerimeter = 2 * side[0] + 2 * side[1];
            RectangleFigure rectangle = new RectangleFigure("Rectangle", side);
            // Act
            double perimeter = rectangle.Perimeter();
            // Assert
            Assert.IsTrue(testPerimeter == perimeter);
        }

        [Test]
        public void TriangleSquareTest()
        {
            // Arrange
            double[] side = new double[1] { 1 };
            double testSquare = Math.Pow(side[0] * side[0], 2) * Math.Sqrt(3) / 4;
            TriangleFigure triangle = new TriangleFigure("Triangle", side);
            // Act
            double square = triangle.Square();
            // Assert
            Assert.IsTrue(testSquare == square);
        }

        [Test]
        public void TrianglePerimeterTest()
        {
            // Arrange
            double[] side = new double[1] { 1 };
            double testPerimeter = 3 * side[0];
            TriangleFigure triangle = new TriangleFigure("Triangle", side);
            // Act
            double perimeter = triangle.Perimeter();
            // Assert
            Assert.IsTrue(testPerimeter == perimeter);
        }

        [Test]
        public void CircleSizeCheckWithCircleTest()
        {
            //Arrange
            double[] side = new double[1] { 1 };
            double[] sideToCut = new double[1] { 0.8 };
            //Act
            CircleFigure figure = new CircleFigure("Figure", side);
            CircleFigure figureToCut = new CircleFigure("Figure to cut", sideToCut);
            //Assert
            Assert.IsTrue(figure.SizeCheck(figureToCut));
        }

        [Test]
        public void CircleSizeCheckWithTriangleTest()
        {
            //Arrange
            double[] side = new double[1] { 1 };
            double[] sideToCut = new double[1] { 1 };
            //Act
            CircleFigure figure = new CircleFigure("Figure", side);
            TriangleFigure figureToCut = new TriangleFigure("Figure to cut", sideToCut);
            //Assert
            Assert.IsTrue(figure.SizeCheck(figureToCut));
        }

        [Test]
        public void CircleSizeCheckWithRectangleTest()
        {
            //Arrange
            double[] side = new double[1] { 1 };
            double[] sideToCut = new double[2] { 0.8 , 1 };
            //Act
            CircleFigure figure = new CircleFigure("Figure", side);
            RectangleFigure figureToCut = new RectangleFigure("Figure to cut", sideToCut);
            //Assert
            Assert.IsTrue(figure.SizeCheck(figureToCut));
        }

        [Test]
        public void RectangleSizeCheckWithCircleTest()
        {
            //Arrange
            double[] side = new double[2] { 1, 2 };
            double[] sideToCut = new double[1] { 0.45 };
            //Act
            RectangleFigure figure = new RectangleFigure("Figure", side);
            CircleFigure figureToCut = new CircleFigure("Figure to cut", sideToCut);
            //Assert
            Assert.IsTrue(figure.SizeCheck(figureToCut));
        }

        [Test]
        public void RectangleSizeCheckWithTriangleTest()
        {
            //Arrange
            double[] side = new double[2] { 1, 2 };
            double[] sideToCut = new double[1] { 1 };
            //Act
            RectangleFigure figure = new RectangleFigure("Figure", side);
            TriangleFigure figureToCut = new TriangleFigure("Figure to cut", sideToCut);
            //Assert
            Assert.IsTrue(figure.SizeCheck(figureToCut));
        }

        [Test]
        public void RectangleSizeCheckWithRectangleTest()
        {
            //Arrange
            double[] side = new double[2] { 1, 2 };
            double[] sideToCut = new double[2] { 0.8, 2 };
            //Act
            RectangleFigure figure = new RectangleFigure("Figure", side);
            RectangleFigure figureToCut = new RectangleFigure("Figure to cut", sideToCut);
            //Assert
            Assert.IsTrue(figure.SizeCheck(figureToCut));
        }

        [Test]
        public void TriangleSizeCheckWithCircleTest()
        {
            //Arrange
            double[] side = new double[1] { 1 };
            double[] sideToCut = new double[1] { 0.2 };
            //Act
            TriangleFigure figure = new TriangleFigure("Figure", side);
            CircleFigure figureToCut = new CircleFigure("Figure to cut", sideToCut);
            //Assert
            Assert.IsTrue(figure.SizeCheck(figureToCut));
        }

        [Test]
        public void TriangleSizeCheckWithTriangleTest()
        {
            //Arrange
            double[] side = new double[1] { 1 };
            double[] sideToCut = new double[1] { 0.8 };
            //Act
            TriangleFigure figure = new TriangleFigure("Figure", side);
            TriangleFigure figureToCut = new TriangleFigure("Figure to cut", sideToCut);
            //Assert
            Assert.IsTrue(figure.SizeCheck(figureToCut));
        }

        [Test]
        public void TriangleSizeCheckWithRectangleTest()
        {
            //Arrange
            double[] side = new double[1] { 1 };
            double[] sideToCut = new double[2] { 0.5, 0.3 };
            //Act
            TriangleFigure figure = new TriangleFigure("Figure", side);
            RectangleFigure figureToCut = new RectangleFigure("Figure to cut", sideToCut);
            //Assert
            Assert.IsTrue(figure.SizeCheck(figureToCut));
        }
    }
}