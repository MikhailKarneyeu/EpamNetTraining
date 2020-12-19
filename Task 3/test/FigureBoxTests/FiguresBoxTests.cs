using NUnit.Framework;
using FigureBox;
using Figures.Entities;
using System.Collections.Generic;
using System.Linq;

namespace FigureBoxTests
{
    /// <summary>
    /// Class to test figure box methods.
    /// </summary>
    public class FiguresBoxTests
    {
        /// <summary>
        /// AddFigure method test.
        /// </summary>
        [Test]
        public void FiguresBoxAddFigureTest()
        {
            //Arrange
            PlasticFigure plasticFigure = new PlasticFigure("Plastic circle", new CircleFigure("Figure", new double[1] { 1 }));
            PaperFigure paperFigure = new PaperFigure("Paper triangle", new TriangleFigure("Figure", new double[1] { 1 }));
            FilmFigure filmFigure = new FilmFigure("Film rectangle", new RectangleFigure("Figure", new double[2] { 1, 2 }));
            FiguresBox box = new FiguresBox();
            List<FigureDecorator> testList = new List<FigureDecorator>(20) { plasticFigure, paperFigure, filmFigure };
            //Act
            box.AddFigure(plasticFigure);
            box.AddFigure(paperFigure);
            box.AddFigure(filmFigure);
            //Assert
            Assert.IsTrue(box.Figures.SequenceEqual(testList));
        }

        /// <summary>
        /// AddFigure method fail test.
        /// </summary>
        [Test]
        public void FiguresBoxAddFigureFailTest()
        {
            //Arrange
            FiguresBox box = new FiguresBox();
            PlasticFigure plasticFigure = new PlasticFigure("Plastic circle", new CircleFigure("Figure", new double[1] { 1 }));
            box.AddFigure(plasticFigure);
            //Act
            void testAction() => box.AddFigure(plasticFigure);
            //Assert
            var ex = Assert.Throws<FigureContainException>(testAction);
            Assert.That(ex.Message, Is.EqualTo("This figure is in the box already."));
        }

        /// <summary>
        /// GetById method test.
        /// </summary>
        [Test]
        public void FiguresBoxGetByIdTest()
        {
            //Arrange
            PlasticFigure plasticFigure = new PlasticFigure("Plastic circle", new CircleFigure("Figure", new double[1] { 1 }));
            PaperFigure paperFigure = new PaperFigure("Paper triangle", new TriangleFigure("Figure", new double[1] { 1 }));
            FilmFigure filmFigure = new FilmFigure("Film rectangle", new RectangleFigure("Figure", new double[2] { 1, 2 }));
            FiguresBox box = new FiguresBox();
            box.AddFigure(plasticFigure);
            box.AddFigure(paperFigure);
            box.AddFigure(filmFigure);
            //Act
            var figure = box.GetById(2);
            //Assert
            Assert.IsTrue(figure.Equals(filmFigure));
        }

        /// <summary>
        /// ExtractById method test.
        /// </summary>
        [Test]
        public void FiguresBoxExtractByIdTest()
        {
            //Arrange
            PlasticFigure plasticFigure = new PlasticFigure("Plastic circle", new CircleFigure("Figure", new double[1] { 1 }));
            PaperFigure paperFigure = new PaperFigure("Paper triangle", new TriangleFigure("Figure", new double[1] { 1 }));
            FilmFigure filmFigure = new FilmFigure("Film rectangle", new RectangleFigure("Figure", new double[2] { 1, 2 }));
            FiguresBox box = new FiguresBox();
            List<FigureDecorator> testList = new List<FigureDecorator>(20) { plasticFigure, paperFigure};
            box.AddFigure(plasticFigure);
            box.AddFigure(paperFigure);
            box.AddFigure(filmFigure);
            //Act
            var figure = box.ExtractById(2);
            //Assert
            Assert.IsTrue(figure.Equals(filmFigure)&&box.Figures.SequenceEqual(testList));
        }

