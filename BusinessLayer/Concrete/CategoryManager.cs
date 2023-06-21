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
		
        public void CategoryAdd(Category category) 
        {
            //Container yapılanması ile ilgili			//var services = new ServiceCollection();
            //services.AddTransient<ICategoryDal, EFCategoryRepository>();

            //// ICategoryService için CategoryManager sınıfını eklemek
            //services.AddTransient<ICategoryService, CategoryManager>();

            //// IServiceProvider oluşturulması
            //var serviceProvider = services.BuildServiceProvider();

            //// CategoryManager'ı ICategoryService bağımlılığıyla oluşturmak için IServiceProvider'dan nesneyi çekme
            //var categoryManager = serviceProvider.GetService<ICategoryDal>();
            //         categoryManager.Insert(category);

            _categoryDal.Insert(category);
        }

        public void CategoryDelete(Category category)
        {
            _categoryDal.Delete(category);
        }

        public void CategoryUpdate(Category category)
        {
            _categoryDal.Update(category);
        }

        public Category GetByID(int id)
        {
            return _categoryDal.GetByID(id);
        }

        public List<Category> GetList()
        {
            return _categoryDal.GetListAll();
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
    }
}
