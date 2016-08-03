using System;
using System.IO;
using System.Linq;
using BitDiffer.Common.Misc;
using BitDiffer.ReportGenerator.Xml;
using System.Xml.Serialization;

namespace BitDiffer.ReportGenerator
{
    /// <summary>
    /// XmlReport class
    /// </summary>
    public class XmlReport
    {
        public static void Generate(string filePath, AssemblyComparison assemblyComparison)
        {
            using (FileStream fs = File.Open(filePath, FileMode.Create))
            {
                ArrayOfChangedNode arrayOfChangedNode = new ArrayOfChangedNode(assemblyComparison);

                XmlSerializer xs = new XmlSerializer(arrayOfChangedNode.GetType());
                xs.Serialize(fs, arrayOfChangedNode);
            }
        }
    }
}
