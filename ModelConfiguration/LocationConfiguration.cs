using Compant_System.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Compant_System.DAL.ModelConfiguration;

public class LocationConfiguration
    : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.HasKey(l => l.Id);

        builder.Property(l => l.LocationName)
            .HasMaxLength(100)
            .IsRequired();

        builder.HasOne(l => l.Department)
            .WithMany(d => d.Locations)
            .HasForeignKey(l => l.DNumber);
    }
}