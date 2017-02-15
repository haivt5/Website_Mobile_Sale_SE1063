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
    
    public partial class ShoppingCart
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ShoppingCart()
        {
            this.CartDetails = new HashSet<CartDetail>();
        }
    
        public int Id { get; set; }
        public int AccountID { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; }
        public decimal Total { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
    
        public virtual Account Account { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CartDetail> CartDetails { get; set; }
    }
}
