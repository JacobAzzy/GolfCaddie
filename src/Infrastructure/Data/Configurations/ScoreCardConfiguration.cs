using GolfCaddie.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GolfCaddie.Infrastructure.Data.Configurations;

public class ScoreCardConfiguration : IEntityTypeConfiguration<ScoreCard>
{
    public void Configure(EntityTypeBuilder<ScoreCard> builder)
    {
        builder.Property(v => v.CourseName)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(v => v.Holes)
            .IsRequired();

        builder.Property(v => v.Date)
            .IsRequired();
    }
}
