using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Website_Mobile_Sale_SE1063.Models.Entities;
using Website_Mobile_Sale_SE1063.Models.ViewModels;
using AutoMapper;

namespace Website_Mobile_Sale_SE1063.Models.Services
{
    


    public class PhoneService
    {
        private WebEntitiyManager entites;

        public PhoneService()
        {
            this.entites = new WebEntitiyManager();
        }

        public List<PhoneViewModel> GetAll()
        {
            List<Phone> products = this.entites.Phones.AsQueryable().ToList();
            Mapper.Initialize(c => c.CreateMap<List<Phone>, List<PhoneViewModel>>());
            return Mapper.Map<List<PhoneViewModel>>(products);
        }

        public PhoneViewModel GetById(int id)
        {
            Phone product = this.entites.Phones.SingleOrDefault<Phone>(q => q.Id == id);
            Mapper.Initialize(c => c.CreateMap<Phone, PhoneViewModel>());
            return Mapper.Map<PhoneViewModel>(product);
        }
    }


}