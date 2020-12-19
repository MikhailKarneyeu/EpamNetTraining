using System;
using System.Collections.Generic;
using System.Text;

namespace Figures.Entities
{
    /// <summary>
    /// Circle figure class.
    /// </summary>
    public class CircleFigure : IFigure
    {
        /// <summary>
        /// Color of figure.
        /// </summary>
        protected string color;

        /// <summary>
        /// Property to get and set figure name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Property to get radius.
        /// </summary>
        public double[] Side { get; }

        /// <summary>
        /// Property to get figure color.
        /// </summary>
        public string Color
        {
            get
            {
                return color;
            }
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public CircleFigure()
        {
        }

        /// <summary>
        /// Constructor with parameters.
        /// </summary>
        /// <param name="name">Figure name.</param>
        /// <param name="side">Figure radius.</param>
        public CircleFigure(string name, double[] side)
        {
            Name = name;
            Side = side;
        }

        /// <summary>
        /// Method to get figure perimeter.
        /// </summary>
        /// <returns>Figure perimeter in double.</returns>
        public double Perimeter()
        {
            return 2 * Math.PI*Side[0];
        }

        /// <summary>
        /// Method to get figure square.
        /// </summary>
        /// <returns>Figure square in double.</returns>
        public double Square()
        {
            return Math.PI * Math.Pow(Side[0],2);
        }

        /// <summary>
        /// Method to paint figure.
        /// </summary>
        /// <param name="paint">Paint color.</param>
        public virtual void Paint(string paint)
        {
            color = paint;
        }

        /// <summary>
        /// Method to check if figure fit in current figure.
        /// </summary>
        /// <param name="figure">Figure to check.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Method to get string.
        /// </summary>
        /// <returns>String "Name;Raduis;Color;Perimeter;Square"</returns>
        public override string ToString()
        {
            return $"{Name};{Side[0]};{Color};{Perimeter()};{Square()}";
        }

        /// <summary>
        /// Method to compare figures.
        /// </summary>
        /// <param name="obj">Figure to compare.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Method to get hashcode.
        /// </summary>
        /// <returns>Integer hashcode.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
