using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using supportupdateAPI.Models;

namespace supportupdateAPI.DataProvider
{
    public interface ISupportUpdateProvider
    {
        //IEnumerable<SupportUpdateType> GetSupportUpdateDetails(int supportupdateid);
        dynamic GetSupportUpdateDetails(int supportupdateid);

        dynamic AddEditSupportUpdate(SupportUpdateType support);

        dynamic DeleteSupportUpdate(int SupportUpdateID);

        dynamic GetSupportUpdateSummary(int staffid, string dateworked);

        dynamic SendSummaryEmail(SupportSummaryType summary);
    }
}
