using System;
using System.Linq;
using BitDiffer.Common.Model;

namespace BitDiffer.ReportGenerator.Xml
{
    internal class PropertyElement : MemberElement
    {
        public PropertyElement(RootDetail node) : base(node)
        {
        }

        protected override MemberType GetElementType
        {
            get
            {
                return MemberType.Property;
            }
        }
    }
}
