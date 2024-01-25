using System.Text;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace BearerJWT;

public class JwtTokenFactory
{
    private const string TokenSecret = "SuperSaveStorageKey_xjhjijlkjjlkjlkjljlk";

    public string CreateToken(UserLoginDto user)
    {
        var key = Encoding.UTF8.GetBytes(TokenSecret);
        SymmetricSecurityKey securityKey = new SymmetricSecurityKey(key);

        SecurityTokenDescriptor descriptor = new()
        {
            Issuer = "https://nonexistingwebsiteforsure.com",
            Audience = "https://nonexistingwebsiteforsure.com",
            Expires = DateTime.UtcNow.AddMinutes(20),
            SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256),
            Claims = new Dictionary<string, object>
            {
                { "username", user.Username },
                { JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString() }
            }
        };

        string token = new JsonWebTokenHandler().CreateToken(descriptor);
        return token;
    }
}