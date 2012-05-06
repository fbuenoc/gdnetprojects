using System.Web.Mvc;
using System.Web.Security;
using WebFramework.Common.AccountModeles;
using WebFramework.Common.Controllers;
using WebFramework.Common.Security;
using WebFramework.Common.Validation;

namespace WebFramework.Controllers.Main
{
    public class AccountController : AbstractController
    {
        public ActionResult LogOn()
        {
            return base.View();
        }

        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {
            if (base.ModelState.IsValid)
            {
                if (base.membershipService.ValidateUser(model.UserName, model.Password))
                {
                    base.formsService.SignIn(model.UserName, model.RememberMe);
                    if (base.Url.IsLocalUrl(returnUrl))
                    {
                        return base.Redirect(returnUrl);
                    }
                    else
                    {
                        return base.Redirect(base.Url.Action<HomeController>(x => x.Index()));
                    }
                }
                else
                {
                    base.ModelState.AddModelError("", "The user name or password provided is incorrect.");
                }
            }

            // If we got this far, something failed, redisplay form
            return base.View(model);
        }

        [Authorize]
        public ActionResult LogOff()
        {
            base.formsService.SignOut();
            return base.Redirect(base.Url.Action<HomeController>(x => x.Index()));
        }

        public ActionResult Register()
        {
            base.ViewBag.PasswordLength = base.membershipService.MinPasswordLength;
            return base.View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (base.ModelState.IsValid)
            {
                // Attempt to register the user
                MembershipCreateStatus createStatus = base.membershipService.CreateUser(model.UserName, model.Password, model.Email);

                if (createStatus == MembershipCreateStatus.Success)
                {
                    base.formsService.SignIn(model.UserName, false /* createPersistentCookie */);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    base.ModelState.AddModelError("", AccountValidation.ErrorCodeToString(createStatus));
                }
            }

            // If we got this far, something failed, redisplay form
            base.ViewBag.PasswordLength = base.membershipService.MinPasswordLength;
            return base.View(model);
        }

        [Authorize]
        public ActionResult ChangePassword()
        {
            base.ViewBag.PasswordLength = base.membershipService.MinPasswordLength;
            return base.View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (base.ModelState.IsValid)
            {
                if (base.membershipService.ChangePassword(User.Identity.Name, model.OldPassword, model.NewPassword))
                {
                    return base.Redirect(base.Url.Action<AccountController>(x => x.ChangePasswordSuccess()));
                }
                else
                {
                    base.ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.");
                }
            }

            // If we got this far, something failed, redisplay form
            base.ViewBag.PasswordLength = base.membershipService.MinPasswordLength;
            return base.View(model);
        }

        public ActionResult ChangePasswordSuccess()
        {
            return base.View();
        }

    }
}
