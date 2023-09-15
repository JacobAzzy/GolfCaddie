namespace GolfCaddie.Domain.Common;

public abstract class BaseAuditableEntity : BaseEntity
{
    public string? CreatedBy { get; set; }
    public DateTimeOffset CreatedDate { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTimeOffset UpdatedDate { get; set; }

    // Is this correct for Concurrency Token?
    public required string ConcurrencyToken { get; set; }
    public bool SoftDeleted { get; set; }
}
