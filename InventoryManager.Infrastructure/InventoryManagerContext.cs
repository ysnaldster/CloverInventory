using InventoryManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Infrastructure
{
    public class InventoryManagerContext : DbContext
    {

        public InventoryManagerContext(DbContextOptions<InventoryManagerContext> options) : base(options) { }

        //Config Fluent API

        public DbSet<Category>? Categories { get; set; }
        public DbSet<Product>? Products { get; set; }
        public DbSet<Storage>? Storages { get; set; }
        public DbSet<TransactionLog>? TransactionLogs { get; set; }
        public DbSet<Warehouse>? Warehouses { get; set; }

        public DbSet<User>? Users { get; set; }
        public DbSet<ProductUserPivot>? ProductUserPivots { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Create CategorySchema
            modelBuilder.Entity<Category>(category =>
            {
                category.ToTable("category");
                category.HasKey(c => c.Id);
                category.Property(c => c.Name).IsRequired().HasMaxLength(20).HasColumnName("Name");
                category.HasData(InitData.LoadCategories());
            });


            // Create WinerySchema
            modelBuilder.Entity<Warehouse>(winery =>
            {
                winery.ToTable("warehouse");
                winery.HasKey(w => w.Id);
                winery.Property(w => w.Name).IsRequired().HasMaxLength(50).HasColumnName("Name");
                winery.Property(w => w.Address).IsRequired().HasMaxLength(200).HasColumnName("Address");
                winery.HasData(InitData.LoadWineries());
            });

            // Create ProductSchema
            modelBuilder.Entity<Product>(product =>
            {
                product.ToTable("product");
                product.HasKey(p => p.Id);
                product.HasOne(p => p.Category).WithMany(p => p.Products);
                product.Property(p => p.Name).IsRequired().HasMaxLength(50).HasColumnName("Name");
                product.Property(p => p.Description).IsRequired().HasMaxLength(200).HasColumnName("Description");
                product.Property(p => p.TotalQuantity).IsRequired().HasColumnName("TotalQuantity");
                product.Property(p => p.CreationDate).HasDefaultValue(DateTime.Now).HasColumnName("CreationDate");
                product.HasData(InitData.LoadProducts());
            });

            // Create StoreSchema
            modelBuilder.Entity<Storage>(storage =>
            {
                storage.ToTable("storage");
                storage.HasKey(s => s.Id);
                storage.HasOne(s => s.Product).WithMany(s => s.Storages);
                storage.HasOne(s => s.Warehouse).WithMany(s => s.Storages);
                storage.Property(s => s.PartialQuantity).HasColumnName("PartialQuantity");
                storage.Property(s => s.CreationDate).HasDefaultValue(DateTime.Now).HasColumnName("CreationDate");
                storage.Property(s => s.UpdateDate).HasDefaultValue(DateTime.Now).HasColumnName("UpdateDate");
                storage.HasData(InitData.LoadStores());
            });

            // Create TransactionLogSchema
            modelBuilder.Entity<TransactionLog>(transactionLog =>
            {
                transactionLog.ToTable("transaction_log");
                transactionLog.HasKey(t => t.Id);
                transactionLog.HasOne(t => t.Storage).WithMany(s => s.TransactionLogs);
                transactionLog.Property(s => s.Quantity).HasColumnName("Quantity");
                transactionLog.Property(s => s.CreationDate).HasDefaultValue(DateTime.Now).HasColumnName("CreationDate");
                transactionLog.Property(s => s.IsInput).HasColumnName("IsInput");
                transactionLog.HasData(InitData.LoadLabelsTransactionLogs());
            });

            //Create UserSchema
            modelBuilder.Entity<User>(user =>
            {
                user.ToTable("user");
                user.HasKey(p => p.Id);
                user.Property(p => p.UserName).IsRequired().HasMaxLength(50).HasColumnName("Username");
                user.HasIndex(p => p.UserName).IsUnique();
                user.Property(p => p.Password).IsRequired().HasColumnName("Password");
                user.Property(p => p.Email).IsRequired().HasColumnName("Email");
                user.Property(p => p.Role).IsRequired().HasColumnName("Role").HasDefaultValue("User");
                user.Property(p => p.CreationDate).HasColumnName("CreationDate").HasDefaultValue(DateTime.Now);
                user.Property(p => p.UpdateDate).HasColumnName("UpdateDate").HasDefaultValue(DateTime.Now);

                user.HasData(InitData.LoadUsers());
            });

             //Create ProductUserPivotSchema
            modelBuilder.Entity<ProductUserPivot>(pivot =>
            {
                pivot.ToTable("product_user");
                pivot.HasKey(p => p.Id);
                pivot.HasOne(p => p.Product).WithMany(p => p.ProductPivots);
                pivot.HasOne(p => p.User).WithMany(p => p.UserPivots);

                pivot.HasData(InitData.LoadProductUserPivot());
            });

        }
    }
}
