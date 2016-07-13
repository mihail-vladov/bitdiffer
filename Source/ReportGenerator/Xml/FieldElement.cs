using System;
using System.Linq;
using BitDiffer.Common.Model;

namespace BitDiffer.ReportGenerator.Xml
{
    internal class FieldElement : MemberElement
    {
        public FieldElement(RootDetail node) : base(node)
        {
        }

        protected override MemberType GetElementType
        {
            get
            {
                return MemberType.Field;
            }
        }
    }
}
