using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using News.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace News.Controllers
{
   
    
        public class RoleController : Controller
        {
        private readonly Microsoft.AspNetCore.Identity.RoleManager<IdentityRole> roleManager;

        public RoleController(Microsoft.AspNetCore.Identity.RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult CreateRole() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleVM model)
        {
            if (ModelState.IsValid)
            {
                // We just need to specify a unique role name to create a new role
                IdentityRole identityRole = new IdentityRole
                {
                    Name = model.RoleName
                };

                // Saves the role in the underlying AspNetRoles table
                Microsoft.AspNetCore.Identity.IdentityResult result = await roleManager.CreateAsync(identityRole);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }


        [HttpGet]
        public IActionResult ListRoles()
        {
            var roles = roleManager.Roles;
            return View(roles);
        }

    }
}
