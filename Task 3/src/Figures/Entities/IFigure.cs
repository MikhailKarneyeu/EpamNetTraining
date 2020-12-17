using System;
using System.Collections.Generic;
using System.Text;

namespace Figures.Entities
{
    public interface IFigure
    {
        public string Name { get; set; }
        public double [] Side { get; }
        public string Color { get; }
        public void Paint(string paint);
        public double Square();
        public double Perimeter();
        public bool SizeCheck(IFigure figure);

    }
}
