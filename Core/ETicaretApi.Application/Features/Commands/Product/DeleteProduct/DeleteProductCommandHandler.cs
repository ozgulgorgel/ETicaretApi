using ETicaretApi.Application.Abstractions;
using ETicaretApi.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Application.Features.Commands.Product.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, DeleteProductCommandResponse>
    {

        private readonly IProductWriteRepository _productWriteRepository;
        readonly ICacheService _cacheService;

        public DeleteProductCommandHandler(IProductWriteRepository productWriteRepository, ICacheService cacheService)
        {
            _cacheService = cacheService;
            _productWriteRepository = productWriteRepository;
        }

        public async Task<DeleteProductCommandResponse> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            await _productWriteRepository.RemoveAsync(request.Id);
            await _productWriteRepository.SaveAsync();
            _cacheService.Remove("product");
            return new();

        }
    }
}
