using User_Service.Models;

namespace User_Service.DTO
{
    public class SpeechTherapistDTO : UserDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public Byte[] Salt { get; set; }
        public ICollection<Child> children { get; set; }
    }
}
