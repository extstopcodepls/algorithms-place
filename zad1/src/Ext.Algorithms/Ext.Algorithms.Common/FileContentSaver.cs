using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ext.Algorithms.Common
{
    public class FileContentSaver
    {
        public static void Save(string content, string fileName)
        {
            fileName = !String.IsNullOrEmpty(fileName) ? fileName : "text.out.txt";

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            File.AppendAllText(fileName, content);
        }
    }
}
