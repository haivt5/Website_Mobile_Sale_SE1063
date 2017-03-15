using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Website_Mobile_Sale_SE1063.Models.ViewModels;
using Website_Mobile_Sale_SE1063.Models.Entities;
using AutoMapper;

namespace Website_Mobile_Sale_SE1063.Models.Services
{
    public interface ICategoryService
    {
        List<Category> GetAll();
    }

    public class CategoryService : ICategoryService
    {
        private WebEntitiyManager entites = new WebEntitiyManager();

        public List<Category> GetAll()
        {
            List<Category> categories = this.entites.Categories.AsEnumerable().ToList();
            //Mapper.Initialize(c => c.CreateMap<List<Category>, List<CategoryViewModel>>());
            //List<CategoryViewModel> model = Mapper.Map<List<CategoryViewModel>>(categories);
            return categories;
        }
    }
}