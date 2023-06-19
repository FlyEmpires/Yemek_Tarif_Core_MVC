using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
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

        public Recipe GetByID(int id)
        {
            return _recipeDal.GetByID(id);
        }
        public List<Recipe> GetRecipeByID(int id) 
        {
            return _recipeDal.GetListAll(x => x.ReceipeID == id);
        }

        public List<Recipe> GetList()
        {
            return _recipeDal.GetListAll();
        }

        public List<Recipe> GetRecipeListWithCategory()
        {
            return _recipeDal.GetListWithCategory();
        }

        public void RecipeAdd(Recipe recipe)
        {
            throw new NotImplementedException();
        }

        public void RecipeDelete(Recipe recipe)
        {
            throw new NotImplementedException();
        }

        public void RecipeUpdate(Recipe recipe)
        {
            throw new NotImplementedException();
        }
    }
}
