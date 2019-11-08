using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using supportupdateAPI.Models;

namespace supportupdateAPI.DataProvider
{
    public interface IEmployeeLoginProvider
    {
        IEnumerable<EmployeeLoginType> GetEmployeeLoginDetails(string email, string pwd);

        dynamic AddEditEmployeeLogin(EmployeeLoginType employee);
    }
}
