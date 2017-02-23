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

        /// <summary>
        /// Get infomation of an account
        /// </summary>
        /// <param name="id">Id of account (type: int - Id in AccountInfo table, not AspNetUser table)</param>
        /// <returns></returns>
        public AccountInfoViewModel GetById(int id)
        {
            AccountInfo accountInfo = this.entites.AccountInfoes.SingleOrDefault(q => q.Id == id);
            Mapper.Initialize(c => c.CreateMap<AccountInfo, AccountInfoViewModel>());
            AccountInfoViewModel model = Mapper.Map<AccountInfoViewModel>(accountInfo);

            Mapper.Initialize(c => c.CreateMap<List<AspNetUser>, List<AspNetUserViewModel>>());
            List<AspNetRole> roles = new AspNetUserService().GetRoleById(accountInfo.AspNetUser.Id);
            model.AspNetRoles = Mapper.Map<List<AspNetRoleViewModel>>(roles);

            return model;
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