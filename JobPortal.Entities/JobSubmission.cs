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

        public int? SeekerId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? AppliedDate { get; set; }

        public int? Status { get; set; }
    }
}
