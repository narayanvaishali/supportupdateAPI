using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace supportupdateAPI.Models
{
    public partial class SupportPriorityType
    {

        [Key]
        public int PriorityID { get; set; }

        public string Priority{ get; set; }

    }

}
