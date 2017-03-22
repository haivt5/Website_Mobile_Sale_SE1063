using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website_Mobile_Sale_SE1063.Models.Entities;
using Website_Mobile_Sale_SE1063.Models.Services;
using Website_Mobile_Sale_SE1063.Models.ViewModels;
using PagedList;
using PagedList.Mvc;
using System.IO;

namespace Website_Mobile_Sale_SE1063.Controllers
{
    public class AdminController : Controller
    {
        WebEntitiyManager db = new WebEntitiyManager();
        public ActionResult AdminPhoneList(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 10;
            return View(db.Phones.ToList().OrderBy(n => n.Category.Name).ToPagedList(pageNumber, pageSize));
        }

        

        //public ActionResult AdminPhoneList(int categoryId)
        //{
        //    IPhoneService service = new PhoneService();
        //    List<Phone> model = service.GetByCategoryId(categoryId);
        //    return View(model);
        //}

        [HttpGet]
        public ActionResult AdminAddNewPhone()
        {
            ViewBag.CategoryID = new SelectList(db.Categories.ToList().OrderBy(n => n.Name), "Id", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult AdminAddNewPhone(Phone phone, string imageURL)
        {
            //var fileName = Path.GetFileName(fileUpload.FileName);
            //var path = Path.Combine(Server.MapPath("~/Content/images/add_new_phone"), fileName);

            ViewBag.CategoryID = new SelectList(db.Categories.ToList().OrderBy(n => n.Name), "Id", "Name");

            if (ModelState.IsValid)
            {
                
                db.Phones.Add(phone);
                db.SaveChanges();
            }
            return View();
        }

        [HttpGet]
        public ActionResult AdminEditPhone(int PhoneId)
        {
            Phone phone = db.Phones.SingleOrDefault(n => n.Id == PhoneId);
            if(phone == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(phone);
        }

        public ActionResult AdminViewDetail(int PhoneId)
        {
            Phone phone = db.Phones.SingleOrDefault(n => n.Id == PhoneId);
            if(phone == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(phone);
        }


        //CATEGORY

        //List all categories
        public ActionResult AdminCategoryList(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 5;
            return View(db.Categories.ToList().OrderBy(n => n.Name).ToPagedList(pageNumber, pageSize));
        }

        //Add new category
        [HttpGet]
        public ActionResult AdminAddNewCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminAddNewCategory(Category category)
        {
            db.Categories.Add(category);
                db.SaveChanges();
            return View();
        }

    }
}