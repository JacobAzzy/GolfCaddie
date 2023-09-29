namespace GolfCaddie.Domain.Common;

public abstract class BaseAuditableEntity : BaseEntity
{
    public string? CreatedBy { get; set; }
    public DateTimeOffset CreatedDate { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTimeOffset? UpdatedDate { get; set; }
    public byte[]? ConcurrencyToken { get; set; }
    public bool SoftDeleted { get; set; }
}

// Create extension method
//{
//    CreatedBy = "";
//    CreatedDate = DateTime.UtcNow;
//    UpdatedBy = "";
//    UpdatedDate = DateTime.UtcNow;
//    SoftDeleted = false;
//}
