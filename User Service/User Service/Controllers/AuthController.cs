using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using User_Service.DTO;
using User_Service.Models;
using User_Service.Service;
using User_Service.Service.Interfaces;

namespace User_Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ISpeechTherapistService _speechTherapistService;
        private readonly IParentService _parentService;
        private readonly IAuthService _authenticationService;
        private readonly PasswordHasherService _passwordHasherService;

        public AuthController(ISpeechTherapistService speechService, IParentService parentService, IAuthService authenticationService, PasswordHasherService passwordHasherService)
        {
            _speechTherapistService = speechService;
            _parentService = parentService;
            _authenticationService = authenticationService;
            _passwordHasherService = passwordHasherService;
        }

        [HttpPost("login")]
        public IActionResult LoginSpeech([FromBody] LoginDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var speechTherapist = _speechTherapistService.Authenticate(model.Email, model.Password);

            if (speechTherapist == null)
                return Unauthorized();

            var token = _authenticationService.GenerateToken(speechTherapist);

            return Ok(new { Token = token });
        }
        [HttpPost("loginParent")]
        public IActionResult LoginParent([FromBody] LoginDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var parent = _parentService.Authenticate(model.Email, model.Password);

            if (parent == null)
                return Unauthorized();

            var token = _authenticationService.GenerateToken(parent);

            return Ok(new { Token = token });
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterDTO model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingUser = _speechTherapistService.GetUserByEmail(model.Email);
            if(existingUser != null)
            {
                return BadRequest("Already a user with this email, try logging in.");
            }

            var (hashedPassword, salt) = _passwordHasherService.HashPassword(model.Password);

            var speechTherapist = new SpeechTherapist
            {
                Email = model.Email,
                Role = Role.Therapist,
                Password = hashedPassword,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Salt = salt
            };

            _speechTherapistService.Register(speechTherapist);

            return Ok(speechTherapist);
        }


    }

}
