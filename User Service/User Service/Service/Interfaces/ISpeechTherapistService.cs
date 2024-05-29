using User_Service.DTO;
using User_Service.Models;

namespace User_Service.Service.Interfaces
{
    public interface ISpeechTherapistService
    {

        Task<SpeechTherapist> GetInformation(int id);

        void ModifyInformation(SpeechTherapist speechTherapist);


        void RemoveAccount(int id);
    }
}
