using AutoMapper;
using eCommerce.Domain.DTOs;
using eCommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Repository.Profiles
{
    public class ProductImageProfile : Profile
    {
        public ProductImageProfile()
        {
            CreateMap<ProductImage, ProductImageDTO>().ForMember(dto => dto.Image,
                                                        e => e.MapFrom(o => ConvertToString(o.Image))).ReverseMap().ForMember(o => o.Image,
                                                        e => e.MapFrom(dto => ConvertToByte(dto.Image)));
        }

        public string ConvertToString(byte[] image)
        {
            var path = Encoding.Default.GetString(image);
            return path;
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
    }
}
