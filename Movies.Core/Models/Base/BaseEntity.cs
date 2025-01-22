namespace Movies.Core.Models.Base
{
    public abstract class BaseEntity
    {
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
    }
}
