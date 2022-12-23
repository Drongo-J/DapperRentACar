using Dapper;
using DapperRentACar.DataAccess.Abstractions;
using DapperRentACar.DataAccess.Entitites;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperRentACar.DataAccess.Concretes
{
    public class ClientRepository : IClientRepository
    {
        public void Add(Client entity)
        {
            using (var connection = new SqlConnection(App.ConnectionString))
            {
                var sql = @"INSERT INTO Clients([Username],[Password]) " +
                           "VALUES (@username, @password)";

                connection.Execute(sql, new { username = entity.Username, password = entity.Password });
            }   
        }

        public void Delete(Client data)
        {
            using (var connection = new SqlConnection(App.ConnectionString))
            {
                var sql = "DELETE FROM Clients " +
                          "WHERE Id=@id";

                connection.Execute(sql, new { id = data.Id });
            }
        }

        public Client Get(int id)
        {
            using (var connection = new SqlConnection(App.ConnectionString))
            {
                var sql = "SELECT * FROM Clients " +
                          "WHERE Id=@clientId";

                return connection.QuerySingleOrDefault(sql, new { clientId = id });
            }
        }

        public IEnumerable<Client> GetAll()
        {
            var clients = new List<Client>();
            using (var connection = new SqlConnection(App.ConnectionString))
            {
                var sql = "SELECT * FROM Clients";
                clients = connection.Query<Client>(sql).ToList();
            }
            return clients;
        }

        public void Update(Client entity)
        {
            using (var connection = new SqlConnection(App.ConnectionString))
            {
                var sql = "UPDATE Clients " +
                          "SET " +
                          "Username = @username, " +
                          "Password = @password " +
                          "WHERE Id=@id";
                connection.Execute(sql, new { id = entity.Id, username = entity.Username, password = entity.Password });
            }
        }
    }
}
