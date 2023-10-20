using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using WeatherApi.Entities;

namespace WeatherApi.Helpers
{
    public class AuthHelper
    {
        private static string TokenKey = "1kn+dtFAZppYIUXS3DYi5s1hGTFJMkDV2tumZWEsQlo=";
        public static string GenerateToken(User user)
        {
            string token = string.Empty;

            if(user == null)
            {
                return token;
            }

            try
            {
                string userId = user.Id;
                string userName = user.UserName;

                Claim[] claims = new Claim[]
                {
                   new Claim("UserId", userId),
                   new Claim("UserName", userName)
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TokenKey));
               
                var signInCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var tokenCreation = new JwtSecurityToken(
                        issuer: "www.test.com",
                        audience: "www.test.com",
                        expires: DateTime.UtcNow.AddMinutes(5000),
                        claims: claims,
                        signingCredentials: signInCredentials
                    );

                token = new JwtSecurityTokenHandler().WriteToken(tokenCreation);

                return token;
            }
            catch (Exception ex)
            {
                return token;
            }
        }
    }
}
