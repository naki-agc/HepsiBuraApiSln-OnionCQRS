using HepsiBuraApi.Application.Features.Products.Command.CreateProduct;
using HepsiBuraApi.Application.Features.Products.Command.DeleteProduct;
using HepsiBuraApi.Application.Features.Products.Command.UpdateProduct;
using HepsiBuraApi.Application.Features.Products.Queries.GetAllProducts;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HepsiBuraApi.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var response = await _mediator.Send(new GetAllProductsQueryRequest());
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommandRequest request)
        {
            var response = _mediator.Send(request);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommandRequest request)
        {
            var response = _mediator.Send(request);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProduct(DeleteProductCommandRequest request)
        {
            var response = _mediator.Send(request);
            return Ok();
        }


    }
}
