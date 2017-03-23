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
using WebApp.Common;
using System.Data.Entity;

namespace Website_Mobile_Sale_SE1063.Controllers
{
    public class AdminController : Controller
    {
        WebEntitiyManager db = new WebEntitiyManager();
        FileUploader up = new FileUploader();
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
        public ActionResult AdminAddNewPhone(Phone phone, HttpPostedFileBase Image)
        {
            //var fileName = Path.GetFileName(fileUpload.FileName);
            //var path = Path.Combine(Server.MapPath("~/Content/images/add_new_phone"), fileName);

            ViewBag.CategoryID = new SelectList(db.Categories.ToList().OrderBy(n => n.Name), "Id", "Name");
           

            if (ModelState.IsValid)
            {
                //phone.Image = Image.FileName;
                db.Phones.Add(phone);
                db.SaveChanges();
            }
            return RedirectToAction("AdminPhoneList");
        }

        [HttpGet]
        public ActionResult AdminEditPhone(int PhoneId)
        {
            Phone phone = db.Phones.SingleOrDefault(n => n.Id == PhoneId);
            if (phone == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(phone);
        }

        [HttpPost]
        public ActionResult AdminEditPhone(Phone phone)
        {
            IPhoneService service = new PhoneService();
            List<PhoneViewModel> model = service.GetAll();

            ViewBag.CategoryID = new SelectList(db.Phones);

            if (ModelState.IsValid)
            {
                int colid = 0;
                List<Color> colors = db.Colors.ToList();
                if (colors.Count > 0)
                    colid = colors.Last().Id + 1;

                col.Id = colid;
                db.Colors.Add(col);
                try
                {
                    db.SaveChanges();
                }

                return RedirectToAction("AdminPhoneList");
            }
        }

        public ActionResult AdminViewDetail(int PhoneId)
        {
            Phone phone = db.Phones.SingleOrDefault(n => n.Id == PhoneId);
            if (phone == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(phone);
        }

        [HttpGet]
        public ActionResult AdminDeletePhone(int PhoneId)
        {
            Phone phone = db.Phones.SingleOrDefault(n => n.Id == PhoneId);
            if (phone == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(phone);
        }

        [HttpPost,ActionName("AdminDeletePhone")]
        public ActionResult ConfirmDelete(int PhoneId)
        {
            Phone phone = db.Phones.SingleOrDefault(n => n.Id == PhoneId);
            if (phone == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.Phones.Remove(phone);
            db.SaveChanges();
            return RedirectToAction("AdminPhoneList");
        }


        //CATEGORY

        //List all categories
        public ActionResult AdminCategoryList(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 10;
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
            return RedirectToAction("AdminCategoryList");
        }

        //Edit category

        [HttpGet]
        public ActionResult AdminEditNewCategory(int CategoryID)
        {
            Category category = db.Categories.Find(CategoryID);
            if (category == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(category);
        }
        [HttpPost]
        public ActionResult AdminEditNewCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("AdminCategoryList");
            }
            return View(category);
        }
        //Delete Category
       [HttpGet]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(category);
        }
        [HttpPost]
        public ActionResult DeleteConfirmedCategory(int categoryId)
        {
            Category category = db.Categories.Find(categoryId);
            db.Categories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("AdminCategoryList");
        }


    }
}