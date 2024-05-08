using User_Service.Models;

namespace User_Service.Repository
{
    using System.Threading.Tasks;
    using User_Service.Data;
    using User_Service.Models;
    using User_Service.Repository.Interfaces;

    public class SpeechTherapistRepository : BaseRepository<SpeechTherapist>, ISpeechTherapistRepository
    {
        public SpeechTherapistRepository(UserContext context) : base(context)
        {
        }

        public SpeechTherapist GetUserByEmail(string email)
        {
            return _context.SpeechTherapist.FirstOrDefault(u => u.Email == email);
        }
    }
}
