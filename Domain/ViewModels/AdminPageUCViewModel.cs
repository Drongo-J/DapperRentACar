using DapperRentACar.DataAccess.Entitites;
using DapperRentACar.Domain.Commands;
using DapperRentACar.Domain.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace DapperRentACar.Domain.ViewModels
{
    public class AdminPageUCViewModel : BaseViewModel
    {
        public RelayCommand BackCommand { get; set; }

        private ObservableCollection<UIElement> rents = new ObservableCollection<UIElement>();

        public ObservableCollection<UIElement> Rents
        {
            get { return rents; }
            set { rents = value; }
        }

        public AdminPageUCViewModel()
        {
            var rents = App.Database.RentRepository.GetAll();
            foreach (var rent in rents)
            {
                var rentUC = new RentUC();
                var rentUCVM = new RentUCViewModel(rent);
                var car = App.Database.CarRepository.Get(rent.Car_Id);
                rentUC.Image.Source = new BitmapImage(new Uri(car.ImagePath));
                rentUC.DataContext = rentUCVM;
                Rents.Add(rentUC);
            }

            BackCommand = new RelayCommand((b) =>
            {
                App.GoToPreviousPage();
            });
        }
    }
}
