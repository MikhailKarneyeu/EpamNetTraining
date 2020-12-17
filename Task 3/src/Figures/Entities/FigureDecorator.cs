using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Figures.Entities
{
    public class FigureDecorator: IFigure
    {
        [XmlElement("CircleFigure", typeof(CircleFigure))]
        [XmlElement("RectangleFigure", typeof(RectangleFigure))]
        [XmlElement("TriangleFigure", typeof(TriangleFigure))]
        public IFigure Figure { get; }

        public string Name
        {
            get
            {
                return Figure.Name;
            }
            set 
            { 
            }
        }

        public double[] Side
        {
            get
            {
                return Figure.Side;
            }
        }

        public string Color
        {
            get
            {
                return Figure.Color;
            }
        }

        public FigureDecorator()
        {
        }

        public FigureDecorator(IFigure figure)
        {
            Figure = figure;
        }

        public virtual void Paint(string paint)
        {
            Figure.Paint(paint);
        }

        public double Perimeter()
        {
            return Figure.Perimeter();
        }

        public double Square()
        {
            return Figure.Square();
        }

        public bool SizeCheck(IFigure figure)
        {
            return Figure.SizeCheck(figure);
        }

        public override string ToString()
        {
            return Figure.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj.ToString() == ToString())
            {
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
