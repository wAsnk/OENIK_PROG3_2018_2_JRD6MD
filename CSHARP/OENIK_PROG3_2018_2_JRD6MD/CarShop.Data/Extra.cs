//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace CarShop.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Extra
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Extra()
        {
            this.ModelExtraswitches = new HashSet<ModelExtraswitch>();
        }
    
        public decimal Extra_Id { get; set; }
        public string Extra_Category_Name { get; set; }
        public string Extra_Name { get; set; }
        public decimal Extra_Price { get; set; }
        public string Extra_Color { get; set; }
        public decimal Extra_Multiple_Usage { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ModelExtraswitch> ModelExtraswitches { get; set; }
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member