namespace Office.Api.Entities;

public class LawyerProfile : BaseEntity
{
    public int UserId { get; set; }
    public User User { get; set; } = null!;
    public string? Specialization { get; set; }
    public string? LicenseNumber { get; set; }
    public int? ExperienceYears { get; set; }

    public int? OfficeId { get; set; }
    public OfficeEntity? Office { get; set; }
}
