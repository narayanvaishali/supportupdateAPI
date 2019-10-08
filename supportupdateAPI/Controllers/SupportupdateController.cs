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
    public class SupportupdateController : Controller
    {
        private readonly ISupportUpdateProvider _supportProvider;

        public SupportupdateController(ISupportUpdateProvider supportProvider)
        {
            _supportProvider = supportProvider;
        }

        [Route("supportupdatedetails")]
        [HttpGet]
        public IActionResult Get(int supportupdateid)
        {
            return  Ok(_supportProvider.GetSupportUpdateDetails(supportupdateid));
        }

        [Route("addeditsupportupdate")]
        [HttpPost]
        public IActionResult Post([FromBody]SupportUpdateType support)
        {
            return  Ok(_supportProvider.AddEditSupportUpdate(support));
        }

        [Route("deletesupportupdate")]
        [HttpDelete]
        public async Task Delete(int supportupdateid)
        {
            await this._supportProvider.DeleteSupportUpdate(supportupdateid);

        }
    }
   
}