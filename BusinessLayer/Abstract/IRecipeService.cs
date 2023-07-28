using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IRecipeService:IGenericService<Recipe>
    {
        //void RecipeAdd(Recipe recipe);
        //void RecipeDelete(Recipe recipe);
        //void RecipeUpdate(Recipe recipe);
        //List<Recipe> GetList();
        //Recipe GetByID(int id);
        List<Recipe> GetListWithCategoryAndWriter();
        List<Recipe> GetRecipeListWithWriter(int id );
        int GetCommentCountByRecipe(int id);
    }
}
