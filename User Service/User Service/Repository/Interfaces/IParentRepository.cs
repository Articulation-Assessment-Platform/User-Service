using User_Service.Models;

namespace User_Service.Repository.Interfaces
{
    public interface IParentRepository : IBaseRepository<Parent>
    {
        public Task<Parent> AddAsync(Parent entity);

        public Task<Parent> GetByIdAsync(int id);

        public void Remove(Parent entity);

        public void Update(Parent entity);

        Parent GetUserByEmail(string email);
    }
}
