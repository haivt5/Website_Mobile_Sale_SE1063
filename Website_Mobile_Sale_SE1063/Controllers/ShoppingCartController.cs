using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website_Mobile_Sale_SE1063.Models.ViewModels;
using Website_Mobile_Sale_SE1063.Models.Services;
using Website_Mobile_Sale_SE1063.Models.Entities;

namespace Website_Mobile_Sale_SE1063.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        public ActionResult Cart()
        {
            
            return View();
        }


        [HttpPost]
        public JsonResult GetCart(int? cartId, string userId)
        {
            ShoppingCartCheckoutViewModel model = new ShoppingCartCheckoutViewModel();
            model.CartDetails = new List<CartDetailViewModel>();
            if (cartId.HasValue)
            {
                IShoppingCartService cartService = new ShoppingCartService();
                ICartDetailService cartDetailService = new CartDetailService();

                List<CartDetail> cartDetails = cartDetailService.GetByCartId(cartId.Value);
                foreach (var item in cartDetails)
                {
                    CartDetailViewModel c = new CartDetailViewModel();
                    c.CartId = item.CartId;
                    c.Id = item.Id;
                    c.Quantity = item.Quantity;
                    c.Total = item.Total;
                    c.Phone = MapperService<Phone, PhoneViewModel>.Map(item.Phone, new PhoneViewModel());
                    model.CartDetails.Add(c);

                }
                model.Total = cartDetails.Sum(q => q.Total).Value;
            } else if (userId != null)
            {
                IShoppingCartService cartService = new ShoppingCartService();
                ICartDetailService cartDetailService = new CartDetailService();

                List<CartDetail> cartDetails = cartDetailService.GetByUserId(userId);
                foreach (var item in cartDetails)
                {
                    CartDetailViewModel c = new CartDetailViewModel();
                    c.CartId = item.CartId;
                    c.Id = item.Id;
                    c.Quantity = item.Quantity;
                    c.Total = item.Total;
                    c.Phone = MapperService<Phone, PhoneViewModel>.Map(item.Phone, new PhoneViewModel());
                    model.CartDetails.Add(c);

                }
                model.Total = cartDetails.Sum(q => q.Total).Value;
            }

            return Json(model);
        }

        [HttpPost]
        public JsonResult Create(ShoppingCartCreateViewModel model)
        {
            IShoppingCartService service = new ShoppingCartService();
            try
            {
                if (model.AccountID == null) {
                    IAspNetUserService userService = new AspNetUserService();
                    model.AccountID = userService.GetIdByEmail(User.Identity.Name);
                }
                int id = service.Create(model);
                return Json(new {
                    Success = true,
                    CartId = id,
                });
            }
            catch (Exception e)
            {
                return Json(new {
                    Success = false,
                    Error = e.Message,
                });
            }
            
        }

        [HttpPost]
        public JsonResult Add(int cartId, int phoneId, int quantity)
        {
            IShoppingCartService cartService = new ShoppingCartService();
            try
            {
                int id = cartService.Add(cartId, phoneId, quantity);
                return Json(new {
                    Success = true,
                    Id = id
                });
            }
            catch (Exception e)
            {
                return Json(new {
                    Success = false,
                    Error = e.Message
                });
            }
        }


        [HttpPost]
        public JsonResult Update(int cartId, int phoneId, int quantity)
        {
            IShoppingCartService cartService = new ShoppingCartService();
            try
            {
                int id = cartService.Update(cartId, phoneId, quantity);
                return Json(new
                {
                    Success = true,
                    Id = id
                });
            }
            catch (Exception e)
            {
                return Json(new
                {
                    Success = false,
                    Error = e.Message
                });
            }
        }


        [HttpPost]
        public JsonResult RemoveCart(int cartId)
        {
            IShoppingCartService cartService = new ShoppingCartService();
            try
            {
                bool result = cartService.RemoveCart(cartId);
                return Json(new
                {
                    Success = true,
                });
            }
            catch (Exception e)
            {
                return Json(new
                {
                    Success = false,
                    Error = e.Message
                });
            }
        }


    }
}