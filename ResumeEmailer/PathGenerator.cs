using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResumeEmailer
{
    public class PathGenerator
    {
        //string targetPath = sourceRootFolder + '/' + "ProcessedSchedules";
        //var newFileName = Path.Combine(destinationPath, Path.GetFileNameWithoutExtension(file) + DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(file));

        //private static string startUpPath = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
        private static string startUpPath = Application.StartupPath;
        private readonly string applicationsFilePath = Path.Combine(startUpPath, "/Documents/Addresses/Addresses.txt");

        public static string GetAddressesPath()
        {
           var temp = Application.StartupPath + @"\Documents\Addresses\Addresses.txt";
           //var temp2 = Path.GetFullPath(Path.Combine(startUpPath2, "../Documents/Addresses/Addresses.txt"));
            return temp;
        }

        public static string GetEmailBodyPath()
        {
            return startUpPath + @"\Documents\EmailBody\EmailBody.txt";
            //return Path.Combine(startUpPath, "/Documents/EmailBody/EmailBody.txt");
        }

        public static string GetOfferLetterPath()
        {
            return startUpPath + @"\Documents\OfferLetter.txt";
        }

        public static string GetResumePath()
        {
            return startUpPath + @"\Documents\Resume\";
            //return Path.Combine(startUpPath, "/Documents/Resume/Resume.txt");
        }

        public static string GetApplicationFilePath()
        {
            return startUpPath + @"\Documents\Applications\";
        }


    }
}
