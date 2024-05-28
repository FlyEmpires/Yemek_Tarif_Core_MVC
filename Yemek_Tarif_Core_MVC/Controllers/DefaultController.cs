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
using System.Security.Claims;
using DocumentFormat.OpenXml.Spreadsheet;
using DataAccessLayer.Concrete;
using System.Linq;

namespace Yemek_Tarif_Core_MVC.Controllers
{
	[AllowAnonymous]
    public class DefaultController : Controller
    {		
		RecipeManager rm = new RecipeManager(new EFRecipeRepository());
		static UserManager um = new UserManager(new EFUserRepository());
        public async Task<IActionResult> Index()
        {
			var values = rm.GetListWithCategoryAndWriter();
            //var values = rm.GetList();
            //return RedirectToAction("HavaDurumuApi");
            //ViewBag.havaDurumu = await HavaDurumuApi(); 
            var user = this.HttpContext.User; //User Claims Identity'e erişmek için
            ViewBag.havaDurumu = await GetWeather(user);//metod task tipinde olduğu için await kullanarak çağırdık. Bunun için ise Index Actionu da Task tipinde tanımlamamız gerekti
            return View(values);
		}
		//static public async Task<string> Derece()
		//{
           
            //using (var client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri("https://weatherapi-com.p.rapidapi.com");
            //    client.DefaultRequestHeaders.Add("X-RapidAPI-Key", "9ad07b8d6cmshfaaf9e433c4d7f3p1a14afjsnd04f7cbf5e8b");
            //    client.DefaultRequestHeaders.Add("X-RapidAPI-Host", "weatherapi-com.p.rapidapi.com");

            //    var response = await client.GetAsync("/current.json?q=37.8716%2C32.4846");//Konya'nın enlem ve boylamına göre çalışır
            //                                                                              //To do: Lokasyon her gün değişecek

            //    if (response.IsSuccessStatusCode)
            //    {
            //        var json = await response.Content.ReadAsStringAsync();
            //        JObject data = JObject.Parse(json);
            //        string temperature = data["current"]["temp_c"].ToString();
            //        string zaman = data["current"]["last_updated"].ToString();
            //        string lokasyon = data["location"]["name"].ToString();
            //        var havaDurumu = $"Sıcaklık: {temperature} Derece\n {lokasyon}";
            //        return havaDurumu;
            //    }

            //    else
            //    {
            //        return string.Empty;
            //    }
            //}
        //}
        public string GetCityByUserId(string userId) //kullanıcının şehrini getirir
        {
            Context db = new Context();
            var user = um.TGetByID(int.Parse(userId));
            var city = user.CityID;
            var a = (from i in db.Cities where user.CityID == i.CityID select i.CityName).FirstOrDefault();   
            return a.ToString();
        }
        public async Task<string> GetWeather(ClaimsPrincipal user)
		{
            string city;
            string weather;
            try
            {
                //var userName = user.Identity.Name;
                var a = user.FindFirstValue(ClaimTypes.NameIdentifier);
                //var userID = User.FindFirstValue(ClaimTypes.NameIdentifier); // direkt kullanamıyoruz çünkü Viewcomponent içerisinde User'a direkt erişemiyoruz. Viewcomponent içinde HttpContext üzerinden erişmemiz gerektiği için Metoda parametre olarak göndermem gerekti. (Statistic1.cs)
                if (a != null)
                {
                    city = GetCityByUserId(a);
                    weather = await HavaDurumuApi(city);
                    return weather.ToString();
                }
                else // eğer ki kayıt olmadan direkt olarak Anasayfaya erişilirse default olarak İstanbul Döndürsün
                {

                    weather = await HavaDurumuApi("Istanbul");
                    return weather.ToString();
                }
            }
            catch (Exception s)
            {

                throw s.InnerException;
            }
          
        }
       static public async Task<string> HavaDurumuApi(string city)
        {
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri("https://weatherapi-com.p.rapidapi.com");
				client.DefaultRequestHeaders.Add("X-RapidAPI-Key", "9ad07b8d6cmshfaaf9e433c4d7f3p1a14afjsnd04f7cbf5e8b");
				client.DefaultRequestHeaders.Add("X-RapidAPI-Host", "weatherapi-com.p.rapidapi.com");

                var response = await client.GetAsync($"/current.json?q={Uri.EscapeDataString(city)}"); //escapedatastring ifadesi New York Şeklinde boşluk olarak kullanılırsa boşluk ifadesini %20 olarak kodlar = "New%20York"
                

                if (response.IsSuccessStatusCode)
				{
					var json = await response.Content.ReadAsStringAsync();
					JObject data = JObject.Parse(json);
					string temperature = data["current"]["temp_c"].ToString();
					string zaman = data["current"]["last_updated"].ToString();
					string lokasyon = data["location"]["name"].ToString();
                    var havaDurumu = $"Sıcaklık: {temperature} Derece\nTarih: {DateTime.Parse(zaman):dd MMMM yyyy}, {lokasyon}";

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
