using HepsiBuraApi.Application.Bases;
using HepsiBuraApi.Application.Features.Products.Rules;
using HepsiBuraApi.Application.Interface.AutoMapper;
using HepsiBuraApi.Application.Interface.UnitOfWorks;
using HepsiBuraApi.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiBuraApi.Application.Features.Products.Command.CreateProduct
{
    public class CreateProductCommandHandler :BaseHandler, IRequestHandler<CreateProductCommandRequest, Unit>
    {
        private readonly ProductRules _productRules;
        public CreateProductCommandHandler(IMapper mapper, ProductRules productRules, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base (mapper, unitOfWork, httpContextAccessor)
        {
            _productRules = productRules;
        }
        public async Task<Unit> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            IList<Product> products = await _unitOfWork.GetReadRepository<Product>().GetAllAsync();// tüm kayıtları alıyoruz

            await _productRules.ProductTitleMustNotBeSameException(products, request.Title);// ürün başlığı daha önce eklenmemiş olmalı

            Product product = new Product(request.Title,request.Description,request.BrandId,request.Price,request.Discount);


            await _unitOfWork.GetWriteRepository<Product>().AddAsync(product);

            if (await _unitOfWork.SaveAsync() > 0)
            {
                foreach (var categoryId in request.CategoryIds)
                {

                    await _unitOfWork.GetWriteRepository<ProductCategory>().AddAsync(new()
                    {
                        ProductId = product.Id,
                        CategoryId = categoryId
                    });
                }
                await _unitOfWork.SaveAsync();
            }

            return Unit.Value;//Unit boş dönmemizi sağlar
        }
    }
}
