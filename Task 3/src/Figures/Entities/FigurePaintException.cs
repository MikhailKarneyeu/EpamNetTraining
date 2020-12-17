using System;
using System.Collections.Generic;
using System.Text;

namespace Figures.Entities
{
    public class FigurePaintException : Exception
    {
        public FigurePaintException()
        {
        }

        public FigurePaintException(string message) : base(message)
        {
        }

        public FigurePaintException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
