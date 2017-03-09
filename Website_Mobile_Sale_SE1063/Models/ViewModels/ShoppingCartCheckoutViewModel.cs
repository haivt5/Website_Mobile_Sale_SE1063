using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Website_Mobile_Sale_SE1063.Models.Entities;

namespace Website_Mobile_Sale_SE1063.Models.ViewModels
{
    public class ShoppingCartCheckoutViewModel
    {
        public List<CartDetail> CartDetails { get; set; }
        public decimal Total { get; set; }
    }

}