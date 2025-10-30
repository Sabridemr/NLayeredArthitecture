using Repositories.Entities;

namespace NLayeredArthitecture.Repositories
{
    public class Categories:IAuditEntity
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public List<Product>? Products { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}