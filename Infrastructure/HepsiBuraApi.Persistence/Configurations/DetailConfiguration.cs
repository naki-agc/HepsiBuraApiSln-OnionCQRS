using Bogus;
using HepsiBuraApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HepsiBuraApi.Persistence.Configurations;

public class DetailConfiguration:IEntityTypeConfiguration<Detail>
{
    public void Configure(EntityTypeBuilder<Detail> builder)
    {
        Faker faker = new("tr");
        Detail detail1 = new()
        {
            Id = 1,
            Title = faker.Lorem.Sentence(),
            Description = faker.Lorem.Sentence(5),
            CategoryId = 1,
            CreatedDate = DateTime.Now,
            IsDeleted = false
        };

        Detail detail2 = new()
        {
            Id = 2,
            Title = faker.Lorem.Sentence(2),
            Description = faker.Lorem.Sentence(5),
            CategoryId = 3,
            CreatedDate = DateTime.Now,
            IsDeleted = true
        };
        
        
        Detail detail3 = new()
        {
            Id = 3,
            Title = faker.Lorem.Sentence(1),
            Description = faker.Lorem.Sentence(5),
            CategoryId = 4,
            CreatedDate = DateTime.Now,
            IsDeleted = false
        };
        
        builder.HasData(detail1, detail2, detail3);
    
            
    }
}