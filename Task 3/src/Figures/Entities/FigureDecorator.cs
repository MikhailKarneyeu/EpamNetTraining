using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Figures.Entities
{
    /// <summary>
    /// Decorator class to add material to figure.
    /// </summary>
    [XmlInclude(typeof(PaperFigure)), XmlInclude(typeof(PlasticFigure)), XmlInclude(typeof(FilmFigure))]
    public class FigureDecorator: IFigure, IXmlSerializable
    {
        /// <summary>
        /// Figure to add material.
        /// </summary>
        public IFigure Figure 
        { get; private set; }

        /// <summary>
        /// Figure name.
        /// </summary>
        public string Name
        {
            get
            {
                return Figure.Name;
            }
            set { }
        }

        /// <summary>
        /// Sides or radius of figure.
        /// </summary>
        public double[] Side
        {
            get
            {
                return Figure.Side;
            }
        }

        /// <summary>
        /// Figure color.
        /// </summary>
        public string Color
        {
            get
            {
                return Figure.Color;
            }
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public FigureDecorator()
        {
        }

        /// <summary>
        /// Constructior with parameter.
        /// </summary>
        /// <param name="figure">Figure implemented IFigure.</param>
        public FigureDecorator(IFigure figure)
        {
            Figure = figure;
        }

        /// <summary>
        /// Method to get figure color.
        /// </summary>
        /// <param name="paint">Paint color.</param>
        public virtual void Paint(string paint)
        {
            Figure.Paint(paint);
        }

        /// <summary>
        /// Method to get figure perimeter.
        /// </summary>
        /// <returns></returns>
        public double Perimeter()
        {
            return Figure.Perimeter();
        }

        /// <summary>
        /// Method to get figure square.
        /// </summary>
        /// <returns></returns>
        public double Square()
        {
            return Figure.Square();
        }

        /// <summary>
        /// Method to check if figre fit in current figure.
        /// </summary>
        /// <param name="figure">Figure to fit.</param>
        /// <returns></returns>
        public bool SizeCheck(IFigure figure)
        {
            return Figure.SizeCheck(figure);
        }

        /// <summary>
        /// Overrided method to get string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Figure.ToString();
        }

        /// <summary>
        /// Overrided method to compare objects.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj.ToString() == ToString())
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Method to get hashcode of object.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Method to get xmlchema.
        /// </summary>
        /// <returns>Null.</returns>
        public virtual XmlSchema GetSchema()
        {
            return null;
        }

        /// <summary>
        /// Method to read object during serialization.
        /// </summary>
        /// <param name="reader">Xmlreader.</param>
        public virtual void ReadXml(XmlReader reader)
        {
            reader.Read();
            reader.MoveToFirstAttribute();
            string figureType = reader.Value;
            string name = null;
            reader.Read();
            if (!reader.IsEmptyElement)
                name = reader.ReadElementContentAsString();
            else reader.Read();
            string color = null;
            if (!reader.IsEmptyElement)
                color = reader.ReadElementContentAsString();
            else reader.Read();
            double[] side = new double[2];
            reader.Read();
            side[0] = reader.ReadElementContentAsDouble();
            if (reader.NodeType != XmlNodeType.EndElement)
            {
                side[1] = reader.ReadElementContentAsDouble();
                reader.Read();
            }
            else reader.Read();
            switch (figureType)
            {
                case "CircleFigure":
                    Figure = new CircleFigure(name, new double[1] { side[0] });
                    if (color != null)
                        Figure.Paint(color);
                    break;
                case "TriangleFigure":
                    Figure = new TriangleFigure(name, new double[1] { side[0] });
                    if (color != null)
                        Figure.Paint(color);
                    break;
                case "RectangleFigure":
                    Figure = new RectangleFigure(name, side);
                    if (color != null)
                        Figure.Paint(color);
                    break;
            }
            reader.Read();
            reader.Read();
        }

        /// <summary>
        /// Method to save object during serialization.
        /// </summary>
        /// <param name="writer">Xmlreader.</param>
        public virtual void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("Figure");
            writer.WriteAttributeString("FigureType", Figure.GetType().Name);
            writer.WriteElementString("Name", Name);
            writer.WriteElementString("Color", Color);
            writer.WriteStartElement("Side");
            for (int i = 0; i < Side.Length; i++)
            {
                writer.WriteElementString("Side", Side[i].ToString());
            }
            writer.WriteEndElement();
            writer.WriteEndElement();
        }
    }
}
