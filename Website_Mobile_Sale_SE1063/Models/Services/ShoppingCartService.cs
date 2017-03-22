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
        int Add(int cartId, int phoneId, int quantity);
        int Update(int cartId, int phoneId, int quantity);
        bool Remove(int cartId, int phoneId);
        bool RemoveCart(int cartId);
        bool Checkout(int cartId, string email);
        bool CompleteCart(int cartId, string userId);
        int UpdateEntireCart(int cartId, List<int> phoneId, List<int> quantity);
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
                var shoppingCart = new ShoppingCart();
                shoppingCart.AccountID = model.AccountID;
                shoppingCart.DateCreated = DateTime.Now;
                shoppingCart.Quantity = model.Quantity;
                shoppingCart.Status = model.Status;
                shoppingCart.Total = model.Total;
                shoppingCart = this.Entities.ShoppingCarts.Add(shoppingCart);
                this.Entities.SaveChanges();
                return shoppingCart.Id;
            }
            catch (Exception e)
            {
                throw e;
            }
        }



        public int Add(int cartId, int phoneId, int quantity)
        {
            CartDetail cartDetail = this.Entities.CartDetails.FirstOrDefault(q => q.CartId == cartId && q.PhoneId == phoneId);
            IPhoneService phoneService = new PhoneService();
            PhoneViewModel phone = phoneService.GetById(phoneId);
            if (phone.Quantity < quantity)
                return -1;
            if (cartDetail != null)
            {
                cartDetail.Quantity += quantity;
                cartDetail.Total = phone.Price * cartDetail.Quantity;

                ShoppingCart cart = this.Entities.ShoppingCarts.SingleOrDefault(q => q.Id == cartId);
                cart.Quantity += cartDetail.Quantity.Value;
                cart.Total += cartDetail.Total.Value;
            }
            else
            {
                CartDetail c = new CartDetail();
                c.CartId = cartId;
                c.PhoneId = phoneId;
                c.Quantity = quantity;
                c.Total = phone.Price * quantity;
                cartDetail = this.Entities.CartDetails.Add(c);

                ShoppingCart cart = this.Entities.ShoppingCarts.SingleOrDefault(q => q.Id == cartId);
                cart.Quantity += c.Quantity.Value;
                cart.Total += c.Total.Value;
            }
            try
            {
                this.Entities.SaveChanges();
                return cartDetail.Id;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int Update(int cartId, int phoneId, int quantity)
        {
            IPhoneService phoneService = new PhoneService();
            PhoneViewModel phone = phoneService.GetById(phoneId);
            if (phone.Quantity < quantity)
                return -1;
            ShoppingCart cart = this.Entities.ShoppingCarts.SingleOrDefault(q => q.Id == cartId);
            CartDetail cartDetail = this.Entities.CartDetails
                .SingleOrDefault<CartDetail>(q => q.CartId == cartId && q.PhoneId == phoneId);

            cart.Quantity = cart.Quantity - cartDetail.Quantity.Value + quantity;
            cart.Total -= cartDetail.Total.Value;

            
            cartDetail.Quantity = quantity;
            cartDetail.Total = phone.Price * quantity;

            cart.Total += cartDetail.Total.Value;
            try
            {
                this.Entities.SaveChanges();
                return cartDetail.Id;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool Remove(int cartId, int phoneId)
        {
            ShoppingCart cart = this.Entities.ShoppingCarts.SingleOrDefault(q => q.Id == cartId);
            CartDetail cartDetail = this.Entities.CartDetails
                .SingleOrDefault<CartDetail>(q => q.CartId == cartId && q.PhoneId == phoneId);
            try
            {
                CartDetail removedCart = this.Entities.CartDetails.Remove(cartDetail);
                cart.Quantity -= cartDetail.Quantity.Value;
                cart.Total -= cartDetail.Total.Value;
                this.Entities.SaveChanges();
                return removedCart != null;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public bool RemoveCart(int cartId)
        {
            try
            {
                var cartDetail = this.Entities.CartDetails
                    .Where<CartDetail>(q => q.CartId == cartId).AsEnumerable();
                this.Entities.CartDetails.RemoveRange(cartDetail);
                this.Entities.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool Checkout(int cartId, string email)
        {
            ShoppingCart cart = this.Entities.ShoppingCarts.SingleOrDefault(q => q.Id == cartId);
            IAspNetUserService userService = new AspNetUserService();
            cart.AccountID = userService.GetIdByEmail(email);
            cart.Status = "checkout";
            try
            {
                this.Entities.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool CompleteCart(int cartId, string userId)
        {
            try
            {
                ShoppingCart cart = this.Entities.ShoppingCarts.SingleOrDefault(q => q.Id == cartId);
                cart.Status = "Complete";
                cart.AccountID = userId;
                this.Entities.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }

        public int UpdateEntireCart(int cartId, List<int> phoneId, List<int> quantity)
        {
            List<CartDetail> cartDetails = this.Entities.CartDetails.Where(q => q.CartId == cartId).ToList();
            for (int i = 0; i < cartDetails.Count; i++)
            {
                int pos = phoneId.IndexOf(cartDetails[i].PhoneId.Value);
                if (pos < 0)
                {
                    this.Entities.CartDetails.Remove(cartDetails[i]);
                }
                else
                {
                    cartDetails[i].Quantity = quantity[pos];
                    cartDetails[i].Total = quantity[pos] * cartDetails[i].Phone.Price;
                }
            }
            var cart = this.Entities.ShoppingCarts.SingleOrDefault(q => q.Id == cartId);
            cart.Total = this.Entities.CartDetails.Local.Sum(q => q.Total.Value);
            this.Entities.SaveChanges();
            return cartId;
        }
    }
}