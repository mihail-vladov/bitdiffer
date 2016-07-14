using System;
using System.Collections.Generic;
using System.Reflection;
using BitDiffer.Common.Configuration;
using BitDiffer.Common.Misc;

namespace BitDiffer.Common.Model
{
    [Serializable]
    public class CodeDetail : MemberDetail
    {
        private List<TypeSerializationInfo> _parameterTypes;

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

        public List<TypeSerializationInfo> ParameterTypes
        {
            get
            {
                if (this._parameterTypes == null)
                {
                    this._parameterTypes = new List<TypeSerializationInfo>();
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
