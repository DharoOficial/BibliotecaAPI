using Microsoft.IdentityModel.Tokens;
using MVCAPIBiblioteca.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MVCAPIBiblioteca.Utils
{
    public class TokenJwt<T> where T : Usuarios
    {
        public static string GerarToken(T user)
        {
            Claim[] claim =
            {
            new Claim("Id",user.Id.ToString()),
            new Claim("UserName",user.NomeUsuario),
            new Claim("Email",user.Email),
            new Claim("Role",user.Role.ToString())
            };
            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("imtringbutitshardjustalittlemrrigthnowiguess"));
            var signingCredentials = new SigningCredentials(chave,SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
                (
                expires: DateTime.Now.AddHours(1),
                claims: claim,
                signingCredentials: signingCredentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
