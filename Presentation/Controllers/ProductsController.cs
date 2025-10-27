using Microsoft.AspNetCore.Mvc;
using NLayeredArthitecture.Services;

namespace NLayeredArthitecture.Presentation
{
    

    public class ProductsController(IProductService productService) : CustomBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()=> CreateActionResult(await productService.GetAllAsync());

        [HttpGet]
        public async Task<IActionResult> GetById(int id) => CreateActionResult(await productService.GetProductByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductRequestDto requset) => CreateActionResult(await productService.CreateProductAsync(requset));

        [HttpPut]
        public async Task<IActionResult> Update(int id, UpdateProductRequestDto request) => CreateActionResult(await productService.UpdateProductAsync(id, request));

        [HttpDelete]
        public async Task<IActionResult> Delete(int id) => CreateActionResult(await productService.DeleteProductAsync(id));
    }
}