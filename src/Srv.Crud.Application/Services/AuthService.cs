using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Srv.Crud.Domain.Commands;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Srv.Crud.Application.IServices;
using Srv.Crud.Repository.Models;
using Srv.Crud.Repository.IRepositories;

namespace Srv.Crud.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly IAuthRepository _authRepository;

        private string? _jwtKey = "";
        private string? _issuer = "";
        private string? _audience = "";
        private int _accessTokenExpirationInMinutes = 0;
        private int _refreshTokenExpirationInDays = 0;


        public AuthService(IConfiguration configuration, IAuthRepository authRepository)
        {
            _configuration = configuration;
            _authRepository = authRepository;
            CheckAppSettingsConfig();
        }

        public virtual async Task<string> GenerateJwtToken(Login login)
        {
            var validateLogin = await _authRepository.ValidateLogin(login);

            if (validateLogin)
            {
                List<Claim> claims = new List<Claim>
                {
                    new Claim("Type", "Token")
                };

                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtKey + ""));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
                var accessTokenDescriptor = new JwtSecurityToken(
                    issuer: _issuer,
                    audience: _audience,
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(_accessTokenExpirationInMinutes),
                    signingCredentials: credentials);

                string jwtAccessToken = new JwtSecurityTokenHandler().WriteToken(accessTokenDescriptor);

                return jwtAccessToken;
            }
            else
            {
                return "";
            }
        }

    
        #region Auxiliar methods
        private void CheckAppSettingsConfig()
        {
            _jwtKey = _configuration.GetSection("Jwt").GetChildren().SingleOrDefault(c => c.Key == "Key")?.Value;
            _issuer = _configuration.GetSection("Jwt").GetChildren().SingleOrDefault(c => c.Key == "Issuer")?.Value;
            _audience = _configuration.GetSection("Jwt").GetChildren().SingleOrDefault(c => c.Key == "Audience")?.Value;
            string? _config_accessTokenExpirationInMinutes = _configuration.GetSection("Jwt").GetChildren().SingleOrDefault(c => c.Key == "AccessTokenExpirationInMinutes")?.Value;
            string? _config_refreshTokenExpirationInDays = _configuration.GetSection("Jwt").GetChildren().SingleOrDefault(c => c.Key == "RefreshTokenExpirationInDays")?.Value;

            bool validExpirationAccessToken = Int32.TryParse(_config_accessTokenExpirationInMinutes, out _accessTokenExpirationInMinutes);
            bool validExpirationRefreshToken = Int32.TryParse(_config_refreshTokenExpirationInDays, out _refreshTokenExpirationInDays);

            if (String.IsNullOrWhiteSpace(_jwtKey) || String.IsNullOrWhiteSpace(_issuer) || String.IsNullOrWhiteSpace(_audience)
                || String.IsNullOrWhiteSpace(_config_accessTokenExpirationInMinutes)
                || String.IsNullOrWhiteSpace(_config_refreshTokenExpirationInDays)
                || (!validExpirationAccessToken) || (!validExpirationRefreshToken))
            {
                throw new Exception("Arquivo de configuração appsettings.json incompleto. Por favor, verifique os campos do objeto Jwt: 'Key', 'Issuer', 'Audience', 'AccessTokenExpirationInMinutes' e 'RefreshTokenExpirationInDays'.");
            }
        }

        private byte[] GetHash(string inputString)
        {
            using (HashAlgorithm algorithm = SHA256.Create())
            {
                return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
            }
        }

        private string GetHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
            {
                sb.Append(b.ToString("X2"));
            }
            return sb.ToString();
        }

        #endregion
    }
}
