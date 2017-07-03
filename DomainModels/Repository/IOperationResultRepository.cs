﻿using DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.Repository
{
    public interface IOperationResultRepository
    {
        void Add(OperationResult operResult);
        IEnumerable<OperationResult> GetAll();
    }
}
