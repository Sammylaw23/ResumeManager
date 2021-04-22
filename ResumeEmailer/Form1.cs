using ResumeEmailer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResumeEmailer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //When I click the button to send resume, first check if I have sent to the address before, if yes dont send. 
            //        FLag as already sent and write those ones into another file(Duplicate) with date in fromt of them.

            //    Send resume to the address then insert into Audit file for the month that it was successfully sent with date.

        }

        private async void sendResume_ClickAsync(object sender, EventArgs e)
        {
            try
            {
                //Get Addresses: subject
                Helpers helpers = new Helpers();
                Emailer emailer = new Emailer();
                Applicant applicant = new Applicant();
                List<string> applications = new List<string>();

                List<string> addressesAndSubjects = helpers.GetEmailAddressesAndSubjects();
                //Get body of mail from file
                string emailBody = helpers.GetEmailBody();

                //Get Resume
                string resumePath = PathGenerator.GetResumePath();

                var resume = helpers.GetResume(resumePath);
                var tempResumeName = Path.GetFileNameWithoutExtension(resume);

                foreach (var emailHeader in addressesAndSubjects)
                {
                    //emailer.SendEmailHtmlMessageAttachment(applicant.ApplicantEmail, emailHeader.Split(':')[0], emailHeader.Split(':')[1], emailBody, resume, tempResumeName, resumePath);
                    if (emailer.SendEmailGmail(emailHeader.Split(':')[0], emailHeader.Split(':')[1], emailBody, tempResumeName, resume))
                        applications.Add(emailHeader);
                }

                if (applications.Count > 0)
                    await helpers.SaveApplicationsDoneAsync(applications, PathGenerator.GetApplicationFilePath());
                //Get Addresses: subject

                //Get body of mail from file

                //Get CV
            }
            catch (Exception ex)
            {

                throw;
            }

        }



    }
}
