using KASHOP.DAL.Data.DTOs.Authentication.Requests;
using KASHOP.DAL.Data.DTOs.Authentication.Responses;
using KASHOP.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace KASHOP.BLL.Services.AuthenticationServices
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;

        public AuthenticationService(UserManager<ApplicationUser> userManager, IConfiguration configuration) 
        {
            _userManager = userManager;
            _configuration = configuration;
        }
        public async Task<UserResponseDTO> LoginAsync(LoginRequestDTO LoginRequest)
        {
            var user = await _userManager.FindByEmailAsync(LoginRequest.Email);
            if (user == null)
            {
                throw new Exception("Invalid email or password");
            }

            var isPassValid = await _userManager.CheckPasswordAsync(user, LoginRequest.Password);
            if (!isPassValid)
            {
                throw new Exception("Invalid email or password");
            }

            return new UserResponseDTO
            {
                Token = await CreateTokenAsync(user)

            };
            
        }

        public async Task<UserResponseDTO> RegisterAsync(RegisterRequestDTO RegisterRequest)
        {
            var user = new ApplicationUser()
            {
                FullName = RegisterRequest.FullName,
                Email = RegisterRequest.Email,
                PhoneNumber = RegisterRequest.PhoneNumber,
                UserName = RegisterRequest.UserName,
            };
            
            var result = await _userManager.CreateAsync(user, RegisterRequest.Password);

            if (result.Succeeded)
            {
                return new UserResponseDTO()
                {
                    Token = RegisterRequest.Email
                };
            }
            else
            {
                throw new Exception($"{string.Join("; ", result.Errors.Select(e => e.Description))}");
            }
        }

        private async Task<string> CreateTokenAsync(ApplicationUser user)
        {
            var Claims = new List<Claim>()
             {
        new Claim("Email", user.Email),
        new Claim("Name", user.UserName),
        new Claim("Id", user.Id.ToString())
             };

            var Roles = await _userManager.GetRolesAsync(user);
            foreach (var role in Roles)
            {
                Claims.Add(new Claim("role", role));
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("jwtOptions")["SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: Claims,
                expires: DateTime.Now.AddDays(15),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
