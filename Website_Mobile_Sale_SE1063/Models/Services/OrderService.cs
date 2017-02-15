using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Website_Mobile_Sale_SE1063.Models.Entities;
using Website_Mobile_Sale_SE1063.Models.ViewModels;
using AutoMapper;

namespace Website_Mobile_Sale_SE1063.Models.Services
{
    public class OrderService
    {
        private WebEntitiyManager Entities;

        public OrderService()
        {
            this.Entities = new WebEntitiyManager();
        }

        public List<ShoppingCart> GetAll()
        {
            return this.Entities.ShoppingCarts.AsQueryable().ToList();
        }

        public ShoppingCart GetById(int id)
        {
            return this.Entities.ShoppingCarts.SingleOrDefault(q => q.Id == id);
        }

        /// <summary>
        /// Get order by account id
        /// </summary>
        /// <param name="accountId"> Account id</param>
        /// <returns></returns>
        public List<ShoppingCartViewModel> GetByAccountId(int accountId)
        {
            List<ShoppingCart> orders = this.Entities.ShoppingCarts.Where(c => c.Account.Id == accountId).ToList();
            Mapper.Initialize(c => c.CreateMap<List<ShoppingCart>, List<ShoppingCartViewModel>>());
            return Mapper.Map<List<ShoppingCartViewModel>>(orders);
        }

    }
}