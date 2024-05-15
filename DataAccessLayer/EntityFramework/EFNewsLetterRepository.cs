using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFNewsLetterRepository:GenericRepository<NewsLetter>,INewsLetterDal
    {
        public bool IfExistMail(string mail)
        {

            using (var ctx=new Context())
            {
                var a =ctx.NewsLetters.FirstOrDefault(x => x.Mail == mail);
                if (a != null)
                
                    return true;
                
                else  

                    return false;
                
            }

        }
    }
}
