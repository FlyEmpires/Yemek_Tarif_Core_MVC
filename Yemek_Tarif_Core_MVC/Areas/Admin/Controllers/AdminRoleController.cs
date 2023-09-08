using DocumentFormat.OpenXml.Office2010.Excel;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yemek_Tarif_Core_MVC.Areas.Admin.Models;
using Yemek_Tarif_Core_MVC.Models;

namespace Yemek_Tarif_Core_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class AdminRoleController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public AdminRoleController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var values = _roleManager.Roles.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddRole(RoleViewModel rM)
        {
            if (ModelState.IsValid)
            {
                AppRole role = new()
                {
                    Name = rM.Name

                };
                var result = await _roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);

                }
            }
            return View(rM);
        }
        //[HttpPost]
        public async Task<IActionResult> DeleteRole(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            var result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");

            }
            return View();
        }
        [HttpGet]
        public IActionResult UpdateRole(int id)
        {
            var role = _roleManager.Roles.Where(x=>x.Id==id).FirstOrDefault();
            RoleViewModel rm = new RoleViewModel()
            {
                Id = id,
                Name = role.Name
            };
            //var role =  _roleManager.Roles.Where(x=>x.Id==id);

            return View(rm);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateRole(RoleViewModel rM)
        {
            //var role = await _roleManager.Roles.Where(x=>x.Id==);
            //var result= await _roleManager.UpdateAsync(role);
            //if (result.Succeeded)
            //{
            //    return RedirectToAction("Index");
            //}
            var roles=_roleManager.Roles.Where(x=>x.Id==rM.Id).FirstOrDefault();
            roles.Name = rM.Name;
            var result= await _roleManager.UpdateAsync(roles);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult UserRoleList()
        {
            var values = _userManager.Users.ToList();
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> AssingRole(int id)
        { 
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
            var roles = _roleManager.Roles.ToList();
            TempData["Userid"] = user.Id;
            var userRoles = await _userManager.GetRolesAsync(user);

            List<RoleAssignViewModel> model = new();
            foreach (var item in roles)
            {
                RoleAssignViewModel m = new RoleAssignViewModel();
                m.ROleID = item.Id;
                m.Name = item.Name;
                m.Exist = userRoles.Contains(item.Name);
                model.Add(m);
            }
            return View(model);
        }
        public async Task<IActionResult> AssingRole(List<RoleAssignViewModel> model)
        {
            var userid = (int)TempData["UserId"];
            var user = _userManager.Users.FirstOrDefault(x => x.Id == userid);
            foreach (var item in model)
            {
                if (item.Exist)
                {
                    await _userManager.AddToRoleAsync(user, item.Name);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, item.Name);
                }
            }
            return RedirectToAction("UserRoleList");
        }
    }
}
