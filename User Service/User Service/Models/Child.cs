namespace User_Service.Models
{
    public class Child : User
    {
        public DateTime Birthdate { get; set; }
        public Parent Parent { get; set; }
        public SpeechTherapist SpeechTherapist { get; set; }

        public Boolean Archived { get; set; }
    }
}
