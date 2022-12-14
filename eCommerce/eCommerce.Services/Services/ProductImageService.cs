using AutoMapper;
using eCommerce.Domain.DTOs;
using eCommerce.Domain.Models;
using eCommerce.Repository;
using eCommerce.Repository.Interfaces;
using eCommerce.Services.Services.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Services.Services
{
    public class ProductImageService : IProductImageService
    {
        private IProductImageRepository _productImageRepository;
        private readonly IMapper _mapper;

        public ProductImageService(IMapper mapper, IProductImageRepository productImageRepository)
        {
            _productImageRepository = productImageRepository;
            _mapper = mapper;
        }


        public async Task AddProductImage(ProductImageDTO productImageDTO)
        {
            byte[] image = ConvertToByte(productImageDTO.Image);

            var productImage = _mapper.Map<ProductImage>(productImageDTO);

            productImage.Image = image;

            await _productImageRepository.AddProductImage(productImage);
        }

        public async Task<IEnumerable<ProductImageDTO>> GetProductImages()
        {
            var result = await _productImageRepository.GetProductImages();

            //List<ProductImageDTO> mapped = new List<ProductImageDTO>();

            //for (int i = 0; i < result.Count(); i++)
            //{
            //    var productImageDTO = _mapper.Map<ProductImage, ProductImageDTO>(result.Cast<ProductImage>().ElementAt(i), opt =>
            //    {
            //        opt.AfterMap((image, dto) => dto.Image = ConvertToString(image.Image));
            //    });

            //    mapped.Add(productImageDTO);
            //}

            //return mapped.AsEnumerable();
            var map = _mapper.Map<IEnumerable<ProductImageDTO>>(result);
            return map;

        }

        public Task RemoveProductImage(int id)
        {
            throw new NotImplementedException();
        }

        public byte[] ConvertToByte(string path)
        {
            byte[] image;

            //var stream = new FileStream(path, FileMode.Open, FileAccess.Read);

            //var reader = new BinaryReader(stream);

            //image = reader.ReadBytes((int)stream.Length);

            image = Encoding.Default.GetBytes(path);

            return image;
        }

        //public string ConvertToString(byte[] image)
        //{
        //    var path = Encoding.Default.GetString(image);
        //    return path;
        //}
    }
}
