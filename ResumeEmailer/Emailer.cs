using ResumeEmailer.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace ResumeEmailer
{
    public class Emailer
    {
        /// <summary>
        /// Summary description for Email
        /// </summary>

        string sendFrom, emailServer, emailPort, emailCopy;

        public Emailer()
        {
            sendFrom = ConfigurationManager.AppSettings["EmailSender"];
            emailServer = ConfigurationManager.AppSettings["EmailServer"];
            emailPort = ConfigurationManager.AppSettings["EmailPort"];
            emailCopy = ConfigurationManager.AppSettings["EmailInCopy"];
        }

        public string SendEmailHTML(string sender, string recipient, string EmSuj, string EmMsg)
        {
            MyLogger.LogError("About to send eamil to " + recipient + " for " + EmSuj);

            System.Net.Mail.MailAddress AddressFrom = new MailAddress(sender, "GAPS");
            System.Net.Mail.MailAddress AddressTo = new MailAddress(recipient);
            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage(AddressFrom, AddressTo);
            msg.To.Add(recipient);
            msg.Subject = EmSuj;
            msg.IsBodyHtml = true;
            msg.Body = EmMsg;

            string sent = "Succeed";
            using (SmtpClient sendmail = new SmtpClient())
            {
                try
                {

                    sendmail.Host = ConfigurationManager.AppSettings["EmailServer"];
                    sendmail.Send(msg);

                    return sent;

                }
                catch (SmtpFailedRecipientException ex)
                {
                    return ex.Message;
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }


            }


        }

        public string SendMessage(string sendTo, string copyTo, string sendSubject, string sendMessage)
        {
            //String StartUpPath = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            try
            {
                // create the email message
                MailMessage message = new MailMessage(sendFrom, sendTo, sendSubject, sendMessage);
                message.IsBodyHtml = true;
                //string sFileName = HttpContext.Current.Server.MapPath(@"~/dirname/dev.jpg");
                //message.Attachments.Add(new Attachment("C:\\Settlement\\dev.jpeg"));

                MailAddress cc = new MailAddress(copyTo);
                //MailAddress cc2 = new MailAddress(copyTo2);
                //message.To.Add(copyTo2);
                message.CC.Add(cc);
                message.CC.Add(emailCopy);

                // create smtp client at mail server location
                SmtpClient client = new SmtpClient(emailServer);
                // add credentials
                client.UseDefaultCredentials = false;

                // send message
                client.Send(message);

                return "Message sent to " + sendTo + " at " +
                DateTime.Now.ToString() + ".";
            }
            catch (SmtpFailedRecipientException ex)
            {
                MyLogger.LogError(ex.Message);
                //LogHandler.WriteLog("An error occured while mailing the initiator " + sendTo + " : " + ex.Message, "OneOff_Statement_Error");
                return "Error sending to: " + sendTo;
            }
        }

        public string SendMessage(string sendTo, string copyTo, string sendSubject, string sendMessage, string filePath)
        {
            //String StartUpPath = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            try
            {
                // create the email message
                MailMessage message = new MailMessage(sendFrom, sendTo, sendSubject, sendMessage);
                //string sFileName = HttpContext.Current.Server.MapPath(@"~/dirname/dev.jpg");
                message.Attachments.Add(new Attachment(filePath));

                MailAddress cc = new MailAddress(copyTo);
                message.CC.Add(cc);
                message.CC.Add(emailCopy);
                // create smtp client at mail server location
                SmtpClient client = new SmtpClient(emailServer);
                // add credentials
                client.UseDefaultCredentials = false;

                // send message
                client.Send(message);

                return "Message sent to " + sendTo + " at " +
                DateTime.Now.ToString() + ".";
            }
            catch (SmtpFailedRecipientException ex)
            {
                MyLogger.LogError(ex.Message);
                //LogHandler.WriteLog("An error occured while mailing the initiator " + sendTo + " : " + ex.Message, "OneOff_Statement_Error");
                return "Error sending to: " + sendTo;
            }
        }

        public string SendEmail(string recipient, string EmSuj, string EmMsg)
        {
            string sent = "Succeed";
            SmtpClient sendmail = new SmtpClient();

            try
            {
                sendmail.Host = emailServer;
                sendmail.Port = int.Parse(emailPort);
                sendmail.Send(sendFrom, recipient, EmSuj, EmMsg);
                return sent;

            }
            catch (SmtpFailedRecipientException ex)
            {
                MyLogger.LogError(ex.Message);
                return ex.Message;
            }
            //sendmail.Dispose();
        }

        public bool SendEmailGmail(string recipient, string EmailSubject, string htmlString, string nameOfFile, string filePath)
        {
            try
            {
                Applicant applicant = new Applicant();

                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress(applicant.ApplicantEmail);
                message.To.Add(new MailAddress(recipient));
                message.Subject = EmailSubject;
                message.IsBodyHtml = true; //to make message body as html  
                message.Body = htmlString;

                System.Net.Mail.Attachment myAttachment = new System.Net.Mail.Attachment(filePath);
                myAttachment.Name = nameOfFile;
                message.Attachments.Add(myAttachment);

                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com"; //for gmail host  
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(applicant.ApplicantEmail, "Sammylaw2310%");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
                return true;
            }
            catch (Exception ex)
            {
                return false;
                //https://accounts.google.com/DisplayUnlockCaptcha
            }
        }

        public bool SendEmailHtmlMessageAttachment(string sendFrom, string sendTo, string sendSubject, string HtmlMessage, byte[] pdfbytes, string NameofFile, string filePath)
        {
            try
            {
                System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
                message.IsBodyHtml = true;
                message.Body = HtmlMessage;
                message.Subject = sendSubject;

                message.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(HtmlMessage, new System.Net.Mime.ContentType("text/html")));

                AlternateView avHtml = AlternateView.CreateAlternateViewFromString(HtmlMessage, null, MediaTypeNames.Text.Html);

                // Add the alternate views instead of using MailMessage.Body
                MailMessage m = new MailMessage();
                m.AlternateViews.Add(avHtml);

                //message.From = new MailAddress("GTBank E-Statement<" + sendFrom + ">");
                message.From = new MailAddress(sendFrom.Trim());

                foreach (string addr in sendTo.Replace(',', ';').Split(';'))
                {
                    message.To.Add(new MailAddress(addr.Trim()));
                }

                if (pdfbytes != null && pdfbytes.Length > 0)
                {
                    System.Net.Mail.Attachment myAttachment = new System.Net.Mail.Attachment(filePath);
                    myAttachment.Name = NameofFile;
                    message.Attachments.Add(myAttachment);
                }


                // create smtp client at mail server location
                SmtpClient client = new SmtpClient(emailServer);

                // add credentials

                client.UseDefaultCredentials = false;

                // send message
                client.Send(message);

                // message.Attachments.Clear();
                message.Attachments.Dispose();
                client.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                //ErrHandler.LogError("Exception sending Email: " + ex.Message);
                return false;
            }

        }


    }
}


