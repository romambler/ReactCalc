using DomainModels.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebCalc.Controllers
{
    public class OperationResultController : Controller
    {
        private IOperationResultRepository operationResult { get; set; }

        public OperationResultController()
        {
            operationResult = new OperationResultRepository();
        }
        // GET: OperationResult
        public ActionResult OperationResult()
        {
            return View(operationResult.GetAll().ToList());
        }
    }
}