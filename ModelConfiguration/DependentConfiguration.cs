using Compant_System.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Compant_System.DAL.ModelConfiguration;


public class DependentConfiguration
    : IEntityTypeConfiguration<Dependent>
{
    public void Configure(EntityTypeBuilder<Dependent> builder)
    {
        builder.HasKey(d => d.Id);

        builder.Property(d => d.DependentName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(d => d.Relationship)
            .HasMaxLength(50);

        builder.HasOne(d => d.Employee)
            .WithMany(e => e.Dependents)
            .HasForeignKey(d => d.SSN);
    }
}