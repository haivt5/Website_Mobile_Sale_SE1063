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
        public ActionResult Cart(int cartId)
        {
            IShoppingCartService cartService = new ShoppingCartService();
            ICartDetailService cartDetailService = new CartDetailService();

            List<CartDetail> cartDetails = cartDetailService.GetByCartId(cartId);
            ShoppingCartCheckoutViewModel model = new ShoppingCartCheckoutViewModel();
            model.CartDetails = cartDetails;
            model.Total = cartDetails.Sum(q => q.Total).Value;
            return View(model);
        }

        [HttpPost]
        public JsonResult Create(ShoppingCartCreateViewModel model)
        {
            IShoppingCartService service = new ShoppingCartService();
            try
            {
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

        //[HttpPost]
        //public JsonResult Add(int PhoneId, int Quantity)
        //{
            
        //}
    }
}