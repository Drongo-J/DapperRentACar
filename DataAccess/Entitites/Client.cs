using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperRentACar.DataAccess.Entitites
{
    public class Client : Human
    {
        public virtual ICollection<Rent> Rents { get; set; }
    }
}
