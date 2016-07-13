using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitDiffer.Common.Model;
using BitDiffer.Common.Misc;

namespace BitDiffer.ReportGenerator.Xml
{
    internal static class ElementPool
    {
        private static Dictionary<Type, Func<RootDetail, XmlElementBase>> store = new Dictionary<Type, Func<RootDetail, XmlElementBase>>();

        static ElementPool()
        {
            store.Add(typeof(ClassDetail), (node) => new ClassElement(node));
            store.Add(typeof(EnumDetail), (node) => new EnumElement(node));
            store.Add(typeof(MethodDetail), (node) => new MethodElement(node));
            store.Add(typeof(PropertyDetail), (node) => new PropertyElement(node));
            store.Add(typeof(FieldDetail), (node) => new FieldElement(node));
            store.Add(typeof(EventDetail), (node) => new EventElement(node));
            store.Add(typeof(RootDetail), (node) => new RootElement(node));
        }

        internal static XmlElementBase CreateInstance(RootDetail node)
        {
            Type elementType = node.GetType();

            Func<RootDetail, XmlElementBase> func = null;
            if (store.TryGetValue(elementType, out func))
            {
                XmlElementBase xmlElement = store[elementType](node);

                return xmlElement;
            }

            elementType = typeof(RootDetail);

            return store[elementType](node);
        }
    }
}
