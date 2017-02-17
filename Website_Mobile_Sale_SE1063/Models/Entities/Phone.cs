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
    
    public partial class Phone
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Phone()
        {
            this.CartDetails = new HashSet<CartDetail>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryID { get; set; }
        public float Capacity { get; set; }
        public string Color { get; set; }
        public string ScreenResolution { get; set; }
        public Nullable<int> RAM { get; set; }
        public string Platform { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CartDetail> CartDetails { get; set; }
        public virtual Category Category { get; set; }
    }
}