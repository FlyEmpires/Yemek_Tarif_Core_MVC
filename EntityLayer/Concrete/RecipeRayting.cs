using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class RecipeRayting
    {
        public int RecipeRaytingID { get; set; }
        public int RecipeID { get; set; }
        public int RecipeTotalScore { get; set; }
        public int RecipeRaytingCount { get; set; }
    }
}
