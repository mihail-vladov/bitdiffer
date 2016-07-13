using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.ComponentModel;

using BitDiffer.Common.Interfaces;
using BitDiffer.Common.Utility;
using BitDiffer.Common.Misc;
using BitDiffer.Common.Configuration;

namespace BitDiffer.Common.Model
{
    [Serializable]
    public class AttributeDetail : MemberDetail
    {
        private List<ArgumentDetail> _constructorArguments = new List<ArgumentDetail>();
        private List<ArgumentDetail> _namedArguments = new List<ArgumentDetail>();

        public AttributeDetail()
        {
        }

        public AttributeDetail(RootDetail parent, CustomAttributeData cad)
            : base(parent, cad.Constructor.DeclaringType.FullName)
        {
            foreach (var item in cad.ConstructorArguments)
            {
                ArgumentDetail argument = new ArgumentDetail(item.Value, item.ArgumentType);
                this.ConstructorArguments.Add(argument);
            }

            foreach (var item in cad.NamedArguments)
            {
                ArgumentDetail argument = new ArgumentDetail(item.TypedValue, null);
                this.NamedArguments.Add(argument);
            }

            _declaration = cad.ToString();

            CodeStringBuilder csb = new CodeStringBuilder();

            AppendAttributesDeclaration(csb);

            csb.AppendType(cad.Constructor.DeclaringType);

            if (cad.ConstructorArguments.Count > 0)
            {
                csb.AppendText("(");
                csb.AppendQuotedValue(cad.ConstructorArguments[0].Value);
                csb.AppendText(")");
            }

            _declaration = csb.ToString();
            _declarationHtml = csb.ToHtmlString();
        }

        public List<ArgumentDetail> ConstructorArguments
        {
            get
            {
                if (_constructorArguments == null)
                {
                    this._constructorArguments = new List<ArgumentDetail>();
                }

                return this._constructorArguments;
            }
        }

        public List<ArgumentDetail> NamedArguments
        {
            get
            {
                if (_namedArguments == null)
                {
                    this._namedArguments = new List<ArgumentDetail>();
                }

                return this._namedArguments;
            }
        }

        protected override bool FullNameRoot
        {
            get { return true; }
        }

        public override string GetTextTitle()
        {
            return "Attribute " + _name;
        }

        protected override void ApplyFilterInstance(ComparisonFilter filter)
        {
            base.ApplyFilterInstance(filter);

            if ((filter.IgnoreAssemblyAttributeChanges) && (this.Parent.GetType() == typeof(AttributesDetail)) && (this.Parent.Parent.GetType() == typeof(AssemblyDetail)))
            {
                _changeThisInstance = ChangeType.None;
            }
        }

        protected override string SerializeGetElementName()
        {
            return "Attribute";
        }
    }
}
