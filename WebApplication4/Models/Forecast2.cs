//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication4.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Forecast2
    {
        public System.DateTime TheDate { get; set; }
        public string Operation { get; set; }
        public string EquipmentToRig { get; set; }
        public string EquipmentFromRig { get; set; }
        public string Vessels { get; set; }
        public Nullable<int> Personnel { get; set; }
    }
}
