using System.Net;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using NLayeredArthitecture.Repositories;
using Repositories.Entities;



namespace NLayeredArthitecture.Services
{
    public class ProductService(IProductRepository productRepository , IUnitOfWork unitOfWork) : IProductService
    {
        public async Task<ServiceResult<List<ProductDto>>> GetTopPriceProductsAsync(int count)
        {
            var products = await productRepository.GetTopPriceProductsAsync(count);
            var productAsDto = products.Select(p => new ProductDto(p.ProductId, p.ProductName, p.Price, p.Stock)).ToList();
            return new ServiceResult<List<ProductDto>>()
            {
                Data = productAsDto
            };

        }

        public async Task<ServiceResult<List<ProductDto>>> GetAllAsync()
        {
            var products = await productRepository.GetAll().ToListAsync();

            var productAsDto = products.Select(p => new ProductDto(p.ProductId, p.ProductName, p.Price, p.Stock)).ToList();

            return ServiceResult<List<ProductDto>>.Success(productAsDto);

        }

        public async Task<ServiceResult<List<ProductDto>>> GetPagedAllListAsync(int pageNumber,int pageSize)
        {


            var products = await productRepository.GetAll().Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            var productAsDto = products.Select(p => new ProductDto(p.ProductId, p.ProductName, p.Price, p.Stock)).ToList();
            return ServiceResult<List<ProductDto>>.Success(productAsDto);
            
        }

        public async Task<ServiceResult<ProductDto>> GetProductByIdAsync(int id)
        {
            var product = await productRepository.GetByIdAsync(id);

            if (product is null)
            {
                return ServiceResult<ProductDto>.Fail("Product not found", HttpStatusCode.NotFound);
            }

            var productAsDto = new ProductDto(product.ProductId, product.ProductName, product.Price, product.Stock);
            return ServiceResult<ProductDto>.Success(productAsDto!);

        }

        public async Task<ServiceResult<CreateProductResponseDto>> CreateProductAsync(CreateProductRequestDto request)
        {
            var product = new Product()
            {
                ProductName = request.Name,
                Price = request.Price,
                Stock = request.Stock
            };

            await productRepository.AddAsync(product);
            await unitOfWork.SaveChangeAsync();
            return ServiceResult<CreateProductResponseDto>.Success(new CreateProductResponseDto(product.ProductId));

        }

        public async Task<ServiceResult> UpdateProductAsync(int id, UpdateProductRequestDto requset)
        {
            var product = await productRepository.GetByIdAsync(id);

            if (product is null)
            {
                return ServiceResult.Fail("Product not found", HttpStatusCode.NotFound);
            }

            product.ProductName = requset.Name;
            product.Price = requset.Price;
            product.Stock = requset.Stock;

            productRepository.Update(product);
            await unitOfWork.SaveChangeAsync();

            return ServiceResult.Success();
        }

        public async Task<ServiceResult> UpdateStockAsync(int productId , int quantity)
        {
            var product = await productRepository.GetByIdAsync(productId);
            if (product is null)
            {
                return ServiceResult.Fail("Product Not Found", HttpStatusCode.NotFound);
            }

            product.Stock = quantity;
            productRepository.Update(product);
            await unitOfWork.SaveChangeAsync();
            return ServiceResult.Success(HttpStatusCode.NoContent);


        }
        public async Task<ServiceResult> DeleteProductAsync(int id)
        {
            var product = await productRepository.GetByIdAsync(id);

            if (product is null)
            {
                return ServiceResult.Fail("Product not found", HttpStatusCode.NotFound);
            }

            productRepository.Delete(product);
            await unitOfWork.SaveChangeAsync();
            return ServiceResult.Success();

        }

    }
} 