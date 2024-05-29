using User_Service.Models;

namespace User_Service.DTO
{
    public class ParentDTO : UserDTO
    {
        public string Email { get; set; }
        public ICollection<Child> Children { get; set; }
    }
}
