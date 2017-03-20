using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Website_Mobile_Sale_SE1063.Models.Entities;
using Website_Mobile_Sale_SE1063.Models.ViewModels;
using AutoMapper;

namespace Website_Mobile_Sale_SE1063.Models.Services
{
    
    public interface IPhoneService
    {
        List<PhoneViewModel> GetAll();
        PhoneViewModel GetById(int id);
        List<Phone> GetByCategoryId(int categoryId);
        List<Phone> GetAllGroupByCategory();
        List<PhoneViewModel> GetNewPhones();
        List<PhoneViewModel> GetByPriceRange(int from, int to);
    }

    public class PhoneService : IPhoneService
    {
        private WebEntitiyManager entites = new WebEntitiyManager();

        public List<PhoneViewModel> GetAll()
        {
            List<Phone> products = this.entites.Phones.AsQueryable().ToList();
            Mapper.Initialize(c => c.CreateMap<List<Phone>, List<PhoneViewModel>>());
            List<PhoneViewModel> model = Mapper.Map<List<PhoneViewModel>>(products);
            return model;
        }

        public List<Phone> GetAllGroupByCategory()
        {
            var phones = this.entites.Phones.AsEnumerable().OrderBy(q => q.CategoryID).ToList();
            return phones;
        }

        public List<Phone> GetByCategoryId(int categoryId)
        {
            List<Phone> products = this.entites.Phones.Where(q => q.CategoryID == categoryId).AsEnumerable().ToList();
            return products;
        }

        public PhoneViewModel GetById(int id)
        {
            Phone product = this.entites.Phones.SingleOrDefault<Phone>(q => q.Id == id);
            PhoneViewModel model = MapperService<Phone, PhoneViewModel>.Map(product, new PhoneViewModel());
            model.CategoryModel = MapperService<Category, CategoryViewModel>.Map(product.Category, new CategoryViewModel());
            return model;
        }

        public List<PhoneViewModel> GetByPriceRange(int from, int to)
        {
            List<Phone> phones = this.entites.Phones.Where(q => q.Price > from && q.Price <= to)
                .OrderBy(q => q.Price).AsEnumerable().ToList();
            List<PhoneViewModel> model = new List<PhoneViewModel>();
            foreach (var phone in phones)
            {
                model.Add(MapperService<Phone, PhoneViewModel>.Map(phone, new PhoneViewModel()));
            }

            return model;

        }

        public List<PhoneViewModel> GetNewPhones()
        {
            var phones = this.entites.Phones.OrderByDescending(q => q.Id).ToList();
            Mapper.Initialize(c => c.CreateMap<Phone, PhoneViewModel>());
            List<PhoneViewModel> model = new List<PhoneViewModel>();
            foreach (var item in phones)
            {
                model.Add(Mapper.Map<PhoneViewModel>(item));
            }
            return model;
        }
    }
    

}