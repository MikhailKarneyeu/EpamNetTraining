using Figures.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace FigureBox
{
    public class FiguresBox
    {
        private List<FigureDecorator> figures;

        public FiguresBox()
        {
            figures = new List<FigureDecorator>(20);
        }

        public void AddFigure(FigureDecorator figure)
        {
            if (!figures.Contains(figure))
                figures.Add(figure);
            else
                throw new FigureContainException("This figure is in the box already.");
        }

        public List<FigureDecorator> Figures
        {
            get
            {
                return figures;
            }
        }

        public IFigure GetById(int index)
        {
            return figures[index];
        }

        public IFigure ExtractById(int index)
        {
            IFigure result = figures[index];
            figures.RemoveAt(index);
            return result;
        }

        public void ReplaceById(int index, FigureDecorator figure)
        {
            figures[index] = figure;
        }

        public IFigure FindEqual(FigureDecorator figure)
        {
            return figures.Find(e => e.GetType()==figure.GetType() && e.Side.SequenceEqual(figure.Side) && e.Color==figure.Color);
        }

        public int FigureCount()
        {
            return figures.Count;
        }

        public double GetSquareSumm()
        {
            double summ = 0;
            foreach(FigureDecorator figure in figures)
            {
                summ += figure.Square();
            }
            return summ;
        }

        public double GetPerimeterSumm()
        {
            double summ = 0;
            foreach (FigureDecorator figure in figures)
            {
                summ += figure.Perimeter();
            }
            return summ;
        }

        public List<FigureDecorator> GetCircleFigures()
        {
            List<FigureDecorator> circles = figures.FindAll(e => e.Figure.GetType()==typeof(CircleFigure));
            return circles;
        }

        public List<FigureDecorator> GetFilmFigures()
        {
            List<FigureDecorator> filmFigures = figures.FindAll(e => e.GetType() == typeof(FilmFigure));
            return filmFigures;
        }

        public List<FigureDecorator> GetPlasticUncolored()
        {
            List<FigureDecorator> plasticFigures = figures.FindAll(e => e.GetType() == typeof(PlasticFigure)&&e.Figure.Color==null);
            return plasticFigures;
        }

        public void SaveFiguresStreamWriter(string typeName, string filePath)
        {
            switch(typeName)
            {
                case "CircleFigure":
                    XmlSerializer figureSerializer = new XmlSerializer(typeof(List<CircleFigure>));
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        figureSerializer.Serialize(writer, figures.FindAll(e => e.Figure.GetType()==typeof(CircleFigure)));
                    }
                    break;
                case "RectangleFigure":
                    figureSerializer = new XmlSerializer(typeof(List<RectangleFigure>));
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        figureSerializer.Serialize(writer, figures.FindAll(e => e.Figure.GetType() == typeof(RectangleFigure)));
                    }
                    break;
                default:
                    figureSerializer = new XmlSerializer(figures.GetType());
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        figureSerializer.Serialize(writer, figures);
                    }
                    break;
            }
        }

        public void ReadFiguresStreamWriter(string filePath)
        {
            using (var reader = new StreamReader(filePath))
            {
                XmlSerializer deserializer = new XmlSerializer(figures.GetType());
                figures = (List<FigureDecorator>)deserializer.Deserialize(reader);
            }
        }

    }
}
