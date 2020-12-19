using System;
using System.Collections.Generic;
using System.Text;

namespace FigureBox
{
    /// <summary>
    /// Figure is already in box exception.
    /// </summary>
    public class FigureContainException: Exception
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public FigureContainException()
        {
        }

        /// <summary>
        /// Constructor with parameters.
        /// </summary>
        /// <param name="message">Exception message.</param>
        public FigureContainException(string message) : base(message)
        {
        }

        /// <summary>
        /// Constructor with parameters.
        /// </summary>
        /// <param name="message">Exception message.</param>
        /// <param name="inner">Exception inner object.</param>
        public FigureContainException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
