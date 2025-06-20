﻿using HepsiBuraApi.Application.Interface.Repositories;
using HepsiBuraApi.Application.Interface.UnitOfWorks;
using HepsiBuraApi.Persistence.Context;
using HepsiBuraApi.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HepsiBuraApi.Persistence.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async ValueTask DisposeAsync() => await _dbContext.DisposeAsync();

        public int Save() => _dbContext.SaveChanges();
        public async Task<int> SaveAsync() => await _dbContext.SaveChangesAsync();
        IReadRepository<T> IUnitOfWork.GetReadRepository<T>() => new ReadRepository<T>(_dbContext);
        IWriteRepository<T> IUnitOfWork.GetWriteRepository<T>() => new WriteRepository<T>(_dbContext);
    }
}
