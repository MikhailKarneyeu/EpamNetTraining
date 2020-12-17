using System;
using System.Collections.Generic;
using System.Text;

namespace Figures.Entities
{
    public class PaperFigure : FigureDecorator
    {
        public PaperFigure()
        {
        }

        public PaperFigure(string name, IFigure figure) : base(figure)
        {
            figure.Name = name;
        }

        public PaperFigure(string name, PaperFigure originalFigure, IFigure figure) : base(figure)
        {
            figure.Name = name;
            if (originalFigure.SizeCheck(figure))
            {
                Figure.Paint(originalFigure.Color);
            }
            else
            {
                throw new InvalidFigureSizeException("Original figure is too small.");
            }
        }
        public override void Paint(string paint)
        {
            if (Color == null)
                Figure.Paint(paint);
            else
                throw new FigurePaintException("Figure is painted.");
        }
    }
}
