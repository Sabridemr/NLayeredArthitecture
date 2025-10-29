using Services.DTOS;

namespace NLayeredArthitecture.Services
{
    public interface ICategoryService
    {
        Task<ServiceResult<int>> CreateAsync(CreateCategoryRequest request);
        Task<ServiceResult> UpdateAsync(int id, UpdateCategoryRequest request);
        Task<ServiceResult> DeleteAysnc(int id);
        Task<ServiceResult<List<CategoryDto>>> GetAllListAsync();
        Task<ServiceResult<CategoryDto>> GetByIdAsync(int id);
        Task<ServiceResult<List<ProductCategoryDto>>> GetCategoryWithProduct();
        Task<ServiceResult<ProductCategoryDto>> GetCategoryWithProductsAsync(int categoryId);
    }
    
}