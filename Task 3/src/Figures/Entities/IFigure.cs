using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Figures.Entities
{
    /// <summary>
    /// Interface for figures.
    /// </summary>
    public interface IFigure
    {
        /// <summary>
        /// Figure name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Figure sides or radius.
        /// </summary>
        public double[] Side { get; }

        /// <summary>
        /// Figure color.
        /// </summary>
        public string Color { get; }

        /// <summary>
        /// Method to paint figure.
        /// </summary>
        /// <param name="paint">Color of paint.</param>
        public void Paint(string paint);

        /// <summary>
        /// Method to get figure square.
        /// </summary>
        /// <returns>Figure square in double.</returns>
        public double Square();

        /// <summary>
        /// Method to get figure perimeter.
        /// </summary>
        /// <returns>Figure perimeter in double.</returns>
        public double Perimeter();

        /// <summary>
        /// Method to check if figure fit in current figure.
        /// </summary>
        /// <param name="figure">Figure to check.</param>
        /// <returns></returns>
        public bool SizeCheck(IFigure figure);

    }
}
