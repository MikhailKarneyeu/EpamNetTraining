using System;
using System.Collections.Generic;
using System.Text;

namespace Figures.Entities
{
    public class RectangleFigure : IFigure
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

        public RectangleFigure()
        {
        }

        public RectangleFigure(string name, double[] sides)
        {
            Name = name;
            Side = sides;
        }
        public double Perimeter()
        {
            return Side[0]*2+Side[1]*2;
        }

        public double Square()
        {
            return Side[0]*Side[1];
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
                    result = figure.Side[0] <= Side[0]/2&&figure.Side[0] <= Side[1]/2;
                    break;
                case "RectangleFigure":
                    result = (figure.Side[0]<=Side[0]&&figure.Side[1] <= Side[1]) || (figure.Side[0] <= Side[1] && figure.Side[1] <= Side[0]);
                    break;
                case "TriangleFigure":
                    double height = Math.Sqrt(3) * figure.Side[0] / 2;
                    result = (figure.Side[0] <= Side[0] && height <= Side[1]) || (figure.Side[0] <= Side[1] && height <= Side[0]);
                    break;
            }
            return result;
        }

        public override string ToString()
        {
            return $"{Name};{Side[0]};{Side[1]};{Color};{Perimeter()};{Square()}";
        }

        public override bool Equals(object obj)
        {
            if(obj.GetType()==typeof(RectangleFigure))
            {
                if(obj.ToString()==ToString())
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
