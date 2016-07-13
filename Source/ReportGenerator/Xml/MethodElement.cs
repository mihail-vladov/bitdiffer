using System;
using BitDiffer.Common.Model;
using System.Xml;

namespace BitDiffer.ReportGenerator.Xml
{
    internal class MethodElement : MemberElement
    {
        public MethodElement(RootDetail node) : base(node)
        {

        }

        protected override bool ShouldExportOverride()
        {
            if (this.Node.Name == "get" || this.Node.Name == "set")
            {
                return false;
            }

            return true;
        }

        protected override MemberType GetElementType
        {
            get
            {
                return MemberType.Method;
            }
        }

        protected override string GetParameters()
        {
            string parameters = string.Empty;

            MethodDetail methodDetail = this.Node as MethodDetail;
            if(methodDetail != null)
            {
                foreach (var parameterType in methodDetail.ParameterTypes)
                {
                    parameters += parameterType.Name;
                }
            }

            return parameters;
        }
    }
}