using DapperRentACar.DataAccess.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperRentACar.DataAccess.Concretes
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICarRepository CarRepository => new CarRepository();

        public IRentRepository RentRepository => new RentRepository();

        public IAdminRepository AdminRepository => new AdminRepository();

        public IClientRepository ClientRepository => new ClientRepository();
    }
}
