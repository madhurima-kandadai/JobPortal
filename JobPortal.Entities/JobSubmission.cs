namespace JobPortal.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("JobSubmission")]
    public partial class JobSubmission
    {
        public int Id { get; set; }

        public int? JobId { get; set; }

        [StringLength(128)]
        public string SeekerId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? AppliedDate { get; set; }

        public int? StatusId { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }

        public virtual Job Job { get; set; }

        public virtual JobStatus JobStatu { get; set; }
    }
}
