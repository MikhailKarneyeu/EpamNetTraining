using System;

namespace Figures
{
    public abstract class Figure
    {
        public double[] X { get; set; }

        public double[] Y { get; set; }

        public Figure(double[] X, double[] Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public abstract double Perimeter();

        public abstract double Square();
    }
}
