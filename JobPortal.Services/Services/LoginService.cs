using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobPortal.Entities;
using JobPortal.Services.Interfaces;

namespace JobPortal.Services.Services
{
    public class LoginService : ILoginService
    {
        /// <summary>
        /// 
        /// </summary>
        JobModel dbModel;
        public LoginService()
        {
            dbModel = new JobModel();
        }

        public void GetUsers()
        {
            var list = dbModel.Jobs.AsQueryable().AsEnumerable().ToList();
        }

        public bool GetUser(string emailId)
        {
            var roleId = dbModel.AspNetUsers.AsQueryable().AsEnumerable().FirstOrDefault(x => x.Email == emailId).RoleId;
            if (roleId == 1)
            {
                return true;
            }
            return false;
        }
    }
}
