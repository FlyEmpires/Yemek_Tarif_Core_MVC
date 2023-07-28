using EntityLayer.Concrete;
using EntityLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
   public interface IReceipeDal:IGenericDal<Recipe>
    {
        List<Recipe> GetListWithCategoryAndWriter();
        List<Recipe> GetListWithCategoryByWriter(int id);  // Yazarın kendi panelinde görebileceği, kendi yemeklerinin listelenmesini sağlayan metod

        int GetCommentCountByRecipe(int id);
    }
}
