using HepsiBuraApi.Application.Interface.AutoMapper;
using HepsiBuraApi.Application.Interface.UnitOfWorks;
using HepsiBuraApi.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiBuraApi.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, IList<GetAllProductsQueryResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllProductsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IList<GetAllProductsQueryResponse>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var products = await _unitOfWork.GetReadRepository<Product>().GetAllAsync(include:x=> x.Include(b=> b.Brand));
            List<GetAllProductsQueryResponse> response = new();
            
       

            var map = _mapper.Map<GetAllProductsQueryResponse, Product>(products);
            foreach (var item in map)
            {
                item.Price -= (item.Price * item.Discount / 100);
            }

            return map;
            //throw new Exception("Hata mesajı");
        }
    }
}
