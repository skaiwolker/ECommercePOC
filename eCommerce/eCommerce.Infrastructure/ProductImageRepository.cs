using Dapper;
using eCommerce.Domain.Models;
using eCommerce.Repository.Context;
using eCommerce.Repository.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Repository
{
    public class ProductImageRepository : IProductImageRepository
    {
        private eCommerceContext _context;
        private readonly IDbConnection _connection;

        public ProductImageRepository(eCommerceContext context, IConfiguration configuration)
        {
            _context = context;
            _connection = _connection.AddConnection(configuration);
        }

        public async Task AddProductImage(ProductImage productImage)
        {
            //await _context.AddAsync(productImage);

            var query = @"INSERT INTO ProductImages
                        SELECT @Image, @ProductId";

            var con = new SqlConnection(_connection.ConnectionString);

            con.Open();
            var cmd = new SqlCommand(query, con);
            cmd.Parameters.Add("@Image", System.Data.SqlDbType.Image, productImage.Image.Length).Value = productImage.Image;
            cmd.Parameters.AddWithValue("@ProductId", productImage.ProductId);

            await cmd.ExecuteNonQueryAsync();

            // await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductImage>> GetProductImages()
        {
            List<ProductImage> images = new List<ProductImage>();

            ProductImage image = new ProductImage();

            var query = @"SELECT * FROM ProductImages";

            var con = new SqlConnection(_connection.ConnectionString);

            con.Open();
            var cmd = new SqlCommand(query, con);

            var dr = cmd.ExecuteReader();


            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    image.Id = (int)dr["id"];
                    image.Image = dr["image"] != null ? (byte[])dr["image"] : null;
                    image.ProductId = (int)dr["productId"];

                    images.Add(image);
                }
            }

            return images.AsEnumerable();
        }

        public async Task RemoveProductImage(ProductImage productImage)
        {
            _context.Remove(productImage);
            await _context.SaveChangesAsync();
        }
    }
}
