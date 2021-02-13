using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DotNetLab2021Feb.Api.Models;

#nullable disable

namespace DotNetLab2021Feb.Api.Context
{
    public partial class DotNetLab2021FebDatabaseContext : DbContext
    {
        public DotNetLab2021FebDatabaseContext()
        {
        }

        public DotNetLab2021FebDatabaseContext(DbContextOptions<DotNetLab2021FebDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<DepartmentMember> DepartmentMembers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderView> OrderViews { get; set; }
        public virtual DbSet<Sample> Samples { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\ProjectsV13;Initial Catalog=DotNetLab2021Feb.Database");
            }
            var fact = new EntityFrameworkLogger();
            optionsBuilder.UseLoggerFactory(fact.GetLoggerFactory());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Japanese_CI_AS");

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.DepartmentNo)
                    .HasName("PK__Departme__B207A396DF3E1D95");

                entity.ToTable("Department");

                entity.Property(e => e.DepartmentNo).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<DepartmentMember>(entity =>
            {
                entity.HasKey(e => new { e.DepartmentNo, e.UserId })
                    .HasName("PK__Departme__637F2F528090DE09");

                entity.ToTable("DepartmentMember");

                entity.Property(e => e.UserId)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.HasOne(d => d.DepartmentNoNavigation)
                    .WithMany(p => p.DepartmentMembers)
                    .HasForeignKey(d => d.DepartmentNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DepartmentMember_ToDepartment");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.OrderNo)
                    .HasName("PK__Order__C3907C74E892A467");

                entity.ToTable("Order");

                entity.Property(e => e.OrderNo).ValueGeneratedNever();

                entity.Property(e => e.OrderName)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<OrderView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("OrderView");

                entity.Property(e => e.OrderName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.SalesUserName).HasMaxLength(50);
            });

            modelBuilder.Entity<Sample>(entity =>
            {
                entity.ToTable("Sample");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
