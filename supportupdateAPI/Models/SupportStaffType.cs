using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace supportupdateAPI.Models
{
    public partial class SupportStaffType
    {

        [Key]
        public int StaffID { get; set; }

        public string StaffName{ get; set; }

        public string StaffEmail { get; set; }

    }

}
