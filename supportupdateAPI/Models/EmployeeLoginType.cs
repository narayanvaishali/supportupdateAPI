using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace supportupdateAPI.Models
{
    public partial class EmployeeLoginType
    {

        [Key]
        public int ID { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
        public string EmployeeName { get; set; }

        public int StaffID { get; set; }

    }

}
