using DomainModels.Models;
using DomainModels.Repository;
using RectCalc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace WebCalc.Controllers
{
    public class OperationResultController : BaseController
    {
        public OperationResultController(IORRepository orrepository, IUserRepository UserRepository, IORepository OperationRepository, ILikeRepository LikeRepository)
            : base(orrepository, UserRepository, OperationRepository, LikeRepository)
        {
        }

        public ActionResult Index()
        {
            Regex patternForMethod = new Regex(",;");
            string[] s = patternForMethod.Split("1;2");
            var curUser = GetCurrentUser();

            var results = ORRepository.GetByUser(curUser);

            var likes = LikeRepository.GetByUserId(curUser.Id)     // получаем все лайки
                .Select(it => it.ResultId);         // достаем из лайков результаты операций  

            foreach (var result in results)
            {
                result.IsLiked = likes.Contains(result.Id);
            }

            return View(results);
        }

        [HttpPost]
        public JsonResult Like(long id)
        {
            var result = ORRepository.Get(id);
            if (result == null)
            {
                return Json(new { Success = false, Error = "Не удалось найти результат" });
            }

            // Получить текущего юзера
            var curUser = GetCurrentUser();

            var like = LikeRepository.GetAll().FirstOrDefault(it => it.UserId == curUser.Id && it.ResultId == id);

            if (like != null)
            {
                LikeRepository.Delete(like);
                return Json(new { Success = true, Name = "like" });
            }

            // Создать лайк
            like = LikeRepository.Create();

            // Заполнить свойства
            like.UserId = curUser.Id;
            like.ResultId = result.Id;

            // Сохранить
            LikeRepository.Update(like);
            // Вернуться к списку операций
            return Json(new { Success = true, Name = "dislike" });
        }

        public JsonResult NewResult(long id, long idOper, string inputData)
        {
            var calc = new Calc(@"C:\Users\pc1\Documents\visual studio 2015\Projects\ReactCalc\WebCalc\bin");
            var oper = OperRepository.GetById(idOper);
            var operation = calc.Operations.FirstOrDefault(o => o.Name == oper.Name);
            var operResult = ORRepository.Get(id);

            Regex patternForMethod = new Regex(",");
            string[] s = patternForMethod.Split(inputData);

            var newResult = operation.Execute(new double[] { double.Parse(s[0]), double.Parse(s[1]) });
            var execDate = DateTime.Now;

            operResult.Result = newResult;
            operResult.ExecutionDate = execDate;

            ORRepository.Update(operResult);

            return Json(new { Id = id, Result = newResult, Time = execDate.ToString() });
        }
    }
}