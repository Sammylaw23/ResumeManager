using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeEmailer
{
    public class FileReader
    {
        public static string ReadTextFile(string filePath)
        {
            string fileContent = string.Empty;

            fileContent = File.ReadAllText(filePath);

            return fileContent;
        }
    }
}
