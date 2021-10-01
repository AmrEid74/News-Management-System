using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using News.BL.Models;
using News.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
    
namespace News.Controllers
{
    public class AccountController : Controller


    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManger;

        private readonly RoleManager<IdentityRole> roleManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManger, RoleManager<IdentityRole> roleManager)


       
        {
            this.userManager = userManager;
            this.signInManger = signInManger;
            this.roleManager = roleManager;
        }

        #region Role


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
                IdentityResult result = await roleManager.CreateAsync(identityRole);

                if (result.Succeeded)
                {
                    return RedirectToAction("index", "home");
                }

                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }


        #endregion

        #region List Roles


        [HttpGet]
        public IActionResult ListRoles()
        {
            var roles = roleManager.Roles;
            return View(roles);
        }

        #endregion

        #region Edit  Role

        // Role ID is passed from the URL to the action
        [HttpGet]
        public async Task<IActionResult> EditRole(string id)
        {
            // Find the role by Role ID
            var role = await roleManager.FindByIdAsync(id);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {id} cannot be found";
                return View("NotFound");
            }

            var model = new EditRoleVM
            {
                Id = role.Id,
                RoleName = role.Name 
                
            };
            foreach (var user in await userManager.GetUsersInRoleAsync(role.Name))
            {
                model.Users.Add(user.UserName);
            }
        
            return View(model);
            
        }

        // This action responds to HttpPost and receives EditRoleViewModel
        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleVM model)
        {
            var role = await roleManager.FindByIdAsync(model.Id);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {model.Id} cannot be found";
                return View("NotFound");
            }
            else
            {
                role.Name = model.RoleName;

                // Update the Role using UpdateAsync
                var result = await roleManager.UpdateAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(model);
            }
        }


        #endregion


        #region Edit Users In Role
        [HttpGet]
        public async Task<IActionResult> EditUserRole(string roleId)
        {
            ViewBag.roleId = roleId;

            var role = await roleManager.FindByIdAsync(roleId);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {roleId} cannot be found";
                return View("NotFound");
            }

            var model = new List<UserRoleVM>();

            foreach (var user in  userManager.Users)
            {
                var userRoleViewModel = new UserRoleVM { 
                    UserId = user.Id,
                    UserName = user.UserName,
                   
                };
                do
                {
                    model.Add(userRoleViewModel);
                } while (true);
                if ( await userManager.IsInRoleAsync(user, role.Name))
                {
                    userRoleViewModel.IsSelected = true;
                }
                else
                {
                    userRoleViewModel.IsSelected = false;
                }
                model.Add(userRoleViewModel);
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditUserRole(List<UserRoleVM> model, string roleId)
        {
            var roleInEdit = await userManager.FindByIdAsync(roleId);

            if (roleInEdit == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {roleId} cannot be found";
                return View("NotFound");
            }

            foreach (var userRole in model)
            {
                var user = await userManager.FindByIdAsync(userRole.UserId);
                var isInRole = await userManager.IsInRoleAsync(user, roleInEdit.Id);

                IdentityResult result = null;
                if (userRole.IsSelected && !isInRole)
                    result = await userManager.AddToRoleAsync(user, roleInEdit.Id);
                else if (!userRole.IsSelected && isInRole)
                    result = await userManager.RemoveFromRoleAsync(user, roleInEdit.Id);

                if (result?.Succeeded == false)
                    break;
            }

            return RedirectToAction("EditRole", new { Id = roleId });
        }

        #endregion

        #region Login

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> LoginAsync(LoginVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await signInManger.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalied Password Or Email");
                    }
                }
            }

            catch (Exception ex)
            {


            }


            return View();
        }
        #endregion


        #region Sign Up
        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registration(CreateUserVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = new ApplicationUser()
                    {
                        FullName = model.FullName,
                        UserName = model.Email ,
                        
                        

                    };
                    var result = await userManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Login");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);

                        }
                    }

                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {


            }
            return View();
        }

        #endregion


        #region Sign Out
        [HttpPost]
        public async Task<IActionResult> LogOff()
        {
            await signInManger.SignOutAsync();
            return RedirectToAction("Login");
        }

        #endregion











        #region Forget Password

        [HttpGet]
        public IActionResult ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ForgetPassword(ForgetPasswordVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                }
            }
            catch (Exception ex)
            {


            }

            return View();
        }




        [HttpGet]
        public IActionResult ConfirmForgetPassword()
        {
            return View();
        }







        #endregion

        #region Reset Password


        [HttpGet]
        public IActionResult ResetPassword()
        {

            return View();


        }

        [HttpPost]
        public IActionResult ResetPassword(ResetPasswordVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                }
            }
            catch (Exception ex)
            {


            }
            return View();

        }



        [HttpGet]
        public IActionResult ConfirmResetPassword()
        {
            return View();
        }

        #endregion


    }

}
