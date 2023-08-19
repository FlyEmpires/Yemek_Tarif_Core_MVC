using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.DTO;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;

namespace BusinessLayer.Statistic
{

    public class Statistics
    {
        static CategoryManager cm = new(new EFCategoryRepository());

        static Context db = new();
        public static int MessageCount()
        {
            var values = from message in db.Messages select message;
            return values.Count();
        }
        public static int RecipeCount()
        {
            var values = from recipe in db.Recipes select recipe;
            return values.Count();
        }
        public static int CommentCount()
        {
            var values = from comment in db.Comments select comment;
            return values.Count();
        }
        public static Recipe LastRecipe()
        {
            var values = (from recipe in db.Recipes select recipe).OrderByDescending(x=>x.ReceipeID).FirstOrDefault();
            return values;
        }
        public static List<ChartDTO> PieChart()
        {
            var list = new List<ChartDTO>();
            var chartList = (from i in db.Categories
                          select new ChartDTO
                          {
                              kategoriadi = i.CategoryName,
                              yemeksayisi = i.Recipes.Count()
                          }).ToList();
            return chartList;
        }
    }
}
