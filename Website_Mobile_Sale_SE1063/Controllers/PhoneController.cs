﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Website_Mobile_Sale_SE1063.Models.Services;
using Website_Mobile_Sale_SE1063.Models.ViewModels;

namespace Website_Mobile_Sale_SE1063.Controllers
{
    public class PhoneController : Controller
    {
        // GET: Product
        public ActionResult PhoneList(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        public ActionResult PhoneDetail(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        public ActionResult Product(int id)
        {
            PhoneService service = new PhoneService();
            PhoneViewModel model = service.GetById(id);
            return View(model);
        }
    }
}