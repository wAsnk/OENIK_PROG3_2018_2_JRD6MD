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
    
    public partial class ModelExtraswitch
    {
        public decimal ModelExtraswitch_Id { get; set; }
        public decimal Model_Id { get; set; }
        public decimal Extra_Id { get; set; }
    
        public virtual Extra Extra { get; set; }
        public virtual Model Model { get; set; }
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member