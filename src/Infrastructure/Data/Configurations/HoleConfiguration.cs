using GolfCaddie.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GolfCaddie.Infrastructure.Data.Configurations;

public class HoleConfiguration : IEntityTypeConfiguration<Hole>
{
    public void Configure(EntityTypeBuilder<Hole> builder)
    {
        builder.Property(v => v.Par)
            .IsRequired();

        builder.Property(v => v.HoleNumber)
            .IsRequired();

        builder.Property(v => v.Score)
            .IsRequired();
    }
}
