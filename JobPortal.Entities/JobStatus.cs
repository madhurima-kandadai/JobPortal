namespace JobPortal.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class JobStatus
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }
    }
}
