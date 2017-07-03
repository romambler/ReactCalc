using DomainModels.Models;
using DomainModels.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace WebCalc.Controllers
{
    public class OperationController : Controller
    {
        private IOperationRepository operation { get; set; }

        public OperationController()
        {
            operation = new OperationRepository();
        }
        
        // GET: Operation
        public ActionResult Operation()
        {
            List<Operation> operations = operation.GetAll().ToList();
            return View(operations);
        }
    }
}