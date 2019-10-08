using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using supportupdateAPI.Models;

namespace supportupdateAPI.DataProvider
{
    public interface ISupportStatusProvider
    {
        IEnumerable<SupportStausType> GetSupportStatusDetails(int statusid);

        dynamic AddEditStatus(SupportStausType status);

        dynamic DeleteStatus(int statusid);
    }
}
