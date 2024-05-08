namespace User_Service.Models
{
    public class JwtSettings
    {
        public string Secret { get; set; }
        public int ExpiryHours { get; set; }
    }
}
