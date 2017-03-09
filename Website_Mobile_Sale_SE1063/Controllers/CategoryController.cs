using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website_Mobile_Sale_SE1063.Models.Services;
using Website_Mobile_Sale_SE1063.Models.Entities;
using Newtonsoft.Json;
using AutoMapper;
using Website_Mobile_Sale_SE1063.Models.ViewModels;

namespace Website_Mobile_Sale_SE1063.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetAll()
        {
            ICategoryService service = new CategoryService();
            List<Category> categories = service.GetAll();
            Mapper.Initialize(q => q.CreateMap<Category, CategoryViewModel>());
            List<CategoryViewModel> model = new List<CategoryViewModel>();
            foreach (var item in categories)
            {
                model.Add(Mapper.Map<CategoryViewModel>(item));
            }
            return Json(model);
        }

    }
}