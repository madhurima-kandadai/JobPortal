using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Models
{
    public class JobDetailsModel
    {
        public int Id { get; set; }

        public string RecruiterId { get; set; }
        public string RecruiterName { get; set; }

        public string JobTitle { get; set; }

        public string JobDescription { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? LastDate { get; set; }
    }
}
