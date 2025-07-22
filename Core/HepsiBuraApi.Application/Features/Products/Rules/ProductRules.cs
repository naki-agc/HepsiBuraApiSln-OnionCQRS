using HepsiBuraApi.Application.Bases;
using HepsiBuraApi.Application.Features.Products.Exceptions;
using HepsiBuraApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiBuraApi.Application.Features.Products.Rules
{
    public class ProductRules:BaseRules
    {
        public Task ProductTitleMustNotBeSameException(IList<Product> products,  string productTitle)
        {
            if (products.Any(x=> x.Title == productTitle)) throw new ProductTitleMustNotBeSameException();// kontrol ediyoruz, eğer varsa hata fırlatıyoruz yoksa işlem devam ediyor
            return Task.CompletedTask;
        }
    }
}
