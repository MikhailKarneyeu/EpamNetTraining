using System;
using System.Diagnostics.CodeAnalysis;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace StudentsTests
{
    /// <summary>
    /// Student test class.
    /// </summary>
    public class StudentsTest : IComparable<StudentsTest>, IXmlSerializable
    {
        /// <summary>
        /// Student name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Test name.
        /// </summary>
        public string TestName { get; private set; }

        /// <summary>
        /// Test date.
        /// </summary>
        public DateTime Date { get; private set; }

        /// <summary>
        /// Student grade.
        /// </summary>
        public int Grade { get; private set; }

        /// <summary>
        /// Deafult constructor.
        /// </summary>
        public StudentsTest()
        {
        }

        /// <summary>
        /// Constructor with parameters.
        /// </summary>
        /// <param name="name">Student name.</param>
        /// <param name="testName">Test name.</param>
        /// <param name="date">Test date.</param>
        /// <param name="grade">Student grade.</param>
        public StudentsTest(string name, string testName, DateTime date, int grade)
        {
            Name = name;
            TestName = testName;
            Date = date;
            Grade = grade;
        }

        private string Key()
        {
            return Name + TestName;
        }

        /// <summary>
        /// Compare two tests method.
        /// </summary>
        /// <param name="other">Second test to compare.</param>
        /// <returns>Comparison result</returns>
        public int CompareTo(StudentsTest other)
        {
            if (string.Compare(Key(), other.Key(), StringComparison.Ordinal) > 0)
                return 1;
            else if (string.Compare(Key(), other.Key(), StringComparison.Ordinal) < 0)
                return -1;
            else
                return 0;
        }

        /// <summary>
        /// Method to get xml schema.
        /// </summary>
        /// <returns>Null.</returns>
        public XmlSchema GetSchema()
        {
            return null;
        }

        /// <summary>
        /// Method to deserialize test.
        /// </summary>
        /// <param name="reader">Xml reader object.</param>
        public void ReadXml(XmlReader reader)
        {
            reader.Read();
            if (!reader.IsEmptyElement)
                Name = reader.ReadElementContentAsString();
            else reader.Read();
            if (!reader.IsEmptyElement)
                TestName = reader.ReadElementContentAsString();
            else reader.Read();
            if (!reader.IsEmptyElement)
                Date = reader.ReadElementContentAsDateTime();
            else reader.Read();
            if (!reader.IsEmptyElement)
                Grade = reader.ReadElementContentAsInt();
            else reader.Read();
            reader.Read();
        }

        /// <summary>
        /// Method to serialize test.
        /// </summary>
        /// <param name="writer">Xml writer object.</param>
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteElementString("Name", Name);
            writer.WriteElementString("TestName", TestName);
            writer.WriteElementString("Date", Date.ToString("yyyy-MM-dd'T'HH:mm:ss.fffffff"));
            writer.WriteElementString("Grade", Grade.ToString());
        }

        /// <summary>
        /// Method to get test in string.
        /// </summary>
        /// <returns>Name;Test name; Date; Grade</returns>
        public override string ToString()
        {
            return $"{Name};{TestName};{Date};{Grade}";
        }

        /// <summary>
        /// Method to chech if test if equal to object.
        /// </summary>
        /// <param name="obj">Objcet to compare.</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (this.GetType()==obj.GetType()&&obj.ToString() == ToString())
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Method to get hash code of test.
        /// </summary>
        /// <returns>Integer hash code.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
