using HepsiBuraApi.Domain.Common;

namespace HepsiBuraApi.Domain.Entities;

public class Category:EntityBase
{

    public Category()
    {
        
    }

    public Category(int parentId, string name, int priority)
    {
        ParentId = parentId;
        Name = name;
        Priority = priority;
    }
    public required int ParentId { get; set; }
    public required string Name { get; set; }
    public required int Priority { get; set; }
    public ICollection<Detail> Details { get; set; }
    
    public ICollection<Product> Products { get; set; }
}