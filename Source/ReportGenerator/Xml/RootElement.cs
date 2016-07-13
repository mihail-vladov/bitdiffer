using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitDiffer.Common.Model;

namespace BitDiffer.ReportGenerator.Xml
{
    internal class RootElement : XmlElementBase
    {
        public RootElement(RootDetail node) : base(node)
        {
        }

        protected override MemberType GetElementType
        {
            get
            {
                return MemberType.Other;
            }
        }

        protected override bool ShouldExportOverride()
        {
            return false;
        }
    }
}