        /// <summary>
        /// ReplaceById method test.
        /// </summary>
        [Test]
        public void FiguresBoxReplaceByIdTest()
        {
            //Arrange
            PlasticFigure plasticFigure = new PlasticFigure("Plastic circle", new CircleFigure("Figure", new double[1] { 1 }));
            PaperFigure paperFigure = new PaperFigure("Paper triangle", new TriangleFigure("Figure", new double[1] { 1 }));
            FilmFigure filmFigure = new FilmFigure("Film rectangle", new RectangleFigure("Figure", new double[2] { 1, 2 }));
            FiguresBox box = new FiguresBox();
            List<FigureDecorator> testList = new List<FigureDecorator>(20) { plasticFigure, filmFigure };
            box.AddFigure(plasticFigure);
            box.AddFigure(paperFigure);
            //Act
            box.ReplaceById(1, filmFigure);
            var figure = box.GetById(1);
            //Assert
            Assert.IsTrue(figure.Equals(filmFigure) && box.Figures.SequenceEqual(testList));
        }

        /// <summary>
        /// FindEqual method test.
        /// </summary>
        [Test]
        public void FiguresBoxFindEqualTest()
        {
            //Arrange
            PlasticFigure plasticFigure = new PlasticFigure("Plastic circle", new CircleFigure("Figure", new double[1] { 1 }));
            PaperFigure paperFigure = new PaperFigure("Paper triangle", new TriangleFigure("Figure", new double[1] { 1 }));
            PaperFigure paperFigureToCheck = new PaperFigure("Paper triangle 2", new TriangleFigure("Figure", new double[1] { 1 }));
            FiguresBox box = new FiguresBox();
            box.AddFigure(plasticFigure);
            box.AddFigure(paperFigure);
            //Act
            var figure = box.FindEqual(paperFigureToCheck);
            //Assert
            Assert.IsTrue(figure.Equals(paperFigure));
        }

        /// <summary>
        /// FigureCount method test.
        /// </summary>
        [Test]
        public void FiguresBoxFigureCountTest()
        {
            //Arrange
            PlasticFigure plasticFigure = new PlasticFigure("Plastic circle", new CircleFigure("Figure", new double[1] { 1 }));
            PaperFigure paperFigure = new PaperFigure("Paper triangle", new TriangleFigure("Figure", new double[1] { 1 }));
            FiguresBox box = new FiguresBox();
            box.AddFigure(plasticFigure);
            box.AddFigure(paperFigure);
            int testFigureCount = 2;
            //Act
            var figureCount = box.FigureCount();
            //Assert
            Assert.IsTrue(testFigureCount == figureCount);
        }

        /// <summary>
        /// GetSquareSumm method test.
        /// </summary>
        [Test]
        public void FiguresBoxGetSquareSummTest()
        {
            //Arrange
            PlasticFigure plasticFigure = new PlasticFigure("Plastic circle", new CircleFigure("Figure", new double[1] { 1 }));
            PaperFigure paperFigure = new PaperFigure("Paper triangle", new TriangleFigure("Figure", new double[1] { 1 }));
            FilmFigure filmFigure = new FilmFigure("Film rectangle", new RectangleFigure("Figure", new double[2] { 1, 2 }));
            FiguresBox box = new FiguresBox();
            box.AddFigure(plasticFigure);
            box.AddFigure(paperFigure);
            box.AddFigure(filmFigure);
            double testSquareSumm = plasticFigure.Square() + paperFigure.Square() + filmFigure.Square();
            //Act
            double sqaureSumm = box.GetSquareSumm();
            //Assert
            Assert.IsTrue(sqaureSumm == testSquareSumm);
        }

        /// <summary>
        /// GetPerimeterSumm method test.
        /// </summary>
        [Test]
        public void FiguresBoxGetPerimeterSummTest()
        {
            //Arrange
            PlasticFigure plasticFigure = new PlasticFigure("Plastic circle", new CircleFigure("Figure", new double[1] { 1 }));
            PaperFigure paperFigure = new PaperFigure("Paper triangle", new TriangleFigure("Figure", new double[1] { 1 }));
            FilmFigure filmFigure = new FilmFigure("Film rectangle", new RectangleFigure("Figure", new double[2] { 1, 2 }));
            FiguresBox box = new FiguresBox();
            box.AddFigure(plasticFigure);
            box.AddFigure(paperFigure);
            box.AddFigure(filmFigure);
            double testPerimeterSumm = plasticFigure.Perimeter() + paperFigure.Perimeter() + filmFigure.Perimeter();
            //Act
            double perimeterSumm = box.GetPerimeterSumm();
            //Assert
            Assert.IsTrue(perimeterSumm == testPerimeterSumm);
        }

