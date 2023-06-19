using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        Context db = new();
        public void Delete(T t)
        {
            db.Remove(t);
            db.SaveChanges();
        }

        public T GetByID(int id)
        {
            return db.Set<T>().Find(id);
        }

        public List<T> GetListAll()
        {
            return db.Set<T>().ToList();
        }

        public void Insert(T t)
        {
            db.Add(t);
            db.SaveChanges();
        }

        public List<T> GetListAll(Expression<Func<T, bool>> filter)
        {
            return db.Set<T>().Where(filter).ToList();
        }

        public void Update(T t)
        {
            db.Update(t);
            db.SaveChanges();
        }
    }
}
