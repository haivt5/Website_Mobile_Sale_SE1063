using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website_Mobile_Sale_SE1063.Models.ViewModels
{
    public class PhoneViewModel
    {
        public int Id;
        public string Name;
        public CategoryViewModel Category;
        public double Capacity;
        public string Color;
        public string ScreenResolution;
        public int RAM;
        public string Platform;
        public int Quantity;
        public string Image;
    }
}