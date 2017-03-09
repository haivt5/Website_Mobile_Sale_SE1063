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