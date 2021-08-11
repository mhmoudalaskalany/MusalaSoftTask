﻿using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BackendCore.Common.DTO.Login;
using BackendCore.Common.DTO.User;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BackendCore.Service.Services.Base
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;
        private readonly UserLoginReturn _userLoginReturn;
        public TokenService(IConfiguration config)
        {
            _config = config;
            _userLoginReturn = new UserLoginReturn();
        }

        public UserLoginReturn GenerateJsonWebToken(UserDto userInfo, string role)
        {
            var claims = new[] {
                new Claim( JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.UserName),
                new Claim("UserId", userInfo.Id.ToString()),
                new Claim("Role", role)
            };
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SecretKey"]));
            var expiryInHours = DateTime.Now.AddHours(Convert.ToDouble(_config["Jwt:ExpiryInHours"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                expires: expiryInHours,
                signingCredentials: credentials,
                claims: claims);

            _userLoginReturn.UserId = userInfo.Id ?? 1;
            _userLoginReturn.TokenValidTo = token.ValidTo;

            _userLoginReturn.Token = new JwtSecurityTokenHandler().WriteToken(token);
            return _userLoginReturn;
        }
    }
}