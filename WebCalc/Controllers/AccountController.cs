using DomainModels.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace WebCalc.Views.Account
{
    public class AccountController : Controller
    {
        private IUserRepository UserRepository { get; set; }

        public AccountController(IUserRepository UserRepository)
        {
            this.UserRepository = UserRepository;
        }
        // GET: Account
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(string name, string password)
        {
            if (UserRepository.Valid(name, password))
            {
                FormsAuthentication.SetAuthCookie(name, true);
                return RedirectToAction("Index", "Calc");
            }
            else
            {
                ModelState.AddModelError("", "Пользователя с таким логином и паролем нет");
            }

            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("LogIn");
        }
    }
}