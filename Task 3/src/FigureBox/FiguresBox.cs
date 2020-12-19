using Figures.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace FigureBox
{
    /// <summary>
    /// Box for figures class.
    /// </summary>
    public class FiguresBox
    {
        private List<FigureDecorator> figures;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public FiguresBox()
        {
            figures = new List<FigureDecorator>(20);
        }

        /// <summary>
        /// Figure add method.
        /// </summary>
        /// <param name="figure">Figure to add.</param>
        public void AddFigure(FigureDecorator figure)
        {
            if (!figures.Contains(figure))
                figures.Add(figure);
            else
                throw new FigureContainException("This figure is in the box already.");
        }

        /// <summary>
        /// Property to get figures list.
        /// </summary>
        public List<FigureDecorator> Figures
        {
            get
            {
                return figures;
            }
        }

        /// <summary>
        /// Method to get figure by list index.
        /// </summary>
        /// <param name="index">Index in list.</param>
        /// <returns>Figure in index position.</returns>
        public IFigure GetById(int index)
        {
            return figures[index];
        }

        /// <summary>
        /// Method to extract figure from list.
        /// </summary>
        /// <param name="index">Index in list.</param>
        /// <returns>Figure in index position.</returns>
        public IFigure ExtractById(int index)
        {
            IFigure result = figures[index];
            figures.RemoveAt(index);
            return result;
        }

        /// <summary>
        /// Method to replace figure by index.
        /// </summary>
        /// <param name="index">Index in list.</param>
        /// <param name="figure">Figure to place.</param>
        public void ReplaceById(int index, FigureDecorator figure)
        {
            figures[index] = figure;
        }

        /// <summary>
        /// Method to find figure with equal parameters.
        /// </summary>
        /// <param name="figure">Figure to search.</param>
        /// <returns>Figure with equal parameters.</returns>
        public IFigure FindEqual(FigureDecorator figure)
        {
            return figures.Find(e => e.GetType()==figure.GetType() && e.Side.SequenceEqual(figure.Side) && e.Color==figure.Color);
        }

        /// <summary>
        /// Method to get figures count.
        /// </summary>
        /// <returns>Integer count of figures.</returns>
        public int FigureCount()
        {
            return figures.Count;
        }

        /// <summary>
        /// Method to get square summ of all figures.
        /// </summary>
        /// <returns>Square summ in double.</returns>
        public double GetSquareSumm()
        {
            double summ = 0;
            foreach(FigureDecorator figure in figures)
            {
                summ += figure.Square();
            }
            return summ;
        }

        /// <summary>
        /// Method to get perimeter summ of all figures.
        /// </summary>
        /// <returns>Perimeter summ in double.</returns>
        public double GetPerimeterSumm()
        {
            double summ = 0;
            foreach (FigureDecorator figure in figures)
            {
                summ += figure.Perimeter();
            }
            return summ;
        }

        /// <summary>
        /// Method to get circle figures.
        /// </summary>
        /// <returns>List of circle figures.</returns>
        public List<FigureDecorator> GetCircleFigures()
        {
            List<FigureDecorator> circles = figures.FindAll(e => e.Figure.GetType()==typeof(CircleFigure));
            return circles;
        }

        /// <summary>
        /// Method to get film figures.
        /// </summary>
        /// <returns>List of film figures.</returns>
        public List<FigureDecorator> GetFilmFigures()
        {
            List<FigureDecorator> filmFigures = figures.FindAll(e => e.GetType() == typeof(FilmFigure));
            return filmFigures;
        }

        /// <summary>
        /// Method to get plastic uncolored figures.
        /// </summary>
        /// <returns>List of plastic uncolored figures.</returns>
        public List<FigureDecorator> GetPlasticUncolored()
        {
            List<FigureDecorator> plasticFigures = figures.FindAll(e => e.GetType() == typeof(PlasticFigure)&&e.Figure.Color==null);
            return plasticFigures;
        }

        /// <summary>
        /// Method to save figures in xml file.
        /// </summary>
        /// <param name="typeName">Form of figures to save.</param>
        /// <param name="filePath">Path to file.</param>
        public void SaveFigures(string typeName, string filePath)
        {
            switch (typeName)
            {
                case "CircleFigure":
                    XmlSerializer rootBoxSerializer = new XmlSerializer(typeof(RootFigureBox));
                    RootFigureBox box = new RootFigureBox
                    {
                        Figures = figures.FindAll(e => e.Figure.GetType() == typeof(CircleFigure))
                    };
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        rootBoxSerializer.Serialize(writer, box);
                    }
                    break;
                case "RectangleFigure":
                    rootBoxSerializer = new XmlSerializer(typeof(RootFigureBox));
                    box = new RootFigureBox
                    {
                        Figures = figures.FindAll(e => e.Figure.GetType() == typeof(RectangleFigure))
                    };
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        rootBoxSerializer.Serialize(writer, box);
                    }
                    break;
                case "TriangleFigure":
                    rootBoxSerializer = new XmlSerializer(typeof(RootFigureBox));
                    box = new RootFigureBox
                    {
                        Figures = figures.FindAll(e => e.Figure.GetType() == typeof(TriangleFigure))
                    };
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        rootBoxSerializer.Serialize(writer, box);
                    }
                    break;
                default:
                    rootBoxSerializer = new XmlSerializer(typeof(RootFigureBox));
                    box = new RootFigureBox
                    {
                        Figures = figures
                    };
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        rootBoxSerializer.Serialize(writer, box);
                    }
                    break;
            }
        }

        /// <summary>
        /// Method to read figures from xml file.
        /// </summary>
        /// <param name="filePath">Path to file.</param>
        public void ReadFigures(string filePath)
        {
            RootFigureBox box = new RootFigureBox
            {
                Figures = figures
            };
            XmlSerializer figureDeserializer = new XmlSerializer(typeof(RootFigureBox));
            using (StreamReader reader = new StreamReader(filePath))
            {
                box = (RootFigureBox)figureDeserializer.Deserialize(reader);
            }
            figures = box.Figures;
        }
    }
}
