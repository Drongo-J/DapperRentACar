using DapperRentACar.DataAccess.Concretes;
using DapperRentACar.DataAccess.Entitites;
using DapperRentACar.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace DapperRentACar
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Grid MyGrid { get; internal set; }

        public static List<UIElement> Pages { get; internal set; } = new List<UIElement>();

        public static UnitOfWork Database;

        public static string ConnectionString;

        public static Window ChildWindow { get; internal set; }

        public static Rectangle Rectangle { get; internal set; }

        public static Client CurrentClient { get; internal set; }

        public App()
        {
            CurrentClient = null;
            ConnectionString = ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString;
            Database = new UnitOfWork();
        }

        public static void ChangePage(UIElement newPage, bool add = true)
        {
            if (add)
                Pages.Add(newPage);
            MyGrid.Children.Clear();
            MyGrid.Children.Insert(Constants.BeginningIndex, newPage);
        }

        public static void GoToPreviousPage()
        {
            Pages.Remove(Pages.Last());
            App.ChangePage(Pages.Last(), false);
        }
    }
}
