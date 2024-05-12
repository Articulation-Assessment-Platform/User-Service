using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using User_Service.DTO;
using User_Service.Models;
using User_Service.Service.Interfaces;

namespace User_Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Roles = "Therapist")]
    public class SpeechTherapistController : ControllerBase
    {
        private readonly ISpeechTherapistService _speechTherapistService;

        public SpeechTherapistController(ISpeechTherapistService speechTherapistService)
        {
            _speechTherapistService = speechTherapistService;
        }

        // Get your information
        [HttpGet("profile")]
        public async Task<IActionResult> GetInformation()
        {
            // Get the user ID from the token's claims
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest("User ID not found in token");
            }

            // Retrieve user information based on the user ID
            var user = await _speechTherapistService.GetInformation(Convert.ToInt32(userId));

            if (user == null)
            {
                return NotFound("User not found");
            }

            return Ok(user);
        }

        // Change data
        [HttpPut("changedata")]
        public IActionResult ChangeData([FromBody] SpeechTherapistDTO model)
        {
            var speechTherapist = new SpeechTherapist
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName
            };
            _speechTherapistService.ModifyInformation(speechTherapist);
            return Ok("Data changed successfully");

        }

        // Remove account
        [HttpDelete("remove")]
        public IActionResult RemoveAccount()
        {
            // Get the user ID from the token's claims
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest("Account not found");
            }

            _speechTherapistService.RemoveAccount(Convert.ToInt32(userId));

            return Ok("User deleted successfully.");
        }
    }
}
