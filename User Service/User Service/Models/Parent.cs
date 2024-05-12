using System.Text.Json.Serialization;

namespace User_Service.Models
{
    public class Parent : User
    { 

        public string Email { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        public Byte[] Salt { get; set; }

        public ICollection<Child> Children { get; set; }
    }
}
