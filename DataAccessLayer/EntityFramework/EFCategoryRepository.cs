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
   public class EFCategoryRepository:GenericRepository<Category>,ICategoryDal
    {
		public List<Recipe> GetListWithCategoryDetails(int id)
		{
			using (var ctx = new Context())
			{
				return ctx.Recipes.Where(x=>x.CategoryID==id).Include(x => x.Category).ToList();
			}
		}
	}
}
