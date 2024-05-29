using System.Text.Json.Serialization;

namespace User_Service.Models
{
    public class SpeechTherapist : User
    {

        public string Email { get; set; }
        public ICollection<Child> children { get; set; }
    }
}
