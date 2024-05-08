namespace User_Service.Models
{
    public class Parent : User
    {
        public string RoleName { get; } = "Parent";

        public string Email { get; set; }
        public string Password { get; set; }
        public Byte[] Salt { get; set; }

        public ICollection<Child> Children { get; set; }
    }
}
