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
    public class StatusController : Controller
    {
        private readonly ISupportStatusProvider _statusProvider;

        public StatusController(ISupportStatusProvider statusProvider)
        {
            _statusProvider = statusProvider;
        }

        [Route("getstatusdetails")]
        [HttpGet]
        public IActionResult Get(int statusid)
        {
            return  Ok(_statusProvider.GetSupportStatusDetails(statusid));
        }

        [Route("addeditstatus")]
        [HttpPost]
        public IActionResult Post([FromBody]SupportStausType status)
        {
            return  Ok(_statusProvider.AddEditStatus(status));
        }

        [Route("deletestatus")]
        [HttpDelete]
        public IActionResult Delete(int statusid)
        {
            return Ok(_statusProvider.DeleteStatus(statusid));

        }

    }
   
}