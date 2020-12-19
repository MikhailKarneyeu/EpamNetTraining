using NUnit.Framework;
using Figures.Entities;

namespace FiguresTests
{
    /// <summary>
    /// Class to test decorator entities of Figures class.
    /// </summary>
    public  class FigureDecoratorTests
    {
        /// <summary>
        /// Paint method of FilmFigure test.
        /// </summary>
        [Test]
        public void FilmFigurePaintTest()
        {
            //Arrange
            FilmFigure figure = new FilmFigure("Film figure", new CircleFigure("Figure", new double[1] { 1 }));
            //Act
            void testAction() => figure.Paint(ColorsEnum.Red.ToString());
            //Assert
            var ex = Assert.Throws<FigurePaintException>(testAction);
            Assert.That(ex.Message, Is.EqualTo("Figure cant be painted."));
        }

        /// <summary>
        /// Paint method of PaperFigure test.
        /// </summary>
        [Test]
        public void PaperFigurePaintTest()
        {
            //Arrange
            PaperFigure figure = new PaperFigure("Paper figure", new CircleFigure("Figure", new double[1] { 1 }));
            //Act
            figure.Paint(ColorsEnum.Red.ToString());
            //Assert
            Assert.IsTrue(figure.Color == ColorsEnum.Red.ToString());
        }

        /// <summary>
        /// Second paint of PaperFigure test.
        /// </summary>
        [Test]
        public void PaperFigureSecondPaintTest()
        {
            //Arrange
            PaperFigure figure = new PaperFigure("Paper figure", new CircleFigure("Figure", new double[1] { 1 }));
            //Act
            figure.Paint(ColorsEnum.Red.ToString());
            void testAction() => figure.Paint(ColorsEnum.Blue.ToString());
            //Assert
            var ex = Assert.Throws<FigurePaintException>(testAction);
            Assert.That(ex.Message, Is.EqualTo("Figure is painted."));
        }

        /// <summary>
        /// Paint method of PlasticFigure test.
        /// </summary>
        [Test]
        public void PlasticFigurePaintTest()
        {
            //Arrange
            PlasticFigure figure = new PlasticFigure("Plastic figure", new CircleFigure("Figure", new double[1] { 1 }));
            //Act
            figure.Paint(ColorsEnum.Red.ToString());
            //Assert
            Assert.IsTrue(figure.Color == ColorsEnum.Red.ToString());
        }

        /// <summary>
        /// Cut figure from PaperFigure costructor test.
        /// </summary>
        [Test]
        public void PaperFigureConstructorCutTest()
        {
            //Arrange
            PaperFigure originalFigure = new PaperFigure("Paper figure", new CircleFigure("Figure", new double[1] { 1 }));
            CircleFigure figure = new CircleFigure("Figure to cut", new double[1] { 0.8 });
            PaperFigure testFigure = new PaperFigure("Cuted figure", new CircleFigure("Figure", new double[1] { 0.8 }));
            //Act
            PaperFigure cutedFigure = new PaperFigure("Cuted figure", originalFigure, figure);
            //Assert
            Assert.IsTrue(cutedFigure.Equals(testFigure));
        }

        /// <summary>
        /// Cut figure from PaperFigure costructor fail test.
        /// </summary>
        [Test]
        public void PaperFigureConstructorCutFailTest()
        {
            //Arrange
            PaperFigure originalFigure = new PaperFigure("Paper figure", new CircleFigure("Figure", new double[1] { 1 }));
            CircleFigure figure = new CircleFigure("Figure to cut", new double[1] { 2 });
            //Act
            void testAction() => new PaperFigure("Cuted figure", originalFigure, figure);
            //Assert
            var ex = Assert.Throws<InvalidFigureSizeException>(testAction);
            Assert.That(ex.Message, Is.EqualTo("Original figure is too small."));
        }

        /// <summary>
        /// Cut figure from FilmFigure costructor fail test.
        /// </summary>
        [Test]
        public void FilmFigureConstructorCutFailTest()
        {
            //Arrange
            FilmFigure originalFigure = new FilmFigure("Film figure", new CircleFigure("Figure", new double[1] { 1 }));
            CircleFigure figure = new CircleFigure("Figure to cut", new double[1] { 2 });
            //Act
            void testAction() => new FilmFigure("Cuted figure", originalFigure, figure);
            //Assert
            var ex = Assert.Throws<InvalidFigureSizeException>(testAction);
            Assert.That(ex.Message, Is.EqualTo("Original figure is too small."));
        }

        /// <summary>
        /// Cut figure from PlasticFigure costructor fail test.
        /// </summary>
        [Test]
        public void PlasticFigureConstructorCutFailTest()
        {
            //Arrange
            PlasticFigure originalFigure = new PlasticFigure("Plastic figure", new CircleFigure("Figure", new double[1] { 1 }));
            CircleFigure figure = new CircleFigure("Figure to cut", new double[1] { 2 });
            //Act
            void testAction() => new PlasticFigure("Cuted figure", originalFigure, figure);
            //Assert
            var ex = Assert.Throws<InvalidFigureSizeException>(testAction);
            Assert.That(ex.Message, Is.EqualTo("Original figure is too small."));
        }

    }
}
