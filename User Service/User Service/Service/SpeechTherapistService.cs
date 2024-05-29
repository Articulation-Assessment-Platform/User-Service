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

        public SpeechTherapistService(ISpeechTherapistRepository userRepository)
        {
            _speechTherapistRepository = userRepository;
        }

        public async Task<SpeechTherapist> GetInformation(int id)
        {
            return await _speechTherapistRepository.GetByIdAsync(id);
        }


        public void ModifyInformation(SpeechTherapist speechTherapist)
        {
             _speechTherapistRepository.Update(speechTherapist);
        }


        public async void RemoveAccount(int id)
        {
            SpeechTherapist sp = await GetInformation(id);
            _speechTherapistRepository.Remove(sp);
        }
    }
}
