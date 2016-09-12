namespace JobPortal.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class JobModel : DbContext
    {
        public JobModel()
            : base("name=JobModel")
        {
        }

        public virtual DbSet<Job> Jobs { get; set; }
        public virtual DbSet<JobRole> JobRoles { get; set; }
        public virtual DbSet<JobStatus> JobStatus { get; set; }
        public virtual DbSet<JobSubmission> JobSubmissions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
