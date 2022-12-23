using DapperRentACar.DataAccess.Entitites;
using DapperRentACar.Domain.Commands;
using DapperRentACar.Domain.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace DapperRentACar.Domain.ViewModels
{
    public class RentUCViewModel : BaseViewModel
    {
        public RelayCommand SendEmail { get; set; }

        public Rent Rent { get; set; }

        public Client Client { get; set; }

        public string RentStartDate { get; set; }

        public string RentEndDate { get; set; }

        private SolidColorBrush borderColor;

        public SolidColorBrush BorderColor
        {
            get { return borderColor; }
            set { borderColor = value; OnPropertyChanged(); }
        }

        public RentUCViewModel(Rent _rent)
        {
            Rent = _rent;
            var date1 = Rent.RentStartDate.ToLongDateString().Split(',');
            RentStartDate = date1[1].Trim() + ", " + date1[2].Trim();
            var date2 = Rent.RentEndDate.ToLongDateString().Split(',');
            RentEndDate = date2[1].Trim() + ", " + date2[2].Trim();
            Client = App.Database.ClientRepository.Get(Rent.Client_Id);

            if (DateTime.Now < Rent.RentEndDate)
            {
                BorderColor = Brushes.Green;
            }
            else
            {
                BorderColor = Brushes.Red;

            }
        }

    }
}
