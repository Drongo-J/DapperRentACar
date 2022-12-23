using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperRentACar.DataAccess.Entitites
{
    public class Rent
    {
        public int Id { get; set; }
        public int Car_Id { get; set; }
        public int Client_Id { get; set; }
        public DateTime RentStartDate { get; set; }
        public DateTime RentEndDate { get; set; }
    }
}
