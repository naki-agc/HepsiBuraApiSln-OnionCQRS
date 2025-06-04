using HepsiBuraApi.Application.Interface.Repositories;
using HepsiBuraApi.Application.Interface.UnitOfWork;
using HepsiBuraApi.Persistence.Context;
using HepsiBuraApi.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiBuraApi.Persistence.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public ValueTask DisposeAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<int> Save() => await _dbContext.SaveChangesAsync();

        public async Task<int> SaveAsync() => await _dbContext.SaveChangesAsync();

        IReadRepository<T> IUnitOfWork.GetReadRepository<T>() => new ReadRepository<T>(_dbContext);

        IWriteRepository<T> IUnitOfWork.GetWriteRepository<T>() => new WriteRepository<T>(_dbContext);
    }
}
