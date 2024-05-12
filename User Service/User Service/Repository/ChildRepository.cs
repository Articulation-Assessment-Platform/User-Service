using System.Runtime.ExceptionServices;
using User_Service.Data;
using User_Service.Models;
using User_Service.Repository.Interfaces;

namespace User_Service.Repository
{
    public class ChildRepository : BaseRepository<Child>, IChildRepository
    {
        public ChildRepository(UserContext context) : base(context)
        {
        }

        public async Task<List<Child>> GetUsersByName(string name)
        {
            var children = _context.Child
            .Where(u => u.FirstName == name)
            .ToList();

            return children;
        }

        public async Task<List<Child>> GetChildrenAsync(int speechTherapistID)
        {
            var children = _context.Child
            .Where(c => c.SpeechTherapist.Id == speechTherapistID)
            .ToList();

            return children;
        }
    }
}