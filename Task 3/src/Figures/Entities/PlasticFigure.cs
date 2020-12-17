using System;
using System.Collections.Generic;
using System.Text;

namespace Figures.Entities
{
    public class PlasticFigure: FigureDecorator
    {
        public PlasticFigure()
        {
        }

        public PlasticFigure(string name, IFigure figure):base(figure)
        {
            figure.Name = name;
        }
        public PlasticFigure(string name, IFigure originalFigure, IFigure figure) : base(figure)
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
            Figure.Paint(paint);
        }
    }
}
