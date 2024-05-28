using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IUserService:IGenericService<AppUser>
    {
        int TotalRecipeCountByWriter(int id); //dashboard tarafında yazara ait toplam yemek sayısını getirir.

    }
}
