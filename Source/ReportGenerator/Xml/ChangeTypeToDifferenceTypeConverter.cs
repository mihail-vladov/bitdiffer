using BitDiffer.Common.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitDiffer.ReportGenerator.Xml
{
    internal static class ChangeTypeToDifferenceTypeConverter
    {
        private static Dictionary<ChangeType, DifferenceType> store = new Dictionary<ChangeType, DifferenceType>();

        static ChangeTypeToDifferenceTypeConverter()
        {
            store.Add(ChangeType.None, DifferenceType.NoDifferences);
            store.Add(ChangeType.Added, DifferenceType.Added);
            store.Add(ChangeType.RemovedBreaking, DifferenceType.Deleted);
            // TODO: how this case should be handled.
            store.Add(ChangeType.VisibilityChangedBreaking, DifferenceType.Deleted);
        }

        public static DifferenceType GetDifferenceType(ChangeType changeType)
        {
            DifferenceType result = DifferenceType.NoDifferences;
            if (store.TryGetValue(changeType, out result))
            {
                return result;
            }

            return DifferenceType.Modified;
        }
    }
}
