using System;
using MediatorPattern.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MediatorPattern.DataAccess
{
    public partial class MediatorDBContext : DbContext
    {
        public MediatorDBContext()
        {
        }

        public MediatorDBContext(DbContextOptions<MediatorDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Products> Products { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Server=BUGRAK;Database=MediatorDB;Trusted_Connection=True;");
        //    }
        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Products>(entity =>
        //    {
        //        entity.Property(e => e.Name)
        //            .IsRequired()
        //            .HasMaxLength(50);
        //    });
        //}
    }
}
