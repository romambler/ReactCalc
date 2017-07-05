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
    public class BaseController : Controller
    {
        protected IORRepository ORRepository { get; set; }
        protected IUserRepository UserReposiory { get; set; }
        protected IORepository OperRepository { get; set; }
        protected ILikeRepository LikeRepository { get; set; }
        
        public BaseController(IORRepository ORRepository, IUserRepository UserReposiory, IORepository OperRepository, ILikeRepository LikeRepository)
        {
            this.ORRepository = ORRepository;
            this.UserReposiory = UserReposiory;
            this.OperRepository = OperRepository;
            this.LikeRepository = LikeRepository;
        }

        protected User GetCurrentUser()
        {
            return UserReposiory.GetByName(User.Identity.Name);
        }
    }
}