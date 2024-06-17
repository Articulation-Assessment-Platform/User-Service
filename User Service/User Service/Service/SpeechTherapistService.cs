using Microsoft.AspNetCore.Identity;
using User_Service.DTO;
using User_Service.Messaging;
using User_Service.Models;
using User_Service.Repository.Interfaces;
using User_Service.Service.Interfaces;

namespace User_Service.Service
{
    public class SpeechTherapistService : ISpeechTherapistService
    {
        private readonly ISpeechTherapistRepository _speechTherapistRepository;
        private readonly UserDeletionMessaging _userDeletionMessaging;

        public SpeechTherapistService(ISpeechTherapistRepository userRepository, UserDeletionMessaging userDeletionMessaging)
        {
            _speechTherapistRepository = userRepository;
            _userDeletionMessaging = userDeletionMessaging;
        }

        public async Task<SpeechTherapist> GetInformation(int id)
        {
            return await _speechTherapistRepository.GetByIdAsync(id);
        }

        public async Task<SpeechTherapist> AddSpeechTherapist(SpeechTherapist speechTherapist)
        {
            return await _speechTherapistRepository.AddAsync(speechTherapist);
        }


        public void ModifyInformation(SpeechTherapist speechTherapist)
        {
             _speechTherapistRepository.Update(speechTherapist);
        }


        public async void RemoveAccount(SpeechTherapist user)
        {
            _speechTherapistRepository.Remove(user);
            await _userDeletionMessaging.SendUserDeletionMessageAsync(user.Id);
        }
    }
}
