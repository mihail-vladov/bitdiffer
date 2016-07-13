using System;

namespace BitDiffer.Common.Model
{
    [Serializable]
    public class ArgumentDetail
    {
        public ArgumentDetail(object value, Type argumentType)
        {
            this.Value = value;
            this.ArgumentType = argumentType;
        }

        public object Value { get; set; }

        public Type ArgumentType { get; set; }
    }
}