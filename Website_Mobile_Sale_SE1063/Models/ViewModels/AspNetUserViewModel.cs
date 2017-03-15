using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website_Mobile_Sale_SE1063.Models.ViewModels
{
    public class AspNetUserViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public List<AspNetRoleViewModel> Roles { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}