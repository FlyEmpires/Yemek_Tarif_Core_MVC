using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using EntityLayer.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class RecipeManager : IRecipeService
    {
        IReceipeDal _recipeDal;

        public RecipeManager(IReceipeDal recipeDal)
        {
            _recipeDal = recipeDal;
        }

        public Recipe TGetByID(int id)
        {
            return _recipeDal.GetByID(id);
        }
        public List<Recipe> GetRecipeByID(int id) 
        {
            return _recipeDal.GetListAll(x => x.ReceipeID == id);
        }
        public int Getdate(int id) // Bir tarifin dakika cinsinden ne kadar önce yayınlandığını gösterir
        {
           var value= _recipeDal.GetListAll(x => x.ReceipeID == id).FirstOrDefault();
            var date = DateTime.Now- value.CreateDate;
            var Minutes = date.Minutes;
            return Minutes;
        }
        //      public List<Recipe> GetRecipeByCategoryID(int id)
        //      {
        //		return _recipeDal.GetListAll(x => x.CategoryID == id);
        //	//using (var ctx = new Context())
        //	//{
        //	//    return ctx.Recipes.Include(x => x.Category).ToList();
        //	//}
        //}
        //     public List<Recipe> GetRecipeCategoryWithInclude()
        //     {
        //         using (var ctx=new Context())
        //         {
        //       return ctx.Recipes.Include(x => x.Category).ToList();

        //}
        //     }
        public List<Recipe> GetList()
        {
            return _recipeDal.GetListAll();
        }
        public List<Recipe> GetListWithCategoryByWriterRM(int id)
        {
            return _recipeDal.GetListWithCategoryByWriter(id);
        }
        public List<Recipe> GetListWithCategoryAndWriter()
        {
            return _recipeDal.GetListWithCategoryAndWriter();
        }

        public List<Recipe> GetRecipeListWithWriter(int id)
        {
            return _recipeDal.GetListAll(x => x.AppUserID == id);

        }

        public int GetCommentCountByRecipe(int id)
        {
            return _recipeDal.GetCommentCountByRecipe(id);
        }
        public List<Recipe> GetLast3Recipes()
        {
            return _recipeDal.GetListAll().Take(3).ToList();
        }

        public void TAdd(Recipe t)
        {
            _recipeDal.Insert(t);
        }

        public void TDelete(Recipe t)
        {
            _recipeDal.Delete(t);
        }

        public void TUpdate(Recipe t)
        {
            _recipeDal.Update(t);
        }
    }
}
