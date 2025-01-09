namespace ECommerceBackend.Domain.Common;

public abstract class BaseEntity
{
    public Guid Id { get; protected set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
} 