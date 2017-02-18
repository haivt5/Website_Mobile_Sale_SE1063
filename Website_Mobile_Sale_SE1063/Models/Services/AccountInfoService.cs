using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Website_Mobile_Sale_SE1063.Models.Entities;
using Website_Mobile_Sale_SE1063.Models.ViewModels;

namespace Website_Mobile_Sale_SE1063.Models.Services
{
    public class AccountInfoService 
    {
        private WebEntitiyManager entites;

        public AccountInfoService()
        {
            this.entites = new WebEntitiyManager();
        }

        public List<AccountInfo> GetAll()
        {
            return this.entites.AccountInfoes.AsQueryable().ToList();
        }

        public AccountInfo GetById(int id)
        {
            return this.entites.AccountInfoes.SingleOrDefault(q => q.Id == id);
        }

        public int Create(AccountInfoViewModel model)
        {
            Mapper.Initialize(c => c.CreateMap<AccountInfoViewModel, AccountInfo>());
            AccountInfo AccountInfo = Mapper.Map<AccountInfo>(model);
            var result = this.entites.AccountInfoes.Add(AccountInfo);
            this.entites.SaveChanges();
            return result.Id;
        }
    }
}