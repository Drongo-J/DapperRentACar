using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace DapperRentACar.Domain.Helpers
{
    public class Constants
    {
        public const string AllBrands = "All Brands";
        public const string AllCarTypes = "All Types";
        public const string DateTypeOld = "Old";
        public const string DateTypeNew = "New";
        public const string DateTypeAll = "All Date Types";
        public const string AllColors = "All Colors";
        public const string AllFuelTypes = "All Fuels Types";
        public const string NoPrice = "No Price";
        public static string NoMileage = "No Mileage";
        public const string NoYear = "No Year";
        public const string DollarSign = "$";
        public const string Kilometer = "km";
        public static int BeginningIndex = 0;
        public static string PerDay = " / day";
        public static string True = "true";
        public static string False = "false";
        public static string UsernameTakenError = "That username is taken. Try another.";
        public static string EmptyUsernameError = "Username cannot be empty!";
        public static string EmptyEmailError = "E-mail cannot be empty!";
        public static string EmailAlreadyRegisteredError = "Email is already registered.";
        public static string EmptyPasswordError = "Password cannot be empty!";
        public static string PasswordLengthError = "Password length must be 8 or greater!";
        public static string UsernameLengthError = "Username length must be 3 or greater!";
        public static string IncorrectEmailError = "Please, enter valid e-mail!";
        public static string EmailSubject = "Security Code";
    }
}
