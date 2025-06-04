using HepsiBuraApi.Application.Interface.Repositories;
using HepsiBuraApi.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiBuraApi.Application.Interface.UnitOfWork
{
    public interface IUnitOfWork:IAsyncDisposable
    {

        IReadRepository<T> GetReadRepository<T>() where T : class, IEntityBase, new();
        IWriteRepository<T> GetWriteRepository<T>() where T : class, IEntityBase, new();

        Task<int> SaveAsync();
        Task<int> Save();
    }
}
