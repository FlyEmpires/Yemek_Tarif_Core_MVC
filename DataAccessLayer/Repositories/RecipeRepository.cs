using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class RecipeRepository : IReceipeDal
    {
        public void AddReceipe(Recipe receipe)
        {
            using var db = new Context();
            db.Add(receipe);
            db.SaveChanges();
        }

        public void DeleteReceipe(Recipe receipe)
        {
            using var db = new Context();
            db.Remove(receipe);
            db.SaveChanges();
        }

        public Recipe GetByID(int id)
        {
            using var db = new Context();
            return db.Recipes.Find(id);
        }

        public List<Recipe> ListAllCategory()
        {
            using var db = new Context();
            return db.Recipes.ToList();
            
        }

        public void UpdateReceipe(Recipe receipe)
        {
            using var db = new Context();
            db.Update(receipe);
            db.SaveChanges();
        }

    }
}
