﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website_Mobile_Sale_SE1063.Models.ViewModels
{
    public class CategoryViewModel
    {
        public int Id;
        public string Name;
        public string Description;
        public Nullable<int> ParentId;

        //public ICollection<PhoneViewModel> Phones;
    }
}