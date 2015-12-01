using System;
using System.Collections.Generic;
using ATT.Infrastructure.ActionResults;
using ATT.Infrastructure.Models;

namespace ATT.Infrastructure.Repository
{
    public interface IRepository : IDisposable
    {
        IRepositoryResult Find(int id);
        IRepositoryResult Get(ISecurableObject obj);
        IRepositoryResult Create(ISecurableObject obj);
        IRepositoryResult Update(ISecurableObject obj);
        IRepositoryResult Delete(ISecurableObject obj);
    }
}