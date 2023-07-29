using eCommerce.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Repository.Context
{
    public class eCommerceContext : DbContext
    {
        public eCommerceContext(DbContextOptions<eCommerceContext> options) : base(options)
        {
        }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<CreditCard> CreditCards { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<OrderProduct> OrderProducts { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<ProductImage> ProductImages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Address>().HasOne(address => address.User)
                .WithMany(user => user.Addresses)
                .HasForeignKey(address => address.UserId);

            builder.Entity<CreditCard>().HasOne(creditCard => creditCard.User)
                .WithMany(user => user.CreditCards)
                .HasForeignKey(creditCard => creditCard.UserId);

            builder.Entity<Order>().HasOne(order => order.User)
                .WithMany(user => user.Orders)
                .HasForeignKey(order => order.UserId);

            builder.Entity<OrderProduct>().HasOne(orderProduct => orderProduct.Order)
                .WithMany(order => order.OrderProducts)
                .HasForeignKey(orderProduct => orderProduct.OrderId);

            builder.Entity<OrderProduct>().HasOne(orderProduct => orderProduct.Product)
                .WithMany(product => product.OrderProducts)
                .HasForeignKey(orderProduct => orderProduct.ProductId);

            builder.Entity<User>().HasOne(user => user.Role)
                .WithMany(role => role.Users).HasForeignKey(user => user.RoleId);

            builder.Entity<ProductImage>().HasOne(productImage => productImage.Product)
                .WithMany(product => product.ProductImages)
                .HasForeignKey(productImage => productImage.ProductId);
        }
    }
}
