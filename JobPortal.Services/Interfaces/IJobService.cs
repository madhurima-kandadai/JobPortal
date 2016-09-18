using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobPortal.Entities;
using JobPortal.Models;

namespace JobPortal.Services.Interfaces
{
    public interface IJobService
    {
        List<JobDetailsModel> GetAllJobs();

        Job GetJobDetails(int jobId);

        void DeleteJob(int jobId);

        void AddJob(JobDetailsModel job);

        void UpdateJob(Job job);

        void ApplyJob(JobSubmissionModel jobSubmission);

        List<JobSubmissionModel> GetSubmissions(string seekerId);

        List<JobDetailsModel> GetJobsByRecruiter(string recruiterId);

        List<JobSubmissionModel> GetJobSubmissionsByRecruiter(string recruiterId);
    }
}
