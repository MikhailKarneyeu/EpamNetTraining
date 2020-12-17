using System;
using System.Collections.Generic;
using System.Text;

namespace Figures.Entities
{
    public class FilmFigure: FigureDecorator
    {
        public FilmFigure()
        {
        }

        public FilmFigure(string name, IFigure figure):base(figure)
        {
            figure.Name = name;
        }
        public FilmFigure(string name, IFigure originalFigure, IFigure figure) : base(figure)
        {
            figure.Name = name;
            if (!originalFigure.SizeCheck(figure))
            {
                throw new InvalidFigureSizeException("Original figure is too small.");
            }
        }
        public override void Paint(string paint)
        {
            throw new FigurePaintException("Figure cant be painted.");
        }
    }
}
