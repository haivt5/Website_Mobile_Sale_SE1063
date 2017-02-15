using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website_Mobile_Sale_SE1063.Models.ViewModels
{
    public class CartDetailViewModel
    {
        public int Id;
        public ShoppingCartViewModel Cart;
        public PhoneViewModel Phone;
        public int Quantity;
        public decimal Total;
    }
}