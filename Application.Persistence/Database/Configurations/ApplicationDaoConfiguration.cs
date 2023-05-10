using Application.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Persistence.Database.Configurations;

public class ApplicationDaoConfiguration : IEntityTypeConfiguration<ApplicationDao>
{
    public void Configure(EntityTypeBuilder<ApplicationDao> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder
            .Property(x => x.Id)
            .ValueGeneratedOnAdd();

    }
}