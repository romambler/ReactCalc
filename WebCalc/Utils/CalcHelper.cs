using DomainModels.Repository;
using RectCalc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebCalc.Utils
{
    public static class CalcHelper
    {
        public static void UpdateOperations()
        {
            var calcOperations = new Calc(@"C:\Users\pc1\Documents\visual studio 2015\Projects\ReactCalc\WebCalc\bin").Operations;

            var operationRepository = DependencyResolver.Current.GetService<IORepository>();

            var dbOperations = operationRepository.GetAll();
            var fullNames = dbOperations.Select(o => o.FullName.ToLower());

            foreach (var calcOper in calcOperations)
            {
                var fullName = calcOper.GetType().FullName.ToLower();
                if (fullNames.Contains(fullName))
                    continue;

                var newOper = operationRepository.Create();
                newOper.FullName = fullName;
                newOper.Name = calcOper.Name;

                operationRepository.Update(newOper);
            }
        }
    }
}