using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class Recipe
    {
        [Key]
        public int ReceipeID { get; set; }
        public string ReceipeName { get; set; }
        public string ReceipeDescription { get; set; }
        public string ReceipeThumbnailImage { get; set; }
        public string ReceipeImage { get; set; }
        public string ReceipeIngredient { get; set; }
        public DateTime CreateDate { get; set; }
        public bool RecipeStatus { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public Writer Writer { get; set; }
        public int WriterID{ get; set; }
        public List<Comment> Comments { get; set; }
    }
}
