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
            this.Value = value;
        }

        public object Value { get; private set; }

        public TypeSerializationInfo ArgumentType { get; private set; }
    }
}