using Compant_System.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Compant_System.DAL.ModelConfiguration;

public class ProjectConfiguration
    : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.HasKey(p => p.PNumber);

        builder.Property(p => p.PName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(p => p.PLocation)
            .HasMaxLength(100);

        builder.HasOne(p => p.Department)
            .WithMany(d => d.Projects)
            .HasForeignKey(p => p.DNumber)
            .OnDelete(DeleteBehavior.Restrict);
    }
}