using HepsiBuraApi.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiBuraApi.Application.Interface.Repositories
{
    public interface IWriteRepository<T> where T : class , IEntityBase, new()
    {
        Task AddAsync(T entity);
        Task AddRangeAsync(IList<T> entities);
        Task UpdateAsync(T entity);
        Task HardDeleteAsync(T entity);
    }
}
