using System;
using System.Collections.Generic;
using System.Text;

namespace FigureBox
{
    public class FigureContainException: Exception
    {
        public FigureContainException()
        {
        }

        public FigureContainException(string message) : base(message)
        {
        }

        public FigureContainException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
