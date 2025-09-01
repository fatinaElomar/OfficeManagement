namespace Office.Api.Entities;

public class AIChat : BaseEntity
{
    public int RequestId { get; set; }
    public LegalRequest Request { get; set; } = null!;
    public int UserId { get; set; } // who sent it (client/lawyer) or 0 if system
    public string Role { get; set; } = "user"; // user, ai
    public string Message { get; set; } = "";
}
