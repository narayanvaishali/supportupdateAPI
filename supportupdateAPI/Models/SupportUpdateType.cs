using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace supportupdateAPI.Models
{
    public partial class SupportUpdateType
    {

        [Key]
        public int SupportUpdateID { get; set; }
        public int ZD_ID { get; set; }
        public string ZD_Descr { get; set; }

        public int PriorityID { get; set; }
        public int CurrentStatusID { get; set; }
        public int TimeSpent { get; set; }
        //public DateTime DateWorked { get; set; }

        [DataType(DataType.Date)]
        [JsonConverter(typeof(JsonDateConverter))]
        public DateTime? DateWorked { get; set; }

        public int ClientID { get; set; }

        public int StaffID { get; set; }
        public string Staff_Email { get; set; }
    }

    class JsonDateConverter : IsoDateTimeConverter
    {
        public JsonDateConverter()
        {
            DateTimeFormat = "yyyy-MM-dd";
        }
    }
}
