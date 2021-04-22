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

            string addressPath = PathGenerator.GetAddressesPath();
            string addressContent = FileReader.ReadTextFile(addressPath);

            foreach (var address in addressContent.Split(','))
            {
                addresses.Add(address);
                //addresses.Add(address.Split(':')[0]);
            }

            return addresses;
        }



        internal string GetEmailBody()
        {
            string emailBody = FileReader.ReadTextFile(PathGenerator.GetEmailBodyPath());
            return emailBody;
        }

        internal string GetResume(string path)
        {
            var retrievedFile = Directory.GetFiles(path).Where(x => x.ToUpper().Contains("RESUME")).FirstOrDefault();
            return retrievedFile;

            //var retrievedFileContent = FileReader.ReadTextFile(retrievedFile);
            //return retrievedFileContent;




            //var files = from retrievedFile in Directory.EnumerateFiles(archiveDirectory, "*.txt", SearchOption.AllDirectories)
            //            from line in File.ReadLines(retrievedFile)
            //            where line.Contains("Example")
            //            select new
            //            {
            //                File = retrievedFile,
            //                Line = line
            //            };
        }

        internal async Task SaveApplicationsDoneAsync(List<string> applications, string applicationsFilePath)
        {
            //if (File.Exists(applicationsFilePath))
            //    File.AppendAllLines(applicationsFilePath,);
            //else

            using (StreamWriter file = new StreamWriter("Applications.txt"))
            {
                foreach (string application in applications)
                {
                    await file.WriteLineAsync(application);

                }
            }




        }
    }
}
