using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Website_Mobile_Sale_SE1063.Models.Entities;

namespace Website_Mobile_Sale_SE1063.Models.Services
{
    public class AspNetUserService
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