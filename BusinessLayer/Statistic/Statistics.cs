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
        public static int UserCount()
        {
            var values = (from user in db.Users select user).ToList().Count;
            return values;
        }
        public static int TotalLike()
        {
            var values = (from like in db.RecipeRaytings select like.RecipeRaytingCount).ToList().Sum();
            return values;
        }
        public static int TotalCategory()
        {
            var values=(from category in db.Categories select category).ToList().Count;
            return values;
        }
        public static string MostlyLikedRecipe() 
        {
            var values = (from likedRecipe in db.RecipeRaytings  select likedRecipe.RecipeRaytingCount).ToList();         
            var max = values.Max();
            var recipeID = (from i in db.RecipeRaytings where i.RecipeRaytingCount == max  select i.RecipeID).FirstOrDefault();
            var recipeName = (from recipe in db.Recipes where recipe.ReceipeID == recipeID select recipe.ReceipeName).FirstOrDefault();
            return recipeName;
        }
        public static string LastRegisteredUser()
        {
            var values = (from user in db.Users select user).ToList().TakeLast(1);
            return values.FirstOrDefault().NameSurname;
        }
        public static int AdminCount() 
        {
            var values=(from admin in db.UserRoles where admin.RoleId==1 select admin).ToList().Count;
            return values;
        }

    }
}
