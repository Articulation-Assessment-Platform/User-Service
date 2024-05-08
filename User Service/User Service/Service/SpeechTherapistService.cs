using Microsoft.AspNetCore.Identity;
using User_Service.DTO;
using User_Service.Models;
using User_Service.Repository.Interfaces;
using User_Service.Service.Interfaces;

namespace User_Service.Service
{
    public class SpeechTherapistService : ISpeechTherapistService
    {
        private readonly ISpeechTherapistRepository _speechTherapistRepository;
        private readonly PasswordHasherService _passwordHasher;

        public SpeechTherapistService(ISpeechTherapistRepository userRepository, PasswordHasherService passwordHasher)
        {
            _speechTherapistRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public Task<SpeechTherapistDTO> GetInformation()
        {
            throw new NotImplementedException();
        }

        public SpeechTherapist Authenticate(string email, string password)
        {
            SpeechTherapist speechTherapist = _speechTherapistRepository.GetUserByEmail(email);

            // No speech therapist with this email 
            if (speechTherapist == null) { return null;  }

            // Password hash
            if (_passwordHasher.VerifyPassword(password, speechTherapist.Password, speechTherapist.Salt))
            {
                // speechTherapist hash matches
                return speechTherapist;
            }

            // Authentication was not successful 
            return null;
        }

        public Task ModifyInformation()
        {
            throw new NotImplementedException();
        }

        public SpeechTherapist GetUserByEmail(string email)
        {
           return _speechTherapistRepository.GetUserByEmail(email);
        }

        public Task Register(SpeechTherapist speechTherapist)
        {
            return _speechTherapistRepository.AddAsync(speechTherapist);
        }
    }
}
