using eCommerce.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Infrastructure.Context
{
    public class eCommerceContext : DbContext
    {
        public eCommerceContext(DbContextOptions<eCommerceContext> options) : base (options)
        {
        }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<CreditCard> CreditCards { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<OrderProduct> OrderProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Address>().HasOne(address => address.Client)
                .WithMany(client => client.Addresses)
                .HasForeignKey(address => address.ClientId);

            builder.Entity<CreditCard>().HasOne(creditCard => creditCard.Client)
                .WithMany(client => client.CreditCards)
                .HasForeignKey(creditCard => creditCard.ClientId);

            builder.Entity<Order>().HasOne(order => order.Client)
                .WithMany(client => client.Orders)
                .HasForeignKey(order => order.ClientId);

            builder.Entity<OrderProduct>().HasOne(cart => cart.Order)
                .WithMany(order => order.OrderProducts)
                .HasForeignKey(cart => cart.OrderId);

            builder.Entity<OrderProduct>().HasOne(cart => cart.Product)
                .WithMany(product => product.OrderProducts)
                .HasForeignKey(cart => cart.ProductId);
        }
    }
}
