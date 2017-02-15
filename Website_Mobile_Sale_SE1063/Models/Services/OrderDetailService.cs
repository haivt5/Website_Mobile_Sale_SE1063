using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Website_Mobile_Sale_SE1063.Models.Entities;
using Website_Mobile_Sale_SE1063.Models.ViewModels;

namespace Website_Mobile_Sale_SE1063.Models.Services
{
    public class CartDetailService
    {
        private WebEntitiyManager entities;

        public CartDetailService()
        {
            this.entities = new WebEntitiyManager();
        }

        public List<CartDetail> GetAll()
        {
            return this.entities.CartDetails.AsQueryable().ToList();
        }

        public CartDetail GetById(int id)
        {
            return this.entities.CartDetails.SingleOrDefault(q => q.Id == id);
        }

        public List<CartDetail> GetByCartId(int cartId)
        {
            List<CartDetail> orderDetails = this.entities.CartDetails.Where(c => c.ShoppingCart.Id == cartId).ToList() ;
            return orderDetails;
        }
    }
}