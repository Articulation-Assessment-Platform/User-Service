namespace User_Service.DTO
{
    public class UserRegistrationBody
    {
        public required int Id { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
