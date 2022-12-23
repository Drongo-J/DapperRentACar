using DapperRentACar.DataAccess.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperRentACar.DataAccess.Abstractions
{
    public interface ICarRepository : IRepository<Car> 
    {
    }
}
