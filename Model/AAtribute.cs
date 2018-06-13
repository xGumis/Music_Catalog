using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Katalog_Muzyki
{
    abstract class AAtribute : IXmlSerializable
    {
        public string AttrName { get; }
        public AAtribute(string value) { this.AttrName = value; }
        abstract public string GetValue();
        public bool Equals(AAtribute x)
        {
            if (x.GetValue() == this.GetValue()) return true;
            return false;
        }
        public override string ToString() { return GetValue(); }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            throw new NotImplementedException();
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteValue(GetValue());
        }
    }
}
