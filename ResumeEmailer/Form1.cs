using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        }

        private void sendResume_Click(object sender, EventArgs e)
        {
            //Get Addresses: subject
            Helpers helpers = new Helpers();
            List<string> addresses = helpers.GetEmailAddressesAndSubjects();
            //Get body of mail from file
            string emailBody = helpers.GetEmailBody();

            //Get Resume
            string resume = PathGenerator.GetResumePath();
            
            foreach (var address in addresses)
            {
                Emailer emailer = new Emailer();
                emailer.SendEmailGmail(address.Split(':')[0], address.Split(':')[1], emailBody);
            }
        }


        //Get Addresses: subject

        //Get body of mail from file

        //Get CV
    }
}
