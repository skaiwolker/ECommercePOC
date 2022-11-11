using AutoMapper;
using eCommerce.Domain.DTOs;
using eCommerce.Domain.Models;
using eCommerce.Infrastructure.Repository.Interfaces;
using eCommerce.Services.Exceptions;
using eCommerce.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eCommerce.Services.Services
{
    public class ClientService : IClientService
    {
        private IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public ClientService(IMapper mapper, IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public async Task AddClient(ClientDTO clientDTO)
        {
            var client = _mapper.Map<Client>(clientDTO);
            await _clientRepository.AddClient(client);
        }

        public async Task<IEnumerable<ClientDTO>> GetClients()
        {
            var result = await _clientRepository.GetClients();
            return _mapper.Map<IEnumerable<ClientDTO>>(result);
        }

        public async Task<ClientDTO> GetClientById(int id)
        {
            var result = await _clientRepository.GetClientById(id);
            return _mapper.Map<ClientDTO>(result);
        }

        public async Task UpdateClient(ClientDTO clientDTO)
        {
            var client = _mapper.Map<Client>(clientDTO);
            await _clientRepository.UpdateClient(client);
        }

        public async Task<bool> RemoveClient(int id)
        {
            var client = _clientRepository.GetClientById(id).Result;

            if (client != null) {
                await _clientRepository.RemoveClient(client);
                return true;
            }
            throw new IdNotFoundException("Client Id Not Found");
        }
    }
}
