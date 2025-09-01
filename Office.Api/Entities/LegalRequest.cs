namespace Office.Api.Entities;

public class LegalRequest : BaseEntity
{
    public int ClientId { get; set; }
    public User Client { get; set; } = null!;
    public int? LawyerId { get; set; }
    public User? Lawyer { get; set; }
    public int? OfficeId { get; set; }
    public OfficeEntity? Office { get; set; }

    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public string Status { get; set; } = "new"; // new, in_progress, completed, cancelled

    public ICollection<RequestFile> Files { get; set; } = [];
    public ICollection<AIChat> Chats { get; set; } = [];
    public ICollection<Payment> Payments { get; set; } = [];
    public ICollection<Commission> Commissions { get; set; } = [];
}
