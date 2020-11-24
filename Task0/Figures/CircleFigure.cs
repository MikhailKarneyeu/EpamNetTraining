using System;
using System.Collections.Generic;
using System.Text;

namespace Figures
{
    public class CircleFigure : Figure
    {
        public CircleFigure(double[] X, double[] Y) : base(X, Y)
        { }

        public override double Perimeter()
        {
            double radius = Math.Sqrt(Math.Pow((X[0] - X[1]), 2) + Math.Pow((Y[0] - Y[1]), 2));
            double perimeter = 2 * Math.PI * radius;
            return perimeter;
        }

        public override double Square()
        {
            double radius = Math.Sqrt(Math.Pow((X[0] - X[1]), 2) + Math.Pow((Y[0] - Y[1]), 2));
            double square = Math.PI * radius* radius;
            return square;
        }
    }
}
