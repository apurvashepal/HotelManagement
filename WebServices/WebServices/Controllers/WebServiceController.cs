using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebServices.Models;

namespace WebServices.Controllers
{
    public class WebServiceController : ApiController
    {
        EmployeeEntities dbcon = new EmployeeEntities();
        public List<EmployeeEntities> EmpList = new List<EmployeeEntities>(); 

        public List<EmployeeEntities> getEmpDetails (int id)
        {
            return dbcon.EmpList.Tolist();
        }
        
    }
}
