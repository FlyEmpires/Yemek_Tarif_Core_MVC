using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Yemek_Tarif_Core_MVC.Models;

namespace Yemek_Tarif_Core_MVC.Controllers
{
    public class NewsLettersAPI : Controller
    {
        public async Task<IActionResult> Index()
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:7122/api/Default/NewsLettersList");
            var jsonString=await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<NewsLetterstDTO>>(jsonString);
            return View(values);
        }
        [HttpGet]
        public IActionResult AddNewsLetters()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddNewsLetters(NewsLetterstDTO nL)
        {
            var httpClient = new HttpClient();
            var jsonNewsLetters = JsonConvert.SerializeObject(nL);
            StringContent content = new(jsonNewsLetters, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PostAsync("https://localhost:7122/api/Default/AddNewsLetters", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(nL);
        }
        [HttpGet]
        public async Task<IActionResult> UpdateNewsLetters(int id)
        {
            try
            {
                var httpClient = new HttpClient();
                var responseMessage = await httpClient.GetAsync("https://localhost:7122/api/Default/GetNewsLetters/" + id);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonNewsLetters = await responseMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<NewsLetterstDTO>(jsonNewsLetters);


                    return Json(values);
                }
            }
            catch (Exception ex)
            {

            }

            return RedirectToAction("Index");
           
        }
        [HttpPost]
        public async Task<IActionResult> UpdateNewsLetters(NewsLetterstDTO nL)
        {
            var httpClient = new HttpClient();
            var jsonNewsLetters = JsonConvert.SerializeObject(nL);
            var content = new StringContent(jsonNewsLetters, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PutAsync("https://localhost:7122/api/Default/UpdateNewsLetters", content
                );
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return Json(nL);
        }
        [HttpGet]
        public async Task<IActionResult> DeleteNewsLetters(int id)
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.DeleteAsync("https://localhost:7122/api/Default/DeleteNewsLetters/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return Json(id);
            }
            return View();
        }
    }
}
