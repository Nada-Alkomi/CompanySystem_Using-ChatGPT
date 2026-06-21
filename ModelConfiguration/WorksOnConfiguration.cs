using Compant_System.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Compant_System.DAL.ModelConfiguration;

public class WorksOnConfiguration
    : IEntityTypeConfiguration<Works_On>
{
    public void Configure(EntityTypeBuilder<Works_On> builder)
    {
        builder.HasKey(w => new
        {
            w.SSN,
            w.PNumber
        });

        builder.Property(w => w.Hours)
            .IsRequired();

        builder.HasOne(w => w.Employee)
            .WithMany(e => e.WorksOns)
            .HasForeignKey(w => w.SSN);

        builder.HasOne(w => w.Project)
            .WithMany(p => p.WorksOns)
            .HasForeignKey(w => w.PNumber);
    }
}