using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NAS.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NAS.Controllers
{
    [ApiController]
    [Route("account")]
    public class AccountController : ControllerBase
    {
        private UserManager<AppUser> UserMgr { get; }
        private SignInManager<AppUser> SignInMgr { get; }

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            UserMgr = userManager;
            SignInMgr = signInManager;
        }



        [HttpGet]
        [Route("getMethod")]
        public async Task<string> getMethod()
        {
            var Message = "";
            try
            {
                Message = "User already registered";

                AppUser user = await UserMgr.FindByNameAsync("nhoarau");
                if (user == null)
                {
                    user = new AppUser();
                    user.UserName = "nhoarau";
                    user.Email = "nathan.hoarau11@gmail.com";
                    user.FirstName = "Nathan";
                    user.LastName = "HOARAU";

                    IdentityResult result = await UserMgr.CreateAsync(user, "PhilDougTest33*");
                    Message = "User was created";
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }

            return Message;
        }

        [HttpPost]
        [Produces("application/json")]
        [Route("login")]
        public async Task<bool> Login(JObject userJson)
        {
            var userInfo = JsonConvert.DeserializeObject<UserLoginModel>(userJson.ToString());

            if (!ModelState.IsValid)
            {
                return false;
            }

            var user = await UserMgr.FindByEmailAsync(userInfo.Email);
            if (user != null &&
                await UserMgr.CheckPasswordAsync(user, userInfo.Password))
            {
                var identity = new ClaimsIdentity(IdentityConstants.ApplicationScheme);
                identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));

                await HttpContext.SignInAsync(IdentityConstants.ApplicationScheme,
                    new ClaimsPrincipal(identity));

                return true;
            }
            else
            {
                ModelState.AddModelError("", "Invalid UserName or Password");
                return false;
            }
        }

        private IActionResult View(UserLoginModel userModel)
        {
            throw new NotImplementedException();
        }

        //[HttpPost]
        //public async Task<IActionResult> Register( model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = new AppUser { UserName = model.Username };
        //        var result = await UserMgr.CreateAsync(user, model.Password);

        //        if (result.Succeeded)
        //        {
        //            await SignInMgr.SignInAsync(user, false);
        //            return RedirectToAction("Index", "Home");
        //        }
        //        else
        //        {
        //            foreach (var error in result.Errors)
        //            {
        //                ModelState.AddModelError("", error.Description);
        //            }
        //        }
        //    }
        //    return View();
        //}
    }
}