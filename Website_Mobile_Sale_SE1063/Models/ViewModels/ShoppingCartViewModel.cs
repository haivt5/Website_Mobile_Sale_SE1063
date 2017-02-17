﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website_Mobile_Sale_SE1063.Models.ViewModels
{
    public class ShoppingCartViewModel
    {
        public int Id;
        public AccountViewModel Account;
        public int Quantity;
        public string Status;
        public decimal Total;
        public DateTime DateCreated;
    }
}