using User_Service.DTO;

namespace User_Service.Service
{
    public interface ISpeechTherapistService
    {
        Task<SpeechTherapistDTO> Login(LoginDTO loginDTO);

        Task Register(RegisterDTO registerDTO);

        Task<SpeechTherapistDTO> GetInformation();
        
        Task ModifyInformation();
    }
}
