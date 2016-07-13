using System;
using System.Linq;
using BitDiffer.Common.Model;

namespace BitDiffer.ReportGenerator.Xml
{
    internal class TypeElement : XmlElementBase
    {
        public TypeElement(RootDetail node) : base(node)
        {
        }

        protected override MemberType GetElementType
        {
            get
            {
                return MemberType.Type;
            }
        }

        protected override string GetParentName()
        {
            string namespaceString = this.Node.Parent.Name;

            return namespaceString;
        }

        protected override string GetAssemblyName()
        {
            return this.Node.Parent.Parent.Name;
        }
    }
}
