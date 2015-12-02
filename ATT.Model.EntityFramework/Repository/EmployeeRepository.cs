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
        private readonly TaskTrackerEntities _db;
        private EmployeeRepositoryResult _erResult;

        public EmployeeRepository()
        {
            _db = new TaskTrackerEntities();
        }

        public IRepositoryResult Find(int id)
        {
            if (_db == null)
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

            var dbEmp = _db.Employees.Find(id);
            if (dbEmp == null)
            {
                var message = "No employee was found";
                var exception = new TaskTrackerObjectNotFoundException($"Employee with ID [{id}] not found");
                _erResult = new EmployeeRepositoryResult(message, exception);

                return _erResult;
            }

            AttEmployee employee = new AttEmployee(dbEmp.ID)
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
            if (_db?.Employees == null)
            {
                var message = "Database is not available at the moment";
                var exception = new TaskTrackerException("DB context is null", new NullReferenceException());
                _erResult = new EmployeeRepositoryResult(message, exception);

                return _erResult;
            }

            var dbEmp = _db.Employees.ToList();
            if (dbEmp.Count == 0)
            {
                var message = "No employees were found";
                var exception = new TaskTrackerObjectNotFoundException("Employees not found");
                _erResult = new EmployeeRepositoryResult(message, exception);

                return _erResult;
            }

            var employees = dbEmp.Select(employee => new AttEmployee(employee.ID)
            {
                Name = employee.Name,
                Surname = employee.Surname,
                EUID = employee.EUID
            });

            _erResult = new EmployeeRepositoryResult(employees);

            return _erResult;
        }

        public IRepositoryResult Create(ISecurableObject obj)
        {
            if (_db?.Employees == null)
            {
                var message = "Database is not available at the moment";
                var exception = new TaskTrackerException("DB context is null", new NullReferenceException());
                _erResult = new EmployeeRepositoryResult(message, exception);

                return _erResult;
            }

            var newEmployee = obj as AttEmployee;

            if (newEmployee == null)
            {
                var message = "Please specify valid data for Employee";
                var exception = new TaskTrackerException("object cannot be cast to Employee", new ArgumentException());
                _erResult = new EmployeeRepositoryResult(message, exception);

                return _erResult;
            }

            var emp = new Employee()
            {
                EUID = new Guid(),
                Name = newEmployee.Name,
                Surname = newEmployee.Surname
            };


            var dbEmp = _db.Employees.Add(emp);
            _db.SaveChanges();

            newEmployee = new AttEmployee(dbEmp.ID)
            {
                Name = dbEmp.Name,
                Surname = dbEmp.Surname,
                EUID = dbEmp.EUID
            };

            var objects = new List<ISecurableObject>() { newEmployee };
            _erResult = new EmployeeRepositoryResult(objects);

            return _erResult;
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
