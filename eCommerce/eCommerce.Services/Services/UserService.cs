using AutoMapper;
using eCommerce.Domain.DTOs;
using eCommerce.Domain.Enums;
using eCommerce.Domain.Models;
using eCommerce.Repository.Interfaces;
using eCommerce.Services.Exceptions;
using eCommerce.Services.Extensions;
using eCommerce.Services.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Services.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private IConfiguration _configuration;
        private IDistributedCache _cache;

        public UserService(IMapper mapper, IUserRepository userRepository, IConfiguration configuration, IDistributedCache cache)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _configuration = configuration;
            _cache = cache;
        }

        public async Task AddUser(UserDTO userDTO)
        {
            if (string.IsNullOrEmpty(userDTO.Username))
                throw new eCommerceException("Username cannot be null or empty", HttpStatusCode.BadRequest);

            else if (string.IsNullOrEmpty(userDTO.Password))
                throw new eCommerceException("Password cannot be null or empty", HttpStatusCode.BadRequest);

            else if (string.IsNullOrEmpty(userDTO.Email))
                throw new eCommerceException("Email cannot be null or empty", HttpStatusCode.BadRequest);

            else if (string.IsNullOrEmpty(userDTO.FirstName))
                throw new eCommerceException("First Name cannot be null or empty", HttpStatusCode.BadRequest);

            else if (string.IsNullOrEmpty(userDTO.LastName))
                throw new eCommerceException("Last Name cannot be null or empty", HttpStatusCode.BadRequest);
            
            else if (!DateTime.TryParse(userDTO.DateOfBirth.ToString(), out DateTime dateTime))
                throw new eCommerceException("Date of Birth is not in an accepted format", HttpStatusCode.BadRequest);

            var user = _mapper.Map<User>(userDTO);

            user.Password = PasswordCryptography(user.Password);

            user.Delete = 0;

            var exists = await _userRepository.ValidateIfExists(user.Email, user.Username);

            if (exists is not null) throw new eCommerceException("User already exists", HttpStatusCode.Conflict);

            await _userRepository.AddUser(user);
        }

        public async Task<IEnumerable<UserDTO>> GetUsers()
        {
            var users = await _cache.GetRecordAsync<IEnumerable<UserDTO>>("GetUsers");

            if (users is not null)
            {
                return users;
            }

            var result = await _userRepository.GetUsers();

            var map = _mapper.Map<IEnumerable<UserDTO>>(result);

            await _cache.SetRecordAsync<IEnumerable<UserDTO>>("GetUsers", map, TimeSpan.FromMinutes(5));
            return map;
        }

        public async Task<UserDTO> GetUserById(int id)
        {
            var result = await _userRepository.GetUserById(id);

            if (result == null)
            {
                throw new eCommerceException("User Not Found", HttpStatusCode.NotFound);
            }

            return _mapper.Map<UserDTO>(result);
        }

        public async Task UpdateUser(UserDTO userDTO)
        {
            if (string.IsNullOrEmpty(userDTO.Username))
                throw new eCommerceException("Username cannot be null or empty", HttpStatusCode.BadRequest);

            else if (string.IsNullOrEmpty(userDTO.Password))
                throw new eCommerceException("Password cannot be null or empty", HttpStatusCode.BadRequest);

            else if (string.IsNullOrEmpty(userDTO.Email))
                throw new eCommerceException("Email cannot be null or empty", HttpStatusCode.BadRequest);

            else if (string.IsNullOrEmpty(userDTO.FirstName))
                throw new eCommerceException("First Name cannot be null or empty", HttpStatusCode.BadRequest);

            else if (string.IsNullOrEmpty(userDTO.LastName))
                throw new eCommerceException("Last Name cannot be null or empty", HttpStatusCode.BadRequest);


            var user = await _userRepository.GetUserById(userDTO.Id);

            if (user == null)
            {
                throw new eCommerceException("User Not Found", HttpStatusCode.NotFound);
            }

            user.Username = userDTO.Username;
            user.Password = PasswordCryptography(userDTO.Password);
            user.Email = userDTO.Email;
            user.FirstName = userDTO.FirstName;
            user.LastName = userDTO.LastName;
            user.RoleId = userDTO.RoleId; 
            user.Delete = 0;

            await _userRepository.UpdateUser(user);
        }

        public async Task<bool> DeactivateUser(int id)
        {
            var user = _userRepository.GetUserById(id).Result;

            if (user != null)
            {
                user.Delete = 1;
                await _userRepository.DeactivateUser(user);
                return true;
            }
            throw new eCommerceException("User Not Found", HttpStatusCode.NotFound);
        }

        public async Task<UserDTO> Login(LoginDTO loginDTO)
        {
            var passwordLogin = PasswordCryptography(loginDTO.Password);

            var user = await _userRepository.AuthenticateUser(loginDTO.Username, passwordLogin);

            if (user != null)
            {
                if (user.Delete == 1) throw new eCommerceException("User deactivated", HttpStatusCode.BadRequest);

                return _mapper.Map<UserDTO>(user);
            }

            throw new eCommerceException("Not valid information");
        }

        public string GenerateToken(ClaimsIdentity claimsIdentity)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claimsIdentity),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }

        public string PasswordCryptography(string password)
        {
            var encodedValue = Encoding.UTF8.GetBytes(password);
            var encryptedPassword = SHA512.Create().ComputeHash(encodedValue);

            var sb = new StringBuilder();

            foreach(var caracter in encryptedPassword)
            {
                sb.Append(caracter.ToString("X2"));
            }

            return sb.ToString();
        }

    }
}
