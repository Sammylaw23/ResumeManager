using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeEmailer
{
    public class PathGenerator
    {
        private static string startUpPath = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);

        public static string GetAddressesPath() => Path.Combine(startUpPath, "/Documents/Addresses/Addresses.txt");


        public static string GetEmailBodyPath()
        {
            return Path.Combine(startUpPath, "/Documents/EmailBody/EmailBody.txt");
        }

        public static string GetOfferLetterPath()
        {
            return Path.Combine(startUpPath, "/Documents/OfferLetter/OfferLetter.txt");
        }

        public static string GetResumePath()
        {
            return Path.Combine(startUpPath, "/Documents/Resume/Resume.txt");
        }


    }
}
