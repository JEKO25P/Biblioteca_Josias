//using Microsoft.IdentityModel.Tokens;
//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Text;

//public class JwtService
//{
//    private readonly string _secretKey;
//    private readonly string _issuer;
//    private readonly string _audience;

//    public JwtService(IConfiguration configuration)
//    {
//        _secretKey = configuration["Jwt:Secret"];
//        _issuer = configuration["Jwt:Issuer"];
//        _audience = configuration["Jwt:Audience"];
//    }

//    public string GenerateToken(string username, string role)
//    {
//        var claims = new[]
//        {
//            new Claim(ClaimTypes.Name, username),
//            new Claim(ClaimTypes.Role, role)
//        };

//        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
//        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

//        var token = new JwtSecurityToken(
//            issuer: _issuer,
//            audience: _audience,
//            claims: claims,
//            expires: DateTime.Now.AddMinutes(30), // Tiempo de expiración
//            signingCredentials: credentials
//        );

//        return new JwtSecurityTokenHandler().WriteToken(token);
//    }
//}