namespace Office.Api.Entities;

public class ClientProfile : BaseEntity
{
    public int UserId { get; set; }
    public User User { get; set; } = null!;
    public string? Address { get; set; }
    public string? NationalId { get; set; }
    public DateTime? DateOfBirth { get; set; }
}
