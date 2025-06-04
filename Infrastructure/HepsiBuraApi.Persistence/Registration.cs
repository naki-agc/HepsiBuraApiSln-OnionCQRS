using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using HepsiBuraApi.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using HepsiBuraApi.Application.Interface.Repositories;
using HepsiBuraApi.Persistence.Repositories;
using HepsiBuraApi.Application.Interface.UnitOfWork;
using HepsiBuraApi.Persistence.UnitOfWorks;

namespace HepsiBuraApi.Persistence
{
    public static class Registration
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
          services.AddDbContext<AppDbContext>(options =>
          {
              options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
          });

            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

        }
    }
}
