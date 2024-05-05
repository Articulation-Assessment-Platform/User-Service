using User_Service.Models;

namespace User_Service.Repository
{
    public class ISpeechTherapistRepository
    {
        void Register(SpeechTherapist speechTherapist);

        Task<IEnumerable<SpeechTherapist>> GetById();

        Task<IEnumerable<SpeechTherapist>> Login();


    }
}
