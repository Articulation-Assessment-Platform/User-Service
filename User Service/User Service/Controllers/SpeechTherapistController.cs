using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using User_Service.DTO;
using User_Service.Messaging;
using User_Service.Models;
using User_Service.Service.Interfaces;

namespace User_Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "SpeechTherapist")]
    public class SpeechTherapistController : ControllerBase
    {
        private readonly ISpeechTherapistService _speechTherapistService;
        private readonly UserRegisterMessaging _userRegisterMessaging;

        public SpeechTherapistController(ISpeechTherapistService speechTherapistService, UserRegisterMessaging userRegisterMessaging)
        {
            _speechTherapistService = speechTherapistService;
            _userRegisterMessaging = userRegisterMessaging;
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
        public async Task<IActionResult> RemoveAccount()
        {
            // Get the user ID from the token's claims
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest("Account not found");
            }
            SpeechTherapist user = await _speechTherapistService.GetInformation(Convert.ToInt32(userId));

            if (user == null)
            {
                return NotFound("No user found to delete");
            }

            _speechTherapistService.RemoveAccount(user);

            return Ok("User deleted successfully.");
        }

        [HttpPost("add")]
        [AllowAnonymous]
        public async Task<IActionResult> AddSpeechTherapist([FromBody] RegisterDTO model)
        {
            var speechTherapist = new SpeechTherapist
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
            };
            try
            {
                var user = await _speechTherapistService.AddSpeechTherapist(speechTherapist);
                if (user == null)
                {
                    return NotFound("User not found");
                }
                _userRegisterMessaging.SendUserRegister(user.Id, model.Email, model.Password, "SpeechTherapist");

                return Ok(user);
            }
            catch(Exception ex)
            {
                return BadRequest("Already a user with this information.");
            }
        }
    }
}
