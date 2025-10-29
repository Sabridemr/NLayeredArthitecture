namespace NLayeredArthitecture.Services
{
    public record ProductCategoryDto(int CategoryId , string CategoryName , List<ProductDto> Products);
}