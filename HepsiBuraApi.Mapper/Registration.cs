using AutoMapper.Configuration;
using HepsiBuraApi.Application.Interface.AutoMapper;
using HepsiBuraApi.Application.Interface.Repositories;
using HepsiBuraApi.Application.Interface.UnitOfWorks;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiBuraApi.Mapper
{
    public static class Registration
    {
        public static void AddCustomMapper(this IServiceCollection services)
        {
            services.AddSingleton<IMapper, AutoMapper.Mapper>();

        }
    }
}
