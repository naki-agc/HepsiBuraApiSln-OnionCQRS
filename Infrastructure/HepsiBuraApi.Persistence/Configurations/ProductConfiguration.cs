using Bogus;
using HepsiBuraApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HepsiBuraApi.Persistence.Configurations;

public class ProductConfiguration: IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(p => p.Price)
       .HasPrecision(18, 2);

        builder.Property(p => p.Discount)
               .HasPrecision(18, 2);

        Faker faker = new("tr");
        Product product1 = new()
        {
            Id = 1,
            Title = faker.Commerce.ProductName(),
            Description = faker.Commerce.ProductDescription(),
            BrandId = 1,
            Discount = faker.Random.Decimal(1,10),
            Price = faker.Finance.Amount(10,1000),
            CreatedDate = DateTime.Now,
            IsDeleted = false
        };
        
        Product product2 = new()
        {
            Id = 2,
            Title = faker.Commerce.ProductName(),
            Description = faker.Commerce.ProductDescription(),
            BrandId = 3,
            Discount = faker.Random.Decimal(1,10),
            Price = faker.Finance.Amount(10,1000),
            CreatedDate = DateTime.Now,
            IsDeleted = false
        };
        
        builder.HasData(product1, product2);
    }
}