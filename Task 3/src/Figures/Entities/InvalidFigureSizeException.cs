using System;
using System.Collections.Generic;
using System.Text;

namespace Figures.Entities
{
    public class InvalidFigureSizeException: Exception
    {
        public InvalidFigureSizeException()
        {
        }

        public InvalidFigureSizeException(string message) : base(message)
        {
        }

        public InvalidFigureSizeException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
