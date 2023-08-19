using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YemekTarifApi.Controllers.DataAccessLayer;

namespace YemekTarifApi.Controllers
{
    [Route("api/[controller]/[action]")]
    //[Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [HttpGet]
        public IActionResult EmployeeList()
        {
            using var c = new Context();
            var values = c.Employees.ToList();
            return Ok(values);
        }
    }
}
