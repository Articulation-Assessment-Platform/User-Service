using User_Service.Models;

namespace User_Service.Repository.Interfaces
{
    public interface ISpeechTherapistRepository : IBaseRepository<SpeechTherapist>
    {

        SpeechTherapist GetUserByEmail(string email);

    }
}
