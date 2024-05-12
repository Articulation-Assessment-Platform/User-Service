using User_Service.Models;
using User_Service.Repository.Interfaces;
using User_Service.Service.Interfaces;

namespace User_Service.Service
{
    public class ChildService: IChildService
    {
        private readonly IChildRepository _childRepository;

        public ChildService(IChildRepository childRepository)
        {
            _childRepository = childRepository;
        }

        public Task Create(Child child)
        {
            return _childRepository.AddAsync(child);
        }

        public Task<Child> GetInformation(int id)
        {
            return _childRepository.GetByIdAsync(id);
        }

        public async Task Delete(int id)
        {
            Child c = await GetInformation(id);
            _childRepository.Remove(c);
        }

        public Task<List<Child>> GetChildrenByName(string name)
        {
            return _childRepository.GetUsersByName(name);
        }

        public void ModifyChild(Child child)
        {
            _childRepository.Update(child);
        }

        public async void ArchiveChild(int id, bool correct)
        {
            Child c = await GetInformation(id);
            c.Archived = correct;
            _childRepository.Update(c);
        }
        
        public Task<List<Child>> GetChildren(int speechTherapistID)
        {
            return _childRepository.GetChildrenAsync(speechTherapistID);
        }
    }
}
