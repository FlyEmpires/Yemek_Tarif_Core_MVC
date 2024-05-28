using BusinessLayer.Abstract;
using DataAccessLayer;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using EntityLayer.ViewModel;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class WriterManager : IWriterService
    {
        IWriterDal _writerDal;
        Context db = new();
        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public List<Writer> GetList()
        {
         return _writerDal.GetListAll();
        }

        public List<Writer> GetWriterByID(int id)
        {
            return _writerDal.GetListAll(x => x.WriterID == id);
        }

        public void TAdd(Writer t)
        {
            _writerDal.Insert(t);
        }

        public void TDelete(Writer t)
        {
            throw new NotImplementedException();
        }

        public Writer TGetByID(int id)
        {
            return _writerDal.GetByID(id);
        }
        public int TotalMessageCount()
        {
            var values = from message in db.Messages select message;
            return values.Count();
        }
        public int? TotalRecipeCount()
        {
            var values = from recipe in db.Recipes select recipe;
            return values.Count();
        }
        //public int TotalRecipeCountByWriter(int id)
        //{
        //    var values = from recipe in db.Recipes where recipe.WriterID == id select recipe;
        //    return values.Count();
        //}
        public int TotalRecipeCountLast7Days()
        {
            var values = (from recipe in db.Recipes select recipe.CreateDate).ToList();
            int count = values.OrderByDescending(x => x.Date).TakeWhile(item => (DateTime.Now - item).Days <= 7).Count();

            /*bu aşağıdaki kod satırında geriye doğru en son tarihten başlayarak bir sıralama yapılıyor ve eğer createdate 7 günden eski ise döngü kırılıp performans açısından olumlu bir sonuç elde ediliyor. Böylelikle tek tek bütün tariflere bakmıyor */
                
            //         var count = 0;
            //         foreach (var item in values.OrderByDescending(x=>x.Date))
            //{
            //	TimeSpan date = DateTime.Now - item;

            //	if (date.Days <= 7)
            //	{
            //		count++;
            //	}
            //	else
            //		break;
            //	if (count == 7)
            //		break;
            //}

            return count;
        }

        public void TUpdate(Writer t)
        {
            _writerDal.Update(t);
        }
       

        //public void WriterAdd(Writer writer)
        //{
        //	_writerDal.Insert(writer);
        //}

        public Writer WriterLogin(Writer p)
        {
            var values = (from writer in db.Writers where writer.WriterMail == p.WriterMail && writer.WriterPassword == p.WriterPassword select writer).FirstOrDefault();
            return values;
        }
        public List<Writer> GetSessionByWriter(string p)
        {
     
            var values = _writerDal.GetListAll(x => x.WriterMail == p);
            return values;
        }
        public string GetWriterMail(string username)
        {
            var values = db.Users.Where(x => x.UserName== username).Select(x => x.Email).FirstOrDefault();
            return values.ToString();
        }
    }
}
