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
    public class RentRepository : IRentRepository
    {
        public void Add(Rent entity)
        {
            using (var connection = new SqlConnection(App.ConnectionString))
            {
                var sql = "INSERT INTO Rents([Car_Id],[Client_Id],[RentStartDate],[RentEndDate]) " +
                          "VALUES (@carId, @clientId, @rentStartDate, @rentEndDate)";

                connection.Execute(sql, new { carId = entity.Car_Id, clientId = entity.Client_Id, 
                                              rentStartDate = entity.RentStartDate, rentEndDate = entity.RentEndDate });
            }
        }

        public void Delete(Rent data)
        {
            using (var connection = new SqlConnection(App.ConnectionString))
            {
                var sql = "DELETE FROM Rents " +
                          "WHERE Id=@rentId";

                connection.Execute(sql, new { rentId = data.Id });
            }
        }

        public Rent Get(int id)
        {
            using (var connection = new SqlConnection(App.ConnectionString))
            {
                var sql = "SELECT * FROM Rents " +
                          "WHERE Id=@rentId";
                return connection.QuerySingleOrDefault<Rent>(sql, new { rentId = id });
            }
        }

        public IEnumerable<Rent> GetAll()
        {
            var rents = new List<Rent>();
            using (var connection = new SqlConnection(App.ConnectionString))
            {
                var sql = "SELECT * FROM Rents";
                rents = connection.Query<Rent>(sql).ToList();
            }
            return rents;
        }

        public void Update(Rent entity)
        {
            using (var connection = new SqlConnection(App.ConnectionString))
            {
                var sql = "UPDATE Rents " +
                          "SET " +
                          "Car_Id=@carId, " +
                          "Client_Id=@clientId" +
                          "RentStartDate = @rentStartDate" +
                          "RentEndDate = @RentEndDate " +
                          "WHERE Id=@rentId";

                connection.Execute(sql, new
                {
                    carId = entity.Car_Id,
                    clientId = entity.Client_Id,
                    rentStartDate = entity.RentStartDate,
                    rentEndDate = entity.RentEndDate
                });
            }
        }
    }
}
