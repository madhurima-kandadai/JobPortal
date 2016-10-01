using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Models
{
    public class JobSubmissionModel
    {
        public int Id { get; set; }

        public int? JobId { get; set; }
        
        public string SeekerId { get; set; }
        
        public DateTime? AppliedDate { get; set; }

        public int? StatusId { get; set; }

        public string SeekerName { get; set; }

        public string JobDescription { get; set; }

        public string RecruiterName { get; set; }

        public string JobTitle { get; set; }        
    }
}
