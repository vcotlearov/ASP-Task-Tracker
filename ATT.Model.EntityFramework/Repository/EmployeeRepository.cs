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
    public class EmployeeRepository : IRepository
    {
        private TaskTrackerEntities db;
        private EmployeeRepositoryResult _erResult;

        public EmployeeRepository()
        {
            db = new TaskTrackerEntities();
            
        }

        public IRepositoryResult Find(int id)
        {
            if (db == null)
            {
                var message = "Database is not available at the moment";
                var exception = new TaskTrackerException("DB context is null", new NullReferenceException());
                _erResult = new EmployeeRepositoryResult(message, exception);

                return _erResult;
            }

            if (id < 1)
            {
                var message = "Invalid identification number was specified";
                var exception = new TaskTrackerException($"Invalid ID [{id}]", new ArgumentOutOfRangeException());
                _erResult = new EmployeeRepositoryResult(message, exception);
            }

            var dbEmp = db.Employees.Find(id);
            if (dbEmp == null)
            {
                var message = "No employee was found";
                var exception = new TaskTrackerObjectNotFoundException($"Employee with ID [{id}] not found");
                _erResult = new EmployeeRepositoryResult(message, exception);

                return _erResult;
            }

            AttEmployee employee = new AttEmployee()
            {
                Name = dbEmp.Name,
                Surname = dbEmp.Surname,
                EUID = dbEmp.EUID
            };

            var objects = new List<ISecurableObject>() { employee };
            _erResult = new EmployeeRepositoryResult(objects);

            return _erResult;

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
            db?.Dispose();
        }
    }
}
