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
        }
    }
}
