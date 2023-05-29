using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
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
        public List<Recipe> GetListWithCategory()
        {
            using (var ctx=new Context())
            {
                return ctx.Recipes.Include(x => x.Category).ToList();
            }
        }
    }
}
