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
    
    public partial class Model
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Model()
        {
            this.ModelExtraswitches = new HashSet<ModelExtraswitch>();
        }
    
        public decimal Model_Id { get; set; }
        public decimal Carbrand_Id { get; set; }
        public string Model_Name { get; set; }
        public Nullable<System.DateTime> Model_Release_Day { get; set; }
        public decimal Model_Engine_Volume { get; set; }
        public decimal Model_Horsepower { get; set; }
        public decimal Model_Base_Price { get; set; }
    
        public virtual CarBrand CarBrand { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ModelExtraswitch> ModelExtraswitches { get; set; }
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member