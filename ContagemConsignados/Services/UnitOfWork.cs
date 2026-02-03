using ContagemConsignados.AppDataBase;
using ContagemConsignados.Mvvm.Model;
using ContagemConsignados.Services.Interface;
using SQLite;
using System.Data;
using System.Data.Common;

namespace ContagemConsignados.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDatabase _database;
        public ICountServices? _countServices;
        public IProductServices? _productServices;

        public UnitOfWork(AppDatabase database)
        {
            _database = database;
        }


        public ICountServices CountServices
        {
            get
            {
                return _countServices = _countServices ?? new CountServices(_database);
            }
        }

        public IProductServices ProductServices
        {
            get
            {
                return _productServices ?? new ProductServices(_database);
            }
        }

    }
}
