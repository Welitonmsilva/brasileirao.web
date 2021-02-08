using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Brasileirao.web.Models.IEntities;
using Brasileirao.web.Helpers;
using Brasileirao.web.Models;
using System.Linq;
using System.Threading.Tasks;


namespace Brasileirao.web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserHelper userHelper;

        public AccountController(IUserHelper _userHelper)
        {
            this.userHelper = _userHelper;

        }


        public IActionResult Login()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return this.RedirectToAction("Index", "Home");

            }
            return this.View();
        }


        [HttpPost]

        public async Task<IActionResult> login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await this.userHelper.LoginAsync(model);
                if (result.Succeeded)
                {
                    if (this.Request.Query.Keys.Contains("returnUrl"))
                    {
                        return this.Redirect(this.Request.Query["returnUrl"].First());
                    }
                    return this.RedirectToAction("Index", "Home");
                }
            }
            this.ModelState.AddModelError(string.Empty, "Filed to Login");
            return this.View(model);
        }




        public async Task<IActionResult> Logout()
        {
            await this.userHelper.LogoutAsync();
            return this.RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            return this.View();
        }



        [HttpPost]
        public async Task<IActionResult> Register(RegisterNewUserViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var user = await this.userHelper.GetUserByEmailAsync(model.UserName);
                if (user == null)
                {
                    user = new User
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Email = model.UserName,
                        UserName = model.UserName
                    };

                    var result = await this.userHelper.AddUserAsync(user, model.Password);
                    if (result != IdentityResult.Success)
                    {
                        this.ModelState.AddModelError(string.Empty, "The user couldn't be created.");
                        return this.View(model);
                    }

                    var loginViewModel = new LoginViewModel
                    {
                        Password = model.Password,
                        RememberMe = false,
                        Username = model.UserName
                    };

                    var result2 = await this.userHelper.LoginAsync(loginViewModel);

                    if (result2.Succeeded)
                    {
                        return this.RedirectToAction("Index", "Home");
                    }

                    this.ModelState.AddModelError(string.Empty, "The user couldn't be login.");
                    return this.View(model);
                }

                this.ModelState.AddModelError(string.Empty, "The username is already registered.");
            }

            return this.View(model);
        }


        public async Task<IActionResult> ChangeUser()
        {
            var user = await this.userHelper.GetUserByEmailAsync(this.User.Identity.Name);
            var model = new ChangeUserViewModel();
            if (user != null)
            {
                model.FirstName = user.FirstName;
                model.LastName = user.LastName;
            }
            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeUser(ChangeUserViewModel model)
        {
            if (this.ModelState.IsValid)
            {

                var user = await this.userHelper.GetUserByEmailAsync(this.User.Identity.Name);
                if (user !=null)
                {
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    var respose = await this.userHelper.UpdateUserAseync(user);
                    if (respose.Succeeded)
                    {
                        this.ViewBag.UserMessage = "User Update";
                    }
                    else
                    {
                        this.ModelState.AddModelError(string.Empty, respose.Errors.FirstOrDefault().Description);
                    }
                }
                else
                {
                    this.ModelState.AddModelError(string.Empty, "User not found");
                }
            }
            return this.View(model);

        }


       [HttpPost]
       public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var user = await this.userHelper.GetUserByEmailAsync(this.User.Identity.Name);
                if (user != null)
                {
                    var result = await this.userHelper.ChangePassewordAsync(user, model.OldPassword, model.NewPassword);
                    if (result.Succeeded)
                    {
                        return this.RedirectToAction("ChangeUser");
                    }
                    else
                    {
                        this.ModelState.AddModelError(string.Empty, result.Errors.FirstOrDefault().Description);
                    }
                }
                else
                {
                    this.ModelState.AddModelError(string.Empty, "User no found.");
                }
            }

            return this.View(model);
        }

    }
}
