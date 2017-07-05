using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DomainModels.Repository;

namespace WebCalc.Controllers
{
    public class OperationController : BaseController
    {
        public OperationController(IORRepository ORRepository, IUserRepository UserReposiory, IORepository OperRepository, ILikeRepository LikeRepository) : base(ORRepository, UserReposiory, OperRepository, LikeRepository)
        {
        }

        // GET: Operation
        public ActionResult Index()
        {
            var operations = OperRepository.GetAll();
            return View(operations);
        }
    }
}