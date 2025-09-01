namespace Office.Api.Entities;

public class ActivityLog : BaseEntity
{
    public int UserId { get; set; }
    public string Action { get; set; } = "";  // login, update_status, payment, etc.
    public string? Details { get; set; }
}
