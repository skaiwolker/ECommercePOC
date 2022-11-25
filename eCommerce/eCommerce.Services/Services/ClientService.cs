using AutoMapper;
using eCommerce.Domain.DTOs;
using eCommerce.Domain.Models;
using eCommerce.Repository.Interfaces;
using eCommerce.Services.Exceptions;
using eCommerce.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
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
            if (string.IsNullOrEmpty(clientDTO.FirstName))
                throw new eCommerceException("First Name cannot be null or empty", HttpStatusCode.BadRequest);

            else if (string.IsNullOrEmpty(clientDTO.LastName))         
                throw new eCommerceException("Last Name cannot be null or empty", HttpStatusCode.BadRequest);

            else if (!DateTime.TryParse(clientDTO.DateOfBirth.ToString(), out DateTime dateTime))
                throw new eCommerceException("Date of Birth is not an Date value", HttpStatusCode.BadRequest);


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

            if (result == null)
            {
                throw new eCommerceException("Client Not Found", HttpStatusCode.NotFound);
            }

            return _mapper.Map<ClientDTO>(result);
        }

        public async Task UpdateClient(ClientDTO clientDTO)
        {
            if (string.IsNullOrEmpty(clientDTO.FirstName))
            {
                throw new eCommerceException("First Name cannot be null or empty", HttpStatusCode.BadRequest);
            }
            else if (string.IsNullOrEmpty(clientDTO.LastName))
            {
                throw new eCommerceException("Last Name cannot be null or empty", HttpStatusCode.BadRequest);
            }
            else if (!DateTime.TryParse(clientDTO.DateOfBirth.ToString(), out DateTime dateTime))
            {
                throw new eCommerceException("Date of Birth is not an Date value", HttpStatusCode.BadRequest);
            }

            var client = await _clientRepository.GetClientById(clientDTO.Id);

            if (client == null)
            {
                throw new eCommerceException("Client Not Found", HttpStatusCode.NotFound);
            }

            //client = _mapper.Map<Client>(clientDTO);

            client.FirstName = clientDTO.FirstName;
            client.LastName = clientDTO.LastName;
            client.DateOfBirth = clientDTO.DateOfBirth;

            await _clientRepository.UpdateClient(client);
        }

        public async Task<bool> RemoveClient(int id)
        {
            var client = _clientRepository.GetClientById(id).Result;

            if (client != null)
            {
                await _clientRepository.RemoveClient(client);
                return true;
            }
            throw new eCommerceException("Client Not Found", HttpStatusCode.NotFound);
        }
    }
}
