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
    
    public partial class Teams
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Teams()
        {
            this.Coaches = new HashSet<Coaches>();
            this.Players = new HashSet<Players>();
        }
    
        public int ID { get; set; }
        public int Season { get; set; }
        public int Category { get; set; }
        public string Name { get; set; }
        public int TrainingDay1 { get; set; }
        public System.TimeSpan TrainingTime1 { get; set; }
        public Nullable<int> TrainingDay2 { get; set; }
        public Nullable<System.TimeSpan> TrainingTime2 { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Coaches> Coaches { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Players> Players { get; set; }
    }
}