using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFCommentRepository : GenericRepository<Comment>, ICommentDal
    {
        public List<Comment> GetListWithRecipe()
        {
            using (var ctx = new Context())
            {
                return ctx.Comments.Include(x => x.Recipe).ToList();
            }
        }
    }
}
