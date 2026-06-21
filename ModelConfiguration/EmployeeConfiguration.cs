using Compant_System.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Compant_System.DAL.ModelConfiguration;

    public class EmployeeConfiguration
        : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.SSN);

            builder.Property(e => e.FName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(e => e.LName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(e => e.Address)
                .HasMaxLength(200);

            builder.Property(e => e.Gender)
                .HasMaxLength(10);

            builder.Property(e => e.Salary)
                .HasColumnType("decimal(18,2)");

            // Employee -> Department
            builder.HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.Dno)
                .OnDelete(DeleteBehavior.Restrict);

            // Self Relationship
            builder.HasOne(e => e.Supervisor)
                .WithMany(e => e.Subordinates)
                .HasForeignKey(e => e.SuperSSN)
                .OnDelete(DeleteBehavior.NoAction);
        }
}