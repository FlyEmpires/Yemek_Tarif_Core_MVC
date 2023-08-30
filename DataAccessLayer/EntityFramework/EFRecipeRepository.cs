using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using EntityLayer.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFRecipeRepository : GenericRepository<Recipe>, IReceipeDal
    {
        public List<Recipe> GetListWithCategoryAndWriter()
        {
            using (var ctx=new Context())
            {
                return ctx.Recipes.Include(x => x.Category).Include(x=>x.AppUser).ToList();
            }
        }

        public int GetCommentCountByRecipe(int id)
        {
            using (var ctx = new Context())
            {
                var comments = (from cmnt in ctx.Comments where cmnt.RecipeID == id select cmnt).Count();
                return comments;
            }
        }

        public List<Recipe> GetListWithCategoryByWriter(int id)
        {
            using (var ctx = new Context())
            {
                return ctx.Recipes.Include(x => x.Category).Where(x => x.AppUserID==id).ToList();
            }
        }
    }
}
