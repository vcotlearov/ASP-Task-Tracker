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
            if (_db?.Accounts == null)
            {
                var message = "Database is not available at the moment";
                var exception = new TaskTrackerException("DB context is null", new NullReferenceException());
                _arResult = new AccountRepositoryResult(message, exception);

                return _arResult;
            }

            var queryAccount = obj as AttAccount;

            if (queryAccount == null)
            {
                var message = "Please specify valid data for Account";
                var exception = new TaskTrackerException("object cannot be cast to Account", new ArgumentException());
                _arResult = new AccountRepositoryResult(message, exception);

                return _arResult;
            }

            var dbAcc = _db.Accounts.Where(acc=>acc.EUID == queryAccount.EUID);
            if (!dbAcc.Any())
            {
                var message = "No accounts were found";
                var exception = new TaskTrackerObjectNotFoundException("Accounts not found");
                _arResult = new AccountRepositoryResult(message, exception);

                return _arResult;
            }

            var accounts = dbAcc.Select(account => new AttAccount(account.ID)
            {
               Name = account.Name,
               EUID = account.EUID,
               PasswordHash = account.PasswordHash
            });

            _arResult = new AccountRepositoryResult(accounts);

            return _arResult;
        }

        public IRepositoryResult Create(ISecurableObject obj)
        {
            if (_db?.Accounts == null)
            {
                var message = "Database is not available at the moment";
                var exception = new TaskTrackerException("DB context is null", new NullReferenceException());
                _arResult = new AccountRepositoryResult(message, exception);

                return _arResult;
            }

            var newAccount = obj as AttAccount;

            if (newAccount == null)
            {
                var message = "Please specify valid data for Account";
                var exception = new TaskTrackerException("object cannot be cast to Account", new ArgumentException());
                _arResult = new AccountRepositoryResult(message, exception);

                return _arResult;
            }

            var acc = new Account()
            {
                
                EUID = new Guid(),
                Name = newAccount.Name,
                PasswordHash = newAccount.PasswordHash,
                TypeID = newAccount.Type.Id
            };


            var dbAcc = _db.Accounts.Add(acc);
            _db.SaveChanges();

            newAccount = new AttAccount(dbAcc.ID)
            {
                Name = dbAcc.Name,
                EUID = dbAcc.EUID,
                Type = new AttAccountType(dbAcc.TypeID)
            };

            var objects = new List<ISecurableObject>() { newAccount };
            _arResult = new AccountRepositoryResult(objects);

            return _arResult;
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
