using System;
using System.Collections.Generic;
using DomainModels.Models;
using System.Data.SqlClient;

namespace DomainModels.Repository
{
    public class OperationRepository : IOperationRepository
    {

        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\pc1\Documents\visual studio 2015\Projects\ReactCalc\DomainModels\App_Data\ReactCalc.mdf;Integrated Security=True";

        public void Add(Operation operation)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Operation> GetAll()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(
                  "SELECT Id, Name, FullName FROM Operation;",
                  connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var Id = reader.GetInt64(0);
                        var Name = reader.GetString(1);
                        var FullName = reader.GetString(2);

                        yield return new Operation { Id = Id, Name = Name, FullName = FullName};
                    }
                }
                reader.Close();
            }
        }
    }
}
