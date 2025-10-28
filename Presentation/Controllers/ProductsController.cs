using System.Data;
using Microsoft.AspNetCore.Mvc;
using NLayeredArthitecture.Services;

namespace NLayeredArthitecture.Presentation
{
    

    public class ProductsController(IProductService productService) : CustomBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll() => CreateActionResult(await productService.GetAllAsync());

        [HttpGet("{pageNumber:int}/{pageSize:int}")]
        public async Task<IActionResult> GetPagedAll(int pageNumber , int pageSize)=> CreateActionResult(await productService.GetPagedAllListAsync(pageNumber,pageSize));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) => CreateActionResult(await productService.GetProductByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductRequestDto requset) => CreateActionResult(await productService.CreateProductAsync(requset));

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateProductRequestDto request) => CreateActionResult(await productService.UpdateProductAsync(id, request));

        [HttpPatch]
        public async Task<IActionResult> UpdateStock(int productId, int quantity) => CreateActionResult(await productService.UpdateStockAsync(productId, quantity));


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) => CreateActionResult(await productService.DeleteProductAsync(id));
    }
}