using HepsiBuraApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HepsiBuraApi.Persistence.Configurations;

public class CategoryConfiguration:IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.Property(x=>x.Name).IsRequired();
        
        Category category1 = new()
        {
            Id = 1,
            Name = "Elektrik",
            Priority = 1,
            ParentId = 0,
            IsDeleted = false,
            CreatedDate = DateTime.Now,
        };

        Category category2 = new()
        {
            Id = 2,
            Name = "Moda",
            Priority = 2,
            ParentId = 0,
            IsDeleted = false,
            CreatedDate = DateTime.Now,
        };
        
        Category parent1 = new()
        {
            Id = 3,
            Name = "Bilgisayar",
            Priority = 1,
            ParentId = 1,
            IsDeleted = false,
            CreatedDate = DateTime.Now,
        };
        
        Category parent2 = new()
        {
            Id = 4,
            Name = "Kadın",
            Priority = 1,
            ParentId = 2,
            IsDeleted = false,
            CreatedDate = DateTime.Now,
        };
        
        builder.HasData(category1, category2, parent1, parent2);

    }
}