using User_Service.DTO;
using User_Service.Models;

namespace User_Service.Service.Interfaces
{
    public interface ISpeechTherapistService
    {
        SpeechTherapist Authenticate(string email, string password);

        Task Register(SpeechTherapist speechTherapist);

        Task<SpeechTherapist> GetInformation(int id);

        void ModifyInformation(SpeechTherapist speechTherapist);

        SpeechTherapist GetUserByEmail(string email);

        void RemoveAccount(int id);
    }
}
