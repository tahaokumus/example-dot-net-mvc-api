namespace NewMvcProj.Models;

public class User
{
    public string? Id { get; set; }
    public string? UserName { get; set; }
    public string? Password { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public DateTime BirthDate { get; set; }
    public int CountryCode { get; set; }
}