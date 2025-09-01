namespace Office.Api.Entities;

public class Commission : BaseEntity
{
    public int OfficeId { get; set; }
    public OfficeEntity Office { get; set; } = null!;
    public int LawyerId { get; set; }
    public User Lawyer { get; set; } = null!;
    public int RequestId { get; set; }
    public LegalRequest Request { get; set; } = null!;
    public decimal CommissionPercentage { get; set; } // 10.00 means 10%
    public decimal CommissionAmount { get; set; }
}
