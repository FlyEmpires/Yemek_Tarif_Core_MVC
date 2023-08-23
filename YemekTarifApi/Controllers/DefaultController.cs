using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YemekTarifApi.Controllers.DataAccessLayer;
using YemekTarifApi.Controllers.EntityLayer.Concrete;

namespace YemekTarifApi.Controllers
{
    [Route("api/[controller]/[action]")]
    //[Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [HttpGet]
        public IActionResult NewsLettersList()
        {
            using var c = new Context();
            var values = c.NewsLetters.ToList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddNewsLetters(NewsLetters nL)
        {
            using var c = new Context();
            c.NewsLetters.Add(nL);
            c.SaveChanges();
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetNewsLetters(int id)
        {
            using var c = new Context();
            var values = c.NewsLetters.Find(id);
            if (values == null)
            {
                return NotFound();
            }
            return Ok(values);

        }
        [HttpDelete("{id}")]
        public IActionResult DeleteNewsLetters(int id)
        {
            using var c = new Context();
            var values = c.NewsLetters.Find(id);
            if (values == null)
            {
                return NotFound();
            }
            else
            {
                c.NewsLetters.Remove(values);
                c.SaveChanges();
                return Ok(values);
            }

        }
        [HttpPut]
        public IActionResult UpdateNewsLetters(NewsLetters nL)
        {
            using var c = new Context();
            //var id = c.Employees.Find(e.ID);
            var values = c.NewsLetters.Where(x => x.MailID == nL.MailID).FirstOrDefault();
            //var values = c.Find<Employee>(e.ID); Alternatif
            if (values != null)
            {
                values.Mail = nL.Mail;
                c.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
