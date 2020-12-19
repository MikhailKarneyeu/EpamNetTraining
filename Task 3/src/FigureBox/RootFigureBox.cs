using Figures.Entities;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace FigureBox
{
    /// <summary>
    /// Class for figure list serializing.
    /// </summary>
    public class RootFigureBox
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public RootFigureBox() { }

        /// <summary>
        /// Property to store figures to serialize.
        /// </summary>
        [XmlElement("FilmFigure", typeof(FilmFigure))]
        [XmlElement("PaperFigure", typeof(PaperFigure))]
        [XmlElement("PlasticFigure", typeof(PlasticFigure))]
        public List<FigureDecorator> Figures{ get; set; }
    }
}
