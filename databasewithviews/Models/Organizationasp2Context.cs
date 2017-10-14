using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace databasewithviews.Models
{
    public partial class Organizationasp2Context : DbContext
    {
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Organizatiion> Organizatiion { get; set; }



        public Organizationasp2Context(DbContextOptions<Organizationasp2Context> abc): base(abc)

        { }            
            
            
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-B3IASG2;Database=Organizationasp2;Trusted_Connection=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.CustomerCity)
                    .HasColumnName("customer_city")
                    .HasColumnType("nchar(10)");

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasColumnName("customer_name")
                    .HasColumnType("nchar(10)");

                entity.Property(e => e.CustomerProjname)
                    .IsRequired()
                    .HasColumnName("customer_projname")
                    .HasColumnType("nchar(10)");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("PK_Employee");

                entity.Property(e => e.EmpId).HasColumnName("emp_id");

                entity.Property(e => e.EmpAge).HasColumnName("emp_age");

                entity.Property(e => e.EmpName)
                    .IsRequired()
                    .HasColumnName("emp_name")
                    .HasColumnType("nchar(10)");

                entity.Property(e => e.EmpSalary)
                    .HasColumnName("emp_salary")
                    .HasColumnType("money");

                entity.Property(e => e.EmpScale)
                    .IsRequired()
                    .HasColumnName("emp_scale")
                    .HasColumnType("nchar(10)");
            });

            modelBuilder.Entity<Organizatiion>(entity =>
            {
                entity.HasKey(e => e.OrgId)
                    .HasName("PK_Organizatiion");

                entity.Property(e => e.OrgId).HasColumnName("org_id");

                entity.Property(e => e.OrgBudget)
                    .HasColumnName("org_budget")
                    .HasColumnType("money");

                entity.Property(e => e.OrgLoc)
                    .IsRequired()
                    .HasColumnName("org_loc")
                    .HasColumnType("nchar(10)");

                entity.Property(e => e.OrgName)
                    .IsRequired()
                    .HasColumnName("org_name")
                    .HasColumnType("nchar(10)");
            });
        }
    }
}