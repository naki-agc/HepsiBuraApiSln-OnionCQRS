using HepsiBuraApi.Application.Exceptions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using MediatR;
using HepsiBuraApi.Application.Beheviors;
using FluentValidation;

namespace HepsiBuraApi.Application
{
    public static class Registration
    {

        public static void AddApplication(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddTransient<ExceptionMiddleware>();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));


            // fluentValidation için registration
            //
            services.AddValidatorsFromAssembly(assembly);

            ValidatorOptions.LanguageManager = new FluentValidation.Resources.LanguageManager
            {
                Culture = new CultureInfo("tr")
            };

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehevior<,>));
            //
        
        }
    }
}
