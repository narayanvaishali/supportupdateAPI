using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using supportupdateAPI.Models;

namespace supportupdateAPI.DataProvider
{
    public interface ISupportStaffProvider
    {
        IEnumerable<SupportStaffType> GetSupportStaffDetails(int staffid);

        dynamic AddEditStaff(SupportStaffType staff);

        dynamic DeleteStaff(int staffid);
    }
}
