using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Website_Mobile_Sale_SE1063.Models.Entities;
using Website_Mobile_Sale_SE1063.Models.ViewModels;
using AutoMapper;

namespace Website_Mobile_Sale_SE1063.Models.Services
{

    public interface IShoppingCartService
    {
        List<ShoppingCart> GetAll();
        ShoppingCart GetById(int id);
        List<ShoppingCartViewModel> GetByAccountId(string accountId);
        int Create(ShoppingCartCreateViewModel model);
    }

    public class ShoppingCartService : IShoppingCartService
    {
        private WebEntitiyManager Entities;

        public ShoppingCartService()
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

        public List<ShoppingCartViewModel> GetByAccountId(string accountId)
        {
            List<ShoppingCart> orders = this.Entities.ShoppingCarts.Where(c => c.AspNetUser.Id == accountId).ToList();
            Mapper.Initialize(c => c.CreateMap<List<ShoppingCart>, List<ShoppingCartViewModel>>());
            return Mapper.Map<List<ShoppingCartViewModel>>(orders);
        }

        public int Create(ShoppingCartCreateViewModel model)
        {
            try
            {
                Mapper.Initialize(c => c.CreateMap<ShoppingCartCreateViewModel, ShoppingCart>());
                ShoppingCart cart = Mapper.Map<ShoppingCart>(model);
                var shoppingCart = this.Entities.ShoppingCarts.Add(cart);
                this.Entities.SaveChanges();
                return shoppingCart.Id;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}