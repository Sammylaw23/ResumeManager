using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Globalization;

namespace ResumeEmailer
{
    class MyLogger
    {       
     
            public static void LogError(string errorMessage)
            {

                String StartUpPath = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
                try
                {
                    string loc = StartUpPath + "/Error/" + DateTime.Today.ToString("dd-MM-yy");
                    //string path = "Error/" + DateTime.Today.ToString("dd-MM-yy") + ".txt";
                    if (!Directory.Exists(loc))
                    {

                        Directory.CreateDirectory(loc);


                    }

                    string path = loc + "/" + DateTime.Today.ToString("dd-MM-yy") + ".txt";
                    //Check for the file exists, or create a new file     
                    //if (!File.Exists(System.IO.Path.GetFullPath(path)))     
                    //{       
                    //    File.Create(System.IO.Path.GetFullPath(path)).Close();
                    //}
                    using (StreamWriter w = File.AppendText(System.IO.Path.GetFullPath(path)))
                    {        // using the stream writer class write       
                             // log message in a file.        
                        w.WriteLine("\r\nLog Entry : ");
                        w.WriteLine("{0}", DateTime.Now.ToString(CultureInfo.InvariantCulture));
                        string err = "Error Message:" + errorMessage;
                        w.WriteLine(err);
                        w.WriteLine("____________________________________________________________________");
                        w.Flush();
                        w.Close();
                    }
                }
                catch (Exception ex)
                {
                    //LogError(ex.StackTrace);
                }
            }


        public static void WriteToCSV(string errorMessage, string fileName)
        {

            String StartUpPath = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            try
            {
                string loc = StartUpPath + "/Error/" + DateTime.Today.ToString("dd-MM-yy");
                //string path = "Error/" + DateTime.Today.ToString("dd-MM-yy") + ".txt";
                if (!Directory.Exists(loc))
                {

                    Directory.CreateDirectory(loc);


                }

                string path = loc + "/" + DateTime.Today.ToString("dd-MM-yy") + fileName + ".csv";
                //Check for the file exists, or create a new file     
                //if (!File.Exists(System.IO.Path.GetFullPath(path)))     
                //{       
                //    File.Create(System.IO.Path.GetFullPath(path)).Close();
                //}
                using (StreamWriter w = File.AppendText(System.IO.Path.GetFullPath(path)))
                {        // using the stream writer class write       
                         // log message in a file.        
                    //w.WriteLine("\r\nLog Entry : ");
                    //w.WriteLine("{0}", DateTime.Now.ToString(CultureInfo.InvariantCulture));
                   // string err =  errorMessage;
                    w.WriteLine(errorMessage);
                    w.WriteLine("____________________________________________________________________");
                    w.Flush();
                    w.Close();
                }

                            
            }
            catch (Exception ex)
            {
                //LogError(ex.StackTrace);
            }
        }


        public static string WriteSummary(string errorMessage, string fileName)
        {
            string path = string.Empty;
            String StartUpPath = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            try
            {
                string loc = StartUpPath + "/Error/" + DateTime.Today.ToString("dd-MM-yy");
                //string path = "Error/" + DateTime.Today.ToString("dd-MM-yy") + ".txt";
                if (!Directory.Exists(loc))
                {

                    Directory.CreateDirectory(loc);


                }

                path = loc + "/" + DateTime.Today.ToString("dd-MM-yy") + fileName + ".txt";
                //Check for the file exists, or create a new file     
                //if (!File.Exists(System.IO.Path.GetFullPath(path)))     
                //{       
                //    File.Create(System.IO.Path.GetFullPath(path)).Close();
                //}
                using (StreamWriter w = File.AppendText(System.IO.Path.GetFullPath(path)))
                {        // using the stream writer class write       
                         // log message in a file.        
                         //w.WriteLine("\r\nLog Entry : ");
                         //w.WriteLine("{0}", DateTime.Now.ToString(CultureInfo.InvariantCulture));
                         // string err =  errorMessage;
                    w.WriteLine(errorMessage);
                    w.WriteLine("____________________________________________________________________");
                    w.Flush();
                    w.Close();
                }


            }
            catch (Exception ex)
            {
                //LogError(ex.StackTrace);
            }

            return path;
        }



    }



}