        /// <summary>
        /// GetCirckeFigures method test.
        /// </summary>
        [Test]
        public void FiguresBoxGetCircleFiguresTest()
        {
            //Arrange
            PlasticFigure plasticFigure = new PlasticFigure("Plastic circle", new CircleFigure("Figure", new double[1] { 1 }));
            PaperFigure paperFigure = new PaperFigure("Paper circle", new CircleFigure("Figure", new double[1] { 1 }));
            PaperFigure paperFigure2 = new PaperFigure("Paper triangle", new TriangleFigure("Figure", new double[1] { 1 }));
            FilmFigure filmFigure = new FilmFigure("Film rectangle", new RectangleFigure("Figure", new double[2] { 1, 2 }));
            List<FigureDecorator> testList = new List<FigureDecorator>(20) { plasticFigure, paperFigure };
            FiguresBox box = new FiguresBox();
            box.AddFigure(plasticFigure);
            box.AddFigure(paperFigure);
            box.AddFigure(paperFigure2);
            box.AddFigure(filmFigure);
            //Act
            var circleList = box.GetCircleFigures();
            //Assert
            Assert.IsTrue(circleList.SequenceEqual(testList));
        }

        /// <summary>
        /// GetFilmFigures method test.
        /// </summary>
        [Test]
        public void FiguresBoxGetFilmFiguresTest()
        {
            //Arrange
            PlasticFigure plasticFigure = new PlasticFigure("Plastic circle", new CircleFigure("Figure", new double[1] { 1 }));
            FilmFigure filmFigure = new FilmFigure("Film circle", new CircleFigure("Figure", new double[1] { 1 }));
            PaperFigure paperFigure = new PaperFigure("Paper triangle", new TriangleFigure("Figure", new double[1] { 1 }));
            FilmFigure filmFigure2 = new FilmFigure("Film rectangle", new RectangleFigure("Figure", new double[2] { 1, 2 }));
            List<FigureDecorator> testList = new List<FigureDecorator>(20) { filmFigure, filmFigure2 };
            FiguresBox box = new FiguresBox();
            box.AddFigure(plasticFigure);
            box.AddFigure(paperFigure);
            box.AddFigure(filmFigure);
            box.AddFigure(filmFigure2);
            //Act
            var filmList = box.GetFilmFigures();
            //Assert
            Assert.IsTrue(filmList.SequenceEqual(testList));
        }

        /// <summary>
        /// GetPlasticUncolored method test.
        /// </summary>
        [Test]
        public void FiguresBoxGetPlasticUncoloredTest()
        {
            //Arrange
            PlasticFigure plasticFigure = new PlasticFigure("Plastic circle", new CircleFigure("Figure", new double[1] { 1 }));
            FilmFigure filmFigure = new FilmFigure("Film circle", new CircleFigure("Figure", new double[1] { 1 }));
            PaperFigure paperFigure = new PaperFigure("Paper triangle", new TriangleFigure("Figure", new double[1] { 1 }));
            PlasticFigure plasticFigure2 = new PlasticFigure("Plastic rectangle", new RectangleFigure("Figure", new double[2] { 1, 2 }));
            plasticFigure2.Paint(ColorsEnum.Red.ToString());
            List<FigureDecorator> testList = new List<FigureDecorator>(20) { plasticFigure };
            FiguresBox box = new FiguresBox();
            box.AddFigure(plasticFigure);
            box.AddFigure(paperFigure);
            box.AddFigure(filmFigure);
            box.AddFigure(plasticFigure2);
            //Act
            var uncoloredList = box.GetPlasticUncolored();
            //Assert
            Assert.IsTrue(uncoloredList.SequenceEqual(testList));
        }

