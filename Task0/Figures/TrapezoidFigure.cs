using System;
using System.Collections.Generic;
using System.Text;

namespace Figures
{
    public class TrapezoidFigure : Figure
    {
        public TrapezoidFigure(double[] X, double[] Y) : base(X, Y)
        { }

        public override double Perimeter()
        {
            double perimeter = 0;
            double side = 0;
            for (int i = 0; i < 3; i++)
            {
                side = Math.Sqrt(Math.Pow((X[i] - X[i + 1]), 2) + Math.Pow((Y[i] - Y[i + 1]), 2));
                perimeter = perimeter + side;
            }
            side = Math.Sqrt(Math.Pow((X[0] - X[3]), 2) + Math.Pow((Y[0] - Y[3]), 2));
            perimeter = perimeter + side;
            return perimeter;
        }

        public override double Square()
        {
            double square = 0;
            square = X[0] * (Y[1] - Y[Y.Length - 1]);
            for(int i=1; i<X.Length-1; i++)
            {
                square = square + X[i] * (Y[i + 1] - Y[i - 1]);
            }
            square = (square + X[X.Length-1] * (Y[0] - Y[Y.Length - 2]))/2;
            return square;
        }
    }
}
