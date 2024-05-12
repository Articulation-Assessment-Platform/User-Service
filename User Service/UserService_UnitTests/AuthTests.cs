using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using User_Service.Models;
using User_Service.Service;
namespace UserService_UnitTests
{
    [TestClass]
    public class AuthTests
    {

        [TestMethod]
        public void GenerateToken_Returns_Valid_Token()
        {
            // Arrange
            var user = new User
            {
                Id = 1,
                Role = Role.Therapist 
            };

            var jwtSettings = new JwtSettings
            {
                Secret = "7VYrOlWeSgn9GqcN46gNEhEBY2P2lnTBo6DQyK/4Z5M=",
                ExpiryHours = 2
            };

            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    {"Jwt:Issuer", "test_issuer"},
                    {"Jwt:Audience", "test_audience"}
                })
                .Build();

            var jwtSettingsOptions = Options.Create(jwtSettings);

            var authService = new AuthService(jwtSettingsOptions, configuration);

            // Act
            var token = authService.GenerateToken(user);

            // Assert
            Assert.IsNotNull(token);
            Assert.IsFalse(string.IsNullOrEmpty(token));

            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(token);

            var claimsIdentity = jwtToken.Claims.FirstOrDefault(c => c.Type == "nameid");
            Assert.IsNotNull(claimsIdentity);
            Assert.AreEqual(user.Id.ToString(), claimsIdentity.Value);

            var roleClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "role");
            Assert.IsNotNull(roleClaim);
            Assert.AreEqual(user.Role.ToString(), roleClaim.Value);
        }
    }
}