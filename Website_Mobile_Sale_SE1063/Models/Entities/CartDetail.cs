//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Website_Mobile_Sale_SE1063.Models.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class CartDetail
    {
        public int Id { get; set; }
        public Nullable<int> CartId { get; set; }
        public Nullable<int> PhoneId { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<decimal> Total { get; set; }
    
        public virtual ShoppingCart ShoppingCart { get; set; }
        public virtual Phone Phone { get; set; }
    }
}
