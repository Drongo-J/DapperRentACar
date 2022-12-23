using DapperRentACar.DataAccess.Entitites;
using DapperRentACar.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperRentACar.Domain.ViewModels
{
    public class CarUCViewModel : BaseViewModel
    {
        public Car Car { get; set; }

        public string RentPrice { get; set; }

        public string CarDetails1 { get; set; }
        public string CarDetails2 { get; set; }

        public CarUCViewModel(Car car)
        {
            Car = car;
            RentPrice = Car.RentPrice.ToString() + " " + Constants.DollarSign + " / day"; // rent price

            if (Car.Color.Trim() == string.Empty)
                CarDetails1 = "No Info";
            else
                CarDetails1 = Car.Color;
            CarDetails2 = Car.Year + ", " + Car.FuelType + ", " + Car.Mileage + " " + Constants.Kilometer;
            //ImageSource = @"\Domain\Images\carImage.jpeg";
        }
    }
}
