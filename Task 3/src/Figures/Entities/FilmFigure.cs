using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Figures.Entities
{
    /// <summary>
    /// Film figure class.
    /// </summary>
    public class FilmFigure: FigureDecorator, IXmlSerializable
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public FilmFigure()
        {
        }

        /// <summary>
        /// Constructor with parameters.
        /// </summary>
        /// <param name="name">Figure name.</param>
        /// <param name="figure">Figure to make fimlfigure.</param>
        public FilmFigure(string name, IFigure figure):base(figure)
        {
            figure.Name = name;
        }

        /// <summary>
        /// Constructor with parameters.
        /// </summary>
        /// <param name="name">Figure name.</param>
        /// <param name="originalFigure">Figure to make fimlfigure from.</param>
        /// <param name="figure">Figure to make fimlfigure.</param>
        public FilmFigure(string name, IFigure originalFigure, IFigure figure) : base(figure)
        {
            figure.Name = name;
            if (!originalFigure.SizeCheck(figure))
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
            throw new FigurePaintException("Figure cant be painted.");
        }

        /// <summary>
        /// Method to get xmlchema.
        /// </summary>
        /// <returns>Null.</returns>
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
