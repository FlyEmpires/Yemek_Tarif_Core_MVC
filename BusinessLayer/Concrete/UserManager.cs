using BusinessLayer.Abstract;
using DataAccessLayer;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BusinessLayer.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        Context db = new();
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public List<AppUser> GetList()
        {
          return _userDal.GetListAll();
        }

        public void TAdd(AppUser t)
        {
            _userDal.Insert(t);
        }

        public void TDelete(AppUser t)
        {
            _userDal.Delete(t);
        }

        public AppUser TGetByID(int id)
        {
           return _userDal.GetByID(id);
        }

        public void TUpdate(AppUser t)
        {
            _userDal.Update(t);
        }
        public AppUser GetSessionByWriter(string p)
        {

            var values = _userDal.GetListAll(x => x.UserName == p);
            return values.FirstOrDefault();
        }
        public int TotalRecipeCountByWriter(int id)
        {
            var values=from recipe in db.Recipes where recipe.AppUserID==id select recipe;
            return values.Count();
        }

      
    }
}
