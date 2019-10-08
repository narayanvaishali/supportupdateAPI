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
    public class PriorityController : Controller
    {
        private readonly ISupportPriorityProvider _priorityProvider;

        public PriorityController(ISupportPriorityProvider priorityProvider)
        {
            _priorityProvider = priorityProvider;
        }

        [Route("getprioritydetails")]
        [HttpGet]
        public IActionResult Get(int statusid)
        {
            return  Ok(_priorityProvider.GetSupportPriorityDetails(statusid));
        }

        [Route("addeditpriority")]
        [HttpPost]
        public IActionResult Post([FromBody]SupportPriorityType priority)
        {
            return  Ok(_priorityProvider.AddEditPriority(priority));
        }

        [Route("deletepriority")]
        [HttpDelete]
        public IActionResult Delete(int priorityid)
        {
            return Ok(_priorityProvider.DeletePriority(priorityid));

        }

    }
   
}