using ETicaretApi.Application.Features.Commands.Product.CreateProduct;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ETicaretApi.Application.Validators.Product
{
    public class CreateProductValidatiors : AbstractValidator<CreateProductCommandRequest>
    {
        public CreateProductValidatiors()
        {
            RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull()
            .WithMessage("lütfen ürün adını boş geçmeyiniz")
            .MinimumLength(5)
            .WithMessage("lütfen ürün adını 5  karakter  giriniz");



            RuleFor(x => x.Stock)
                .NotEmpty()
                .NotNull()
                .WithMessage("lütfen stok bilgisini boş geçmeyiniz")
                .Must(s => s >= 0)
                .WithMessage("stok bilgisi negatif olamaz");


        }
    }
}
