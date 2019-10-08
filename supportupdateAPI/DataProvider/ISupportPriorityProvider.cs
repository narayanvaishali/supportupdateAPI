using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using supportupdateAPI.Models;

namespace supportupdateAPI.DataProvider
{
    public interface ISupportPriorityProvider
    {
        IEnumerable<SupportPriorityType> GetSupportPriorityDetails(int priorityid);

        dynamic AddEditPriority(SupportPriorityType priority);

        dynamic DeletePriority(int priorityid);
    }
}
