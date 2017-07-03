using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModels.Models;
using System.Data.SqlClient;

namespace DomainModels.Repository
{
    public class OperationResultRepository : IOperationResultRepository
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\pc1\Documents\visual studio 2015\Projects\ReactCalc\DomainModels\App_Data\ReactCalc.mdf;Integrated Security=True";
        public void Add(OperationResult operResult)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OperationResult> GetAll()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(
                  "select operRes.Id, author.FIO, oper.Name, operRes.InputData, operRes.Result, operRes.ExecutionTIme, operRes.ExecutionDate from OperationResult AS operRes " +
                    "LEFT JOIN(select Id, FIO from Users) AS author ON operRes.Author = author.Id " + 
                    "LEFT JOIN(select Id, Name from Operation) AS oper ON operRes.Operation = oper.Id; ",
                  connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var id = reader.GetInt64(0);
                        var fIO = reader.GetString(1);
                        var nameOper = reader.GetString(2);
                        var inputData = reader.GetString(3);
                        var result = reader.GetDouble(4);
                        var executionTime = reader.GetInt32(5);
                        var executionDate = reader.GetDateTime(6);

                        yield return new OperationResult { Id = id,
                                                           Author = new User {FIO = fIO },
                                                           Operation = new Operation { Name = nameOper },
                                                           InputData = inputData,
                                                           Result = result,
                                                           ExeutionTime = executionTime,
                                                           ExecutionDate = executionDate};
                    }
                }
                reader.Close();
            }
        }
    }
}
