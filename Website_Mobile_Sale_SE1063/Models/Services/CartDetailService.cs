using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Website_Mobile_Sale_SE1063.Models.Entities;
using Website_Mobile_Sale_SE1063.Models.ViewModels;
using AutoMapper;

namespace Website_Mobile_Sale_SE1063.Models.Services
{

    public interface ICartDetailService
    {
        List<CartDetail> GetAll();
        CartDetail GetById(int id);
        List<CartDetail> GetByCartId(int cartId);
        List<CartDetail> GetByUserId(string userId);
    }

    public class CartDetailService : ICartDetailService
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

        public List<CartDetail> GetByUserId(string userId)
        {
            List<CartDetail> orderDetails = 
                this.entities.CartDetails.Where(c => c.ShoppingCart.AccountID == userId).ToList();
            return orderDetails;
        }
    }
}