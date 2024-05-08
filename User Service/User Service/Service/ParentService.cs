using User_Service.Models;
using User_Service.Repository;
using User_Service.Repository.Interfaces;
using User_Service.Service.Interfaces;

namespace User_Service.Service
{
    public class ParentService : IParentService
    {
        private readonly IParentRepository _parentRepository;
        private readonly PasswordHasherService _passwordHasher;
        public ParentService(IParentRepository parentRepository, PasswordHasherService passwordHasher)
        {
            _parentRepository = parentRepository;
            _passwordHasher = passwordHasher;
        }
        public Parent Authenticate(string email, string password)
        {
            Parent parent = _parentRepository.GetUserByEmail(email);

            // No parent with this email 
            if (parent == null) { return null; }

            // Password hash
            if (_passwordHasher.VerifyPassword(password, parent.Password, parent.Salt))
            {
                // parent hash matches
                return parent;
            }

            // Authentication was not successful 
            return null;
        }
    }
}
