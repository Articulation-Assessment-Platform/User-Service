using System.Text.Json.Serialization;

namespace User_Service.Models
{
    public class Parent : User
    { 

        public string Email { get; set; }

        public ICollection<Child> Children { get; set; }
    }
}
