using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeEmailer.Models
{
    public class Applicant
    {
        public string ApplicantName { get; set; }
        public string ApplicantEmail { get; set; } = ConfigurationManager.AppSettings["ApplicantEmail"];
        public string ApplicantPhoneNo { get; set; }
    }
}
