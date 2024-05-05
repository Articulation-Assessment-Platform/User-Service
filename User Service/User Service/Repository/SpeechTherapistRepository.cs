using User_Service.Models;
using User_Service.Repository;

public class SpeechTherapistRepository : ISpeechTherapistRepository
{
    private readonly AppDbContext _context;

    public SpeechTherapistRepository(AppDbContext context)
    {
        _context = context;
    }

    public void Register(SpeechTherapist speechTherapist)
    {
        _context.SpeechTherapists.Add(speechTherapist);
        _context.SaveChanges();
    }

    public async Task<SpeechTherapist> GetById(int id)
    {
        return await _context.SpeechTherapists.FindAsync(id);
    }

    public async Task<SpeechTherapist> Login(string username, string password)
    {
        // You might want to replace this with actual logic for login
        return await _context.SpeechTherapists.FirstOrDefaultAsync(st => st.Username == username && st.Password == password);
    }
}
