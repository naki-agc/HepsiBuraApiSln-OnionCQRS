using HepsiBuraApi.Infrastructure.Tokens;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiBuraApi.Infrastructure
{
    public static class Registration
    {
        public static void AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
        {
            services.Configure<TokenSettings>(configuration.GetSection("JWT"));

            // Burada altyapı ile ilgili servisleri ekleyebilirsiniz.
            // Örneğin, veri tabanı bağlantıları, dış hizmet entegrasyonları vb.

            // Örnek: services.AddDbContext<MyDbContext>(options => ...);
            // Örnek: services.AddHttpClient();
        }
    }
}
