using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace JWT_Core_Yemek_Tarif.DAL
{
    public class BuildToken
    {
        public string CreateToken()
        {
            //var bytes = Encoding.UTF8.GetBytes("yemektarifcore");
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("yemektarifcorejwt1"));
            SigningCredentials credentials = new(key, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken token = new(issuer: "http://localhost", audience: "http://localhost", notBefore: DateTime.Now, expires: DateTime.Now.AddMinutes(1), signingCredentials: credentials);
            JwtSecurityTokenHandler handler = new();
            return handler.WriteToken(token);
        }
    }
}
