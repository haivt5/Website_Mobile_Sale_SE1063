﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website_Mobile_Sale_SE1063.Models.ViewModels
{
    public class AccountInfoViewModel
    {
        public int Id;
        public string Name;
        public string Address;
        public string UserId;

        public AspNetUserViewModel AspNetUser;
        public List<AspNetRoleViewModel> AspNetRoles;
    }
}