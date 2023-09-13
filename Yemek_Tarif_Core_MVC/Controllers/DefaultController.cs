using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Authorization;

namespace Yemek_Tarif_Core_MVC.Controllers
{
	[AllowAnonymous]
    public class DefaultController : Controller
    {		
		RecipeManager rm = new RecipeManager(new EFRecipeRepository());
	
        public async Task<IActionResult> Index()
        {
			var values = rm.GetListWithCategoryAndWriter();
			//var values = rm.GetList();
			//return RedirectToAction("HavaDurumuApi");
			ViewBag.havaDurumu = await HavaDurumuApi(); //metod task tipinde olduğu için await kullanarak çağırdık. Bunun için ise Index Actionu da Task tipinde tanımlamamız gerekti
														//int id = 0;
														//ViewBag.id = id;
		
            return View(values);
		}
		static public async Task<string> Derece()
		{
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://weatherapi-com.p.rapidapi.com");
                client.DefaultRequestHeaders.Add("X-RapidAPI-Key", "9ad07b8d6cmshfaaf9e433c4d7f3p1a14afjsnd04f7cbf5e8b");
                client.DefaultRequestHeaders.Add("X-RapidAPI-Host", "weatherapi-com.p.rapidapi.com");

                var response = await client.GetAsync("/current.json?q=37.8716%2C32.4846");//Konya'nın enlem ve boylamına göre çalışır
                                                                                          //To do: Lokasyon her gün değişecek

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    JObject data = JObject.Parse(json);
                    string temperature = data["current"]["temp_c"].ToString();
                    string zaman = data["current"]["last_updated"].ToString();
                    string lokasyon = data["location"]["name"].ToString();
                    var havaDurumu = $"Sıcaklık: {temperature} Derece\n {lokasyon}";
                    return havaDurumu;
                }

                else
                {
                    return string.Empty;
                }
            }
        }
		
       static public async Task<string> HavaDurumuApi()
        {
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri("https://weatherapi-com.p.rapidapi.com");
				client.DefaultRequestHeaders.Add("X-RapidAPI-Key", "9ad07b8d6cmshfaaf9e433c4d7f3p1a14afjsnd04f7cbf5e8b");
				client.DefaultRequestHeaders.Add("X-RapidAPI-Host", "weatherapi-com.p.rapidapi.com");

                var response = await client.GetAsync("/current.json?q=37.8716%2C32.4846");//Konya'nın enlem ve boylamına göre çalışır
																						  //To do: Lokasyon her gün değişecek

                if (response.IsSuccessStatusCode)
				{
					var json = await response.Content.ReadAsStringAsync();
					JObject data = JObject.Parse(json);
					string temperature = data["current"]["temp_c"].ToString();
					string zaman = data["current"]["last_updated"].ToString();
					string lokasyon = data["location"]["name"].ToString();
					var havaDurumu= $"Sıcaklık: {temperature} Derece\nTarih : {DateTime.Parse(zaman):dd MMMM yyyy}, {lokasyon}";
					return havaDurumu;	
				}
			
				else
				{
					return string.Empty;
				}
			}
        }
    }
}
