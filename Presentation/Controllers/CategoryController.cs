using Microsoft.AspNetCore.Mvc;
using NLayeredArthitecture.Services;
using Services.DTOS;

namespace NLayeredArthitecture.Presentation
{
    public class CategoryController(ICategoryService categoryService) : CustomBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetCategories() => CreateActionResult(await categoryService.GetAllListAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id) => CreateActionResult(await categoryService.GetByIdAsync(id));

        [HttpGet("{id}/products")]
        public async Task<IActionResult> GetCategoryWithProducts(int id) => CreateActionResult(await categoryService.GetCategoryWithProductsAsync(id));

        [HttpGet("products")]
        public async Task<IActionResult> GetCategoryWithProducts() => CreateActionResult(await categoryService.GetCategoryWithProduct());

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryRequest request) => CreateActionResult(await categoryService.CreateAsync(request));

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, UpdateCategoryRequest request) => CreateActionResult(await categoryService.UpdateAsync(id, request));

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id) => CreateActionResult(await categoryService.DeleteAysnc(id));
        
    }
}