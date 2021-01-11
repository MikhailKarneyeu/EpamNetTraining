using System;
using System.Diagnostics.CodeAnalysis;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace StudentsTests
{
    public class StudentsTest : IComparable<StudentsTest>, IXmlSerializable
    {
        public string Name { get; private set; }
        public string TestName { get; private set; }
        public DateTime Date { get; private set; }
        public int Grade { get; private set; }
        public StudentsTest()
        {
        }
        public StudentsTest(string name, string testName, DateTime date, int grade)
        {
            Name = name;
            TestName = testName;
            Date = date;
            Grade = grade;
        }
        public string Key()
        {
            return Name + TestName;
        }
        public int CompareTo(StudentsTest other)
        {
            if (string.Compare(Key(), other.Key(), StringComparison.Ordinal) > 0)
                return 1;
            else if (string.Compare(Key(), other.Key(), StringComparison.Ordinal) < 0)
                return -1;
            else
                return 0;
        }

        public XmlSchema GetSchema()
        {
            return null;
        }

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

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteElementString("Name", Name);
            writer.WriteElementString("TestName", TestName);
            writer.WriteElementString("Date", Date.ToString("yyyy-MM-dd'T'HH:mm:ss.fffffff"));
            writer.WriteElementString("Grade", Grade.ToString());
        }

        public override string ToString()
        {
            return $"{Name};{TestName};{Date};{Grade}";
        }

        public override bool Equals(object obj)
        {
            if (this.GetType()==obj.GetType()&&obj.ToString() == ToString())
            {
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
