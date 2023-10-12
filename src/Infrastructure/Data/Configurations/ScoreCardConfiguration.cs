using GolfCaddie.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GolfCaddie.Infrastructure.Data.Configurations;

public class ScoreCardConfiguration : IEntityTypeConfiguration<ScoreCard>
{
    public void Configure(EntityTypeBuilder<ScoreCard> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasMany(x => x.Holes)
            .WithOne(x => x.ScoreCard);

        builder.Property(v => v.UserId)
            .IsRequired();

        builder.Property(v => v.CourseName)
            .IsRequired();

        builder.Property(v => v.Date)
            .IsRequired();

        builder.Property(v => v.ConcurrencyToken)
            .IsConcurrencyToken()
            .IsRowVersion()
            .HasColumnType("timestamp");
    }
}