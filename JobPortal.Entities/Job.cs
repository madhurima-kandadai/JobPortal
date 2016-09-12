namespace JobPortal.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Job")]
    public partial class Job
    {
        public int Id { get; set; }

        public int RecruiterId { get; set; }

        [Required]
        [StringLength(100)]
        public string JobTitle { get; set; }

        public string JobDescription { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? LastDate { get; set; }
    }
}
