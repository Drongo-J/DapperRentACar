using Dapper;
using DapperRentACar.DataAccess.Abstractions;
using DapperRentACar.DataAccess.Entitites;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace DapperRentACar.DataAccess.Concretes
{
    public class AdminRepository : IAdminRepository
    {
        public void Add(Admin entity)
        {
            using (var connection = new SqlConnection(App.ConnectionString))
            {
                var sql = @"INSERT INTO Admins([Email],[Username],[Password]) " +
                           "VALUES (@email, @username, @password)";

                connection.Execute(sql, new { email = entity.Email, username = entity.Username, password = entity.Password });
            }
        }

        public void Delete(Admin data)
        {
            using (var connection = new SqlConnection(App.ConnectionString))
            {
                var sql = "DELETE FROM Admins " +
                          "WHERE Id=@id";

                connection.Execute(sql, new { id = data.Id });
            }
        }

        public Admin Get(int id)
        {
            using (var connection = new SqlConnection(App.ConnectionString))
            {
                var sql = "SELECT * FROM Admins " +
                          "WHERE Id=@adminId";

                return connection.QuerySingleOrDefault<Admin>(sql, new { adminId = id});
            }
        }

        public IEnumerable<Admin> GetAll()
        {
            var admins = new List<Admin>();
            using (var connection = new SqlConnection(App.ConnectionString))
            {
                var sql = "SELECT * FROM Admins";
                admins = connection.Query<Admin>(sql).ToList();
            }
            return admins;
        }

        public void Update(Admin entity)
        {
            using (var connection = new SqlConnection(App.ConnectionString))
            {
                var sql = "UPDATE Admins " +
                          "SET " +
                          "Email = @email, " +
                          "Username = @username, " +
                          "Password = @password " +
                          "WHERE Id=@id";
                connection.Execute(sql, new { id = entity.Id, email = entity.Email, username = entity.Username, password = entity.Password });
            }
        }
    }
}
