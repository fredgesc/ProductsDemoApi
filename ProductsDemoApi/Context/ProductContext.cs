
using ProductsDemoApi.Models;
using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore.Extensions;

namespace ProductsDemoApi.Context
{
    public class ProductContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductReview> ProductReviews { get;}


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("AppDb");
            optionsBuilder.UseMySQL(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProductReview>()
                .Property(b => b.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<ProductReview>()
                .HasKey(b => b.Id);
            modelBuilder.Entity<ProductReview>()
                .Property(b => b.ProductId).IsRequired();
            modelBuilder.Entity<ProductReview>()
                .Property(b => b.Score).IsRequired();
            modelBuilder.Entity<ProductReview>()
                .Property(b => b.ReviewerName).HasColumnType("VARCHAR(200)").HasDefaultValue("(Anonymous)");
            modelBuilder.Entity<ProductReview>()
                .Property(b => b.Comment).HasColumnType("VARCHAR(1000)");

            modelBuilder.Entity<Product>()
                .Property(b => b.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Product>()
                .HasKey(b => b.Id);
            modelBuilder.Entity<Product>()
                .HasMany(b => b.Reviews)
                .WithOne(b => b.Product)
                .HasForeignKey(b => b.ProductId);
            modelBuilder.Entity<Product>()
                .Property(b => b.Name).IsRequired();
            modelBuilder.Entity<Product>()
                .Property(b => b.Name).HasColumnType("VARCHAR(1000)");
            modelBuilder.Entity<Product>()
                .Property(b => b.Price).IsRequired();
            modelBuilder.Entity<Product>()
                .Property(b => b.Stock).HasDefaultValue(0);


        }
    }
}
