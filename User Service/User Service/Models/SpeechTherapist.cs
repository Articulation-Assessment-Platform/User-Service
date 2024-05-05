namespace User_Service.Models
{
    public class SpeechTherapist : User
    {
        public string Email { get; set; }
        public string Password {  get; set; }
        public Byte[] Salt { get; set; }
        public ICollection<Child> children { get; set; }
    }
}
