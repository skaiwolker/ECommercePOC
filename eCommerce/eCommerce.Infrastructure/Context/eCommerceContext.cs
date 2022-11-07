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

            builder.Entity<Stock>().HasOne(stock => stock.Order)
                .WithMany(order => order.Stocks)
                .HasForeignKey(stock => stock.OrderId);

            builder.Entity<Stock>().HasOne(stock => stock.Product)
                .WithMany(product => product.Stocks)
                .HasForeignKey(stock => stock.ProductId);
        }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<CreditCard> CreditCards { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Stock> Stocks { get; set; }

    }
}
