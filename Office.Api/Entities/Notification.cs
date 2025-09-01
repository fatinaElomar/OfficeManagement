namespace Office.Api.Entities;

public class Notification : BaseEntity
{
    public int UserId { get; set; }
    public string Type { get; set; } = "system"; // email, system
    public string Title { get; set; } = "";
    public string Message { get; set; } = "";
    public bool IsRead { get; set; } = false;
}
