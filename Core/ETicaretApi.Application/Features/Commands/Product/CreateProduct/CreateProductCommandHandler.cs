using ETicaretApi.Application.Abstractions;
using ETicaretApi.Application.Repositories;
using ETicaretApi.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Application.Features.Commands.Product.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {

        readonly IProductWriteRepository _productWriteRepository;
        readonly ICacheService _cacheService;

        public CreateProductCommandHandler(ICacheService cacheService, IProductWriteRepository productWriteRepository)
        {
            _cacheService = cacheService;
            _productWriteRepository = productWriteRepository;
        }


        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            ETicaretApi.Domain.Entities.Product p = new ETicaretApi.Domain.Entities.Product();
            p.Name = request.Name;
            p.Stock = request.Stock;
            p.Price = request.Price;
            p.CreatedDate = DateTime.Now;
            p.Id = Guid.NewGuid();
            await _productWriteRepository.AddAsync(p);
            await _productWriteRepository.SaveAsync();
            _cacheService.Remove("product");
            return new();

        }
    }
}
