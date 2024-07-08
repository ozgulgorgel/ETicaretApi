using ETicaretApi.Application.Abstractions;
using ETicaretApi.Application.Repositories;
using ETicaretApi.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ETicaretApi.Application.Features.Queries.Product.GetByIdProduct
{
    public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQueryRequest, GetByIdProductQueryResponse>
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly ICacheService _cacheservice;
        public GetByIdProductQueryHandler(IProductReadRepository productReadRepository, ICacheService cacheService)
        {
            _productReadRepository = productReadRepository;
            _cacheservice = cacheService;

        }
        public async Task<GetByIdProductQueryResponse> Handle(GetByIdProductQueryRequest request, CancellationToken cancellationToken)
        {
            ETicaretApi.Domain.Entities.Product? product;

            product = _cacheservice.Get<ETicaretApi.Domain.Entities.Product>("product");
            if (product is null)
            {
                product = await _productReadRepository.GetByIdAsync(request.Id);
                _cacheservice.Set<ETicaretApi.Domain.Entities.Product>("product", product);
            }

            GetByIdProductQueryResponse response = new GetByIdProductQueryResponse();
            response.Name = product.Name;
            response.Price = product.Price;
            response.Stock = product.Stock;
            return response;

        }
    }
}
