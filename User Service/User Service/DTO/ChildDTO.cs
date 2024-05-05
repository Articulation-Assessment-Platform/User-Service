using User_Service.Models;

namespace User_Service.DTO
{
    public class ChildDTO : UserDTO
    {
        public DateTime Birthdate { get; set; }
        public Parent Parent { get; set; }
        public SpeechTherapist SpeechTherapist { get; set; }
    }
}
