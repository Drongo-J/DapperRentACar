using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperRentACar.DataAccess.Abstractions
{
    public interface IUnitOfWork
    {
        ICarRepository CarRepository { get; }
        IRentRepository RentRepository { get; }
        IAdminRepository AdminRepository { get; }
        IClientRepository ClientRepository { get; }
    }
}
