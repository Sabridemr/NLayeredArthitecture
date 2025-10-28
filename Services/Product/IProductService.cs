using NLayeredArthitecture.Repositories;

namespace NLayeredArthitecture.Services
{
    public interface IProductService
    {

        Task<ServiceResult<List<ProductDto>>> GetTopPriceProductsAsync(int count);

        Task<ServiceResult<List<ProductDto>>> GetAllAsync();
        Task<ServiceResult<List<ProductDto>>> GetPagedAllListAsync(int pageNumber, int pageSize);
        
        Task<ServiceResult<ProductDto>> GetProductByIdAsync(int id);

        Task<ServiceResult<CreateProductResponseDto>> CreateProductAsync(CreateProductRequestDto request);

        Task<ServiceResult> UpdateProductAsync(int id, UpdateProductRequestDto requset);

        Task<ServiceResult> DeleteProductAsync(int id);
    }
}