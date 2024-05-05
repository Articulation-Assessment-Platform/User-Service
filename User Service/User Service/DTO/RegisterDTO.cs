using User_Service.Models;

namespace User_Service.DTO
{
    public class RegisterDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Password_again {  get; set; }
    }
}
