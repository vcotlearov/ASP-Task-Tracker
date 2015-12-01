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
        private EmployeeRepositoryResult erResult;

        public EmployeeRepository()
        {
            db = new TaskTrackerEntities();
            erResult = new EmployeeRepositoryResult();
        }

        public IRepositoryResult Find(int id)
        {
            if (db == null)
            {
                erResult.ActionStatus = false;
                erResult.RepositoryObjects = null;
                erResult.ActionMessage = "Database is not available at the moment";
                erResult.ActionInnerException = new TaskTrackerException("DB context is null", new NullReferenceException());

                return erResult;
            }
            var dbEmp = db.Employees.Find(id);
            if (dbEmp == null)
            {
                erResult.ActionStatus = false;
                erResult.RepositoryObjects = null;
                erResult.ActionMessage = "No employee was found";
                erResult.ActionInnerException = new TaskTrackerException($"Employee with ID [{id}] not found");

                return erResult;
            }

            AttEmployee employee = new AttEmployee()
            {
                Name = dbEmp.Name,
                Surname = dbEmp.Surname,
                EUID = dbEmp.EUID
            };

            erResult.ActionStatus = true;
            erResult.RepositoryObjects = new List<ISecurableObject>() { employee };
            erResult.ActionMessage = "Success";
            erResult.ActionInnerException = null;

            return erResult;

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
