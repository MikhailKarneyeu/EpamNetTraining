using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Figures.Entities
{
    /// <summary>
    /// Paper figure class.
    /// </summary>
    public class PaperFigure : FigureDecorator, IXmlSerializable
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public PaperFigure()
        {
        }

        /// <summary>
        /// Constructor with parameters.
        /// </summary>
        /// <param name="name">Figure name.</param>
        /// <param name="figure">Figure to make paperfigure.</param>
        public PaperFigure(string name, IFigure figure) : base(figure)
        {
            figure.Name = name;
        }

        /// <summary>
        /// Constructor with parameters.
        /// </summary>
        /// <param name="name">Figure name.</param>
        /// <param name="originalFigure">Figure to make paperfigure from.</param>
        /// <param name="figure">Figure to make paperfigure.</param>
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

        /// <summary>
        /// Method to paint figure.
        /// </summary>
        /// <param name="paint">Paint color.</param>
        public override void Paint(string paint)
        {
            if (Color == null)
                Figure.Paint(paint);
            else
                throw new FigurePaintException("Figure is painted.");
        }

        /// <summary>
        /// Method to get figure perimeter.
        /// </summary>
        /// <returns></returns>
        public override XmlSchema GetSchema()
        {
            return null;
        }

        /// <summary>
        /// Method to read object during serialization.
        /// </summary>
        /// <param name="reader">Xmlreader.</param>
        public override void ReadXml(XmlReader reader)
        {
            base.ReadXml(reader);
        }

        /// <summary>
        /// Method to save object during serialization.
        /// </summary>
        /// <param name="writer">Xmlreader.</param>
        public override void WriteXml(XmlWriter writer)
        {
            base.WriteXml(writer);
        }
    }
}
