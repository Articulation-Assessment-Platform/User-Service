using User_Service.DTO;
using User_Service.Models;

namespace User_Service.Service.Interfaces
{
    public interface ISpeechTherapistService
    {
        SpeechTherapist Authenticate(string email, string password);

        Task Register(SpeechTherapist registerDTO);

        Task<SpeechTherapistDTO> GetInformation();

        Task ModifyInformation();

        SpeechTherapist GetUserByEmail(string email);
    }
}
