using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BitDiffer.Common.Model
{
    [Serializable]
    public class TypeSerializationInfo
    {

        public TypeSerializationInfo(Type type)
        {
            this.Name = type.Name;
            this.FullName = type.FullName;
            this.Namespace = type.Namespace;
            this.AssemblyFullName = type.Assembly.FullName;
        }

        public string Name
        {
            get;
            private set;
        }

        public string FullName
        {
            get;

            private set;
        }

        public string Namespace
        {
            get;
            private set;
        }

        public string AssemblyFullName
        {
            get;
            private set;
        }
    }
}
