using GolfCaddie.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GolfCaddie.Infrastructure.Data.Configurations;

public class HoleConfiguration : IEntityTypeConfiguration<Hole>
{
    public void Configure(EntityTypeBuilder<Hole> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.ScoreCard)
            .WithMany(x => x.Holes)
            .HasForeignKey(x => x.ScoreCardId);

        builder.Property(v => v.HoleNumber)
            .IsRequired();

        builder.Property(v => v.Par)
            .IsRequired();

        builder.Property(v => v.Score)
            .IsRequired();

        builder.Property(v => v.Putts)
            .IsRequired(false);

        builder.Property(v => v.Penalties)
            .IsRequired(false);

        builder.Property(v => v.ConcurrencyToken)
            .IsConcurrencyToken()
            .IsRowVersion()
            .HasColumnType("timestamp");
    }
}