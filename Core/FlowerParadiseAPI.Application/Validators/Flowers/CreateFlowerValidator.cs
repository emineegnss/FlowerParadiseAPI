using FlowerParadiseAPI.Application.ViewModels.Flowers;
using FlowerParadiseAPI.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerParadiseAPI.Application.Validators.Flowers
{
    public class CreateFlowerValidator : AbstractValidator<VM_Create_Flower>
    {
        public CreateFlowerValidator() {
            RuleFor(f => f.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Ürün Adını Boş Geçmeyiniz.")
                .MaximumLength(150)
                .MinimumLength(3)
                .WithMessage("Lütfen Ürün adını 5 ile 150 karakter arasında giriniz..");
            RuleFor(f => f.Stock)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Stok bilgisini boş geçmeyiniz")
                .Must(f => f >= 0)
                .WithMessage("Stok bilgisini 0'dan büyük giriniz");
            RuleFor(f => f.Price)
                 .NotEmpty()
                 .NotNull()
                 .WithMessage("Lütfen Price bilgisini boş geçmeyiniz")
                 .Must(f => f >= 0)
                 .WithMessage("Price bilgisini 0'dan büyük giriniz");
        }
    }
}
