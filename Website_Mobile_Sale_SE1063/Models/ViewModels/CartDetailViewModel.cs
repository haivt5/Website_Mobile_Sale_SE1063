using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website_Mobile_Sale_SE1063.Models.ViewModels
{
    public class CartDetailViewModel
    {
        public int Id { get; set;}
        public int CartId { get; set;}
        public int PhoneId { get; set;}
        public int Quantity { get; set;}
        public decimal Total { get; set;}

        public PhoneViewModel PhoneModel { get; set;}
    }
}