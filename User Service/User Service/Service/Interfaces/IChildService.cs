using User_Service.Models;

namespace User_Service.Service.Interfaces
{
    public interface IChildService
    {
        Task Create(Child child);
        Task<List<Child>> GetChildrenByName(string name);
        void ModifyChild(Child child);
        void ArchiveChild(int id, bool correct);
        Task<List<Child>> GetChildren(int speechTherapistID);
        Task<Child> GetInformation(int id);
    }
}
