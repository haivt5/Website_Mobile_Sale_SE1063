using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website_Mobile_Sale_SE1063.Models.ViewModels;
using Website_Mobile_Sale_SE1063.Models.Services;

namespace Website_Mobile_Sale_SE1063.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        public ActionResult Cart(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
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
    }
}