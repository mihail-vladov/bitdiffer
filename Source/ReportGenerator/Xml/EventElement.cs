using System;
using System.Linq;
using BitDiffer.Common.Model;

namespace BitDiffer.ReportGenerator.Xml
{
    internal class EventElement : MemberElement
    {
        public EventElement(RootDetail node) : base(node)
        {
        }

        protected override MemberType GetElementType
        {
            get
            {
                // TODO: check how exactly it should be.
                return MemberType.Method;
            }
        }
    }
}
