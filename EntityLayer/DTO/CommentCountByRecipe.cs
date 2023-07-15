using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTO
{
    public class CommentCountByRecipe
    {
        public int RecipeID { get; set; }
        public string RecipeName { get; set; }
        public Category Category { get; set; }
        public DateTime CreateDate { get; set; }
        public int CommentCount { get; set; }
        public string RecipeImage{ get; set; }

    }
}
