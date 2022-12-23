using Dapper;
using DapperRentACar.DataAccess.Abstractions;
using DapperRentACar.DataAccess.Entitites;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DapperRentACar.DataAccess.Concretes
{
    public class CarRepository : ICarRepository
    {
        public void Add(Car entity)
        {
            using (var connection = new SqlConnection(App.ConnectionString))
            {
                var sql = "INSERT INTO Cars([ImagePath],[Brand],[Model],[IsNew],[Mileage],[Type],[Year],[Color],[Price],[FuelType]) " +
                          "VALUES (@imagePath, @brand, @model, @isNew, @mileage, @type, @year, @color, @price, @fuelType)";

                connection.Execute(sql, new
                {
                    imagePath = entity.ImagePath,
                    brand = entity.Brand,
                    model = entity.Model,
                    isNew = entity.IsNew,
                    mileage = entity.Mileage,
                    type = entity.Type,
                    year     = entity.Year,
                    color = entity.Color,
                    price = entity.Price,
                    fuelType = entity.FuelType
                });
            }
        }

        public void Delete(Car data)
        {
            using (var connection = new SqlConnection(App.ConnectionString))
            {
                var sql = "DELETE FROM Cars " +
                          "WHERE Id=@id";

                connection.Execute(sql, new { id = data.Id });
            }
        }

        public Car Get(int id)
        {
            using (var connection = new SqlConnection(App.ConnectionString))
            {
                var sql = "SELECT * FROM Cars " +
                          "WHERE Id=@carId";

                return connection.QuerySingleOrDefault<Car>(sql, new { carId = id });
            }
        }

        public IEnumerable<Car> GetAll()
        {
            var cars = new List<Car>();
            using (var connection = new SqlConnection(App.ConnectionString))
            {
                var sql = "SELECT * FROM Cars ";
                
                cars =  connection.Query<Car>(sql).ToList();
            }
            return cars;
        }

        public void Update(Car entity)
        {
            using (var connection = new SqlConnection(App.ConnectionString))
            {
                var sql = "UPDATE Players " +
                          "SET " +
                          "ImagePath = @imagePath," +
                          "Brand = @brand, " +
                          "Model = @model, " +
                          "IsNew = @isNew, " +
                          "Mileage = @mileage, " +
                          "Type = @type, " +
                          "Year = @year, " +
                          "Color = @color, " +
                          "Price = @price, " +
                          "FuelType = @fuelType " +
                          "WHERE Id=@carId";

                connection.Execute(sql, new
                {
                    id = entity.Id,
                    imagePath = entity.ImagePath,
                    brand = entity.Brand,
                    model = entity.Model,
                    isNew = entity.IsNew,
                    mileage = entity.Mileage,
                    type = entity.Type,
                    year = entity.Year,
                    color = entity.Color,
                    price = entity.Price,
                    fuelType = entity.FuelType
                });
            }
        }
    }
}
