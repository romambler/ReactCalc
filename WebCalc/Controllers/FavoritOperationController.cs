using DomainModels.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebCalc.Controllers
{
    public class FavoritOperationController : Controller
    {
        private IUserFavoritOperRepository favoritOperation { get; set; }

        public FavoritOperationController()
        {
            favoritOperation = new UserFavoritOperRepository();
        }
        // GET: FavoritOperation
        public ActionResult FavoritOperation()
        {
            return View(favoritOperation.GetAll().ToList());
        }
    }
}