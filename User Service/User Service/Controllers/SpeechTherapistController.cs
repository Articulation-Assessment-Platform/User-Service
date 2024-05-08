using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using User_Service.DTO;

namespace User_Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpeechTherapistController : ControllerBase
    {
        // Get your information
        [HttpGet("profile")]
        public IActionResult GetInformation()
        {
            // Implementation for getting information
            return Ok("Your information");
        }

        // Change data
        [HttpPut("changedata")]
        public IActionResult ChangeData([FromBody] SpeechTherapistDTO model)
        {
            // Implementation for changing data
            return Ok("Data changed successfully");
        }

        // Remove account
        [HttpDelete("remove")]
        public IActionResult RemoveAccount()
        {
            // Implementation for removing account
            return Ok("Account removed successfully");
        }
    }
}
