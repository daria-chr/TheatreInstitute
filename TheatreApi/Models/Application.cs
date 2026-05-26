namespace TheatreApi.Models;

public class Application
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Program { get; set; } = string.Empty;
    public string Status { get; set; } = "Новая";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}