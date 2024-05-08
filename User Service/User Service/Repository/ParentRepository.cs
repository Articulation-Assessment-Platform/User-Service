using User_Service.Data;
using User_Service.Models;
using User_Service.Repository.Interfaces;

namespace User_Service.Repository
{
    public class ParentRepository : BaseRepository<Parent> , IParentRepository
    {
        public ParentRepository(UserContext context) : base(context)
        {

        }

        public Parent GetUserByEmail(string email)
        {
            return _context.Parent.FirstOrDefault(u => u.Email == email);
        }
    
    }
}
