using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Website_Mobile_Sale_SE1063.Models.Services;
using Website_Mobile_Sale_SE1063.Models.ViewModels;
using Website_Mobile_Sale_SE1063.Models.Entities;

namespace Website_Mobile_Sale_SE1063.Controllers
{
    public class PhoneController : Controller
    {
        // GET: Product
        //public ActionResult PhoneList(string returnUrl)
        //{
        //    ViewBag.ReturnUrl = returnUrl;
        //    return View();
        //}

        public ActionResult PhoneList(int categoryId)
        {
            IPhoneService service = new PhoneService();
            List<Phone> model = service.GetByCategoryId(categoryId);
            return View(model);
        }

        public ActionResult PhoneDetail(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        public ActionResult Phone(int id)
        {
            IPhoneService service = new PhoneService();
            PhoneViewModel model = service.GetById(id);
            return View(model);
        }

        public JsonResult AllPhone()
        {
            IPhoneService service = new PhoneService();
            service.GetAll();
            return Json(new { });
        }
    }
}