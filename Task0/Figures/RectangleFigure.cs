using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Text;

namespace Figures
{
    public class RectangleFigure : Figure
    {
        public RectangleFigure(double[] X, double[] Y) : base(X, Y)
        { }

        public override double Perimeter()
        {

            double perimeter = 0;
            double side = Math.Sqrt(Math.Pow((X[0] - X[1]), 2) + Math.Pow((Y[0] - Y[1]), 2));
            perimeter = side * 2;
            side = Math.Sqrt(Math.Pow((X[1] - X[2]), 2) + Math.Pow((Y[1] - Y[2]), 2));
            perimeter = perimeter + side * 2;
            return perimeter;
        }

        public override double Square()
        {
            double side1 = Math.Sqrt(Math.Pow((X[0] - X[1]), 2) + Math.Pow((Y[0] - Y[1]), 2));
            double side2 = Math.Sqrt(Math.Pow((X[1] - X[2]), 2) + Math.Pow((Y[1] - Y[2]), 2));
            double square = side1 * side2;
            return square;
        }
    }
}
