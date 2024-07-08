using ETicaretApi.Application.Abstractions;
using ETicaretApi.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Application.Features.Commands.Product.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
    {

         private  readonly IProductReadRepository _productreadrepository;
        private readonly IProductWriteRepository _productwriterepository;
        readonly ICacheService _cacheService;

        public UpdateProductCommandHandler(IProductWriteRepository productwriterepository, IProductReadRepository productreadrepository, ICacheService cacheService)
        {
            _productwriterepository = productwriterepository;
            _productreadrepository = productreadrepository;
            _cacheService = cacheService;
        }

       

        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Product p = await _productreadrepository.GetByIdAsync(request.Id);
            p.Stock = request.Stock;
            p.Price = request.Price;
            p.Name = request.Name;
           _productwriterepository.Update(p);
            _productwriterepository.SaveAsync();
            _cacheService.Remove("product");
            return new();

        }
    }
}
