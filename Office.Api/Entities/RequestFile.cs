namespace Office.Api.Entities;

public class RequestFile : BaseEntity
{
    public int RequestId { get; set; }
    public LegalRequest Request { get; set; } = null!;
    public int UploadedByUserId { get; set; }
    public string FilePath { get; set; } = "";
    public string? FileType { get; set; }
}
