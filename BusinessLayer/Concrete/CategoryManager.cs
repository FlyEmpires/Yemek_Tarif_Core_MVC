using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using EntityLayer.DTO;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;
        //EFCategoryRepository eFCategoryRepository;
        //public CategoryManager()
        //{
        //     eFCategoryRepository = new EFCategoryRepository(); //new anahtar kelimesini kullanılarak bellekte oluşmasını sağlıyor ve sıkı bir bağımlılık yaratıyor
            

        //}

        public CategoryManager(ICategoryDal categoryDal) //dependency injection kullanılarak bağımlılık ortadan kaldırıldı
        {
            _categoryDal = categoryDal;
		}
		
        public static List<CategoryListWithCountDTO> GetListWithCount() //Category Componenti için hangi kategoride kaç tane yemek olduğunu gösteren metod
        {
            Context db = new();
            var values = (from cat in db.Categories
                         select new CategoryListWithCountDTO
                         {
                             CategoryName = cat.CategoryName,
                             CategoryID = cat.CategoryID,
                             RecipeCount = cat.Recipes.Count(),
                             CategoryDescription = cat.CategoryDescription
                         }).ToList();
            return values;
        }

        public Category TGetByID(int id)
        {
           return _categoryDal.GetByID(id);
        }

        public List<Category> GetList()
        {
           return _categoryDal.GetListAll();
        }

        public List<Recipe> GetListWithCategoryDetails(int id)
        {
            return _categoryDal.GetListWithCategoryDetails(id);
        }

        public void TAdd(Category t)
        {
            _categoryDal.Insert(t);
        }

        public void TDelete(Category t)
        {
            _categoryDal.Delete(t);
        }

        public void TUpdate(Category t)
        {
            _categoryDal.Update(t);
        }
    }
}
