using System.Net;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NLayeredArthitecture.Repositories;
using Services.DTOS;

namespace NLayeredArthitecture.Services
{   
    public class CategoryService(ICategoryRepository categoryRepository , IUnitOfWork unitOfWork , IMapper mapper) : ICategoryService
    {
        //Crud Operation
        public async Task<ServiceResult<List<ProductCategoryDto>>> GetCategoryWithProduct()
        {
            var category = await categoryRepository.GetCategoryWithProduct().ToListAsync();

            if (category is null)
            {
                return ServiceResult<List<ProductCategoryDto>>.Fail("Kategori bulunamadı", HttpStatusCode.NotFound);
            }

            var categoriesAsDto = mapper.Map<List<ProductCategoryDto>>(category);
            return ServiceResult<List<ProductCategoryDto>>.Success(categoriesAsDto);


        }
        public async Task<ServiceResult<ProductCategoryDto>> GetCategoryWithProductsAsync(int categoryId)
        {
            var category = await categoryRepository.GetCategoryWithProductAsync(categoryId);

            if (category is null)
            {
                return ServiceResult<ProductCategoryDto>.Fail("Kategori bulunamadı", HttpStatusCode.NotFound);
            }

            var categoriesAsDto = mapper.Map<ProductCategoryDto>(category);
            return ServiceResult<ProductCategoryDto>.Success(categoriesAsDto);


        }
        public async Task<ServiceResult<List<CategoryDto>>> GetAllListAsync()
        {
            var categories = await categoryRepository.GetAll().ToListAsync();
            var categoriesAsDto = mapper.Map<List<CategoryDto>>(categories);
            return ServiceResult<List<CategoryDto>>.Success(categoriesAsDto);
        }
        public async Task<ServiceResult<CategoryDto>> GetByIdAsync(int id)
        {
            var category = await categoryRepository.GetByIdAsync(id);
            if (category is null)
            {
                return ServiceResult<CategoryDto>.Fail("Kategori bulunamadı.", HttpStatusCode.NotFound);
            }
            var categoriesAsDto = mapper.Map<CategoryDto>(category);
            return ServiceResult<CategoryDto>.Success(categoriesAsDto);

        }
        public async Task<ServiceResult<int>> CreateAsync(CreateCategoryRequest request)
        {

            var anyCategory = await categoryRepository.Where(x => x.CategoryName == request.Name).AnyAsync();

            if (anyCategory)
            {
                return ServiceResult<int>.Fail("Kategori ismi veritabanında bulunmaktadır", HttpStatusCode.NotFound);
            }
            var newCategory = new Categories { CategoryName = request.Name };
            await categoryRepository.AddAsync(newCategory);
            await unitOfWork.SaveChangeAsync();
            return ServiceResult<int>.Success(newCategory.CategoryId);
        }
        public async Task<ServiceResult> UpdateAsync(int id, UpdateCategoryRequest request)
        {
            var category = await categoryRepository.GetByIdAsync(id);

            if (category is null)
            {
                return ServiceResult.Fail("Cateogory bulunamadı", HttpStatusCode.NotFound);
            }

            var isCategoryNameExist = await categoryRepository.Where(x => x.CategoryName == request.CateogoryName && x.CategoryId != category.CategoryId).AnyAsync();

            if (isCategoryNameExist)
            {
                return ServiceResult.Fail("Kategori ismi veritabanında bulunmaktadır.", HttpStatusCode.BadRequest);
            }

            category = mapper.Map(request, category);
            categoryRepository.Update(category);
            await unitOfWork.SaveChangeAsync();
            return ServiceResult.Success(HttpStatusCode.NoContent);

        }
        public async Task<ServiceResult> DeleteAysnc(int id)
        {
            var category = await categoryRepository.GetByIdAsync(id);
            if (category is null)
            {
                return ServiceResult.Fail("Kategori bulunamadı", HttpStatusCode.NotFound);
            }

            categoryRepository.Delete(category);
            await unitOfWork.SaveChangeAsync();
            return ServiceResult.Success(HttpStatusCode.NoContent);
        }
        

    }
}