using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using supportupdateAPI.DataProvider;
using supportupdateAPI.Models;
using Microsoft.AspNetCore.Cors;
//using System.Web.Http.Routing;

namespace supportupdateAPI.Controllers
{
    [Route("api/[controller]")]

    [ApiController]
    public class EmployeeLoginController : Controller
    {
        private readonly IEmployeeLoginProvider _employeeloginProvider;

        public EmployeeLoginController(IEmployeeLoginProvider employeeloginProvider)
        {
            _employeeloginProvider = employeeloginProvider;
        }

        [Route("getemployeelogindetails")]
        [HttpGet]
        public IActionResult Get(string email, string pwd)
        {
            return Ok(_employeeloginProvider.GetEmployeeLoginDetails(email, pwd));
        }

        [Route("addeditemployeelogin")]
        [HttpPost]
        public IActionResult Post([FromBody]EmployeeLoginType employeelogin)
        {
            return Ok(_employeeloginProvider.AddEditEmployeeLogin(employeelogin));
        }

    }

}