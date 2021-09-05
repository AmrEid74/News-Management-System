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

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManger)
        {
            this.userManager = userManager;
            this.signInManger = signInManger;
        }

        #region Login

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
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
        public async Task<IActionResult> RegistrationAsync(RegistrationVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = new ApplicationUser()
                    {
                        UserName = model.Email,
                        Email = model.Email
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
