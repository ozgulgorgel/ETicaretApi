using ETicaretApi.Application.Abstractions;
using ETicaretApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Concretes
{
    public class ProductService : IProductService
    {
        public List<Product> GetProducts()
            => new()
            {
                new() {Id=Guid.NewGuid(),Name="product1",Price=100,Stock=44}  ,
                new() {Id=Guid.NewGuid(),Name="product2",Price=11,Stock=45}  ,
                new() {Id=Guid.NewGuid(),Name="product3",Price=12,Stock=46}  ,
                new() {Id=Guid.NewGuid(),Name="product4",Price=13,Stock=444447}
            };
    }
}
