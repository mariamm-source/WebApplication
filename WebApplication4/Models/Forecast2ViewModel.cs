using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class Forecast2ViewModel
    {
        public System.DateTime TheDate { get; set; }
        public string Operation { get; set; }
        public string EquipmentToRig { get; set; }
        public string EquipmentFromRig { get; set; }
        public string Vessels { get; set; }
        public Nullable<int> Personnel
        {
            get; set;
        }
    }
}