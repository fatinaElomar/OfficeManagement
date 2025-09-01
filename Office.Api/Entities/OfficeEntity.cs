namespace Office.Api.Entities;

public class OfficeEntity : BaseEntity
{
    public string OfficeName { get; set; } = "";
    public string? Address { get; set; }
    public string QrCode { get; set; } = Guid.NewGuid().ToString("N");

    public int OwnerUserId { get; set; }
    public User Owner { get; set; } = null!;

    public ICollection<LawyerProfile> Lawyers { get; set; } = [];
    public ICollection<LegalRequest> Requests { get; set; } = [];
    public ICollection<Commission> Commissions { get; set; } = [];
}
