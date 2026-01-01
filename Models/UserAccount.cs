namespace SWMS.Models;

public class UserAccount
{
    public int Id { get; set; }            
    public string Name { get; set; }
    public string Email { get; set; } = "";
    public string PasswordHash { get; set; } = "";
    public DateTime CreatedAt { get; set; }


    public List<Report> Reports { get; set; } = new List<Report>();
}
