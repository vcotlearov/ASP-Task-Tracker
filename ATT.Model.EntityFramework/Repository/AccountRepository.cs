using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATT.Infrastructure.ActionResults;
using ATT.Infrastructure.EntityFramework.Models;
using ATT.Infrastructure.EntityFramework.Results;
using ATT.Infrastructure.Exceptions;
using ATT.Infrastructure.Models;
using ATT.Infrastructure.Models.Employee;
using ATT.Infrastructure.Repository;

namespace ATT.Infrastructure.EntityFramework.Repository
{
    public class AccountRepository : IRepository
    {
        private readonly TaskTrackerEntities _db;
        private AccountRepositoryResult _arResult;

        public AccountRepository()
        {
            _db = new TaskTrackerEntities();
        }

        public IRepositoryResult Find(int id)
        {
            if (_db == null)
            {
                var message = "Database is not available at the moment";
                var exception = new TaskTrackerException("DB context is null", new NullReferenceException());
                _arResult = new AccountRepositoryResult(message, exception);

                return _arResult;
            }

            if (id < 1)
            {
                var message = "Invalid identification number was specified";
                var exception = new TaskTrackerException($"Invalid ID [{id}]", new ArgumentOutOfRangeException());
                _arResult = new AccountRepositoryResult(message, exception);
            }

            var dbAcc = _db.Accounts.Find(id);
            if (dbAcc == null)
            {
                var message = "No acount was found";
                var exception = new TaskTrackerObjectNotFoundException($"Account with ID [{id}] not found");
                _arResult = new AccountRepositoryResult(message, exception);

                return _arResult;
            }

            var employee = new AttAccount(dbAcc.ID)
            {
                Name = dbAcc.Name,
                EUID = dbAcc.EUID
            };

            var objects = new List<ISecurableObject>() { employee };
            _arResult = new AccountRepositoryResult(objects);

            return _arResult;
        }

        public IRepositoryResult Get(ISecurableObject obj)
        {
            throw new NotImplementedException();
        }

        public IRepositoryResult Create(ISecurableObject obj)
        {
            throw new NotImplementedException();
        }

        public IRepositoryResult Update(ISecurableObject obj)
        {
            throw new NotImplementedException();
        }

        public IRepositoryResult Delete(ISecurableObject obj)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _db?.Dispose();
        }
    }
}
