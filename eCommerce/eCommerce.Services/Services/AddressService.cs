using AutoMapper;
using eCommerce.Domain.DTOs;
using eCommerce.Domain.Models;
using eCommerce.Domain.Models.Base;
using eCommerce.Repository.Interfaces;
using eCommerce.Services.Exceptions;
using eCommerce.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace eCommerce.Services.Services
{
    public class AddressService : IAddressService
    {
        private IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public AddressService(IMapper mapper, IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public async Task AddAddress(AddressDTO addressDTO)
        {
            if (string.IsNullOrEmpty(addressDTO.PublicPlace))
            {
                throw new eCommerceException("Public Place cannot be null or empty", HttpStatusCode.BadRequest);
            }
            else if (string.IsNullOrEmpty(addressDTO.District))
            {
                throw new eCommerceException("District cannot be null or empty", HttpStatusCode.BadRequest);
            }
            else if (string.IsNullOrEmpty(addressDTO.City))
            {
                throw new eCommerceException("City cannot be null or empty", HttpStatusCode.BadRequest);
            }
            else if (addressDTO.Number <= 0)
            {
                throw new eCommerceException("Number cannot be less or equal 0", HttpStatusCode.BadRequest);
            }

            var address = _mapper.Map<Address>(addressDTO);

            address.Delete = 0;

            await _addressRepository.AddAddress(address);
        }

        public async Task<IEnumerable<AddressDTO>> GetAddresses()
        {
            var result = await _addressRepository.GetAddresses();
            return _mapper.Map<IEnumerable<AddressDTO>>(result);
        }

        public async Task<AddressDTO> GetAddressById(int id)
        {
            var result = await _addressRepository.GetAddressById(id);

            if (result == null)
            {
                throw new eCommerceException("Address Not Found", HttpStatusCode.NotFound);
            }

            return _mapper.Map<AddressDTO>(result);
        }

        public async Task UpdateAddress(AddressDTO addressDTO)
        {
            if (string.IsNullOrEmpty(addressDTO.PublicPlace))
            {
                throw new eCommerceException("Public Place cannot be null or empty", HttpStatusCode.BadRequest);
            }
            else if (string.IsNullOrEmpty(addressDTO.District))
            {
                throw new eCommerceException("District cannot be null or empty", HttpStatusCode.BadRequest);
            }
            else if (string.IsNullOrEmpty(addressDTO.City))
            {
                throw new eCommerceException("City cannot be null or empty", HttpStatusCode.BadRequest);
            }
            else if (addressDTO.Number <= 0)
            {
                throw new eCommerceException("Number cannot be less or equal 0", HttpStatusCode.BadRequest);
            }

            var address = await _addressRepository.GetAddressById(addressDTO.Id);

            if (address == null)
            {
                throw new eCommerceException("Address Not Found", HttpStatusCode.NotFound);
            }

            //address = _mapper.Map<Address>(addressDTO);

            address.PublicPlace = addressDTO.PublicPlace;
            address.Number = addressDTO.Number;
            address.District = addressDTO.District;
            address.City = addressDTO.City;
            address.Delete = 0;

            await _addressRepository.UpdateAddress(address);
        }

        public async Task<bool> DeactivateAddress(int id)
        {
            var address = _addressRepository.GetAddressById(id).Result;

            if (address != null)
            {
                address.Delete = 1;
                await _addressRepository.DeactivateAddress(address);
                return true;
            }

            throw new eCommerceException("Address Not Found", HttpStatusCode.NotFound);
        }
    }
}
