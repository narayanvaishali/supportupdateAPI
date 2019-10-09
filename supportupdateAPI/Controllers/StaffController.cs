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
    public class StaffController : Controller
    {
        private readonly ISupportStaffProvider _staffProvider;

        public StaffController(ISupportStaffProvider staffProvider)
        {
            _staffProvider = staffProvider;
        }

        [Route("getstaffdetails")]
        [HttpGet]
        public IActionResult Get(int staffid)
        {
            return  Ok(_staffProvider.GetSupportStaffDetails(staffid));
        }

        [Route("addeditstaff")]
        [HttpPost]
        public IActionResult Post([FromBody]SupportStaffType staff)
        {
            return  Ok(_staffProvider.AddEditStaff(staff));
        }

        [Route("deletestaff")]
        [HttpDelete]
        public IActionResult Delete(int staffid)
        {
            return Ok(_staffProvider.DeleteStaff(staffid));

        }

    }
   
}