        /// <summary>
        /// SaveFigures and ReadFigures methods test.
        /// </summary>
        [Test]
        public void FiguresBoxSaveReadFiguresTest()
        {
            //Arrange
            PlasticFigure plasticFigure = new PlasticFigure("Plastic circle", new CircleFigure("Figure", new double[1] { 1 }));
            FilmFigure filmFigure = new FilmFigure("Film circle", new CircleFigure("Figure", new double[1] { 2 }));
            PaperFigure paperFigure = new PaperFigure("Paper triangle", new TriangleFigure("Figure", new double[1] { 3 }));
            PlasticFigure plasticFigure2 = new PlasticFigure("Plastic rectangle", new RectangleFigure("Figure", new double[2] { 4, 4 }));
            paperFigure.Paint(ColorsEnum.Red.ToString());
            List<FigureDecorator> testList = new List<FigureDecorator>(20) { plasticFigure, filmFigure, paperFigure};
            FiguresBox box = new FiguresBox();
            box.AddFigure(plasticFigure);
            box.AddFigure(filmFigure);
            box.AddFigure(paperFigure);
            //Act
            box.SaveFigures(null, "StreamWriterSaveTest.txt");
            box.AddFigure(plasticFigure2);
            box.ReadFigures("StreamWriterSaveTest.txt");
            //Assert
            Assert.IsTrue(box.Figures.SequenceEqual(testList));
        }

        /// <summary>
        /// SaveFigures method with circles test.
        /// </summary>
        [Test]
        public void FiguresBoxSaveCirclesTest()
        {
            //Arrange
            PlasticFigure plasticFigure = new PlasticFigure("Plastic circle", new CircleFigure("Figure", new double[1] { 1 }));
            FilmFigure filmFigure = new FilmFigure("Film circle", new CircleFigure("Figure", new double[1] { 2 }));
            PaperFigure paperFigure = new PaperFigure("Paper triangle", new TriangleFigure("Figure", new double[1] { 3 }));
            paperFigure.Paint(ColorsEnum.Red.ToString());
            List<FigureDecorator> testList = new List<FigureDecorator>(20) { plasticFigure, filmFigure};
            FiguresBox box = new FiguresBox();
            box.AddFigure(plasticFigure);
            box.AddFigure(filmFigure);
            box.AddFigure(paperFigure);
            //Act
            box.SaveFigures("CircleFigure", "StreamWriterSaveTest.txt");
            box.ReadFigures("StreamWriterSaveTest.txt");
            //Assert
            Assert.IsTrue(box.Figures.SequenceEqual(testList));
        }

        /// <summary>
        /// SaveFigures method with triangules test.
        /// </summary>
        [Test]
        public void FiguresBoxTrianglesTest()
        {
            //Arrange
            PlasticFigure plasticFigure = new PlasticFigure("Plastic circle", new CircleFigure("Figure", new double[1] { 1 }));
            FilmFigure filmFigure = new FilmFigure("Film triangle", new TriangleFigure("Figure", new double[1] { 2 }));
            PaperFigure paperFigure = new PaperFigure("Paper triangle", new TriangleFigure("Figure", new double[1] { 3 }));
            paperFigure.Paint(ColorsEnum.Red.ToString());
            List<FigureDecorator> testList = new List<FigureDecorator>(20) { filmFigure, paperFigure };
            FiguresBox box = new FiguresBox();
            box.AddFigure(plasticFigure);
            box.AddFigure(filmFigure);
            box.AddFigure(paperFigure);
            //Act
            box.SaveFigures("TriangleFigure", "StreamWriterSaveTest.txt");
            box.ReadFigures("StreamWriterSaveTest.txt");
            //Assert
            Assert.IsTrue(box.Figures.SequenceEqual(testList));
        }

        /// <summary>
        /// SaveFigures method with rectangles test.
        /// </summary>
        [Test]
        public void FiguresBoxSaveRectanglesTest()
        {
            //Arrange
            PlasticFigure plasticFigure = new PlasticFigure("Plastic rectangle", new RectangleFigure("Figure", new double[2] { 1, 2 }));
            FilmFigure filmFigure = new FilmFigure("Film circle", new CircleFigure("Figure", new double[1] { 2 }));
            PaperFigure paperFigure = new PaperFigure("Paper rectagle", new RectangleFigure("Figure", new double[2] { 3 , 1}));
            paperFigure.Paint(ColorsEnum.Red.ToString());
            List<FigureDecorator> testList = new List<FigureDecorator>(20) { plasticFigure, paperFigure };
            FiguresBox box = new FiguresBox();
            box.AddFigure(plasticFigure);
            box.AddFigure(filmFigure);
            box.AddFigure(paperFigure);
            //Act
            box.SaveFigures("RectangleFigure", "StreamWriterSaveTest.txt");
            box.ReadFigures("StreamWriterSaveTest.txt");
            //Assert
            Assert.IsTrue(box.Figures.SequenceEqual(testList));
        }
    }
}