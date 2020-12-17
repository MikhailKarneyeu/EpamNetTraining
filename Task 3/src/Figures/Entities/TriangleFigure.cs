using System;
using System.Collections.Generic;
using System.Text;

namespace Figures.Entities
{
    public class TriangleFigure : IFigure
    {
        protected string color;
        public string Name { get; set; }

        public double[] Side { get; }

        public string Color 
        { 
            get
            {
                return color;
            }
        }

        public TriangleFigure()
        {
        }

        public TriangleFigure(string name, double[] side)
        {
            Name = name;
            Side = side;
        }

        public double Perimeter()
        {
            return Side[0] * 3;
        }

        public double Square()
        {
            return Math.Pow(Side[0] * Side[0], 2) * Math.Sqrt(3) / 4;
        }

        public virtual void Paint(string paint)
        {
            color = paint;
        }

        public bool SizeCheck(IFigure figure)
        {
            bool result = false;
            switch (figure.GetType().Name)
            {
                case "CircleFigure":
                    result = Square()/Perimeter()<= figure.Side[0];
                    break;
                case "RectangleFigure":
                    double coeff = Side[0]*Side[0]*Math.Sqrt(3)/8;
                    result = figure.Side[0]*figure.Side[1]<=coeff;
                    break;
                case "TriangleFigure":
                    result = figure.Side[0]<=Side[0];
                    break;
            }
            return result;
        }

        public override string ToString()
        {
            return $"{Name};{Side[0]};{Color};{Perimeter()};{Square()}";
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() == typeof(TriangleFigure))
            {
                if (obj.ToString() == ToString())
                {
                    return true;
                }
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
