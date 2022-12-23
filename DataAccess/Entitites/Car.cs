using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperRentACar.DataAccess.Entitites
{
    public class Car
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public bool IsNew { get; set; }
        public int Mileage { get; set; }
        public string Type { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public int Price { get; set; }
        public int RentPrice { get; set; }
        public string FuelType { get; set; }

        public void SetRentPrice(int price)
        {
            RentPrice = price / 600;
        }
    }
}
