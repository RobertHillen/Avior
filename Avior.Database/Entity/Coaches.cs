//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Avior.Database.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Coaches
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Nullable<int> TeamID { get; set; }
    
        public virtual Teams Team { get; set; }
    }
}
