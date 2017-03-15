using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Website_Mobile_Sale_SE1063.Models.Entities;

namespace Website_Mobile_Sale_SE1063.Models.Services
{

    public interface IAspNetUserService
    {
        List<AspNetUser> GetAll();
        List<AspNetRole> GetRoleById(string id);
        string GetIdByEmail(string email);
        AspNetUser GetByEmail(string email);
    }

    public class AspNetUserService : IAspNetUserService
    {
        private WebEntitiyManager entities;

        public AspNetUserService()
        {
            this.entities = new WebEntitiyManager();
        }

        public List<AspNetUser> GetAll()
        {
            return this.entities.AspNetUsers.AsEnumerable().ToList();
        }

        public AspNetUser GetByEmail(string email)
        {
            if (email == null || email == "")
                return null;
            return this.entities.AspNetUsers.SingleOrDefault(q => q.Email == email);
        }

        public string GetIdByEmail(string email)
        {
            if (email == null || email == "")
                return "Anonymous";
            return this.entities.AspNetUsers.SingleOrDefault(q => q.Email == email).Id;
        }


        /// <summary>
        /// Return list of roles of the user
        /// </summary>
        /// <param name="id">Id of the user (type: string - Id in AspNetUser table, not AccountInfo table</param>
        /// <returns>list of roles of the user</returns>
        public List<AspNetRole> GetRoleById(string id)
        {
            var user = this.entities.AspNetUsers.SingleOrDefault(q => q.Id == id);
            return user.AspNetRoles.ToList();
        }
    }
}