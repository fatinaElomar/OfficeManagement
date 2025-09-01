namespace Office.Api.Entities;

public class User : BaseEntity
{
    public string Name { get; set; } = "";
    public string Email { get; set; } = "";
    public string PasswordHash { get; set; } = "";
    public string Phone { get; set; } = "";
    public string Role { get; set; } = "client"; // client, lawyer, office, admin
    public string Status { get; set; } = "active";

    public ClientProfile? ClientProfile { get; set; }
    public LawyerProfile? LawyerProfile { get; set; }
    public OfficeEntity? Office { get; set; }

    public ICollection<LegalRequest> ClientRequests { get; set; } = [];
    public ICollection<LegalRequest> LawyerRequests { get; set; } = [];
    public ICollection<Commission> Commissions { get; set; } = [];
}
