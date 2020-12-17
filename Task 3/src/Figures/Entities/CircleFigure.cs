using System;
using System.Collections.Generic;
using System.Text;

namespace Figures.Entities
{
    public class CircleFigure : IFigure
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

        public CircleFigure()
        {
        }

        public CircleFigure(string name, double[] side)
        {
            Name = name;
            Side = side;
        }

        public double Perimeter()
        {
            return 2 * Math.PI*Side[0];
        }

        public double Square()
        {
            return Math.PI * Math.Pow(Side[0],2);
        }

        public virtual void Paint(string paint)
        {
            color = paint;
        }

        public bool SizeCheck(IFigure figure)
        {
            bool result = false;
            switch(figure.GetType().Name)
            {
                case "CircleFigure":
                    result = figure.Side[0]<=Side[0];
                    break;
                case "RectangleFigure":
                    double R = Math.Sqrt(figure.Side[0]*figure.Side[0]+figure.Side[1]*figure.Side[1])/2;
                    result = R <= Side[0];
                    break;
                case "TriangleFigure":
                    R = 3 * figure.Side[0] / (4 * Square());
                    result = R <= Side[0];
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
            if (obj.GetType() == typeof(CircleFigure))
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
