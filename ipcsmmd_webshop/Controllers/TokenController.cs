using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using ipcsmmd_webshop.Core.DomainService;
using ipcsmmd_webshop.Core.Entity;
using ipcsmmd_webshop.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ipcsmmd_webshop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IAdminRepository adminRepository;

        public TokenController(IAdminRepository repo)
        {
            adminRepository = repo;
        }



        // POST: api/Token
        [HttpPost]
        public IActionResult Post([FromBody]LoginInputModel model)
        {
            Admin admin = adminRepository.GetAll().FirstOrDefault(a => a.Username == model.Username);

            // Check for username
            if (admin == null) { return Unauthorized(); }

            // Check if password is correct
            if (!VerifyPassword(model.Password, admin.PasswordHash, admin.PasswordSalt)) { return Unauthorized(); }

            // Successfull authentication
            return Ok(new
            {
                username = admin.Username,
                token = GenerateToken(admin)
            });
        }

        // This method verifies that the password entered by a user corresponds to the stored
        // password hash for this user. The method computes a Hash-based Message Authentication
        // Code (HMAC) using the SHA512 hash function. The inputs to the computation is the
        // password entered by the user and the stored password salt for this user. If the
        // computed hash value is identical to the stored password hash, the password entered
        // by the user is correct, and the method returns true.
        private bool VerifyPassword(string password, byte[] storedHash, byte[] storedSalt)
        {
            using (var hmac = new HMACSHA512(storedSalt))
            {
                byte[] computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i] ) { return false;  }
                }
            }
            return true;
        }

        // This method generates and returns a JWT token for a user.
        private string GenerateToken(Admin admin)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, admin.Username),
                new Claim(ClaimTypes.Role, "Administrator")
            };

            var token = new JwtSecurityToken(
                new JwtHeader(new SigningCredentials(
                    JwtSecurityKey.Key,
                    SecurityAlgorithms.HmacSha256)),
                new JwtPayload(null,
                               null,
                               claims.ToArray(),
                               DateTime.Now,
                               DateTime.Now.AddMinutes(10)));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
}
}
