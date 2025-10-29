using NLayeredArthitecture.Repositories;

namespace Repositories.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public int CategoryId { get; set; }
        public Categories Category { get; set; } = default!;

    }
}