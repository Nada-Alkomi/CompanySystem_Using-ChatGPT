using Compant_System.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Compant_System.DAL.ModelConfiguration;

public class DepartmentConfiguration
    : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.HasKey(d => d.DNumber);

        builder.Property(d => d.DName)
            .HasMaxLength(100)
            .IsRequired();

        builder.HasIndex(d => d.DName)
            .IsUnique();

        builder.HasOne(d => d.Manager)
            .WithMany()
            .HasForeignKey(d => d.MgrSSN)
            .OnDelete(DeleteBehavior.NoAction);
    }
}