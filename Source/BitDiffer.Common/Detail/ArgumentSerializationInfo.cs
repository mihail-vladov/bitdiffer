using BitDiffer.Common.Utility;
using System;
using System.Reflection;

namespace BitDiffer.Common.Model
{
    [Serializable]
    public class ArgumentSerializationInfo
    {
        public ArgumentSerializationInfo(object value, Type argumentType) :
            this(value, new TypeSerializationInfo(argumentType))
        {

        }

        public ArgumentSerializationInfo(object value, TypeSerializationInfo typeSerializationInfo) :
            this(value)
        {

            this.ArgumentType = typeSerializationInfo;
        }

        public ArgumentSerializationInfo(object value)
        {
            if (value != null)
            {
                this.Value = value.ToString();
            }
        }

        public string Value { get; private set; }

        public TypeSerializationInfo ArgumentType { get; private set; }
    }
}