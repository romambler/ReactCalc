using DomainModels.Models;
using DomainModels.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebCalc.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private IUserRepository UserRepository { get; set; }

        public UserController(IUserRepository UserRepository)
        {
            this.UserRepository = UserRepository;
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

        [HttpGet]
        public ActionResult Edit(long id)
        {
            var user = UserRepository.Get(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            UserRepository.Update(user);
            return RedirectToAction("Index");
        }
    }
}