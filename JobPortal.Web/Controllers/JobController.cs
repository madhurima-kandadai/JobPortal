using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobPortal.Entities;
using JobPortal.Models;
using JobPortal.Services.Interfaces;
using Newtonsoft.Json;

namespace JobPortal.Web.Controllers
{
    public class JobController : Controller
    {
        private readonly ILoginService loginService;
        private readonly IJobService jobService;
        public JobController(ILoginService service, IJobService iJobService)
        {
            this.loginService = service;
            this.jobService = iJobService;
        }
        public ActionResult GetUser()
        {
            var mailId = Request.RequestContext.HttpContext.User.Identity.Name;
            var isRecruiter = this.loginService.GetUser(mailId);
            return Json(isRecruiter, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetJobs()
        {
            var mailId = Request.RequestContext.HttpContext.User.Identity.Name;
            var isRecruiter = this.loginService.GetUser(mailId);
            if (isRecruiter)
            {
                return Json(this.jobService.GetJobsByRecruiter(mailId), JsonRequestBehavior.AllowGet);
            }
            var result = this.jobService.GetAllJobs();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public void AddJob(string job)
        {
            var obj = JsonConvert.DeserializeObject<JobDetailsModel>(job);
            obj.RecruiterName = Request.RequestContext.HttpContext.User.Identity.Name;
            this.jobService.AddJob(obj);
        }

        [HttpPost]
        public void UpdateJob(string job)
        {
            var obj = JsonConvert.DeserializeObject<Job>(job);
            this.jobService.UpdateJob(obj);
        }

        [HttpPost]
        public void DeleteJob(int jobId)
        {
            this.jobService.DeleteJob(jobId);
            //return null;
        }

        [HttpPost]
        public void ApplyJob(string job)
        {
            var obj = JsonConvert.DeserializeObject<JobSubmissionModel>(job);
            obj.SeekerName = Request.RequestContext.HttpContext.User.Identity.Name;
            this.jobService.ApplyJob(obj);
        }
    }
}