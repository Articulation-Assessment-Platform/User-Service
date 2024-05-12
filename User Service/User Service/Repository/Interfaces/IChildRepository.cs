using User_Service.Models;

namespace User_Service.Repository.Interfaces
{
    public interface IChildRepository : IBaseRepository<Child>
    {
        Task<List<Child>> GetUsersByName(string name);
        Task<List<Child>> GetChildrenAsync(int speechTherapistID);

    }
}
