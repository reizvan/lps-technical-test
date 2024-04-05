using System.ComponentModel.DataAnnotations;

namespace DocVault.Domain
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime? Created { get; set; }
        public Nullable<Guid> CreatedBy { get; set; }
    }
}
