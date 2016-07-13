using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Xml;

using BitDiffer.Common.Interfaces;
using BitDiffer.Common.Utility;
using BitDiffer.Common.Misc;
using BitDiffer.Common.Configuration;

namespace BitDiffer.Common.Model
{
    [Serializable]
    public class CodeDetail : MemberDetail
    {
        private List<Type> _parameterTypes;

        protected int _parameterCount;
        protected string _parameterTypesList;

        public CodeDetail()
        {
        }

        public CodeDetail(RootDetail parent, MemberInfo mi)
            : base(parent, mi)
        {
        }

        public string ParameterTypesList
        {
            get { return _parameterTypesList; }
        }

        public List<Type> ParameterTypes
        {
            get
            {
                if (this._parameterTypes == null)
                {
                    this._parameterTypes = new List<Type>();
                }

                return this._parameterTypes;
            }
        }

        public int ParameterCount
        {
            get { return _parameterCount; }
        }

        protected override void ApplyFilterInstance(ComparisonFilter filter)
        {
            base.ApplyFilterInstance(filter);

            if (!filter.CompareMethodImplementations)
            {
                _changeThisInstance &= ~ChangeType.ImplementationChanged;
            }
        }
    }
}
