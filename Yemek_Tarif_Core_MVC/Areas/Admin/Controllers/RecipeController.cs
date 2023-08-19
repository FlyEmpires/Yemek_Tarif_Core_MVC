using ClosedXML.Excel;
using DataAccessLayer.Concrete;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Yemek_Tarif_Core_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RecipeController : Controller
    {

        public IActionResult ExportDynamicRecipeList()
        {
            using (var workBook=new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Yemek Listesi");
                workSheet.Cell(1, 1).Value = "Recipe ID";
                workSheet.Cell(1, 1).Value = "Recipe Name";

                int RecipeRowCount = 2;
                foreach (var item in RecipeTitleList())
                {
                    workSheet.Cell(RecipeRowCount, 1).Value = item.ReceipeID;
                    workSheet.Cell(RecipeRowCount, 2).Value = item.ReceipeName;
                    RecipeRowCount++;
                }
                using (var stream=new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "RecipeList.xlsx");
                }
            }
        }

        public IActionResult RecipeListExcel()
        {
            return View();
        }
        public List<Recipe> RecipeTitleList()
        {
            List<Recipe> recipeList = new();
            using (var db=new Context())
            {
                recipeList = db.Recipes.Select(x => new Recipe
                {
                    ReceipeID = x.ReceipeID,
                    ReceipeName = x.ReceipeName
                }).ToList();
            }
            return recipeList;
        }
    }
}
