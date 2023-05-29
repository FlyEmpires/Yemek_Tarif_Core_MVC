using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IRecipeService
    {
        void RecipeAdd(Recipe recipe);
        void RecipeDelete(Recipe recipe);
        void RecipeUpdate(Recipe recipe);
        List<Recipe> GetList();
        Recipe GetByID(int id);
        List<Recipe> GetRecipeListWithCategory();
    }
}
