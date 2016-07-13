using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using BitDiffer.Common.Misc;
using BitDiffer.Common.Model;

namespace BitDiffer.ReportGenerator.Xml
{
    [XmlRoot("ArrayOfChangedNode")]
    public class ArrayOfChangedNode : IXmlSerializable
    {
        private AssemblyComparison assemblyComparison;

        public ArrayOfChangedNode()
        {

        }

        public ArrayOfChangedNode(AssemblyComparison assemblyComparison)
        {
            this.assemblyComparison = assemblyComparison;
        }

        public XmlSchema GetSchema()
        {
            throw new NotImplementedException();
        }

        public void ReadXml(XmlReader reader)
        {
            throw new NotImplementedException();
        }

        public void WriteXml(XmlWriter writer)
        {
            foreach (AssemblyGroup group in this.assemblyComparison.Groups)
            {
                foreach (AssemblyDetail assemblyDetail in group.Assemblies)
                {
                    XmlElementBase element = ElementPool.CreateInstance(assemblyDetail);
                    element.Write(writer);
                }
            }
        }
    }
}
