using System;
using System.Collections.Generic;
using System.Text;

namespace Figures
{
    public class SquareFigure : Figure
    {
        public SquareFigure(double[] X, double[] Y) : base(X, Y)
        { }

        public override double Perimeter()
        {
            double side = Math.Sqrt(Math.Pow((X[0] - X[1]), 2) + Math.Pow((Y[0] - Y[1]), 2));
            double perimeter = side * 4;
            return perimeter;
        }

        public override double Square()
        {
            double side = Math.Sqrt(Math.Pow((X[0] - X[1]), 2) + Math.Pow((Y[0] - Y[1]), 2));
            double square = side * side;
            return square;
        }
    }
}
