using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobPortal.Entities;
using JobPortal.Models;
using JobPortal.Services.Interfaces;

namespace JobPortal.Services.Services
{
    public class JobService : IJobService
    {
        JobModel dbModel;
        public JobService()
        {
            dbModel = new JobModel();
        }

        public List<JobDetailsModel> GetAllJobs()
        {
            var jobs = dbModel.Jobs.AsQueryable();
            var users = dbModel.AspNetUsers.AsQueryable();
            var query = (from user in users
                         join job in jobs on user.Id equals job.RecruiterId
                         select new JobDetailsModel
                         {
                             Id = job.Id,
                             RecruiterId = job.RecruiterId,
                             LastDate = job.LastDate,
                             JobDescription = job.JobDescription,
                             RecruiterName = user.Email,
                             JobTitle = job.JobTitle,
                             CreatedDate = job.CreatedDate
                         }).ToList();
            return query;
        }

        public Job GetJobDetails(int jobId)
        {
            return dbModel.Jobs.FirstOrDefault(x => x.Id == jobId);
        }

        public void DeleteJob(int jobId)
        {
            var jobSubmissions = dbModel.JobSubmissions.Where(x => x.JobId == jobId).ToList();
            var jobs = dbModel.Jobs.Where(x => x.Id == jobId).ToList();
            dbModel.JobSubmissions.RemoveRange(jobSubmissions);
            dbModel.Jobs.RemoveRange(jobs);
            dbModel.SaveChanges();
        }

        public void AddJob(JobDetailsModel jobDetails)
        {
            var job = new Job
            {
                JobDescription = jobDetails.JobDescription,
                JobTitle = jobDetails.JobTitle,
                CreatedDate = DateTime.Now,
                LastDate = DateTime.Now.AddDays(10)
            };
            job.RecruiterId = dbModel.AspNetUsers.FirstOrDefault(x => x.Email == jobDetails.RecruiterName).Id;
            dbModel.Jobs.Add(job);
            dbModel.SaveChanges();
        }

        public void UpdateJob(Job job)
        {

            dbModel.Jobs.Attach(job);
            dbModel.SaveChanges();
        }

        public void ApplyJob(JobSubmissionModel jobSubmission)
        {
            var submission = new JobSubmission
            {
                AppliedDate = DateTime.Now,
                JobId = jobSubmission.Id,
                StatusId = 1
            };
            submission.SeekerId = dbModel.AspNetUsers.FirstOrDefault(x => x.Email == jobSubmission.SeekerName).Id;
            dbModel.JobSubmissions.Add(submission);
            dbModel.SaveChanges();
        }

        public List<JobSubmissionModel> GetSubmissions(string seekerId)
        {
            var users = dbModel.AspNetUsers.AsQueryable();
            var jobs = dbModel.Jobs.AsQueryable();
            var jobStatus = dbModel.JobStatus.AsQueryable();
            var jobsubmissions = dbModel.JobSubmissions.AsQueryable();
            var query = (from user in users
                        join job in jobs on user.Id equals job.RecruiterId
                        join jobSub in jobsubmissions on job.Id equals jobSub.JobId
                        join stat in jobStatus on jobSub.StatusId equals stat.Id
                        where user.Email == seekerId
                        select new JobSubmissionModel
                        {
                            Id = jobSub.Id,
                            JobDescription = job.JobDescription,
                            AppliedDate = jobSub.AppliedDate                            
                        }).ToList();                     
            return query;
        }

        public List<JobDetailsModel> GetJobsByRecruiter(string recruiterId)
        {
            var jobs = dbModel.Jobs.AsQueryable();
            var users = dbModel.AspNetUsers.AsQueryable();
            var query = (from user in users
                         join job in jobs on user.Id equals job.RecruiterId
                         where job.RecruiterId == recruiterId
                         select new JobDetailsModel
                         {
                             Id = job.Id,
                             RecruiterId = job.RecruiterId,
                             LastDate = job.LastDate,
                             JobDescription = job.JobDescription,
                             RecruiterName = user.Email,
                             JobTitle = job.JobTitle,
                             CreatedDate = job.CreatedDate
                         }).ToList();
            return query;            
        }

        public List<JobSubmissionModel> GetJobSubmissionsByRecruiter(string recruiterId)
        {
            return null;
        }
    }
}
