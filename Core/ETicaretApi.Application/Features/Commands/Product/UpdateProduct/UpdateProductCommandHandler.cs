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

        public UpdateProductCommandHandler(IProductWriteRepository productwriterepository, IProductReadRepository productreadrepository)
        {
            _productwriterepository = productwriterepository;
            _productreadrepository = productreadrepository; 
           
        }

       

        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Product p = await _productreadrepository.GetByIdAsync(request.Id);
            p.Stock = request.Stock;
            p.Price = request.Price;
            p.Name = request.Name;
           _productwriterepository.Update(p);
            _productwriterepository.SaveAsync();
            return new();

        }
    }
}
