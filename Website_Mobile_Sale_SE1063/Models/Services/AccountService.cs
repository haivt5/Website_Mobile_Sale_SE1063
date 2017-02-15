using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Website_Mobile_Sale_SE1063.Models.Entities;
using Website_Mobile_Sale_SE1063.Models.ViewModels;

namespace Website_Mobile_Sale_SE1063.Models.Services
{
    public class AccountService 
    {
        private WebEntitiyManager entites;

        public AccountService()
        {
            this.entites = new WebEntitiyManager();
        }

        public List<Account> GetAll()
        {
            return this.entites.Accounts.AsQueryable().ToList();
        }

        public Account GetById(int id)
        {
            return this.entites.Accounts.SingleOrDefault(q => q.Id == id);
        }

        public int Create(AccountViewModel model)
        {
            Mapper.Initialize(c => c.CreateMap<AccountViewModel, Account>());
            Account account = Mapper.Map<Account>(model);
            var result = this.entites.Accounts.Add(account);
            this.entites.SaveChanges();
            return result.Id;
        }
    }
}