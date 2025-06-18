using MediatR;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiBuraApi.Application.Beheviors
{
    public class FluentValidationBehevior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse> //request döneceği kısımda responsa olacak
    {
        private readonly IEnumerable<IValidator<TRequest>> _validator;
        public FluentValidationBehevior(IEnumerable<IValidator<TRequest>> validator)
        {
            _validator = validator;
        }
        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
           
            var context =new ValidationContext<TRequest>(request);
            var failtures = _validator.Select(x => x.Validate(context))
                .SelectMany(x => x.Errors)
                .GroupBy(x=> x.ErrorMessage)
                .Select(x => x.First())
                .Where(x => x != null).ToList();

            if (failtures.Any())
                throw new ValidationException(failtures);

            return next(); //next ile requesti gönderiyoruz, eğer hata yoksa requesti işleme alacak middleware gibi çalışıyor
        }
    }

}
