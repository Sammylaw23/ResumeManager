using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeEmailer
{
    public class Helpers
    {
        private static string startUpPath = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
        private readonly string addressTextFilePath = Path.Combine(startUpPath, "/Documents/Addresses/Addresses.txt");


        internal List<string> GetEmailAddressesAndSubjects()
        {
            List<string> addresses = new List<string>();

            string addressContent = ReadTextFile(PathGenerator.GetAddressesPath());

            foreach(var address in addressContent.Split(','))
            {
                addresses.Add(address);
            }



            return addresses;
        }



        internal string GetEmailBody()
        {
            string emailBody = ReadTextFile(PathGenerator.GetEmailBodyPath());
            return emailBody;
        }




        private string ReadTextFile(string filePath) {
            string fileContent = string.Empty;

            fileContent = File.ReadAllText(filePath);

            return fileContent;
        }

    }
}
