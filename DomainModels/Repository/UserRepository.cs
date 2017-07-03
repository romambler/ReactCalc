using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModels.Models;
using System.Data.SqlClient;

namespace DomainModels.Repository
{
    public class UserRepository : IUserRepository
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\pc1\Documents\visual studio 2015\Projects\ReactCalc\DomainModels\App_Data\ReactCalc.mdf;Integrated Security=True";


        public User Create()
        {
            throw new NotImplementedException();
        }

        public User Create(User elem)
        {
            throw new NotImplementedException();
        }

        public void Delete(User user)
        {
            throw new NotImplementedException();
        }

        public User Get(long Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(
                  "SELECT Id, FIO, Login, Password FROM Users;",
                  connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var Id = reader.GetInt64(0);
                        var FIO = reader.GetString(1);
                        var Login = reader.GetString(2);
                        
                        yield return new User { Id = Id, FIO = FIO, Login = Login };
                    }
                }
                reader.Close();
            }
        }


        public void Update(User user)
        {
            throw new NotImplementedException();
        }

        public bool Valid(string userName, string password)
        {
            throw new NotImplementedException();
        }
    }
}
