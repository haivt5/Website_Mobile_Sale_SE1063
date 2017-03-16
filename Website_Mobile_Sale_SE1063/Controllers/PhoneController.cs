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
            //IPhoneService service = new PhoneService();
            //List<Phone> model = service.GetByCategoryId(categoryId);
            ViewBag.CategoryId = categoryId;
            return View();
        }

        public ActionResult PhoneDetail(int id)
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

        public JsonResult GetAllGroupByCategory()
        {
            IPhoneService service = new PhoneService();
            Phone[] phones = service.GetAllGroupByCategory().ToArray();
            return Json(phones);
        }

        [HttpPost]
        public JsonResult GetHotPhones()
        {
            ICartDetailService cartDetailService = new CartDetailService();
            IPhoneService phoneService = new PhoneService();

            var result = cartDetailService.GetAll().GroupBy(q => q.PhoneId).Select(q => new
            {
                Total = q.Sum(a => a.Quantity),
                Phone = phoneService.GetById(q.Key.Value),
            }).OrderByDescending(q => q.Total).Take(12).AsEnumerable().ToList();

            return Json(result);
        }

        [HttpPost]
        public JsonResult GetNewPhones()
        {
            IPhoneService phoneService = new PhoneService();
            var phones = phoneService.GetNewPhones().ToArray();
            return Json(phones);
        }

        [HttpPost]
        public JsonResult GetPriceIncrease(int categoryId)
        {
            IPhoneService service = new PhoneService();
            List<Phone> phones = service.GetByCategoryId(categoryId).OrderBy(q => q.Price).ToList();
            List<PhoneViewModel> model = new List<PhoneViewModel>();
            foreach (var item in phones)
            {
                model.Add(MapperService<Phone, PhoneViewModel>.Map(item, new PhoneViewModel()));
            }
            return Json(model);
        }

        [HttpPost]
        public JsonResult GetPriceDecrease(int categoryId)
        {
            IPhoneService service = new PhoneService();
            List<Phone> phones = service.GetByCategoryId(categoryId).OrderByDescending(q => q.Price).ToList();
            List<PhoneViewModel> model = new List<PhoneViewModel>();
            foreach (var item in phones)
            {
                model.Add(MapperService<Phone, PhoneViewModel>.Map(item, new PhoneViewModel()));
            }
            return Json(model);
        }




    }
}