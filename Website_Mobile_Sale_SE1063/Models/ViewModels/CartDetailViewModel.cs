using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website_Mobile_Sale_SE1063.Models.ViewModels
{
    public class CartDetailViewModel
    {
        public int Id;
        public Nullable<int> CartId;
        public Nullable<int> PhoneId;
        public Nullable<int> Quantity;
        public Nullable<decimal> Total;

        public PhoneViewModel Phone;
        public ShoppingCartViewModel ShoppingCart;
    }
}