using AutoMapper;
using eCommerce.Domain.DTOs;
using eCommerce.Domain.Models;
using eCommerce.Infrastructure.Interfaces;
using eCommerce.Services.Interfaces;
using System.Collections.Generic;
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

        public void AddAddress(AddressDTO addressDTO)
        {
            var address = _mapper.Map<Address>(addressDTO);
            _addressRepository.AddAddress(address);
        }

        public async Task<IEnumerable<AddressDTO>> GetAddresses()
        {
            var result = await _addressRepository.GetAddresses();
            return _mapper.Map<IEnumerable<AddressDTO>>(result);
        }

        public async Task<AddressDTO> GetAddressById(int? id)
        {
            var result = await _addressRepository.GetAddressById(id);
            return _mapper.Map<AddressDTO>(result);
        }

        public void UpdateAddress(AddressDTO addressDTO)
        {
            var address = _mapper.Map<Address>(addressDTO);
            _addressRepository.UpdateAddress(address);
        }

        public void RemoveAddress(int? id)
        {
            var address = _addressRepository.GetAddressById(id).Result;
            _addressRepository.RemoveAddress(address);
        }
    }
}
