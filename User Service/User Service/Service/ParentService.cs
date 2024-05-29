using User_Service.Models;
using User_Service.Repository;
using User_Service.Repository.Interfaces;
using User_Service.Service.Interfaces;

namespace User_Service.Service
{
    public class ParentService : IParentService
    {
        private readonly IParentRepository _parentRepository;
        public ParentService(IParentRepository parentRepository)
        {
            _parentRepository = parentRepository;
        }

    }
}
