using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModels.Models;
using System.Data.SqlClient;

namespace DomainModels.Repository
{
    public class UserFavoritOperRepository : IUserFavoritOperRepository
    {

        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\pc1\Documents\visual studio 2015\Projects\ReactCalc\DomainModels\App_Data\ReactCalc.mdf;Integrated Security=True";

        public void Add(UserFavoriteResult operResult)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserFavoriteResult> GetAll()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(
                  "select favoritOper.Id, author.FIO, operRes.Name, operRes.InputData, operRes.Result, operRes.ExecutionTIme, operRes.ExecutionDate from UserFavoritResult AS favoritOper "+
                        "LEFT JOIN(select Id, FIO from Users) AS author ON author.Id = favoritOper.[User] " +
                        "LEFT JOIN(select result.Id, oper.Name, result.InputData, result.Result, result.ExecutionTIme, result.ExecutionDate from OperationResult AS result " +
                        "LEFT JOIN(select Id, Name from Operation) AS oper ON result.Operation = oper.Id) AS operRes ON operRes.Id = favoritOper.Result ORDER BY FIO; ",
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

                        yield return new UserFavoriteResult
                        {
                            Id = id,
                            User = new User { FIO = fIO },
                            Result = new OperationResult
                            {
                                Operation = new Operation { Name = nameOper },
                                InputData = inputData,
                                Result = result,
                                ExecutionTime = executionTime,
                                ExecutionDate = executionDate
                            }
                        };
                    }
                }
                reader.Close();
            }
        }
    }
}
