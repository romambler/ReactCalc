using DomainModels.Models;
using DomainModels.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebCalc.Controllers
{
    public class UserController : Controller
    {
        private IUserRepository UserRepository { get; set; }

        public UserController()
        {
            UserRepository = new DomainModels.EntityFramework.UserRepository();
        }

        public ActionResult Index()
        {
            List<User> users = UserRepository.GetAll().ToList();
            return View(users);
        }

        public ActionResult View(long id)
        {
            var user = UserRepository.Get(id);
            return View(user);
        }
    }
}