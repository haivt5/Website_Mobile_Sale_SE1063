using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website_Mobile_Sale_SE1063.Models.ViewModels
{
    public class ShoppingCartCreateViewModel
    {
        public string AccountID { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; }
        public decimal Total { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
    }
}