using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website_Mobile_Sale_SE1063.Models.ViewModels
{
    public class PhoneViewModel
    {
        public int Id{ get; set; }
        public string Name{ get; set; }
        public int CategoryID{ get; set; }
        public float Capacity{ get; set; }
        public string Color{ get; set; }
        public string ScreenResolution{ get; set; }
        public Nullable<int> RAM{ get; set; }
        public string Platform{ get; set; }
        public int Quantity{ get; set; }
        public string Image{ get; set; }
        public decimal Price{ get; set; }
        public int MyProperty { get; set; }
        public string Description { get; set; }

        public CategoryViewModel CategoryModel{ get; set; }
    }
}