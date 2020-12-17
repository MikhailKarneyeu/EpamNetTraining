using NUnit.Framework;
using Figures.Entities;

namespace FiguresTests
{
    class FigureDecoratorTests
    {
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
