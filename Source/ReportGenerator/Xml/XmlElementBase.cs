using BitDiffer.Common.Misc;
using BitDiffer.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BitDiffer.ReportGenerator.Xml
{
    internal class XmlElementBase
    {
        public static Type ObsoleteType = typeof(ObsoleteAttribute);

        private RootDetail node;

        public XmlElementBase(RootDetail node)
        {
            this.node = node;
        }

        protected RootDetail Node
        {
            get { return node; }
        }

        protected virtual string ElementName
        {
            get
            {
                return "ChangedNode";
            }
        }

        protected virtual MemberType GetElementType { get; }

        public void Write(XmlWriter writer)
        {
            if (this.ShouldExport())
            {
                this.WriteElementStart(writer);

                this.WriteAttributes(writer);

                this.WriteElementEnd(writer);
            }

            if (this.ShouldExportChildren())
            {
                foreach (RootDetail childNode in this.node.Children)
                {
                    XmlElementBase xmlElement = ElementPool.CreateInstance(childNode);
                    xmlElement.Write(writer);
                }
            }
        }

        protected virtual bool ShouldExportOverride()
        {
            return true;
        }

        protected virtual bool ShouldExportChildren()
        {
            return true;
        }

        protected virtual void WriteAttributes(XmlWriter writer)
        {
            this.WriteAssemblyAttribute(writer);

            this.WriteParentAttribute(writer);

            this.WriteNodeAttribute(writer);

            this.WriteTypeAttribute(writer);

            this.WriteDifferenceAttribute(writer);

            this.WriteParametersAttribute(writer);

            this.WriteMessageAttribute(writer);
        }

        protected virtual void WriteAssemblyAttribute(XmlWriter writer)
        {
            string assemblyName = this.GetAssemblyName();

            writer.WriteAttributeString("Assembly", assemblyName);
        }

        protected virtual void WriteParentAttribute(XmlWriter writer)
        {
            string parent = this.GetParentName();
            writer.WriteAttributeString("Parent", parent);
        }

        protected virtual void WriteNodeAttribute(XmlWriter writer)
        {
            string nodeName = this.GetNodeName();
            writer.WriteAttributeString("Node", nodeName);
        }

        protected virtual void WriteTypeAttribute(XmlWriter writer)
        {
            if (this.GetElementType == MemberType.Other)
            {
                return;
            }

            writer.WriteAttributeString("Type", this.GetElementType.ToString());
        }

        protected virtual void WriteDifferenceAttribute(XmlWriter writer)
        {
            DifferenceType difference = this.GetDifferenceType();

            writer.WriteAttributeString("Difference", difference.ToString());
        }

        protected virtual string GetParameters()
        {
            return string.Empty;
        }

        protected virtual void WriteMessageAttribute(XmlWriter writer)
        {
            AttributeDetail obsoleteAttributeDetail = this.GetAttributeDetail(ObsoleteType);
            if (obsoleteAttributeDetail == null)
            {
                return;
            }

            IEnumerable<string> constructorArgumentsValues = obsoleteAttributeDetail.ConstructorArguments
                .Where(arg => arg.ArgumentType.FullName == typeof(string).FullName)
                .Select(arg => arg.Value.ToString());

            string message = string.Join(", ", constructorArgumentsValues);
            if (!string.IsNullOrEmpty(message))
            {
                writer.WriteAttributeString("Message", message);
            }
        }

        protected virtual DifferenceType GetDifferenceType()
        {
            AttributeDetail obsoleteAttributeDetail = this.GetAttributeDetail(ObsoleteType);
            if (obsoleteAttributeDetail != null)
            {
                return DifferenceType.Obsolete;
            }

            DifferenceType differenceType = ChangeTypeToDifferenceTypeConverter.GetDifferenceType(this.Node.Change);

            return differenceType;
        }

        protected virtual string GetAssemblyName()
        {
            return this.Node.Parent.Parent.Parent.Name;
        }

        protected virtual string GetParentName()
        {
            return this.Node.Parent.Name;
        }

        protected virtual string GetNodeName()
        {
            return this.Node.Name;
        }

        private bool ShouldExport()
        {
            DifferenceType differenceType = this.GetDifferenceType();
            if (differenceType == DifferenceType.NoDifferences || differenceType == DifferenceType.Modified)
            {
                return false;
            }

            bool wasVisibleToTheClient = this.WasVisibleToTheClient();
            if (!wasVisibleToTheClient)
            {
                return false;
            }

            return this.ShouldExportOverride();
        }

        private bool WasVisibleToTheClient()
        {
            MemberDetail memberDetail = this.Node as MemberDetail;
            if (memberDetail != null)
            {
                MemberDetail previous = memberDetail.NavigateBackward as MemberDetail;
                if (previous != null)
                {
                    int result = memberDetail.Visibility - previous.Visibility;
                    if (result <= 0 && (previous.Visibility == Visibility.Protected || previous.Visibility == Visibility.Public))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private void WriteElementStart(XmlWriter writer)
        {
            writer.WriteStartElement(this.ElementName);
        }

        private void WriteElementEnd(XmlWriter writer)
        {
            writer.WriteEndElement();
        }

        private void WriteParametersAttribute(XmlWriter writer)
        {
            string parameters = this.GetParameters();

            if (!string.IsNullOrEmpty(parameters))
            {
                writer.WriteAttributeString("Parameters", parameters);
            }
        }

        private AttributeDetail GetAttributeDetail(Type attributeType)
        {
            if (this.Node.Change == ChangeType.AttributesChanged)
            {
                foreach (var child in this.Node.Children)
                {
                    AttributeDetail attributeDetail = child as AttributeDetail;
                    if (attributeDetail != null && attributeDetail.Name == attributeType.FullName)
                    {
                        return attributeDetail;
                    }
                }
            }

            return null;
        }
    }
}
