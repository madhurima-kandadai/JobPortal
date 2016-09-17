using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobPortal.Entities;

namespace JobPortal.Services.Interfaces
{
    public interface ILoginService
    {
        bool GetUser(string mailId);
    }
}
