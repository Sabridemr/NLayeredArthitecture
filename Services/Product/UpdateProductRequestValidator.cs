using FluentValidation;

namespace NLayeredArthitecture.Services
{
    public class UpdateProductRequestValidator : AbstractValidator<UpdateProductRequestDto>
    {
        public UpdateProductRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("Ürün ismi gereklidir.")
                .NotEmpty().WithMessage("Ürün ismi gereklidir.")
                .Length(3, 10).WithMessage("Ürün ismi 3 ile 10 karakter arasında olmalıdır.");
            RuleFor(x => x.Price)
               .GreaterThan(0).WithMessage("Ürün fiyatı 0'dan büyük olmalıdır.");


            RuleFor(x => x.Stock)
               .InclusiveBetween(1, 100).WithMessage("Stok adedi 1 ile 100 arasında olmalıdır.");

            RuleFor(x => x.categoryId)
                .GreaterThan(0).WithMessage("CategoryId greater than zero.");
            
        }
    }
}