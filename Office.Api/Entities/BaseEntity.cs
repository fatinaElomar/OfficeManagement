namespace Office.Api.Entities;

public abstract class BaseEntity
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }   // UTC
    public DateTime UpdatedAt { get; set; }   // UTC
}
