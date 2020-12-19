using System;
using System.Collections.Generic;
using System.Text;

namespace Figures.Entities
{
    /// <summary>
    /// Invalid paint operation exception.
    /// </summary>
    public class FigurePaintException : Exception
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public FigurePaintException()
        {
        }

        /// <summary>
        /// Constructor with parameters.
        /// </summary>
        /// <param name="message">Exception message.</param>
        public FigurePaintException(string message) : base(message)
        {
        }

        /// <summary>
        /// Constructor with parameters.
        /// </summary>
        /// <param name="message">Exception message.</param>
        /// <param name="inner">Exception inner object.</param>
        public FigurePaintException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
