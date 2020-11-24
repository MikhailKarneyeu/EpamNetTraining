using NUnit.Framework;
using Figures;
using System;

namespace FiguresUnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CirclePerimeter()
        {
            // Arrange
            Figure circle = new CircleFigure(new double[2] { 2.5, 3.5 }, new double[2] { 1.2, 2.7 });
            double perimeter = 11.3;
            // Act
            double circlePerimeter = Math.Round(circle.Perimeter(), 1);
            // Assert
            Assert.IsTrue( circlePerimeter == perimeter);
        }

        [Test]
        public void CircleSquare()
        {
            // Arrange
            Figure circle = new CircleFigure(new double[2] { 2.5, 3.5 }, new double[2] { 1.2, 2.7 });
            double square = 10.2;
            // Act
            double circleSquare = Math.Round(circle.Square(), 1);
            // Assert
            Assert.IsTrue(circleSquare == square);
        }

        [Test]
        public void RectanglePerimeter()
        {
            // Arrange
            Figure rectangle = new RectangleFigure(new double[4] { 1, 3.5, 3.5, 1}, new double[4] { 1, 1, 3, 3 });
            double perimeter = 9;
            // Act
            double rectanglePerimeter = Math.Round(rectangle.Perimeter(), 1);
            // Assert
            Assert.IsTrue(rectanglePerimeter == perimeter);
        }

        [Test]
        public void RectangleSquare()
        {
            // Arrange
            Figure rectangle = new RectangleFigure(new double[4] { 1, 3.5, 3.5, 1 }, new double[4] { 1, 1, 3, 3 });
            double square = 5;
            // Act
            double rectangleSquare = Math.Round(rectangle.Square(), 1);
            // Assert
            Assert.IsTrue(rectangleSquare == square);
        }

        [Test]
        public void squarePerimeter()
        {
            // Arrange
            Figure square = new SquareFigure(new double[4] { 1, 2.2, 2.2, 1 }, new double[4] { 1, 1, 2.2, 2.2 });
            double perimeter = 4.8;
            // Act
            double squarePerimeter = Math.Round(square.Perimeter(), 1);
            // Assert
            Assert.IsTrue(squarePerimeter == perimeter);
        }

        [Test]
        public void squareSquare()
        {
            // Arrange
            Figure squareFigure = new SquareFigure(new double[4] { 1, 2.2, 2.2, 1}, new double[4] { 1, 1, 2.2, 2.2});
            double square = 1.4;
            // Act
            double squareSquare = Math.Round(squareFigure.Square(), 1);
            // Assert
            Assert.IsTrue(squareSquare == square);
        }

        [Test]
        public void trapezoidPerimeter()
        {
            // Arrange
            Figure trapezoid = new TrapezoidFigure(new double[4] { 1, 3.2, 3, 1 }, new double[4] { 1.2, 1.2, 2.2, 2.2 });
            double perimeter = 6.2;
            // Act
            double trapezoidPerimeter = Math.Round(trapezoid.Perimeter(), 1);
            // Assert
            Assert.IsTrue(trapezoidPerimeter == perimeter, $"{trapezoidPerimeter}!={perimeter}");
        }

        [Test]
        public void trapezoidSquare()
        {
            // Arrange
            Figure trapezoid = new TrapezoidFigure(new double[4] { 1, 3.2, 3, 1 }, new double[4] { 1.2, 1.2, 2.2, 2.2 });
            double square = 2.1;
            // Act
            double trapezoidSquare = Math.Round(trapezoid.Square(), 1);
            // Assert
            Assert.IsTrue(trapezoidSquare == square, $"{trapezoidSquare}!={square}");
        }

        [Test]
        public void figureOperatorAveragePerimeter()
        {
            //Arrange
            double averagePerimeter = 7.8;
            Figure[] figures = new Figure[] 
            {
                new TrapezoidFigure(new double[4] { 1, 3.2, 3, 1 }, new double[4] { 1.2, 1.2, 2.2, 2.2 }),
                new TrapezoidFigure(new double[4] { 1, 3.2, 3, 1 }, new double[4] { 1.2, 1.2, 2.2, 2.2 }),
                new SquareFigure(new double[4] { 1, 2.2, 2.2, 1}, new double[4] { 1, 1, 2.2, 2.2}),
                new SquareFigure(new double[4] { 1, 2.2, 2.2, 1}, new double[4] { 1, 1, 2.2, 2.2}),
                new CircleFigure(new double[2] { 2.5, 3.5 }, new double[2] { 1.2, 2.7 }),
                new CircleFigure(new double[2] { 2.5, 3.5 }, new double[2] { 1.2, 2.7 }),
                new RectangleFigure(new double[4] { 1, 3.5, 3.5, 1 }, new double[4] { 1, 1, 3, 3 }),
                new RectangleFigure(new double[4] { 1, 3.5, 3.5, 1 }, new double[4] { 1, 1, 3, 3 })
            };
            //Act
            double averageTestPerimeter =Math.Round(FigureOperator.AveragePerimeter(figures),1);
            //Assert
            Assert.IsTrue(averageTestPerimeter == averagePerimeter, $"{averageTestPerimeter}!={averagePerimeter}");
        }

        [Test]
        public void figureOperatorSquareSumm()
        {
            //Arrange
            double squareSumm = 37.5;
            Figure[] figures = new Figure[]
            {
                new TrapezoidFigure(new double[4] { 1, 3.2, 3, 1 }, new double[4] { 1.2, 1.2, 2.2, 2.2 }),
                new TrapezoidFigure(new double[4] { 1, 3.2, 3, 1 }, new double[4] { 1.2, 1.2, 2.2, 2.2 }),
                new SquareFigure(new double[4] { 1, 2.2, 2.2, 1}, new double[4] { 1, 1, 2.2, 2.2}),
                new SquareFigure(new double[4] { 1, 2.2, 2.2, 1}, new double[4] { 1, 1, 2.2, 2.2}),
                new CircleFigure(new double[2] { 2.5, 3.5 }, new double[2] { 1.2, 2.7 }),
                new CircleFigure(new double[2] { 2.5, 3.5 }, new double[2] { 1.2, 2.7 }),
                new RectangleFigure(new double[4] { 1, 3.5, 3.5, 1 }, new double[4] { 1, 1, 3, 3 }),
                new RectangleFigure(new double[4] { 1, 3.5, 3.5, 1 }, new double[4] { 1, 1, 3, 3 })
            };
            //Act
            double squareTestSumm = Math.Round(FigureOperator.SquareSumm(figures), 1);
            //Assert
            Assert.IsTrue(squareTestSumm == squareSumm, $"{squareTestSumm}!={squareSumm}");
        }

        [Test]
        public void figureOperatorMaxPerimeterFigureType()
        {
            //Arrange
            string figureType = "CircleFigure";
            Figure[] figures = new Figure[]
            {
                new TrapezoidFigure(new double[4] { 1, 3.2, 3, 1 }, new double[4] { 1.2, 1.2, 2.2, 2.2 }),
                new TrapezoidFigure(new double[4] { 1, 3.2, 3, 1 }, new double[4] { 1.2, 1.2, 2.2, 2.2 }),
                new SquareFigure(new double[4] { 1, 2.2, 2.2, 1}, new double[4] { 1, 1, 2.2, 2.2}),
                new SquareFigure(new double[4] { 1, 2.2, 2.2, 1}, new double[4] { 1, 1, 2.2, 2.2}),
                new CircleFigure(new double[2] { 2.5, 3.5 }, new double[2] { 1.2, 2.7 }),
                new CircleFigure(new double[2] { 2.5, 3.5 }, new double[2] { 1.2, 3.7 }),
                new RectangleFigure(new double[4] { 1, 3.5, 3.5, 1 }, new double[4] { 1, 1, 3, 3 }),
                new RectangleFigure(new double[4] { 1, 3.5, 3.5, 1 }, new double[4] { 1, 1, 3, 3 })
            };
            //Act
            string figureTestType = FigureOperator.MaxPerimeterFigureType(figures);
            //Assert
            Assert.IsTrue(figureTestType == figureType, $"{figureTestType}!={figureType}");
        }
    }
}