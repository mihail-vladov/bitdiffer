using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitDiffer.ReportGenerator
{
    internal enum DifferenceType
    {
        NoDifferences = 0,
        Modified,
        Deleted,
        Added,
        Obsolete
    }
}
