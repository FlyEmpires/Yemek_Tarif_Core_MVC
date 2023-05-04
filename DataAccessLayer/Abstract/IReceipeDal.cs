using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
   public interface IReceipeDal
    {
        List<Recipe> ListAllCategory();
        void AddReceipe(Recipe receipe);
        void DeleteReceipe(Recipe receipe);
        void UpdateReceipe(Recipe receipe);
        Recipe GetByID(int id);
    }
}
