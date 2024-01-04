using System;
using System.Collections.Generic;
using Cf.Dotnet.EntityFramework.Parte4.Models;
using Microsoft.EntityFrameworkCore;

namespace Cf.Dotnet.EntityFramework.Parte4;

public partial class MyDatabaseNameContext : DbContext
{
    public MyDatabaseNameContext()
    {
    }

    public MyDatabaseNameContext(DbContextOptions<MyDatabaseNameContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CatalogItem> CatalogItems { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=MyDatabaseName");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasIndex(e => e.CatalogItemId, "IX_Orders_CatalogItemId");

            entity.HasIndex(e => e.CustomerId, "IX_Orders_CustomerId");

            entity.HasOne(d => d.CatalogItem).WithMany(p => p.Orders).HasForeignKey(d => d.CatalogItemId);

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders).HasForeignKey(d => d.CustomerId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
