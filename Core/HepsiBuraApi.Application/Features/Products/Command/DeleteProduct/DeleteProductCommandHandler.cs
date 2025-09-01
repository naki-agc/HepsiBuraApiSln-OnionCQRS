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

namespace HepsiBuraApi.Application.Features.Products.Command.DeleteProduct
{
    public class DeleteProductCommandHandler :BaseHandler, IRequestHandler<DeleteProductCommandRequest, Unit>
    {
        public DeleteProductCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }
        public async Task<Unit> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.GetReadRepository<Product>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);
            product.IsDeleted = true;

            await _unitOfWork.GetWriteRepository<Product>().UpdateAsync(product);
            await _unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
