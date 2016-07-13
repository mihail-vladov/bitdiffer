using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitDiffer.Common.Model;

namespace BitDiffer.ReportGenerator.Xml
{
    internal class MemberElement : XmlElementBase
    {
        public MemberElement(RootDetail node) : base(node)
        {
        }

        protected override string GetAssemblyName()
        {
            return this.Node.Parent.Parent.Parent.Name;
        }

        protected override string GetParentName()
        {
            string namespaceString = this.GetNamespace();

            string fullParentName = namespaceString + "." + this.Node.Parent.Name;

            return fullParentName;
        }

        private string GetNamespace()
        {
            return this.Node.Parent.Parent.Name;
        }
    }
}
