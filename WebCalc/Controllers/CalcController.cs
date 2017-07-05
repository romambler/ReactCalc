using DomainModels.EntityFramework;
using DomainModels.Repository;
using RectCalc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCalc.Models;

namespace WebCalc.Controllers
{
    [Authorize]
    public class CalcController : Controller
    {
        private Calc calc { get; set; }
        private IORRepository ORRepository { get; set; }
        private IUserRepository userrep { get; set; }
        private IORepository orep { get; set; }

        public CalcController(IORRepository orrepository, IUserRepository userrep, IORepository orep)
        {
            calc = new Calc(@"C:\Users\pc1\Documents\visual studio 2015\Projects\ReactCalc\WebCalc\bin");
            ORRepository = orrepository;
            this.userrep = userrep;
            this.orep = orep;
        }
        public ActionResult Index()
        {
            var model = new CalcModel();
            model.OperationList = calc.Operations.Select(o => new SelectListItem() { Text = $"{o.Name}", Value = $"{o.Name}" });
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(CalcModel model)
        {
            var oper = orep.GetByName(model.Operation);
            var operation = calc.Operations.FirstOrDefault(o => o.Name == oper.Name);
            model.OperationList = calc.Operations.Select(o => new SelectListItem() { Text = $"{o.Name}", Value = $"{o.Name}", Selected = model.Operation == o.Name });


            if (operation!= null)
            {
                var operid = oper.Id;
                var inputdata = string.Join(", ", model.Arguments);
                var oldResult = ORRepository.GetOldResult(operid, inputdata);

                if (!double.IsNaN(oldResult))
                {
                    model.Result = oldResult;
                }
                else
                {
                    model.Result = operation.Execute(model.Arguments);

                    var rec = ORRepository.Create();
                    var currentUser = userrep.GetByName(User.Identity.Name);
                    var dbOper = orep.GetByName(oper.Name);

                    rec.AuthorId = currentUser.Id;
                    rec.OperationId = operid;
                    rec.ExecutionDate = DateTime.Now;
                    rec.ExecutionTime = new Random().Next(0, 300);
                    rec.InputData = inputdata;
                    rec.Result = model.Result ?? double.NaN;
                    ORRepository.Update(rec);
                }
                return View(model);
            }
            return View();
        }
    }
}