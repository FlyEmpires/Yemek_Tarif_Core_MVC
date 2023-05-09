using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
   public interface IGenericDal<T> where T:class //Somut olarak bir tür belirtmemek için T şeklinde kullanıldı - T yerine herhangi bir şey olabilir <> = generic
    {
        void Insert(T t);
        void Delete(T t);
        void Update(T t);
        List<T> GetListAll();
        T GetByID(int id);

    }
}
