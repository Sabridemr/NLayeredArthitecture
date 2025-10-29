using Repositories.Entities;

namespace NLayeredArthitecture.Repositories
{
    public class Categories
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public List<Product>? Products { get; set; }
    }
}