using JWT_Core_Yemek_Tarif.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWT_Core_Yemek_Tarif.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [HttpGet("[action]")]
        public IActionResult Login()
        {
            return Created("", new BuildToken().CreateToken());
        }
        [Authorize]
        [HttpGet("[action]")]
        public IActionResult Page1()
        {
            return Ok("Sayfa1 için girişiminiz başarılı.!");  
        }
    }
}
