using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website_Mobile_Sale_SE1063.Models.ViewModels
{
    public class ShoppingCartDetailViewModel : ShoppingCartViewModel
    {
        public AspNetUserViewModel User { get; set; }
        public List<CartDetailViewModel> CartDetailsModel { get; set; }
    }
}