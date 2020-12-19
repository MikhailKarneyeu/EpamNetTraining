using System;
using System.Collections.Generic;
using System.Text;

namespace Figures.Entities
{
    /// <summary>
    /// Figure is to small to cut different figure exeption.
    /// </summary>
    public class InvalidFigureSizeException: Exception
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public InvalidFigureSizeException()
        {
        }

        /// <summary>
        /// Constructor with parameters.
        /// </summary>
        /// <param name="message">Exception message.</param>
        public InvalidFigureSizeException(string message) : base(message)
        {
        }

        /// <summary>
        /// Constructor with parameters.
        /// </summary>
        /// <param name="message">Exception message.</param>
        /// <param name="inner">Exception inner object.</param>
        public InvalidFigureSizeException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
